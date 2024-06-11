using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace MarvelData
{
    public class MultiStructEntry : TableEntry
    {
        public List<StructEntryBase> subEntries;
        private string chunkName;

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

        //called in GuessName() to add input info 
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
                else if (subEntries[i] is StructEntry<BaseActChunk>)
                {
                    BaseActChunk chunk = ((StructEntry<BaseActChunk>)subEntries[i]).data;
                    if ((int)chunk.inputCodeDirection <= 10)
                    {
                        nameSB.Append(MVC3DataStructures.NumpadDirections[(int)chunk.inputCodeDirection]);
                    }
                    else
                    {
                        nameSB.Append(chunk.inputCodeButton);
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

            if (this.GetType().ToString().Contains("CollisionEntry"))
            {
                StructEntry<CollisionStandardChunk> chunk = new StructEntry<CollisionStandardChunk>();
                chunk.data = new CollisionStandardChunk();
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunk.name = "unknown";
                subEntries.Add(chunk);
                //this.subEntries[subEntries.Count - 1].SetData         figure out how make unk04 and objectreference -1 by default, maybe update size in the header?
            }
            else
            {
                StructEntry<SpatkUnkChunk> chunk = new StructEntry<SpatkUnkChunk>();
                chunk.data = new SpatkUnkChunk();
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunkName = Tools.GetDescription(chunk.data.subChunkType);
                chunk.name = chunkName;
                subEntries.Add(chunk);
            }
        }

        // creates subchunk section according to selected type - FM: looks fugly af
        public virtual void AddSubChunk(String subChunkType)
        {
            if (subChunkType.Equals("standardInput"))
            {
                StructEntry<SpatkStandardChunk> chunk = new StructEntry<SpatkStandardChunk>();
                chunk.data = new SpatkStandardChunk();
                chunk.data.subChunkType = (SubChunkType)02;
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunk.name = Tools.GetDescription(chunk.data.subChunkType);
                subEntries.Add(chunk);
            }
            else if (subChunkType.Equals("dashDirectionInput"))
            {
                StructEntry<SpatkDirectionalDashChunk> chunk = new StructEntry<SpatkDirectionalDashChunk>();
                chunk.data = new SpatkDirectionalDashChunk();
                chunk.data.subChunkType = (SubChunkType)03;
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunk.name = Tools.GetDescription(chunk.data.subChunkType);
                subEntries.Add(chunk);
            }
            else if (subChunkType.Equals("twoButtonInput1"))
            {
                StructEntry<SpatkTwoButtonChunk> chunk = new StructEntry<SpatkTwoButtonChunk>();
                chunk.data = new SpatkTwoButtonChunk();
                chunk.data.subChunkType = (SubChunkType)04;
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunk.name = Tools.GetDescription(chunk.data.subChunkType);
                subEntries.Add(chunk);
            }
            else if (subChunkType.Equals("directionAndButtonInput"))
            {
                StructEntry<SpatkDirButtonChunk> chunk = new StructEntry<SpatkDirButtonChunk>();
                chunk.data = new SpatkDirButtonChunk();
                chunk.data.subChunkType = (SubChunkType)05;
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunk.name = Tools.GetDescription(chunk.data.subChunkType);
                subEntries.Add(chunk);
            }
            else if (subChunkType.Equals("twoButtonInput2"))
            {
                StructEntry<SpatkTwoButtonAirdashChunk> chunk = new StructEntry<SpatkTwoButtonAirdashChunk>();
                chunk.data = new SpatkTwoButtonAirdashChunk();
                chunk.data.subChunkType = (SubChunkType)07;
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunk.name = Tools.GetDescription(chunk.data.subChunkType);
                subEntries.Add(chunk);
            }
            else if (subChunkType.Equals("executeAction"))
            {
                StructEntry<SpatkActionChunk> chunk = new StructEntry<SpatkActionChunk>();
                chunk.data = new SpatkActionChunk();
                chunk.data.subChunkType = (SubChunkType)09;
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunk.name = Tools.GetDescription(chunk.data.subChunkType);
                subEntries.Add(chunk);
            }
            //else if (subChunkType.Equals("captureState"))
            //{
            //}
            //else if (subChunkType.Equals("stateRestriction"))
            //{
            //}
            //else if (subChunkType.Equals("simpleModeAirComboUnk"))
            //{
            //}
            else if (subChunkType.Equals("modeRequired"))
            {
                StructEntry<SpatkModeRequiredChunk> chunk = new StructEntry<SpatkModeRequiredChunk>();
                chunk.data = new SpatkModeRequiredChunk();
                chunk.data.subChunkType = (SubChunkType)30;
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunk.name = Tools.GetDescription(chunk.data.subChunkType);
                subEntries.Add(chunk);
            }
            //else if (subChunkType.Equals("TACUnk"))
            //{
            //}
            //else if (subChunkType.Equals("airActionLimit"))
            //{
            //}
            else if (subChunkType.Equals("TACDHCAction"))
            {
                StructEntry<SpatkTACDHCChunk> chunk = new StructEntry<SpatkTACDHCChunk>();
                chunk.data = new SpatkTACDHCChunk();
                chunk.data.subChunkType = (SubChunkType)35;
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunk.name = Tools.GetDescription(chunk.data.subChunkType);
                subEntries.Add(chunk);
            }
            //else if (subChunkType.Equals("superJumpAction"))
            //{
            //}
            //else if (subChunkType.Equals("snapBackChar"))
            //{
            //}
            else if (subChunkType.Equals("stateChange"))
            {
                StructEntry<SpatkRestrictedStateChunk> chunk = new StructEntry<SpatkRestrictedStateChunk>();
                chunk.data = new SpatkRestrictedStateChunk();
                chunk.data.subChunkType = (SubChunkType)47;
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunk.name = Tools.GetDescription(chunk.data.subChunkType);
                subEntries.Add(chunk);
            }
            //else if (subChunkType.Equals("SUnk"))
            //{
            //}
            else if (subChunkType.Equals("prohibitedFollowUpAction"))
            {
                StructEntry<SpatkProhibitedChunk> chunk = new StructEntry<SpatkProhibitedChunk>();
                chunk.data = new SpatkProhibitedChunk();
                chunk.data.subChunkType = (SubChunkType)49;
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunk.name = Tools.GetDescription(chunk.data.subChunkType);
                subEntries.Add(chunk);
            }
            //else if (subChunkType.Equals("heightRestriction"))
            //{
            //}
            else if (subChunkType.Equals("airDash"))
            {
                StructEntry<SpatkAirdashChunk> chunk = new StructEntry<SpatkAirdashChunk>();
                chunk.data = new SpatkAirdashChunk();
                chunk.data.subChunkType = (SubChunkType)52;
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunk.name = Tools.GetDescription(chunk.data.subChunkType);
                subEntries.Add(chunk);
            }
            else if (subChunkType.Equals("airSpecialActionLimit"))
            {
                StructEntry<SpatkAirSpecialLimiterChunk> chunk = new StructEntry<SpatkAirSpecialLimiterChunk>();
                chunk.data = new SpatkAirSpecialLimiterChunk();
                chunk.data.subChunkType = (SubChunkType)53;
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunk.name = Tools.GetDescription(chunk.data.subChunkType);
                subEntries.Add(chunk);
            }
            else if (subChunkType.Equals("guardTACAction"))
            {
                StructEntry<SpatkGuardTACChunk> chunk = new StructEntry<SpatkGuardTACChunk>();
                chunk.data = new SpatkGuardTACChunk();
                chunk.data.subChunkType = (SubChunkType)56;
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunk.name = Tools.GetDescription(chunk.data.subChunkType);
                subEntries.Add(chunk);
            }
            else if (subChunkType.Equals("hypers"))
            {
                StructEntry<SpatkHyperChunk> chunk = new StructEntry<SpatkHyperChunk>();
                chunk.data = new SpatkHyperChunk();
                chunk.data.subChunkType = (SubChunkType)58;
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunk.name = Tools.GetDescription(chunk.data.subChunkType);
                subEntries.Add(chunk);
            }
            else if (subChunkType.Equals("allowedChainOnState"))
            {
                StructEntry<SpatkAllowedChainChunk> chunk = new StructEntry<SpatkAllowedChainChunk>();
                chunk.data = new SpatkAllowedChainChunk();
                chunk.data.subChunkType = (SubChunkType)63;
                size += 0x20;
                chunk.size = 0x20;
                chunk.bHasData = true;
                chunk.name = Tools.GetDescription(chunk.data.subChunkType);
                subEntries.Add(chunk);
            }
            //else if (subChunkType.Equals("advGuardUnk"))
            //{
            //}
            else
            {
                AddSubChunk();
            }

            subEntries.Count();

        }
    }
}
