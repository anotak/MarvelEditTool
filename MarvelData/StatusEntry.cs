using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace MarvelData
{
    public unsafe class StatusEntry : TableEntry
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct StatusChunk
        {
            public int index;
            public StatusFlags statusflags;
            public int totalhealth;
            public float unk0C;
            public float damagegiven;
            public float damagetaken;
            public float speedself;
            public float speedreceived;
            public float unk20;
            public float comboweight;
            public int unk28;
            public float unk2C;
            public float CameraSizeX;
            public float partner2offsetIntro;
            public float partner1offsetIntro;
            public int unk3C;
            public int unk40;
            public int airActions;
            public float unk48;
            public float dashSpeed;
            public float unk50;
            public float dashTraction;
            public int unk58;
            public float unk5C;
            public float unk60;
            public float flightClearance;
            public float unk68;
            public int unk6C; // 0x6c
            public int unk70;
            public int unk74;
            public int unk7C;
            public int unk80;
            public int unk84;
            public int unk88;
            public int unk8C;
            public int unk90;
            public int unk94;
            public float minDamageScalingNormals;
            public float minScalingSpecials;
            public float minScalingHypers;
            public int unkA4;
            public int unkA8;
            public int unkAC;
            public int unkB0;
            public int unkB4;
            public int unkB8;
            public int unkBC;
            public int unkC0;
            public int unkC4;
            public int unkC8;
            public int unkCC;
            public int unkD0;
            public int unkD4;
            public float XF1Damage;
            public float XF1Speed;
            public float XF1Duration;
            public int unkE4;
            public int unkE8;
            public int unkEC;
            public int unkF0;
            public float unkF4;
            public float unkF8;
            public int unkFC;
            public int unk100;
            public int unk104;
            public float XF2Damage;
            public float XF2Speed;
            public float XF2Duration;
            public int unk114;
            public int unk118;
            public int unk11C;
            public int unk120;
            public float unk124;
            public float unk128;
            public int unk12C;
            public int unk130;
            public int unk134;
            public float XF3Damage;
            public float XF3Speed;
            public float XF3Duration;
            public int unk144;
            public int unk148;
            public int unk150;
            public float unk154;
            public float unk158;
            public int unk15C;
            public int unk160;
            public int unk164;
            public int unk168;
            public int unk16C;
            public int unk170;
            public int unk174;
            public int unk178;
            public int unk17C;
            public int unk180;
            public int unk184;
            public int unk188;
            public int unk18C;
            public int unk190;
            public int unk194;
            public int unk198;
            public int unk19C;
            public int unk1A0;
            public int unk1A4;
            public int unk1A8;
            public int unk1AC;
            public int unk1B0;
            public int unk1B4;
            public int unk1B8;
            public int unk1BC;
            public int unk1C0;
            public int unk1C4;
            public int unk1C8;
            public int unk1CC;
            public int unk1D0;
            public int unk1D4;
            public int unk1D8;
            public int unk1DC;
            public int unk1E0;
            public int unk1E4;
            public int unk1E8;
            public int unk1EC;
            public int unk1F0;
            public int unk1F4;
            public int unk1F8;
            public int unk1FC;
            public int unk200;
            public int unk204;
            public int unk208;
            public int unk20C;
            public int unk210;
            public int unk214;
            public int unk218;
            public int unk21C;
            public int unk220;
            public int unk224;
            public int unk228;
            public int unk22C;
            public int unk230;
            public int unk234;
            public int unk238;
            public int unk23C;
            public int unk240;
            public int unk244;
            public int unk248;
            public int unk24C;
            public int unk250;
            public int unk254;
            public int unk258;
            public int unk25C;
            public int unk260;
            public int unk264;
            public int unk268;
            public int unk26C;
            public int unk270;
            public int unk274;
            public int unk278;
            public int unk27C;
            public int unk280;
            public int unk284;
            public int unk288;
            public int unk28C;
            public int unk290;
            public int unk294;
            public int unk298;
            public int unk29C;
            public int unk2A0;
            public int unk2A4;
            public int unk2A8;
            public int unk2AC;
            public int unk2B0;
            public int unk2B4;
            public int unk2B8;
            public int unk2BC;
            public int unk2C0;
            public int unk2C4;
            public int unk2C8;
            public int unk2CC;
            public int unk2D0;
            public int unk2D4;
            public int unk2D8;
            public int unk2DC;
            public int unk2E0;
            public int unk2E4;
            public int unk2E8;
            public int unk2EC;
            public int unk2F0;
            public int unk2F4;
            public int unk2F8;
            public int unk2FC;
            public int unk300;
            public int unk304;
            public int unk308;
            public int unk30C;
            public int unk310;
            public int unk314;
            public int unk318;
            public int unk31C;
            public int unk320;
            public int unk324;
            public int unk328;
            public int unk32C;
            public int unk330;
            public int unk334;
            public int unk338;
            public int unk33C;
            public int unk340;
            public int unk344;
            public int unk348;
            public int unk34C;
            public int unk350;
            public int unk354;
        }

        [Flags]
        public enum StatusFlags : int
        {
            Male =      0x00000000000000000000000000000001,
            Female =    0x00000000000000000000000000000010
        }

        public StatusChunk data;

        public override byte[] GetData()
        {
            byte[] output = new byte[sizeof(StatusChunk)];
            fixed (StatusChunk* start = &data)
            {
                byte* ptr = (byte*)start;
                for (int i = 0; i < sizeof(StatusChunk); i++)
                {
                    output[i] = *ptr;
                    ptr++;
                }
            }

            return output;
        }

        public override void SetData(byte[] newdata)
        {
            size = sizeof(StatusChunk);
            bHasData = true;

            fixed (StatusChunk* start = &data)
            {
                byte* ptr = (byte*)start;
                for (int i = 0; i < sizeof(StatusChunk); i++)
                {
                    //AELogger.Log(i + " ASDF " + sizeof(StatusChunk));
                    //AELogger.Log(newdata[i] + " is data");
                    *ptr = newdata[i];
                    ptr++;
                }
            }
        }
    }
}
