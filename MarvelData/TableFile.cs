using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Reflection;
using System.Diagnostics.Eventing.Reader;
using System.Security.AccessControl;

namespace MarvelData
{
    public class TableFile
    {
        public List<TableEntry> table;
        public byte[] header;
        public List<StructEntryBase> subEntries;
        public byte[] headerB;
        public byte[] footer;
        private uint totalEntries;
        public Type fileType;
        public TableFile atiFile;
        public int defaultChunkSize;
        public String fileExtension;
        // for .SHT only
        private byte[] shotNameBytes;
        private String shotNameString;
        private byte[] shotName2Bytes;
        private String shotName2String;
        private byte[] headerC;

        public uint TotalEntries
        { get
            {
                return (uint)table.Count(entry => entry.bHasData);
            }
            set
            {
                totalEntries = value;
            }
        }

        public static Type[] structTypes = { typeof(StructEntry<StatusChunk>), typeof(StructEntry<ATKInfoChunk>), typeof(StructEntry<BaseActChunk>),
            typeof(CmdSpAtkEntry), typeof(CmdComboEntry), typeof(AnmChrEntry), typeof(CollisionEntry), typeof(StructEntry<ShotChunk>),
            typeof(StructEntry<ShotSChunk>), typeof(StructEntry<ShotLChunk>), typeof(StructEntry<ShotXSChunk>), typeof(StructEntry<ProfileSelfChunk>), typeof(StructEntry<ProfileChunk>)};
        public static int[] structSizes = { 0x350, 0x18C, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        public static string[] structExtensions = { "CHS", "ATI", "CBA", "CSP", "CCM", "CAC", "CLI", "SHT", "CPI" };

        public static TableFile LoadFile(string filename, bool bAutoIdentify = false, Type entryType = null, int structsize = -1, Boolean isAnmChrEdit = false)
        {
            AELogger.Log("attempting to open table " + filename);
            if (entryType == null)
            {
                entryType = typeof(RawEntry);
            }
            TableFile tablefile = new TableFile();

            if (!File.Exists(filename))
            {
                AELogger.Log("FILE " + filename + " NOT FOUND!!!");
                return null;
            }

            tablefile.table = new List<TableEntry>();
            string filenamelower = filename.ToLowerInvariant();

            // Reads .SHT file here
            if (filenamelower.Contains("10be43d4") || filenamelower.Contains("sht"))
            {
                return ReadShotFile(filename, out entryType, ref structsize, tablefile);
            }
            else if (filenamelower.Contains("1df3e03e") || filenamelower.Contains("cpi"))
            {
                return ReadProfile(filename, out entryType, ref structsize, tablefile);
            }

            // Goes onto normal reading for all other formats
            using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
            {
                long length = reader.BaseStream.Length;
                AELogger.Log("filesize is " + length);
                if (length < 16)
                {
                    // FIXME THIS SUCKS
                    AELogger.Log("TOO SHORT FILE HEADEr " + length + " < " + 16);
                    throw new Exception();
                }
                uint entries;
                tablefile.header = reader.ReadBytes(8);
                entries = tablefile.totalEntries = reader.ReadUInt32();
                tablefile.headerB = reader.ReadBytes(4);

                if (length < 16 + (entries * 8))
                {
                    // FIXME THIS SUCKS
                    AELogger.Log("TOO SHORT FILE tABble " + (16 + (entries * 8)));
                    throw new Exception();
                }

                if (bAutoIdentify)
                {
                    AutoIdentifyFileType(ref entryType, ref structsize, tablefile);
                }

                tablefile.fileExtension = isAnmChrEdit ? "CAC" : tablefile.fileExtension;
                tablefile.fileType = entryType;
                tablefile.defaultChunkSize = structsize;

                uint realCount = 0;
                uint lastindex = 0;
                for (int i = 0; i < entries; i++)
                {
                    uint newindex = reader.ReadUInt32();

                    int fillercount = 0;
                    if (newindex <= lastindex && newindex != 0)
                    {
                        AELogger.Log("newindex: " + newindex + " <= lastindex " + lastindex);
                    }
                    while (newindex > lastindex + 1)
                    {
                        lastindex++;
                        TableEntry filler = (TableEntry)Activator.CreateInstance(entryType);
                        filler.bHasData = false;
                        filler.index = lastindex;
                        filler.name = "***EMPTY DATA***";
                        tablefile.table.Add(filler);
                        fillercount++;
                    }
                    AELogger.Log(fillercount.ToString("X") + "h fillers added, last at " + lastindex.ToString("X") + "h");

                    lastindex = newindex;
                    TableEntry current = (TableEntry)Activator.CreateInstance(entryType);
                    current.bHasData = true;
                    current.index = newindex;
                    //current.name = current.GuessAnmChrName(); // moved later?

                    // data is added/read from file here and put on table entry
                    current.originalPointer = reader.ReadUInt32();

                    AELogger.Log("add current: " + current.index.ToString("X") + "h at " 
                    + current.originalPointer.ToString("X") + "h with name " + current.name);
                    realCount++;
                    tablefile.table.Add(current);
                }

                uint position = (uint)reader.BaseStream.Position;
                if (position < tablefile.table[0].originalPointer - 8)
                {
                    if (reader.ReadUInt32() == 0x0043564D) // "MVC\x00"
                    {
                        for (int i = 0; i < tablefile.table.Count; i++)
                        {
                            if (tablefile.table[i].bHasData)
                            {
                                tablefile.table[i].name = SSFIVAEDataTools.SlurpString(reader);
                            }
                        }
                    }
                }

                for (int i = 0; i < tablefile.table.Count; i++)
                {
                    if (tablefile.table[i].bHasData)
                    {
                        AELogger.Log("reading actual data for " + tablefile.table[i].name + " w original pointer "
                            + tablefile.table[i].originalPointer.ToString("X") + "h while actual position was " + position.ToString("X") + "h");
                        /*
                        uint entryindex = reader.ReadUInt32();
                        if(entryindex != tablefile.table[i].index)
                        {
                            AELogger.Log("OH NO WE GOT A WEIRD INVALID DATA ENTRY");
                            throw new Exception("non matching: entry "
                                  + entryindex.ToString("X")
                                  + " != table "
                                  + tablefile.table[i].index.ToString("X")
                                  + " index ");
                        }
                        */
                        reader.BaseStream.Seek(tablefile.table[i].originalPointer, SeekOrigin.Begin);
                        position = tablefile.table[i].originalPointer;

                        uint entrysize = 0;
                        int j = i + 1;
                        while (j != tablefile.table.Count)
                        {
                            if (tablefile.table[j].bHasData)
                            {
                                entrysize = tablefile.table[j].originalPointer - position;
                                break;
                            }
                            j++;
                        }
                        if (entrysize == 0)
                        {
                            AELogger.Log("last one");
                            entrysize = (uint)reader.BaseStream.Length - position - 16;
                        }
                        AELogger.Log("entrysize is " + entrysize);
                        if (structsize > 0)
                        {
                            if (structsize != entrysize)
                            {
                                throw new Exception("MALFORMED DATA STRUCTURE ERROR: WRONG SIZE " + entrysize + " EXPECTED " + structsize);
                            }
                            tablefile.table[i].size = structsize;
                        }
                        //if (tablefile.fileType == typeof(CmdSpAtkEntry)) {
                        tablefile.table[i].isAnmChrEdit = isAnmChrEdit;
                        //}
                        tablefile.table[i].SetData(reader.ReadBytes((int)entrysize));
                        tablefile.table[i].GuessName();
                        tablefile.table[i].filePath = filenamelower;
                        position += entrysize;
                    } // if bhasdata
                } // for i -> count
                tablefile.footer = reader.ReadBytes(16);
            } // using(reader)

            if (tablefile.fileType == typeof(AnmChrEntry)
                && !filenamelower.Contains("anmtdown")
                && !filenamelower.Contains("anmcmn"))
            {
                // find names by merging cmdspatk
                string spatkpath = Path.Combine(Path.GetDirectoryName(filename), "cmdspatk.52A8DBF6");

                if (!File.Exists(spatkpath))
                {
                    spatkpath = Path.Combine(Path.GetDirectoryName(filename), "cmdspatk.CSP");
                }
                if (!File.Exists(spatkpath))
                {
                    spatkpath = Path.Combine(Path.GetDirectoryName(filename), "cmdspatk.52A8DBF6.CSP");
                }
                if (!File.Exists(spatkpath))
                {
                    MessageBox.Show("The cmdspatk file used for matching labels is missing or could not be found." + Environment.NewLine
                        + Environment.NewLine + "Make sure that the .CSP file is in the same folder to improve command identification."
                        , "Missing CSP File Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (File.Exists(spatkpath))
                {
                    TableFile spatkfile = LoadFile(spatkpath, true, null, -1, true);

                    int spatkcount = spatkfile.table.Count;
                    for (int i = 0; i < spatkcount; i++)
                    {
                        if (spatkfile.table[i].bHasData && spatkfile.table[i] is CmdSpAtkEntry)
                        {
                            ((CmdSpAtkEntry)spatkfile.table[i]).TryToLabelAnmChr(tablefile);
                        }
                    }
                }
            }
            return tablefile;
        }

        // different read method expressly for .SHT files
        private static TableFile ReadShotFile(string filename, out Type entryType, ref int structsize, TableFile tablefile)
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
            {
                uint position = (uint)reader.BaseStream.Position;
                long length = reader.BaseStream.Length; // length of file in bytes
                Console.WriteLine("length is " + length);
                //StringBuilder wholeString = new StringBuilder();
                entryType = structTypes[7];
                tablefile.fileType = entryType;
                tablefile.defaultChunkSize = 868;

                for (int i = 0; i < length - 32; i++)
                {
                    while (i <= 3)
                    {
                        //byte readByte = reader.ReadByte();
                        byte[] readHeaderBytes = BitConverter.GetBytes(reader.ReadUInt32());
                        int[] intReadBytes = new int[4];
                        for (int l = 0; l < readHeaderBytes.Length; l++)
                        {
                            intReadBytes[l] = (readHeaderBytes[l] + 0x00);
                        }
                        tablefile.header = readHeaderBytes;
                        //wholeString.Append(" raw: ");
                        //intReadBytes.ToList().ForEach(i => wholeString.Append(i.ToString("x2")));
                        //Console.WriteLine("headerA - i=" + i + " - " + wholeString + " and reader position is: " + (uint)reader.BaseStream.Position);
                        i = 4;
                    }
                    //wholeString.Clear();
                    AutoIdentifyFileType(ref entryType, ref structsize, tablefile);
                    while (i > 3 && i <= 75)
                    {
                        byte readShtNameByte = reader.ReadByte();
                        if (i >= 4 && i <= 11)
                        {
                            tablefile.headerB = (tablefile.headerB == null) ?
                                new byte[] { readShtNameByte } : Tools.AddByteToArray(tablefile.headerB, readShtNameByte);
                            //wholeString.Append(readShtNameByte.ToString("x2"));
                        }
                        //if (i == 12)
                        //{
                        //    Console.WriteLine("headerB - i=" + i + " - " + wholeString + " and reader position is: " + (uint)reader.BaseStream.Position);
                        //    wholeString.Clear();
                        //}
                        if (i >= 12)
                        {
                            tablefile.shotNameBytes = (tablefile.shotNameBytes == null) ?
                                new byte[] { readShtNameByte } : Tools.AddByteToArray(tablefile.shotNameBytes, readShtNameByte);
                        }
                        i++;
                    }

                    if (i == 76) // 0x4c (at this position, but ignored)
                    {
                        //tablefile.shotNameString = wholeString.ToString();
                        //Console.WriteLine("SHOT NAME from direct read - i=" + i + " " + wholeString + " and reader position is: " + (uint)reader.BaseStream.Position);
                        //wholeString.Clear();
                        tablefile.shotNameBytes.ToList().ForEach(i =>
                        {
                            if (i != 0)
                                tablefile.shotNameString += ((char)(i + 0x00));
                        });
                        //Console.WriteLine("SHOT NAME from tablefile.shotNameString: " + tablefile.shotNameString + " and reader position is: " + (uint)reader.BaseStream.Position);
                        //wholeString.Clear();
                    }
                    while (i >= 76 && i < 100) // 0x4c
                    {
                        // add bytes between 270 and 300 (in 0x5c and 0x60) to .SHT header C
                        byte readShtHeaderCByte = reader.ReadByte();
                        tablefile.headerC = (tablefile.headerC == null) ?
                                new byte[] { readShtHeaderCByte } : Tools.AddByteToArray(tablefile.headerC, readShtHeaderCByte);
                        //wholeString.Append(readShtHeaderCByte.ToString("x2"));
                        i++;
                    }

                    //if (i == 100)
                    //{
                    //    wholeString.Clear();
                    //    tablefile.headerC.ToList().ForEach(i => wholeString.Append(i.ToString("x2")));
                    //    Console.WriteLine("headerC - i=" + i + " " + wholeString + " and reader position is: " + (uint)reader.BaseStream.Position);
                    //    wholeString.Clear();
                    //}

                    // count size of file before body
                    int preBodyFileSize = tablefile.header.Length + tablefile.headerB.Length + tablefile.shotNameBytes.Length + tablefile.headerC.Length;
                    TableEntry current = (TableEntry)Activator.CreateInstance(entryType);
                    byte[] readBodyBytes = new byte[1];
                    while (i >= 100 && i < 267) // 0x64
                    {
                        uint realPosition = (uint)reader.BaseStream.Position;
                        try
                        {   // real data from file is added / read from file here and put on table entry(the hex values)
                            current.originalPointer = reader.ReadUInt32();
                            if (i > 100)
                                readBodyBytes = Tools.AddBytesToArray(readBodyBytes, BitConverter.GetBytes(current.originalPointer));
                            else
                                readBodyBytes = BitConverter.GetBytes(current.originalPointer);
                            //byte[] readBodyBytes = reader.ReadUInt32(); // not used
                            //readBodyBytes.ToList().ForEach(i => wholeString.Append(i.ToString("x2")));

                            //Console.WriteLine("at index " + i + ": " + current.originalPointer.ToString("x2") + " and reader position started at: " + ((uint)reader.BaseStream.Position - 4));
                            //for (int l = 0; l < 4; l++) // get a set of 4 hex values, like in HxD app
                            //{
                            //    byte readByte = reader.ReadByte();
                            //wholeString.Append(readByte.ToString("x2") + " ");
                            i++;
                            //}
                        }
                        catch (EndOfStreamException endOfStreamException)
                        {
                            //Console.WriteLine("reader position ended at: " + realPosition);
                            // break the loop when the file has ended;
                            i = (int)length;
                            break;
                        }
                        // print the line of 4 values and clear it

                        //lastindex = newindex;
                        //current.name = current.GuessAnmChrName(); // moved later?
                        // real data from file is added/read from file here and put on table entry (the hex values)
                        //current.originalPointer = reader.ReadUInt32();
                        //realCount++;
                    }
                    //Console.WriteLine("at index " + i + ": " + wholeString.ToString().TrimEnd() + " and reader is at position: " + ((uint)reader.BaseStream.Position));
                    //wholeString.Clear();

                    // current  entry added to animBox
                    current.index = 0;
                    current.size = (int)reader.BaseStream.Position - preBodyFileSize; //868;
                    current.bHasData = true;
                    current.SetData(readBodyBytes);
                    current.name = tablefile.shotNameString; // sets name on animBox entry
                    tablefile.table.Add(current);
                    //tablefile.table[(int)current.index].SetData(readBodyBytes);

                    // !!!!!!!!!!!!!!!!  PART II  !!!!!!!!!!!!!!!!!!!
                    //wholeString.Clear();
                    while (i >= 267 && i < 331)
                    {
                        byte readShtName2Byte = reader.ReadByte();
                        tablefile.shotName2Bytes = (tablefile.shotName2Bytes == null) ?
                            new byte[] { readShtName2Byte } : Tools.AddByteToArray(tablefile.shotName2Bytes, readShtName2Byte);
                        i++;
                    }

                    if (i == 331) // 0x340
                    {
                        //tablefile.shotNameString = wholeString.ToString();
                        //Console.WriteLine("SHOT NAME 2 from direct read - i=" + i + " " + wholeString + " and reader position is: " + (uint)reader.BaseStream.Position);
                        //wholeString.Clear();
                        tablefile.shotName2Bytes.ToList().ForEach(i =>
                        {
                            if (i != 0)
                                tablefile.shotName2String += ((char)(i + 0x00));
                        });
                        //Console.WriteLine("SHOT NAME 2 from tablefile.shotName2String: " + tablefile.shotName2String + " and reader position is: " + (uint)reader.BaseStream.Position);
                        //wholeString.Clear();
                    }
                    // count size of file before body2
                    int postBodyFileSize = preBodyFileSize + tablefile.table[0].size + tablefile.shotName2Bytes.Length;
                    int remainingBodySize = (int)(length - postBodyFileSize);
                    long ShtRefSize = BitConverter.ToInt32(tablefile.headerB, 4) - 768;
                    int S = 0;
                    if (ShtRefSize == 0) { S = 10; }
                    else if (ShtRefSize == 96) { S = 8; }
                    else if (ShtRefSize == 192) { S = 9; }
                    else { S = 0; }
                    byte[] readBody2Bytes = new byte[0];
                    current = (TableEntry)Activator.CreateInstance(structTypes[S]);
                    while (i >= 331 && i < length) // 0x300
                    {
                        uint realPosition = (uint)reader.BaseStream.Position;
                        try
                        {
                            // real data from file is added / read from file here and put on table entry(the hex values)
                            current.originalPointer = reader.ReadUInt32();
                            if (i > 283)
                                readBody2Bytes = Tools.AddBytesToArray(readBody2Bytes, BitConverter.GetBytes(current.originalPointer));
                            else
                                readBody2Bytes = BitConverter.GetBytes(current.originalPointer);
                            //readBody2Bytes.ToList().ForEach(i => wholeString.Append(i.ToString("x2")));
                            //Console.WriteLine("at index " + i + ": " + current.originalPointer.ToString("x2") + " and reader position started at: " + ((uint)reader.BaseStream.Position - 4));
                            i++;
                        }
                        catch (EndOfStreamException endOfStreamException)
                        {
                            //Console.WriteLine("reader position ended at: " + realPosition);
                            // break the loop when the file has ended;
                            i = (int)length;
                            break;
                        }
                    }
                    //Console.WriteLine("at index " + i + ": " + wholeString.ToString().TrimEnd() + " and reader is at position: " + ((uint)reader.BaseStream.Position));
                    //wholeString.Clear();

                    // current  entry added to animBox
                    current.index = 1;
                    current.size = (int)reader.BaseStream.Position - postBodyFileSize; //868;
                    current.bHasData = true;
                    current.SetData(readBody2Bytes);
                    current.name = tablefile.shotName2String; // sets name on animBox entry
                    tablefile.table.Add(current);
                }
                return tablefile;
            }
        }
        private static TableFile ReadProfile(string filename, out Type entryType, ref int structsize, TableFile tablefile)
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
            {
                uint position = (uint)reader.BaseStream.Position;
                long length = reader.BaseStream.Length; // length of file in bytes
                Console.WriteLine("length is " + length);
                entryType = structTypes[11];
                tablefile.fileType = entryType;
                tablefile.defaultChunkSize = 8;
                tablefile.fileExtension = "CPI";
                    int i = 0;
                    while (i <= 3)
                    {
                        //byte readByte = reader.ReadByte();
                        byte[] readNameBytes = BitConverter.GetBytes(reader.ReadUInt32());
                        int[] intReadBytes = new int[4];
                        for (int l = 0; l < readNameBytes.Length; l++)
                        {
                            intReadBytes[l] = (readNameBytes[l] + 0x00);
                        }
                        tablefile.header = readNameBytes;
                        i = 4;
                    }
                    //wholeString.Clear();
                    //AutoIdentifyFileType(ref entryType, ref structsize, tablefile);

                    while (i > 3 && i <= 7)
                        {
                        byte readHeaderByte = reader.ReadByte();
                        tablefile.header = (tablefile.header == null) ?
                                new byte[] { readHeaderByte } : Tools.AddByteToArray(tablefile.header, readHeaderByte);
                            i++;
                    }
                        while (i >= 8 && i <= 11)
                        {
                        byte readHeaderByte = reader.ReadByte();
                        tablefile.headerB = (tablefile.headerB == null) ?
                                new byte[] { readHeaderByte } : Tools.AddByteToArray(tablefile.headerB, readHeaderByte);
                            i++;
                    }
                        while (i >= 12 && i <= 15)
                        {
                        byte readHeaderByte = reader.ReadByte();
                        tablefile.headerC = (tablefile.headerC == null) ?
                               new byte[] { readHeaderByte } : Tools.AddByteToArray(tablefile.headerC, readHeaderByte);
                            i++;
                        }
                    int preBodyFileSize = tablefile.header.Length + tablefile.headerB.Length + tablefile.headerC.Length;
                int introCount = BitConverter.ToInt32(tablefile.headerB, 0);
                int outroCount = BitConverter.ToInt32(tablefile.headerC, 0);
                int entryCount = BitConverter.ToInt32(tablefile.headerB, 0) + BitConverter.ToInt32(tablefile.headerC, 0);

                    if (((entryCount*4)-4+preBodyFileSize)*2 != length) {

                    MessageBox.Show("Header file mis-matches the total size of the body." + Environment.NewLine
                + Environment.NewLine + "Attempting to automatically fix."
                , "CPI File Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                TableEntry current = (TableEntry)Activator.CreateInstance(entryType);
                byte[] readSelfBytes = new byte[0];
                    byte[] readBodyBytes = new byte[0];

                    if (i >= 16 && i <= 23)
                    {
                    
                        // reads and defines entry 0, uses ProfileSelfChunk 
                    readSelfBytes = reader.ReadBytes(8);
                        current.index = 0;
                        current.size = 8;
                        current.bHasData = true;
                        current.SetData(readSelfBytes);
                        tablefile.table.Add(current);
                        tablefile.table[0].name = "Self ID";

                        /*
                        uint realPosition = (uint)reader.BaseStream.Position;
                        try
                        {
                            current.originalPointer = reader.ReadUInt32();
                            if (i > 100)
                                readBodyBytes = Tools.AddBytesToArray(readBodyBytes, BitConverter.GetBytes(current.originalPointer));
                            else
                                readBodyBytes = BitConverter.GetBytes(current.originalPointer);

                            i++;
                        }
                        catch (EndOfStreamException endOfStreamException)
                        {
                            //Console.WriteLine("reader position ended at: " + realPosition);
                            // break the loop when the file has ended;
                            i = (int)length;
                            break;
                        */
                        i = 24;
                    }
                    

                    int h = 1;
                /*
                 *    first pass, causes overwrite of all lines except for the first index
                while (s <= entryCount)
                {

                    tablefile.table.Add(filler);
                    tablefile.table[s].index = (uint)s;
                    tablefile.table[s].size = 8;
                    tablefile.table[s].SetData(reader.ReadBytes((int)8));
                    tablefile.table[s].bHasData = true;
                    s++;
                }
                */
                while (h <= entryCount) {
                    TableEntry filler = (TableEntry)Activator.CreateInstance(structTypes[12]);
                    tablefile.table.Add(filler);
                    tablefile.table[h].originalPointer = (uint)(h*8 + preBodyFileSize); 
                    h++;
                }
                int s=1;
                while (s <= entryCount) {
                    reader.BaseStream.Seek(preBodyFileSize + s * 8, 0);
                    //position = (uint)(preBodyFileSize + tablefile.table[s].originalPointer);
                    //if (tablefile.fileType == typeof(CmdSpAtkEntry)) {
                    //}

                    tablefile.table[s].size = 8;
                    tablefile.table[s].SetData(reader.ReadBytes(8));
                    tablefile.table[s].index = (uint)s;
                    //tablefile.table[s].GuessName();
                    if ((s - 1) < introCount) {
                        tablefile.table[s].name = "Intro" + s;
                    }
                    else { tablefile.table[s].name = "Outro" + (s-introCount); }
                    s++;
                }
            current.index = 0;
            }
                    return tablefile;
             }


                // sets entry type and structure size of tableFile
                private static void AutoIdentifyFileType(ref Type entryType, ref int structsize, TableFile tablefile)
        {
            string typeString = ASCIIEncoding.Default.GetString(tablefile.header, 0, 3);
            for (int i = 0; i < structExtensions.Length; i++)
            {
                if (typeString == structExtensions[i])
                {
                    AELogger.Log("autodetected " + structExtensions[i]);
                    entryType = structTypes[i];
                    tablefile.fileExtension = structExtensions[i];
                    structsize = structSizes[i];
                    break;
                }
            }
            if (entryType == null)
            {
                throw new Exception("FILETYPE DETECTION FAILED W TYPE " + typeString);
            }
        }

        public List<String> GetNames()
        {
            List<String> tableNames = new List<string>();
            // fixme .count
            for (int i = 0; i < table.Count; i++)
            {
                tableNames.Add(table[i].GetFancyName());
            }
            return tableNames;
        }

        public void Extend()
        {
            AELogger.Log("extending");
            TableEntry entry = null;
            if (fileExtension.ToString() == "CPI")
            {
                entry = (TableEntry)Activator.CreateInstance(typeof(StructEntry<ProfileChunk>));
            }
            else
            {
                entry = (TableEntry)Activator.CreateInstance(fileType);
            }
            if (fileExtension.ToString() == "CLI" ||
                fileExtension.ToString() == "CHS" ||
                fileExtension.ToString() == "CSP")
            {
                entry.bHasData = false;

            }
            else {
                entry.bHasData = true;
            }

            entry.size = defaultChunkSize;
            entry.index = (uint)table.Count;
            entry.originalPointer = 0;
            entry.name = "***EMPTY DATA***";
            table.Add(entry);
        }

        public int Move(int index, int offset)
        {
            int newindex = index + offset;
            if (newindex < 0)
            {
                newindex = table.Count + newindex;
            }
            while (newindex >= table.Count)
            {
                newindex -= table.Count;
            }
            int i = 0;
            //TableEntry first = table[index];
            //TableEntry second = table[newindex];
            TableEntry first = (TableEntry)Activator.CreateInstance(fileType);
            TableEntry second = (TableEntry)Activator.CreateInstance(fileType);
            //subEntries = new List<StructEntryBase>();
            //int total = table[index].subEntries.Count();
            while (i <= 0)
            {
            //first.subEntries = table[index].subEntries;
            //second.subEntries = table[newindex].subEntries;
            i++;
            }
            //(table[index], table[newindex]) = (table[newindex], table[index]);
            //            table[index] = second;
            //            table[newindex] = first;
            first.index = (uint)index;
            second.index = (uint)newindex;
        


            return newindex;
        }

        public void Duplicate(int index)
        {
            int newindex = table.Count;
            if (index < 0 || index > newindex)
            {
                return;
            }

            if (table[index].bHasData)
            {
                TableEntry duplicated_entry = table[index].Duplicate();
                duplicated_entry.index = (uint)newindex;
                duplicated_entry.UpdateSize();
                totalEntries++;
                table.Add(duplicated_entry);
            }
            else
            {
                Extend();
            }
        }

        public void WriteFile(string filename, bool bDoNames = false)
        {
            if (File.Exists(filename))
            {
                try
                {
                    File.Copy(filename, "savebackup", true);
                }
                catch (UnauthorizedAccessException e)
                {
                    AELogger.Log("unable to access backup: " + e.Message);
                }
            }
            Stream t = new FileStream(filename + ".temp", FileMode.Create);
            BinaryWriter b = new BinaryWriter(t);

            uint realCount = 0;
            uint pointer = 16;
            if (bDoNames)
            {
                pointer += 4; // header + "MVC\x00"
            }

            for (int i = 0; i < table.Count; i++)
            {
                if (table[i].bHasData)
                {
                    realCount++;
                    if (i == 0 && this.fileExtension.Contains("SHT"))
                    {
                        shotNameString = table[i].name;
                    }
                    else if (i == 1 && this.fileExtension.Contains("SHT"))
                    {
                        shotName2String = table[i].name;
                    }

                    if (bDoNames)
                    {
                        pointer += (uint)table[i].name.Length + 1;
                    }
                }
            }
            pointer += 8 * realCount;
            b.Write(header);
            if (this.fileExtension != "SHT")
            {
                // b.Write((uint)realCount); // TODO: see if this flies
                b.Write(TotalEntries);
            }
            b.Write(headerB);
            if (this.fileExtension == "SHT")
            {
                shotNameBytes = new byte[64]; //length of shotNameBytes
                //shotNameBytes = new byte[Encoding.ASCII.GetBytes(shotNameString).Length]; //length of shotNameBytes was byte[64]
                Encoding.ASCII.GetBytes(shotNameString).CopyTo(shotNameBytes, 0);
                b.Write(shotNameBytes);
                b.Write(headerC);
            }

            for (int i = 0; i < table.Count; i++)
            {
                if (table[i].bHasData && this.fileExtension != "SHT")
                {
                    AELogger.Log("writing ptr table entry " + table[i].name +
                        " with pointer " + pointer.ToString("X") + "h ");

                    b.Write(table[i].index);
                    b.Write(pointer);
                    table[i].UpdateSize(); // FIXME: useless?
                    pointer += (uint)table[i].size;
                }
            }
#if DONAMES
            b.Write((UInt32)0x0043564D); // metadata for reading it specific to this tool
            // names
            for (int i = 0; i < table.Count; i++)
            {
                if(table[i].bHasData)
                {
                    b.Write(table[i].name.ToCharArray());
                    b.Write((byte)0x00);// null terminator
                }
            }
#endif
            // write data
            for (int i = 0; i < table.Count; i++)
            {
                if (i == 1 && this.fileExtension == "SHT")
                {
                    shotName2Bytes = new byte[64]; //length of shotNameBytes
                    //shotName2Bytes = new byte[Encoding.ASCII.GetBytes(shotName2String).Length]; //length of shotName2Bytes was byte[64]
                    Encoding.ASCII.GetBytes(shotName2String).CopyTo(shotName2Bytes, 0);

                    b.Write(shotName2Bytes);
                }
                if (table[i].bHasData)
                {
                    pointer = (uint)b.BaseStream.Position;
                    AELogger.Log("writing actual data of " + table[i].GetFancyName() +
                        " with pointer " + pointer.ToString("X") + "h ");
                    b.Write(table[i].GetData());
#if DEBUG
                    if (table[i].GetData().Length != table[i].size)
                    {
                        AELogger.Log(i + " SIZE MISMATCH " + table[i].GetData().Length + " != " + table[i].size);
                    }
#endif
                }
            }

            if (footer != null)
            {
                b.Write(footer);
            }

            b.Close();
            t.Close();
            File.Copy(filename + ".temp", filename, true);
            File.Delete(filename + ".temp");
        }


        // this analyze stuff is bad code and im sorry but its quick unoptimized and dirty since its just meant for me
        public void AnalyzeAnmChr()
        {
            StringBuilder builder = new StringBuilder();
            SortedDictionary<long, HashSet<AnmChrEntry>> cmds = new SortedDictionary<long, HashSet<AnmChrEntry>>();
            SortedDictionary<long, HashSet<int>> csizes = new SortedDictionary<long, HashSet<int>>();
            //count
            for (int i = 0; i < table.Count; i++)
            {
                if (table[i].bHasData && table[i] is AnmChrEntry)
                {
                    AnmChrEntry entry = (AnmChrEntry)table[i];
                    for (int j = 0; j < entry.subEntries.Count; j++)
                    {
                        for (int k = 0; k < entry.subEntries[j].subsubEntries.Count; k++)
                        {
                            if (entry.subEntries[j].subsubEntries[k].Length < 8)
                            {
                                AELogger.Log("length too short ?? " + entry.subEntries[j].subsubEntries[k].Length);
                            }
                            else
                            {
                                long header = ((long)entry.subEntries[j].subsubEntries[k][0] << 32)
                                     + (long)entry.subEntries[j].subsubEntries[k][4];

                                if (!cmds.ContainsKey(header))
                                {
                                    cmds.Add(header, new HashSet<AnmChrEntry>());
                                    csizes.Add(header, new HashSet<int>());
                                }

                                cmds[header].Add(entry);
                                csizes[header].Add(entry.subEntries[j].subsubEntries[k].Length);
                            }
                        }
                    }
                }
            }
            // print
            foreach (KeyValuePair<long, HashSet<AnmChrEntry>> pair in cmds)
            {
                builder.Append("key: ");
                builder.Append(pair.Key.ToString("X10"));
                builder.Append("\ncount: ");
                builder.Append(pair.Value.Count);
                builder.Append("\n");

                foreach (AnmChrEntry entry in pair.Value)
                {
                    builder.Append(entry.index.ToString("X2"));
                    builder.Append(",");
                }
                builder.Append("\nsizes: ");

                foreach (int size in csizes[pair.Key])
                {
                    builder.Append(size);
                    builder.Append(",");
                }

                builder.Append("\n");
                AELogger.Log(builder);
                builder.Clear();
            }
        }

        public void Analyze()
        {
            SortedDictionary<int, List<RawEntry>> sizes = new SortedDictionary<int, List<RawEntry>>();
            List<SortedDictionary<int, int>> byteCounts = new List<SortedDictionary<int, int>>(10000);
            List<SortedDictionary<int, int>> byteBySize = new List<SortedDictionary<int, int>>(10000);
            List<SortedDictionary<int, int>> valuesPerBlob = new List<SortedDictionary<int, int>>(255);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < table.Count; i++)
            {
                valuesPerBlob.Add(new SortedDictionary<int, int>());
                if (table[i].bHasData && table[i] is RawEntry)
                {
                    RawEntry r = (RawEntry)table[i];
                    if (!sizes.ContainsKey(table[i].size))
                    {
                        sizes.Add(table[i].size, new List<RawEntry>());
                    }
                    sizes[table[i].size].Add(r);

                    for (int j = 0; j < r.data.Length; j++)
                    {
                        while (j >= byteCounts.Count)
                        {
                            byteCounts.Add(new SortedDictionary<int, int>());
                            byteBySize.Add(new SortedDictionary<int, int>());
                        }

                        if (byteCounts[j].ContainsKey(r.data[j]))
                        {
                            byteCounts[j][r.data[j]]++;
                            if (byteBySize[j][r.data[j]] < table[i].size)
                            {
                                byteBySize[j][r.data[j]] = table[i].size;
                            }
                        }
                        else
                        {
                            byteCounts[j].Add(r.data[j], 1);
                            byteBySize[j].Add(r.data[j], table[i].size);
                        }

                        if (!valuesPerBlob[i].ContainsKey(r.data[j]))
                        {
                            valuesPerBlob[i].Add(r.data[j], 1);
                        }
                        else
                        {
                            valuesPerBlob[i][r.data[j]]++;
                        }
                    }

                    builder.Clear();
                    builder.Append("count of values in blob ");
                    builder.Append(table[i].GetFancyName());
                    builder.Append(" with size ");
                    builder.Append(table[i].size);
                    builder.Append(": ");
                    foreach (KeyValuePair<int, int> pair in valuesPerBlob[i])
                    {
                        builder.Append(pair.Key.ToString("X2"));
                        builder.Append("h: ");
                        builder.Append(pair.Value.ToString("D3"));
                        builder.Append(", ");
                    }
                    AELogger.Log(builder, false);
                }
            }

            foreach (KeyValuePair<int, List<RawEntry>> pair in sizes)
            {
                AELogger.Log(pair.Key + " size has " + pair.Value.Count + " instances");

                if (pair.Value.Count > 1)
                {
                    byte[] previous = pair.Value[0].data;

                    for (int i = 1; i < pair.Value.Count; i++)
                    {
                        AELogger.Log("comparing " + pair.Value[i - 1].GetFancyName() + "@" + pair.Value[i - 1].originalPointer +
                            " and " + pair.Value[i].GetFancyName() + "@" + pair.Value[i].originalPointer);
                        byte[] current = pair.Value[i].data;
                        CompareData(previous, current);
                        previous = pair.Value[i].data;
                    }
                }
            }

            AELogger.Log("-------------------");
            AELogger.Log("VALUES AT EACH BYTE:");
            //StringBuilder builder = new StringBuilder();
            for (int i = 0; i < byteCounts.Count; i++)
            {
                builder.Clear();
                builder.Append("INDEX: ");
                builder.Append(i);
                builder.Append("=");
                builder.Append(i.ToString("X"));
                builder.Append("h\n\t");
                foreach (KeyValuePair<int, int> pair in byteCounts[i])
                {
                    builder.Append(pair.Key.ToString("X2"));
                    builder.Append("h:");
                    builder.Append(pair.Value.ToString("D4"));
                    builder.Append(" ");
                }
                AELogger.Log(builder, false);


                if (byteBySize[i].Count > 1)
                {
                    int previousKey = -1;
                    int previousValue = 0;
                    bool bFound = true;
                    // key is the byte at the location, value is max size
                    foreach (KeyValuePair<int, int> current in byteBySize[i])
                    {
                        if (previousKey >= 0)
                        {
                            if (previousValue > current.Value)
                            {
                                bFound = false;
                                break;
                            }
                        }

                        previousValue = current.Value;
                        previousKey = current.Key;
                    }

                    if (bFound)
                    {
                        builder.Clear();
                        builder.Append("!! BYTE ");
                        builder.Append(i);
                        builder.Append(" has positive size correlation: ");

                        foreach (KeyValuePair<int, int> pair in byteBySize[i])
                        {
                            builder.Append(pair.Key.ToString("X2"));
                            builder.Append("h:");
                            builder.Append(pair.Value.ToString("D2"));
                            builder.Append(" ");
                        }
                        AELogger.Log(builder, false);
                    }
                }
            }


        } // analyze

        public void CompareData(byte[] a, byte[] b)
        {
            int streakStart = 0;
            int length = a.Length;
            bool bStreak = a[0] == b[0];
            bool bCurrent;
            for (int i = 1; i < length; i++)
            {
                bCurrent = a[i] == b[i];
                if (bCurrent && a[i] != 0)
                {
                    AELogger.Log("same value of " + a[i] + " @" + i);
                }
                if (bStreak != bCurrent)
                {
                    string same = bStreak ? "same" : "diff";
                    AELogger.Log(same + " - byte " + streakStart + " - " + (i - 1) + "\t\t\tlength " + (i - streakStart) + "\t\t value: " + a[streakStart] + " " + b[streakStart]);
                    bStreak = bCurrent;
                    streakStart = i;
                }
            }
        }

        // goes over all entries on the table and adds 0_0C and 1_99 CLI and ATI info to the entry label
        public void GetSubSubEntryInfo(ref List<AnmChrSubEntry> subEntries)
        {
            int infoRef = 0;
            for (int i = 0; i < table.Count(); i++)
            {
                infoRef = i;
                if (!table[i].name.Contains("EMPTY DATA"))
                {
                    //for (int l = 0; l < ((AnmChrEntry)tablefile.table[i]).subEntries.Count(); l++)
                    subEntries = ((AnmChrEntry)table[i]).subEntries;

                    subEntries.Sort(delegate (AnmChrSubEntry x, AnmChrSubEntry y)
                    {
                        if (y == null)
                        {
                            if (x == null)
                            {
                                return 0;
                            }
                            return 1;
                        }
                        if (x == null)
                        {
                            return -1;
                        }
                        if (x.localindex > y.localindex)
                        {
                            return 1;
                        }
                        else if (x.localindex == y.localindex)
                        {
                            return 0;
                        }
                        return -1;
                    });

                    BindingList<string> output = new BindingList<string>();
                    for (int l = 0; l < subEntries.Count; l++)
                    {
                        //output.Add(subEntries[l].GetName());
                        for (int m = 0; m < subEntries[l].GetCommandList().ToArray().Length; m++)
                        {
                            if (subEntries[l].GetCommandList().ToArray()[m].Contains("1_99")
                                 && subEntries[l].localindex <= ((AnmChrEntry)table[i]).animTime
                                )
                            {
                                byte[] data = subEntries[l].subsubEntries[m];
                                string dataString = BitConverter.ToString(data).Replace("-", "");
                                string ati = dataString.Substring(dataString.Count() - 16, 2);
                                string cli = dataString.Substring(dataString.Count() - 8, 2);

                                table[infoRef].name += " ATI=>" + ati + "? CLI=>" + cli + "?";
                            }
                            if (subEntries[l].GetCommandList().ToArray()[m].Contains("0_0C")
                                && subEntries[l].localindex <= ((AnmChrEntry)table[i]).animTime
                                )
                            {
                                table[infoRef].name = "Charge " + table[infoRef].name;
                            }
                            if (subEntries[l].GetCommandList().ToArray()[m].Contains("3_30")|| subEntries[l].GetCommandList().ToArray()[m].Contains("3_31")
                                && subEntries[l].localindex <= ((AnmChrEntry)table[i]).animTime
                                )
                            {
                                table[infoRef].name = "Shot " + table[infoRef].name;
                            }
                        }
                    }
                }

            }
        }

        public void MatchAtiNames(string filePath)
        {
            // find names by combining with atkinfo file
            string atiPath = Path.Combine(Path.GetDirectoryName(filePath), "atkinfo.227A8048");

            if (!File.Exists(atiPath))
            {
                atiPath = Path.Combine(Path.GetDirectoryName(filePath), "atkinfo.ATI");
            }
            if (!File.Exists(atiPath))
            {
                atiPath = Path.Combine(Path.GetDirectoryName(filePath), "atkinfo.227A8048.ATI");
            }

            if (File.Exists(atiPath))
            {
                TableFile _atiFile = TableFile.LoadFile(atiPath, true, null, -1, true);
                _atiFile.GetNames();
                atiFile = _atiFile;
            }
            else
            {
                MessageBox.Show("The ati file used for matching labels is missing or could not be found." + Environment.NewLine
                    + Environment.NewLine + "Make sure that the .ATI file is in the same folder to improve command identification."
                    , "Missing ATI File Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //tablefile.table.ForEach(x => );
            string referenceType = "ATI";
            for (int i = 0; i < table.Count(); i++)
            {
                if (table[i].name.Contains("unknown") &&
                    table[i].name.Contains(referenceType) &&
                    atiFile.fileType == typeof(StructEntry<ATKInfoChunk>))
                {
                    string originalName = table[i].name;

                    string test = originalName.Substring(originalName.IndexOf(referenceType) + referenceType.Length + 2, 2);
                    int hexIndex = Convert.ToInt32(originalName.Substring(originalName.IndexOf(referenceType) + referenceType.Length + 2, 2), 16);
                    int hexLastIndex = Convert.ToInt32(originalName.Substring(originalName.LastIndexOf(referenceType) + referenceType.Length + 2, 2), 16);
                    //int hexLastIndex = hexIndex - 1;
                   if (hexIndex <= atiFile.table.Count && hexIndex >= 0)
                   {
                        if (hexIndex != hexLastIndex &&
                        (atiFile.table[hexIndex].name == "unknown" || atiFile.table[hexLastIndex].name == "unknown"))
                        {
                        table[i].name = table[i].name.Replace("unknown", atiFile.table[hexIndex].name + " " + atiFile.table[hexLastIndex].name);
                        }
                        else{
                        table[i].name = table[i].name.Replace("unknown", atiFile.table[hexIndex].name);
                        }
                   }
                    else
                    {
                        table[i].name = table[i].name.Replace("unknown", "unknown - atkinfo doesn't exist?");
                    }
                }
            }
        }

        public unsafe static void DataTest()
        {
            VerifySizes(sizeof(StatusChunk), 0);
            VerifySizes(sizeof(ATKInfoChunk), 1);
            VerifySizes(sizeof(BaseActChunk), 2);
        }

        public static void VerifySizes(int a, int b)
        {
            AELogger.Log("testing sizes a, b");
            if (a != structSizes[b])
            {
                throw new Exception("AAAAAAA " + structTypes[b].Name + " size " + a + " != " + structSizes[b]);
            }
        }
    }
}
