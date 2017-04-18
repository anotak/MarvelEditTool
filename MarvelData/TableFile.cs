using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MarvelData
{
    public class TableFile
    {
        public List<TableEntry> table;
        public byte[] header;
        public byte[] headerB;
        public byte[] footer;
        public Type fileType;
        public int defaultChunkSize;
        
        public static Type[] structTypes = { typeof(StructEntry<StatusChunk>), typeof(StructEntry<ATKInfoChunk>), typeof(StructEntry<BaseActChunk>) };
        public static int[] structSizes = { 0x350, 0x18C, 0x20 };
        public static string[] structExtensions = { "CHS", "ATI", "CBA" };

        public static TableFile LoadFile(string filename, bool bAutoIdentify = false, Type entryType = null, int structsize = -1)
        {
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

            using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
            {
                long length = reader.BaseStream.Length;
                AELogger.Log("filesize is " + length);
                if (length < 16)
                {
                    // FIXME THIS SUCKS
                    AELogger.Log("TOO SHORT FILE HEADEr < " + 16);
                    throw new Exception();
                }
                tablefile.header = reader.ReadBytes(8);
                uint entries = reader.ReadUInt32();
                tablefile.headerB = reader.ReadBytes(4);
                if (length < 16 + (entries * 8))
                {
                    // FIXME THIS SUCKS
                    AELogger.Log("TOO SHORT FILE tABble " + (16 + (entries * 8)));
                    throw new Exception();
                }

                if (bAutoIdentify)
                {
                    string typeString = ASCIIEncoding.Default.GetString(tablefile.header, 0, 3);
                    for (int i = 0; i < structExtensions.Length; i++)
                    {
                        if (typeString == structExtensions[i])
                        {
                            AELogger.Log("autodetected " + structExtensions[i]);
                            entryType = structTypes[i];
                            structsize = structSizes[i];
                            break;
                        }
                    }
                    if (entryType == null)
                    {
                        throw new Exception("FILETYPE DETECTION FAILED W TYPE " + typeString);
                    }
                }

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
                    current.name = TableEntry.GuessAnmChrName(current.index);

                    current.originalPointer = reader.ReadUInt32();

                    AELogger.Log("add current: " +
                        current.index.ToString("X")
                        + "h at " + current.originalPointer.ToString("X") + "h with name " + current.name);
                    realCount++;
                    tablefile.table.Add(current);
                }

                uint position = (uint)reader.BaseStream.Position;
                if(position < tablefile.table[0].originalPointer - 8)
                {
                    if(reader.ReadUInt32() == 0x0043564D) // "MVC\x00"
                    {
                        for(int i = 0; i < tablefile.table.Count; i++)
                        {
                            if (tablefile.table[i].bHasData)
                            {
                                tablefile.table[i].name = SSFIVAEDataTools.SlurpString(reader);
                            }
                        }
                    }
                }

                for(int i = 0; i < tablefile.table.Count; i++)
                {
                    if(tablefile.table[i].bHasData)
                    {
                        AELogger.Log("reading actual data for " + tablefile.table[i].name + " w original pointer " + tablefile.table[i].originalPointer.ToString("X") + "h while actual position was " + position.ToString("X") +"h");

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
                        while(j != tablefile.table.Count)
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
                        tablefile.table[i].SetData(reader.ReadBytes((int)entrysize));
                        position += entrysize;
                    } // if bhasdata
                } // for i -> count
                tablefile.footer = reader.ReadBytes(16);
            } // using(reader)
            return tablefile;
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
            TableEntry entry = (TableEntry)Activator.CreateInstance(fileType);
            entry.bHasData = false;
            entry.size = defaultChunkSize;
            entry.index = (uint)table.Count;
            entry.originalPointer = 0;
            entry.name = "***EMPTY DATA***";
            table.Add(entry);
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

                    if (bDoNames)
                    {
                        pointer += (uint)table[i].name.Length + 1;
                    }
                }
            }
            pointer += 8 * realCount;

            b.Write(header);
            b.Write((uint)realCount);
            b.Write(headerB);

            for (int i = 0; i < table.Count; i++)
            {
                if (table[i].bHasData)
                {
                    AELogger.Log("writing ptr table entry " + table[i].name +
                        " with pointer " + pointer.ToString("X") + "h ");

                    b.Write(table[i].index);
                    b.Write(pointer);
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
                if (table[i].bHasData)
                {
                    pointer = (uint)b.BaseStream.Position;
                    AELogger.Log("writing actual data of " + table[i].GetFancyName() +
                        " with pointer " + pointer.ToString("X") + "h ");
                    b.Write(table[i].GetData());
                }
            }

            b.Write(footer);

            b.Close();
            t.Close();
            File.Copy(filename + ".temp", filename, true);
            File.Delete(filename + ".temp");
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

                    for(int j = 0; j < r.data.Length; j++)
                    {
                        while(j >= byteCounts.Count)
                        {
                            byteCounts.Add(new SortedDictionary<int, int>());
                            byteBySize.Add(new SortedDictionary<int, int>());
                        }

                        if(byteCounts[j].ContainsKey(r.data[j]))
                        {
                            byteCounts[j][r.data[j]]++;
                            if(byteBySize[j][r.data[j]] < table[i].size)
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
                    foreach(KeyValuePair<int,int> pair in valuesPerBlob[i])
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
                
                if(pair.Value.Count > 1)
                {
                    byte[] previous = pair.Value[0].data;

                    for(int i = 1; i < pair.Value.Count; i++)
                    {
                        AELogger.Log("comparing " + pair.Value[i - 1].GetFancyName() + "@" + pair.Value[i-1].originalPointer +
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
            for(int i = 0; i < byteCounts.Count; i++)
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
                AELogger.Log(builder,false);


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
            for(int i = 1; i < length; i++)
            {
                bCurrent = a[i] == b[i];
                if(bCurrent && a[i] != 0)
                {
                    AELogger.Log("same value of " + a[i] + " @" +i);
                }
                if(bStreak != bCurrent)
                {
                    string same = bStreak ? "same" : "diff";
                    AELogger.Log(same + " - byte " + streakStart + " - " + (i - 1) + "\t\t\tlength " + (i - streakStart) + "\t\t value: " + a[streakStart] + " " + b[streakStart]);
                    bStreak = bCurrent;
                    streakStart = i;
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
