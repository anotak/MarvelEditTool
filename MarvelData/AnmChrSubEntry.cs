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
        public bool bEdited;

        public AnmChrSubEntry()
        {
            subsubEntries = new List<byte[]>();
            subsubIndices = new List<int>();
            subsubPointers = new List<uint>();
            bEdited = false;
        }

        public void SetData(BinaryReader reader, uint nextPointer)
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
                    currentSize = (int)nextPointer - ((int)subsubPointers[i] + (int)originalPointer);
                }
                else
                {
                    currentSize = (int)subsubPointers[i+1] - (int)subsubPointers[i];
                }
                reader.BaseStream.Seek(originalPointer + subsubPointers[i], SeekOrigin.Begin);

                subsubEntries.Add(reader.ReadBytes(currentSize));
            }
        }

        public void WriteData(BinaryWriter writer)
        {
            int subcount = subsubEntries.Count;
            if (localindex != tableindex)
            {
                AELogger.Log(" localindex " + localindex + " != tableindex " + tableindex);
            }

            writer.Write(localindex);
            writer.Write(subcount);
            writer.Write(unk08);
            writer.Write(unk0C);
            int pointer = 16 + (subcount * 8);
            for (int i = 0; i < subcount; i++)
            {
                writer.Write(pointer);
                writer.Write(subsubIndices[i]);
                pointer += subsubEntries[i].Length;
            }
            for (int i = 0; i < subcount; i++)
            {
#if DEBUG
                AELogger.Log("position is: " + writer.BaseStream.Position + " / " + writer.BaseStream.Length + " and about to write " + subsubEntries[i].Length);
#endif
                writer.Write(subsubEntries[i]);
            }
        }

        public int GetSize()
        {
            int subsubcount = subsubEntries.Count;
            size = 16 + (subsubcount * 8);
            for (int i = 0; i < subsubcount; i++)
            {
                size += subsubEntries[i].Length;
            }
            return size;
        }

        public AnmChrSubEntry Copy()
        {
            AnmChrSubEntry output = new AnmChrSubEntry();
            output.localindex = localindex;
            output.tableindex = localindex;
            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter writer=  new BinaryWriter(stream))
                {
                    WriteData(writer);
                    writer.Flush();
                    stream.Seek(0, SeekOrigin.Begin);
                    // dont close writer
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        output.SetData(reader, (uint)GetSize());
                    }
                }
            }
            output.bEdited = true;
            return output;
        }
    }
}
