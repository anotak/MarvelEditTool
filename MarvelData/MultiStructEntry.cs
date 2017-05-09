using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarvelData
{
    public class MultiStructEntry : TableEntry
    {
        public List<StructEntryBase> subEntries;
        
        public MultiStructEntry() : base()
        {
            subEntries = new List<StructEntryBase>();
        }

        public override byte[] GetData()
        {
            if (bHasData)
            {
                byte[] output = new byte[size];

                int position = 0;
                for (int i = 0; i < subEntries.Count; i++)
                {
                    byte[] chunk = subEntries[i].GetData();
                    for (int j = 0; j < chunk.Length; j++)
                    {
                        output[position] = chunk[j];
                        position++;
                    }
                }

                return output;
            }
            else
            {
                throw new Exception("NO DATA FOR GETDATA");
            }
        }

        public void SubNameLoop()
        {
            int subCount = subEntries.Count;
            for (int i = 0; i < subCount; i++)
            {
                if (subEntries[i] is StructEntry<SpatkStandardChunk>)
                {
                    SpatkStandardChunk chunk = ((StructEntry<SpatkStandardChunk>)subEntries[i]).data;
                    if ((int)chunk.inputCode <= 10)
                    {
                        nameSB.Append(MVC3DataStructures.NumpadDirections[(int)chunk.inputCode]);
                    }
                    else
                    {
                        nameSB.Append(chunk.inputCode);
                    }
                }
                else if (subEntries[i] is StructEntry<SpatkDirectionalDashChunk>)
                {
                    SpatkDirectionalDashChunk chunk = ((StructEntry<SpatkDirectionalDashChunk>)subEntries[i]).data;
                    if ((int)chunk.inputCode <= 10)
                    {
                        nameSB.Append(MVC3DataStructures.NumpadDirections[(int)chunk.inputCode]);
                    }
                    else
                    {
                        nameSB.Append(chunk.inputCode);
                    }
                }
                else if (subEntries[i] is StructEntry<SpatkDirButtonChunk>)
                {
                    SpatkDirButtonChunk chunk = ((StructEntry<SpatkDirButtonChunk>)subEntries[i]).data;
                    if ((int)chunk.inputCodeDirection <= 10)
                    {
                        nameSB.Append(MVC3DataStructures.NumpadDirections[(int)chunk.inputCodeDirection]);
                    }
                    else
                    {
                        nameSB.Append("?");
                    }

                    nameSB.Append(chunk.inputCodeButton);
                }
                else if (subEntries[i] is StructEntry<SpatkTwoButtonChunk>)
                {
                    nameSB.Append("PP");
                }
                else if (subEntries[i] is StructEntry<SpatkTwoButtonAirdashChunk>)
                {
                    SpatkTwoButtonAirdashChunk chunk = ((StructEntry<SpatkTwoButtonAirdashChunk>)subEntries[i]).data;

                    if ((int)chunk.inputCodeDirection <= 10)
                    {
                        nameSB.Append(MVC3DataStructures.NumpadDirections[(int)chunk.inputCodeDirection]);
                    }
                    else
                    {
                        nameSB.Append("?");
                    }
                    nameSB.Append("PP");
                }
            }
        }

        public virtual void AddSubChunk()
        {
            StructEntry<SpatkUnkChunk> chunk = new StructEntry<SpatkUnkChunk>();
            chunk.data = new SpatkUnkChunk();
            size += 0x20;
            chunk.size = 0x20;
            chunk.bHasData = true;
            subEntries.Add(chunk);
        }
    }
}
