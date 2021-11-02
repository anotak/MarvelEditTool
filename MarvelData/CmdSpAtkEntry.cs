using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarvelData
{
    public class CmdSpAtkEntry : MultiStructEntry
    {
        public int anmChrIndexMaybe;
        private StructEntry<SpatkHeaderChunk> header;
        public static int[] anmChrIndexOffsets = {
            0, // 0 movement
            -1, // 1 blockin
            -1,
            -1,
            -1,
            -1,
            0x96, // normals?
            0xAA, // airdashes?
            0xBE, // 8 specials
            0xDC, //9 supers
            0xF0, // 10 ?? dormamu air spell charge
            -1,
            -1,
            -1,
            -1,
            0x17C, // 15, flight
        };

        public override bool isAnmChrEdit { get; internal set; }

        public override StructEntry<SpatkHeaderChunk> getSpatkHeader() 
        {
            return header;
        }

        public void setHeader(StructEntry<SpatkHeaderChunk> header)
        {
            this.header = header;
        }

        public override void SetData(byte[] newdata)
        {
            anmChrIndexMaybe = 0;
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
            setHeader(new StructEntry<SpatkHeaderChunk>());
            getSpatkHeader().size = 0x24;
            getSpatkHeader().SetData(newdata,0);
            subEntries.Add(getSpatkHeader());

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

                    if (subType == 9 && newChunk is StructEntry<SpatkActionChunk>)
                    {
                        SpatkActionChunk action = ((StructEntry<SpatkActionChunk>)newChunk).data;
                        if (action.actionClass < anmChrIndexOffsets.Length && anmChrIndexOffsets[action.actionClass] >= 0)
                        {
                            anmChrIndexMaybe = anmChrIndexOffsets[action.actionClass] + action.actionIndex;
                        }
                    }
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

            setHeader((StructEntry<SpatkHeaderChunk>)subEntries[0]);
            if (getSpatkHeader().data.disable > 0)
            {
                nameSB.Append((getSpatkHeader().data.disable).ToString().ToUpperInvariant());
                nameSB.Append(" ");
            }
            nameSB.Append(getSpatkHeader().data.positionState);
            nameSB.Append(" ");

            if (getSpatkHeader().data.meterRequirement > 0)
            {
                nameSB.Append(getSpatkHeader().data.meterRequirement);
                nameSB.Append("bar ");
            }

            SubNameLoop();


            if (!getSpatkHeader().data.comboState.Equals(null) && !getSpatkHeader().data.comboState.Equals("Ukn3"))
            {
                nameSB.Append(" in " + getSpatkHeader().data.comboState);
            }

            if (anmChrIndexMaybe > 0 && !isAnmChrEdit)
            {
                nameSB.Append("...anmchr => ");
                nameSB.Append(anmChrIndexMaybe.ToString("X"));
                nameSB.Append("?");
            }

            if (anmChrIndexMaybe == 0 && !isAnmChrEdit)
            {
                if (nameSB.ToString().Contains("Ground S "))
                {
                    nameSB.Append("...anmchr => 168?");
                } else if (nameSB.ToString().Contains("Air S? "))
                {
                    nameSB.Append("...anmchr => 16A?");
                } else if (nameSB.ToString().Contains("Air 8S "))
                {
                    nameSB.Append("...anmchr => 16B?");
                } else if (nameSB.ToString().Contains("Air 2S "))
                {
                    nameSB.Append("...anmchr => 16C?");
                }
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

        public void TryToLabelAnmChr(TableFile file)
        {
            if (anmChrIndexMaybe > 0)
            {
                if (file.table.Count > anmChrIndexMaybe
                    &&
                    file.table[anmChrIndexMaybe].bHasData && file.table[anmChrIndexMaybe].name == "unknown")
                {
                    file.table[anmChrIndexMaybe].name = name;
                }
            }
        }
    } // class
}
