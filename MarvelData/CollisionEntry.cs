using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarvelData
{
    public class CollisionEntry : MultiStructEntry
    {
        private StructEntry<CollisionHeaderChunk> header;
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

        public override StructEntry<CollisionHeaderChunk> getCollisionHeader() 
        {
            return header;
        }

        public void setCollisiontHeader(StructEntry<CollisionHeaderChunk> header)
        {
            this.header = header;
        }

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
            if (size < 0x08)
            {
                throw new Exception("HEADER TOO SMALL");
            }
            setCollisiontHeader(new StructEntry<CollisionHeaderChunk>());
            getCollisionHeader().size = 0x08;
            getCollisionHeader().SetData(newdata,0);
            subEntries.Add(getCollisionHeader());

            for (int i = 0x08; i + 0x1c < size; i += 0x20)
            {
                int subType = newdata[i];
                AELogger.Log("subtype " + subType);
//                if (subType < MVC3DataStructures.SpatkChunkTypes.Length
//                    && MVC3DataStructures.SpatkChunkTypes[subType] != typeof(SpatkUnkChunk))
//                {
//                    Type entryType = typeof(StructEntry<>).MakeGenericType(MVC3DataStructures.SpatkChunkTypes[subType]);
//                    StructEntryBase newChunk = (StructEntryBase)Activator.CreateInstance(entryType);
//                    newChunk.size = 0x20;
//                    newChunk.SetData(newdata, i);

//                    subEntries.Add(newChunk);

//                    if (subType == 9 && newChunk is StructEntry<SpatkActionChunk>)
//                    {
//                        SpatkActionChunk action = ((StructEntry<SpatkActionChunk>)newChunk).data;
//                        if (action.actionClass < anmChrIndexOffsets.Length && anmChrIndexOffsets[action.actionClass] >= 0)
//                        {
//                            //anmChrIndexMaybe = anmChrIndexOffsets[action.actionClass] + action.actionIndex;
//                        }
//                    }
//                    /*
//#if DEBUG
//                    AELogger.Log("creating subchunk of type" + entryType);
//#endif
//                    */
//                }
//                else
                {
                    StructEntry<CollisionStandardChunk> newChunk = new StructEntry<CollisionStandardChunk>();
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

            setCollisiontHeader((StructEntry<CollisionHeaderChunk>)subEntries[0]);

            //if (getSpatkHeader().data.disable > 0)
            //{
            //    nameSB.Append("DISABLED ");
            //}

            //nameSB.Append(getSpatkHeader().data.positionState);
            //nameSB.Append(" ");

            //if (getSpatkHeader().data.meterRequirement > 0)
            //{
            //    nameSB.Append(getSpatkHeader().data.meterRequirement);
            //    nameSB.Append("bar ");
            //}

            //SubNameLoop();


            //if ((int)getSpatkHeader().data.comboState > 1)
            //{
            //    nameSB.Append(" in block/hitstun?");
            //}

            //if (anmChrIndexMaybe > 0)
            //{
            //    nameSB.Append(" ... anmchr ?= ");
            //    nameSB.Append(anmChrIndexMaybe.ToString("X"));
            //    nameSB.Append("?");
            //}

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

        public override void AddSubChunk()
        {
            StructEntry<CollisionStandardChunk> chunk = new StructEntry<CollisionStandardChunk>
            {
                data = new CollisionStandardChunk()
            };
            size += 0x20;
            chunk.size = 0x20;
            chunk.bHasData = true;
            chunk.name = "unknown";
            chunk.data.objectReferenceId = -1;
            chunk.data.unk04 = -1;
            subEntries.Add(chunk);
        }

        //public void TryToLabelAnmChr(TableFile file)
        //{
        //    if (anmChrIndexMaybe > 0)
        //    {
        //        if (file.table.Count > anmChrIndexMaybe
        //            &&
        //            file.table[anmChrIndexMaybe].bHasData && file.table[anmChrIndexMaybe].name == "unknown")
        //        {
        //            file.table[anmChrIndexMaybe].name = name;
        //        }
        //    }
        //}
    } // class
}
