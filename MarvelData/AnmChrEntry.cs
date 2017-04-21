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
        public int subcount;
        public int animTime;
        public int unk08;
        public int unk0C;
        public List<AnmChrSubEntry> subEntries;

        public override void SetData(byte[] newdata)
        {
            using (MemoryStream stream = new MemoryStream(newdata))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    subEntries.Clear();
                    int subcount = reader.ReadInt32();
                    animTime = reader.ReadInt32();
                    unk08 = reader.ReadInt32();
                    unk0C = reader.ReadInt32();

                    for (int i = 0; i < subcount; i++)
                    {
                        AnmChrSubEntry subentry = new AnmChrSubEntry();
                        subentry.tableindex = reader.ReadInt32();
                        subentry.originalPointer = reader.ReadUInt32();
                    }

                    for (int i = 0; i < subcount; i++)
                    {
                        subEntries[i].SetData(reader);
                    }
                }
            }
        }

        public override byte[] GetData()
        {
            throw new Exception();
            return null;
        }
    }
}
