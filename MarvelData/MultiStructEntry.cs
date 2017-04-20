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
    }
}
