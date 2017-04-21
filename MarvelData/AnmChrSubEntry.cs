using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MarvelData
{
    public class AnmChrSubEntry
    {
        public int tableindex;
        public int localindex;
        public int size;
        public int unk08;
        public int unk0C;
        public uint originalPointer; // DONT SAVE THIS
        public List<uint> subsubPointers; // DONT SAVE THIS
        public List<byte[]> subsubEntries;
        public List<int> subsubIndices;

        public void SetData(BinaryReader reader)
        {
            reader.BaseStream.Seek(originalPointer, SeekOrigin.Begin);

            localindex = reader.ReadInt32();
            if (localindex != tableindex)
            {
                AELogger.Log(" localindex " + localindex + " != tableindex " + tableindex);
            }
            int subcount = reader.ReadInt32();
            unk08 = reader.ReadInt32();
            unk0C = reader.ReadInt32();
            subsubEntries.Clear();
            subsubIndices.Clear();
            subsubPointers.Clear();

            for (int i = 0; i < subcount; i++)
            {
                subsubPointers.Add(reader.ReadUInt32());
                subsubIndices.Add(reader.ReadInt32());
            }

            for (int i = 0; i < subcount; i++)
            {
                int currentSize;
                if (i == subcount - 1)
                {
                    currentSize = (int)reader.BaseStream.Length - (int)subsubPointers[i];
                }
                else
                {
                    currentSize = (int)subsubPointers[i+1] - (int)subsubPointers[i];
                }
                reader.BaseStream.Seek(originalPointer + subsubPointers[i], SeekOrigin.Begin);

                subsubEntries.Add(reader.ReadBytes(currentSize));
            }
        }
    }
}
