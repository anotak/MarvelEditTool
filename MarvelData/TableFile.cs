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
        
        public static TableFile LoadFile(string filename)
        {
            TableFile tablefile = new TableFile();

            if (!File.Exists(filename))
            {
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
                        TableEntry filler = new TableEntry();
                        filler.bHasData = false;
                        filler.index = lastindex;
                        filler.name = "***EMPTY DATA***";
                        tablefile.table.Add(filler);
                        fillercount++;
                    }
                    AELogger.Log(fillercount.ToString("X") + "h fillers added, last at " + lastindex.ToString("X") + "h");

                    lastindex = newindex;
                    TableEntry current = new TableEntry();
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
                            entrysize = (uint)reader.BaseStream.Length - position;
                        }
                        AELogger.Log("entrysize is " + entrysize);
                        tablefile.table[i].data = reader.ReadBytes((int)entrysize);
                        tablefile.table[i].size = tablefile.table[i].data.Length;
                        position += entrysize;
                    }
                }
            }

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
            TableEntry entry = new TableEntry();
            entry.bHasData = false;
            entry.index = (uint)table.Count;
            entry.originalPointer = 0;
            entry.name = "***EMPTY DATA***";
            table.Add(entry);
        }

        public void WriteFile(string filename)
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
            uint pointer = 16 + 4; // header + "MVC\x00"
            for (int i = 0; i < table.Count; i++)
            {
                if (table[i].bHasData)
                {
                    realCount++;
                    pointer += (uint)table[i].name.Length + 1;
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
                    pointer += (uint)table[i].data.Length;
                }
            }

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

            // write data
            for (int i = 0; i < table.Count; i++)
            {
                if (table[i].bHasData)
                {
                    AELogger.Log("writing actualy data of " + table[i].name +
                        " with pointer " + pointer.ToString("X") + "h ");
                    b.Write(table[i].data);
                }
            }

            b.Close();
            t.Close();
            File.Copy(filename + ".temp", filename, true);
            File.Delete(filename + ".temp");
        }
    }
}
