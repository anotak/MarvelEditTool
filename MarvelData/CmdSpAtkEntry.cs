using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarvelData
{
    public class CmdSpAtkEntry : MultiStructEntry
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
            if (size < 0x24)
            {
                throw new Exception("HEADER TOO SMALL");
            }
            StructEntry<SpatkHeaderChunk> header = new StructEntry<SpatkHeaderChunk>();
            header.size = 0x24;
            header.SetData(newdata,0);
            subEntries.Add(header);

            for (int i = 0x24; i + 0x19 < size; i += 0x20)
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
        } //setdata

        public override void GuessName()
        {
            if (nameSB == null)
            {
                nameSB = new StringBuilder();
            }
            else
            {
                nameSB.Clear();
            }

            StructEntry<SpatkHeaderChunk> header = (StructEntry<SpatkHeaderChunk>)subEntries[0];

            if (header.data.disable > 0)
            {
                nameSB.Append("DISABLED ");
            }

            nameSB.Append(header.data.positionState);
            nameSB.Append(" ");

            if (header.data.meterrequirement > 0)
            {
                nameSB.Append(header.data.meterrequirement);
                nameSB.Append("bar ");
            }

            SubNameLoop();


            if (header.data.comboState > 1)
            {
                nameSB.Append(" in block/hitstun?");
            }

            // finish up
            if (nameSB.Length > 0)
            {
                name = nameSB.ToString();
            }
            else
            {
                name = "unknown";
            }
        }



    } // class
}
