using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MarvelData
{
    public class AnmChrEntry : TableEntry
    {
        //size is naturally from list
        public int animTime;
        public int unk08;
        public int unk0C;
        public List<AnmChrSubEntry> subEntries;

        public AnmChrEntry() : base()
        {
            subEntries = new List<AnmChrSubEntry>();
        }

        public List<int> getSubEntryList()
        {
            List<int> output = new List<int>();
            for (int i = 0; i < subEntries.Count; i++)
            {
                output.Add(subEntries[i].localindex);
            }
            return output;
        }

        public override void SetData(byte[] newdata)
        {
            if (size <= 0)
            {
                size = newdata.Length;
            }
            using (MemoryStream stream = new MemoryStream(newdata))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    subEntries.Clear();
                    int subcount = reader.ReadInt32() + 1;
                    animTime = reader.ReadInt32();
                    unk08 = reader.ReadInt32();
                    unk0C = reader.ReadInt32();

                    for (int i = 0; i < subcount; i++)
                    {
                        AnmChrSubEntry subentry = new AnmChrSubEntry();
                        subentry.tableindex = reader.ReadInt32();
                        subentry.originalPointer = reader.ReadUInt32();
                        subEntries.Add(subentry);
                    }

                    for (int i = 0; i < subcount; i++)
                    {
                        uint endpointer;
                        if (i == subcount - 1)
                        {
                            endpointer = (uint)size;
                        }
                        else
                        {
                            endpointer = subEntries[i + 1].originalPointer;
                        }
                        subEntries[i].SetData(reader, endpointer);
                    }
                }
            }
        }

        public override byte[] GetData()
        {
            // DUPLICATE CODE FIXME
            int subcount = subEntries.Count;
            UpdateSize();
            // END DUPLICAte

            byte[] output = new byte[size];

            using (MemoryStream stream = new MemoryStream(output)) // THIS SUX
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(subcount-1);
                    writer.Write(animTime);
                    writer.Write(unk08);
                    writer.Write(unk0C);

                    int pointer = 16 + (subcount * 8);
                    for (int i = 0; i < subcount; i++)
                    {
                        writer.Write(subEntries[i].localindex);
                        writer.Write(pointer);
                        pointer += subEntries[i].GetSize();
                    }

                    for (int i = 0; i < subcount; i++)
                    {
#if DEBUG
                        AELogger.Log("writing subsub " + i + " / " + subcount);
#endif
                        subEntries[i].WriteData(writer);
                    }
                }
            }
            
            return output;
        }

        public override void UpdateSize()
        {
            int subcount = subEntries.Count;
            int outsize = 16 + (subcount * 8);
            for (int i = 0; i < subcount; i++)
            {
                outsize += subEntries[i].GetSize();
            }
        }
    }
}
