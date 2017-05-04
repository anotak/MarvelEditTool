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

            for (int i = 0x44; i + 0x19 < size; i += 0x20)
            {
                int subType = newdata[i];
                AELogger.Log("subtype " + subType);
                if (subType < MVC3DataStructures.SpatkChunkTypes.Length
                    && MVC3DataStructures.SpatkChunkTypes[subType] != typeof(SpatkUnkChunk))
                {
                    Type entryType = typeof(StructEntry<>).MakeGenericType(MVC3DataStructures.SpatkChunkTypes[subType]);
                    StructEntryBase newChunk = (StructEntryBase)Activator.CreateInstance(entryType);
                    newChunk.size = 0x20;
                    newChunk.SetData(newdata, i);

                    subEntries.Add(newChunk);
                    /*
#if DEBUG
                    AELogger.Log("creating subchunk of type" + entryType);
#endif
                    */
                }
                else
                {
                    StructEntry<SpatkUnkChunk> newChunk = new StructEntry<SpatkUnkChunk>();
                    newChunk.size = 0x20;
                    newChunk.SetData(newdata, i);

                    subEntries.Add(newChunk);
                }
            }
        }
    }
}
