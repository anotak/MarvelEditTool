using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarvelData
{
    public class CmdComboEntry : MultiStructEntry
    {
        public override void SetData(byte[] newdata)
        {
            bHasData = true;

            if (subEntries == null)
            {
                subEntries = new List<StructEntryBase>();
            }
            else
            {
                subEntries.Clear();
            }
            size = newdata.Length;
            if (size < 0x44)
            {
                throw new Exception("HEADER TOO SMALL");
            }
            StructEntry<CmdComboHeaderChunk> header = new StructEntry<CmdComboHeaderChunk>();
            header.size = 0x44;
            header.SetData(newdata, 0);
            subEntries.Add(header);

            for (int i = 0x44; i < size; i += 0x20)
            {
                StructEntry<SpatkUnkChunk> newChunk = new StructEntry<SpatkUnkChunk>();
                newChunk.size = 0x20;
                newChunk.SetData(newdata, i);
                subEntries.Add(newChunk);
            }
        }
    }
}
