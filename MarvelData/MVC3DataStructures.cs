using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Xml.Linq;

namespace MarvelData {


    
    [StructLayout(LayoutKind.Explicit)]
        public struct ShotChunk
        {
            [FieldOffset(0)] public int unk64;
            [FieldOffset(4)] public int unk68;
            [FieldOffset(8)] public int unk6C;
            [FieldOffset(12)] public int projectileSpawn;
            [FieldOffset(16)] public ShtFlagsA ShtFlagsA;
            [FieldOffset(20)] public ShtFlagsB ShtFlagsB;
            [FieldOffset(24)] public ShtFlagsC ShtFlagsC;
            [FieldOffset(28)] public int unk80;
            [FieldOffset(32)] public float projectileDuration;
            [FieldOffset(36)] public float unk88;
            [FieldOffset(40)] public int unk8c;
            [FieldOffset(44)] public float projectileSpeed;
            [FieldOffset(48)] public float projectileAccel;
            [FieldOffset(52)] public float unk98;
            [FieldOffset(56)] public float beamDuration;
            [FieldOffset(60)] public float projectileYSpeed;
            [FieldOffset(64)] public float projectileYAccel;
            [FieldOffset(68)] public float unkA8;
            [FieldOffset(72)] public float unkAC;
            [FieldOffset(76)] public float trackingStrength;
            [FieldOffset(80)] public float trackingUnk;
            [FieldOffset(84)] public float trackingRotation;
            [FieldOffset(88)] public float trackingStartFrame;
            [FieldOffset(92)] public int unkC0;
            [FieldOffset(96)] public int unkC4;
            [FieldOffset(100)] public float trackingEndFrame;
            [FieldOffset(104)] public int unkCC;
            [FieldOffset(108)] public float despawnProjectileFrame;
            [FieldOffset(112)] public int returnBone;
            [FieldOffset(116)] public int unkD8;
            [FieldOffset(120)] public int unkDC;
            [FieldOffset(124)] public int unkE0;
            [FieldOffset(128)] public int unkE4;
            [FieldOffset(132)] public float unkE8;
            [FieldOffset(136)] public float SpawnVerticalPosition;
            [FieldOffset(140)] public float SpawnHorizontalPosition;
            [FieldOffset(144)] public int unkF4;
            [FieldOffset(148)] public float unkF8;
            [FieldOffset(152)] public int unkFC;
            [FieldOffset(156)] public float unk100;
            [FieldOffset(160)] public float SpawnPositionAngle;
            [FieldOffset(164)] public float ProjectileAngle;
            [FieldOffset(168)] public float unk10C;
            [FieldOffset(172)] public float unk110;
            [FieldOffset(176)] public float RandomSpawnAngle;
            [FieldOffset(180)] public float RandomSpawnAngle2;
            [FieldOffset(184)] public int unk11C;
            [FieldOffset(188)] public int unk120;
            [FieldOffset(192)] public int unk124;
            [FieldOffset(196)] public float unk128;
            [FieldOffset(200)] public float unk12C;
            [FieldOffset(204)] public TrapTransition trapTransition; //bitwise flags
            [FieldOffset(208)] public TrapTransition trapTransition2;
            [FieldOffset(212)] public TrapTransition trapTransition3;
            [FieldOffset(216)] public long projectile2Reference;
            [FieldOffset(280)] public long projectile3Reference;
            [FieldOffset(344)] public long projectile4Reference;
            /*public int projectile2Reference1;
            public int projectile2Reference2;
            public int projectile2Reference3;
            public int projectile2Reference4;
            public int projectile2Reference5;
            public int projectile2Reference6;
            public int projectile2Reference7;
            public int projectile2Reference8;
            public int projectile2Reference9;
            public int projectile2Reference10;
            public int projectile2Reference11;
            public int projectile2Reference12;
            public int projectile2Reference13;
            public int projectile2Reference14;
            public int projectile2Reference15;
            public int projectile2Reference16;
            public int projectile3Reference1;
                public int projectile3Reference2;
                public int projectile3Reference3;
                public int projectile3Reference4;
                public int projectile3Reference5;
                public int projectile3Reference6;
                public int projectile3Reference7;
                public int projectile3Reference8;
                public int projectile3Reference9;
                public int projectile3Reference10;
                public int projectile3Reference11;
                public int projectile3Reference12;
                public int projectile3Reference13;
                public int projectile3Reference14;
                public int projectile3Reference15;
                public int projectile3Reference16;
                public int projectile4Reference1;
                public int projectile4Reference2;
                public int projectile4Reference3;
                public int projectile4Reference4;
                public int projectile4Reference5;
                public int projectile4Reference6;
                public int projectile4Reference7;
                public int projectile4Reference8;
                public int projectile4Reference9;
                public int projectile4Reference10;
                public int projectile4Reference11;
                public int projectile4Reference12;
                public int projectile4Reference13;
                public int projectile4Reference14;
                public int projectile4Reference15;
                public int projectile4Reference16;
            */
            [FieldOffset(408)] public int unk1FC;
            [FieldOffset(412)] public int unk200;
            [FieldOffset(416)] public int unk204;
            [FieldOffset(420)] public int unk208;
            [FieldOffset(424)] public int unk20C;
            [FieldOffset(428)] public int unk210;
            [FieldOffset(432)] public long projectileAnmString;
            /*public int projectileAnmString1;
                public int projectileAnmString2;
                public int projectileAnmString3;
                public int projectileAnmString4;
                public int projectileAnmString5;
                public int projectileAnmString6;
                public int projectileAnmString7;
                public int projectileAnmString8;
                public int projectileAnmString9;
                public int projectileAnmString10;
                public int projectileAnmString11;
                public int projectileAnmString12;
                public int projectileAnmString13;
                public int projectileAnmString14;
                public int projectileAnmString15;
                public int projectileAnmString16;*/
            [FieldOffset(496)] public int unk254;
            [FieldOffset(500)] public int unk258;
            [FieldOffset(504)] public int unk25C;
            [FieldOffset(508)] public int unk260;
            [FieldOffset(512)] public int unk264;
            [FieldOffset(516)] public int unk268;
            [FieldOffset(520)] public int unk26C;
            [FieldOffset(524)] public int unk270;
            [FieldOffset(528)] public int soundIDType;
            [FieldOffset(532)] public int unk278;
            [FieldOffset(536)] public int soundID;
            [FieldOffset(540)] public int soundBankIndexUnk;
            [FieldOffset(544)] public int unk284;
            [FieldOffset(548)] public int unk288;
            [FieldOffset(552)] public int soundPlay;
            [FieldOffset(556)] public int unk290;
            [FieldOffset(560)] public int unk294;
            [FieldOffset(564)] public float unk298;
            [FieldOffset(568)] public float unk29C;
            [FieldOffset(572)] public float unk2A0;
            [FieldOffset(576)] public int unk2A4;
            [FieldOffset(580)] public float unk2A8;
            [FieldOffset(584)] public float unk2AC;
            [FieldOffset(588)] public float unk2B0;
            [FieldOffset(592)] public int unk2B4;
            [FieldOffset(596)] public int effectPlayed;
            [FieldOffset(600)] public int unk2BC;
            [FieldOffset(604)] public int unk2C0;
            [FieldOffset(608)] public int unk2C4;
            [FieldOffset(612)] public float RotationXSpeed;
            [FieldOffset(616)] public float unk2CC;
            [FieldOffset(620)] public float unk2D0;
            [FieldOffset(624)] public float unk2D4;
            [FieldOffset(628)] public int unk2D8;
            [FieldOffset(632)] public int unk2DC;
            [FieldOffset(636)] public int friendlyFire;
            [FieldOffset(640)] public int unk2E4;
            [FieldOffset(644)] public int unk2E8;
            [FieldOffset(648)] public int unk2EC;
            [FieldOffset(652)] public int canBeNullified;
            [FieldOffset(656)] public int unk2F4;
            [FieldOffset(660)] public int unk2F8;
            [FieldOffset(664)] public int unk2FC;
            }

   /* [StructLayout(LayoutKind.Sequential)]
    public struct ShotChunk
    {
                    public int unk64;
     public int unk68;
     public int unk6C;
     public int projectileSpawn;
     public ShtFlagsA ShtFlagsA;
     public ShtFlagsB ShtFlagsB;
     public ShtFlagsC ShtFlagsC;
     public int unk80;
     public float projectileDuration;
     public float unk88;
     public int unk8c;
     public float projectileSpeed;
     public float projectileAccel;
     public float unk98;
     public float beamDuration;
     public float projectileYSpeed;
     public float projectileYAccel;
     public float unkA8;
     public float unkAC;
     public float trackingStrength;
     public float trackingUnk;
     public float trackingRotation;
     public float trackingStartFrame;
     public int unkC0;
     public int unkC4;
     public float trackingEndFrame;
     public int unkCC;
     public float despawnProjectileFrame;
     public int returnBone;
     public int unkD8;
     public int unkDC;
     public int unkE0;
     public int unkE4;
     public float unkE8;
     public float SpawnVerticalPosition;
     public float SpawnHorizontalPosition;
     public int unkF4;
     public float unkF8;
     public int unkFC;
     public float unk100;
     public float SpawnPositionAngle;
     public float ProjectileAngle;
     public float unk10C;
     public float unk110;
     public float RandomSpawnAngle;
     public float RandomSpawnAngle2;
     public int unk11C;
     public int unk120;
     public int unk124;
     public float unk128;
     public float unk12C;
     public TrapTransition trapTransition; //bitwise flags
     public TrapTransition trapTransition2;
     public TrapTransition trapTransition3;
     //public long projectile2Reference;
     //public long projectile3Reference;
     //public long projectile4Reference;
       public int projectile2Reference1;
        public int projectile2Reference2;
        public int projectile2Reference3;
        public int projectile2Reference4;
        public int projectile2Reference5;
        public int projectile2Reference6;
        public int projectile2Reference7;
        public int projectile2Reference8;
        public int projectile2Reference9;
        public int projectile2Reference10;
        public int projectile2Reference11;
        public int projectile2Reference12;
        public int projectile2Reference13;
        public int projectile2Reference14;
        public int projectile2Reference15;
        public int projectile2Reference16;
        public int projectile3Reference1;
            public int projectile3Reference2;
            public int projectile3Reference3;
            public int projectile3Reference4;
            public int projectile3Reference5;
            public int projectile3Reference6;
            public int projectile3Reference7;
            public int projectile3Reference8;
            public int projectile3Reference9;
            public int projectile3Reference10;
            public int projectile3Reference11;
            public int projectile3Reference12;
            public int projectile3Reference13;
            public int projectile3Reference14;
            public int projectile3Reference15;
            public int projectile3Reference16;
            public int projectile4Reference1;
            public int projectile4Reference2;
            public int projectile4Reference3;
            public int projectile4Reference4;
            public int projectile4Reference5;
            public int projectile4Reference6;
            public int projectile4Reference7;
            public int projectile4Reference8;
            public int projectile4Reference9;
            public int projectile4Reference10;
            public int projectile4Reference11;
            public int projectile4Reference12;
            public int projectile4Reference13;
            public int projectile4Reference14;
            public int projectile4Reference15;
            public int projectile4Reference16;
         public int unk1FC;
         public int unk200;
         public int unk204;
         public int unk208;
         public int unk20C;
         public int unk210;
         //public long projectileAnmString;
        public int projectileAnmString1;
            public int projectileAnmString2;
            public int projectileAnmString3;
            public int projectileAnmString4;
            public int projectileAnmString5;
            public int projectileAnmString6;
            public int projectileAnmString7;
            public int projectileAnmString8;
            public int projectileAnmString9;
            public int projectileAnmString10;
            public int projectileAnmString11;
            public int projectileAnmString12;
            public int projectileAnmString13;
            public int projectileAnmString14;
            public int projectileAnmString15;
            public int projectileAnmString16;
         public int unk254;
         public int unk258;
         public int unk25C;
         public int unk260;
         public int unk264;
         public int unk268;
         public int unk26C;
         public int unk270;
         public int soundIDType;
         public int unk278;
         public int soundID;
         public int soundBankIndexUnk;
         public int unk284;
         public int unk288;
         public int soundPlay;
         public int unk290;
         public int unk294;
         public float unk298;
         public float unk29C;
         public float unk2A0;
         public int unk2A4;
         public float unk2A8;
         public float unk2AC;
         public float unk2B0;
         public int unk2B4;
         public int effectPlayed;
         public int unk2BC;
         public int unk2C0;
         public int unk2C4;
         public float RotationXSpeed;
         public float unk2CC;
         public float unk2D0;
         public float unk2D4;
         public int unk2D8;
         public int unk2DC;
         public int friendlyFire;
         public int unk2E4;
         public int unk2E8;
         public int unk2EC;
         public int canBeNullified;
         public int unk2F4;
         public int unk2F8;
         public int unk2FC;
        }
   */
        
    [Flags]
        public enum ShtFlagsA : uint
        {
            None = 0,
            Unk0x01 = 0x00000001,
            Unk0x02 = 0x00000002,
            Unk0x04 = 0x00000004,
            Unk0x08 = 0x00000008,
            Unk0x10 = 0x00000010,
            Unk0x20 = 0x00000020,
            Unk0x40 = 0x00000040,
            Unk0x80 = 0x00000080,
            Unk0x0100 = 0x00000100,
            persistAfterHit = 0x00000200,
            Unk0x0400 = 0x00000400,
            noMovement = 0x00000800,
            canBeReflected = 0x00001000,
            rotateBackwards = 0x00002000,
            despawnInstantUnk = 0x00004000,
            Unk0x8000 = 0x00008000,
            Unk0x10000 = 0x00010000,
            SpawnAtOpponentXY = 0x00020000,
            AimAtOpponent = 0x00040000,
            Unk0x80000 = 0x00080000,
            Unk0x100000 = 0x00100000,
            Unk0x200000 = 0x00200000,
            Unk0x400000 = 0x00400000,
            Unk0x800000 = 0x00800000,
            projectileUnk = 0x01000000,
            Unk0x02000000 = 0x02000000,
            Unk0x04000000 = 0x04000000,
            Unk0x08000000 = 0x08000000,
            Unk0x10000000 = 0x10000000,
            Unk0x20000000 = 0x20000000,
        }


        [Flags]
        public enum ShtFlagsB : uint
        {
            None = 0,
            Unk0x01 = 0x00000001,
            disappearOnOwnerCancel = 0x00000002,
            Unk0x04 = 0x00000004,
            despawnWhenOwnerHit = 0x00000008,
            Unk0x10 = 0x00000010,
            Unk0x20 = 0x00000020,
            Unk0x40 = 0x00000040,
            Unk0x80 = 0x00000080,
            Unk0x0100 = 0x00000100,
            Unk0x0200 = 0x00000200,
            Unk0x0400 = 0x00000400,
            Unk0x0800 = 0x00000800,
            Unk0x1000 = 0x00001000,
            EffectFadeAway = 0x00002000,
            Unk0x4000 = 0x00004000,
            Unk0x8000 = 0x00008000,
            Unk0x10000 = 0x00010000,
            Unk0x20000 = 0x00020000,
            GroundImpactRemoveHitbox = 0x00040000,
            Unk0x80000 = 0x00080000,
            Unk0x100000 = 0x00100000,
            Unk0x200000 = 0x00200000,
            Unk0x400000 = 0x00400000,
            Unk0x800000 = 0x00800000,
            Unkx01000000 = 0x01000000,
            Unk0x02000000 = 0x02000000,
            Unk0x04000000 = 0x04000000,
            Unk0x08000000 = 0x08000000,
            Unk0x10000000 = 0x10000000,
            Unk0x20000000 = 0x20000000,
        }


        [Flags]
        public enum ShtFlagsC : uint
        {
            None = 0,
            Unk0x01 = 0x00000001,
            Unk0x02 = 0x00000002,
            Unk0x04 = 0x00000004,
            Unk0x08 = 0x00000008,
            Unk0x10 = 0x00000010,
            Unk0x20 = 0x00000020,
            Unk0x40 = 0x00000040,
            Unk0x80 = 0x00000080,
            Unk0x0100 = 0x00000100,
            Unk0x0200 = 0x00000200,
            Unk0x0400 = 0x00000400,
            clearEffectOnTransition = 0x00000800,
            Unk0x1000 = 0x00001000,
            Unk0x2000 = 0x00002000,
            Unk0x4000 = 0x00004000,
            Unk0x8000 = 0x00008000,
            Unk0x10000 = 0x00010000,
            Unk0x20000 = 0x00020000,
            Unk0x40000 = 0x00040000,
            Unk0x80000 = 0x00080000,
            Unk0x100000 = 0x00100000,
            Unk0x200000 = 0x00200000,
            Unk0x400000 = 0x00400000,
            Unk0x800000 = 0x00800000,
            Unkx01000000 = 0x01000000,
            Unk0x02000000 = 0x02000000,
            Unk0x04000000 = 0x04000000,
            Unk0x08000000 = 0x08000000,
            Unk0x10000000 = 0x10000000,
            Unk0x20000000 = 0x20000000,
            Unk0x40000000 = 0x40000000,
            Unk0x80000000 = 0x80000000
        }

    [StructLayout(LayoutKind.Sequential)]
        public struct ShotXSChunk
        {
        public float numberOfHits;
        public float NumberOfHitsUnk;
        public float durability;
        public float durabilityUnk;
        public int durabilityType;
        public int unk354;
        public int unk358;
        public int unk35C;
        public int unk360;
        }

    [StructLayout(LayoutKind.Sequential)]
        public struct ShotSChunk
        {
            public float numberOfHits;
            public float NumberOfHitsUnk;
            public float durability;
            public float durabilityUnk;
            public int durabilityType;
            public int unk354;
            public float unk358;
            public int unk35C;
            public int unk360;
            public int unk364;
            public int unk368;
            public int unk36C;
            public int unk370;
            public float unk374;
            public float unk378;
            public int unk37C;
            public int unk380;
            public int unk384;
            public int unk388;
            public float hitboxY;
            public float hitboxX;
            public float unk394;
            public int unk398;
            public float unk39C;
            public float unk3A0;
            public float unk3A4;
            public int unk3A8;
            public float BeamLengthLimitUnk;
            public float unk3B0;
            public float unk3B4;
            public float hitboxSize;
            public int unk3BC;
            public int unk3C0;
            public int unk3C4;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ShotLChunk
        {
            public float numberOfHits;
            public float NumberOfHitsUnk;
            public float durability;
            public float durabilityUnk;
            public int durabilityType;
            public int unk354;
            public float unk358;
            public int unk35C;
            public int unk360;
            public int unk364;
            public int unk368;
            public int unk36C;
            public int unk370;
            public int unk374;
            public int unk378;
            public int unk37C;
            public int unk380;
            public int unk384;
            public int unk388;
            public float altHitboxY;
            public float altHitboxX;
            public int unk394;
            public int unk398;
            public int unk39C;
            public int unk3A0;
            public int unk3A4;
            public int unk3A8;
            public float unk3AC;
            public float unk3B0;
            public int unk3B4;
            public float altHitboxSize;
            public int unk3BC;
            public int unk3C0;
            public int unk3C4;
            public int unk3C8;
            public int unk3CC;
            public int unk3D0;
            public int unk3D4;
            public int unk3D8;
            public int unk3DC;
            public int unk3E0;
            public int unk3E4;
            public int unk3E8;
            public float hitboxY;
            public float hitboxX;
            public int unk3F4;
            public int unk3F8;
            public int unk3FC;
            public int unk400;
            public int unk404;
            public int unk408;
            public float BeamLengthLimitUnk;
            public float unk410;
            public float unk414;
            public float hitboxSize;
            public int unk41C;
            public int unk420;
            public int unk424;
        }


    [StructLayout(LayoutKind.Sequential)]
        public struct StatusChunk
        {
            public int index;
            public StatusFlags statusFlags;
            public int totalHealth;
            public float meterGain;
            public float damageGiven;
            public float damageTaken;
            public float speedSelf;
            public float speedReceived;
            public float minLaunchHeight;
            public float comboWeight;
            public int unk28;
            public float unk2C;
            public float CameraSizeX;
            public float partner2OffsetIntro;
            public float partner1OffsetIntro;
            public float unk3C;
            public float unk40;
            public int airActions;
            public float unk48;
            public float dashAccelAfter;
            public float unk50;
            public float dashTraction;
            public int unk58;
            public float flightAccel;
            public float flightMaxSpeed;
            public float flightClearance;
            public float flightMaxHeight;
            public int stLBaseStun; // 0x6c
            public int stMBaseStun;
            public int stHBaseStun;
            public int crLBaseStun;
            public int crMBaseStun;
            public int crHBaseStun;
            public int jLBaseStun;
            public int jMBaseStun;
            public int jHBaseStun;
            public int GroundChainLimit;
            public int AirChainLimit;
            public float minDmgScalingNormals;
            public float minDmgScalingSpecials;
            public float minDmgScalingHypers;
            public int alphaAssistTHC;
            public int bettaAssistTHC;
            public int gammaAssistTHC;
            public int slot0DHC;
            public int slot1DHC;
            public int slot2DHC;
            public int slot3DHC;
            public int slot4DHC;
            public int slot5DHC;
            public int slot6DHC;
            public int slotDHCUnk;
            public int XF1YellowHealthRegen;
            public int XF1ChipDamageOn;
            public float XF1Damage;
            public float XF1Speed;
            public float XF1Duration;
            public int unkE4;
            public int unkE8;
            public int unkEC;
            public int unkF0;
            public float XF1MeterGain;
            public float XF1DmgTaken;
            public int unkFC;
            public int XF2YellowHealthRegen;
            public int XF2ChipDamageOn;
            public float XF2Damage;
            public float XF2Speed;
            public float XF2Duration;
            public int unk114;
            public int unk118;
            public int unk11C;
            public int unk120;
            public float XF2MeterGain;
            public float XF2DmgTaken;
            public int unk12C;
            public int XF3YellowHealthRegen;
            public int XF3ChipDamageOn;
            public float XF3Damage;
            public float XF3Speed;
            public float XF3Duration;
            public int unk144;
            public int unk148;
            public int unk150;
            public float unk154;
            public float XF3MeterGain;
            public float XF3DmgTaken;
            public int unk160;
            public int frankLevel2XP;
            public int frankLevel3XP;
            public int frankLevel4XP;
            public int frankLevel5XP;
            public int unk174;
            public float unk178;
            public float unk17C;
            public int unk180;
            public int unk184;
            public int unk188;
            public float LandingDustCloudXScaling;
            public float LandingDustCloudYScaling;
            public float JumpAndKnockdownEffectScaling;
            public float unk198;
            public int unk19C;
            public int unk1A0;
            public int unk1A4;
            public int unk1A8;
            public int unk1AC;
            public int damageSFXOnHit;
            public int blockSFXOnHit;
            public int jumpLandSFX;
            public float unk1BC;
            public float unk1C0;
            public float unk1C4;
            public float unk1C8;
            public int unk1CC;
            public float unk1D0;
            public float unk1D4;
            public float unk1D8;
            public float unk1DC;
            public float unk1E0;
            public float unk1E4;
            public float unk1E8;
            public float unk1EC;
            public int unk1F0;
            public float unk1F4;
            public float unk1F8;
            public float unk1FC;
            public float unk200;
            public float unk204;
            public float unk208;
            public int unk20C;
            public int unk210;
            public float unk214;
            public float unk218;
            public float unk21C;
            public float unk220;
            public float unk224;
            public float unk228;
            public float unk22C;
            public float unk230;
            public float unk234;
            public float unk238;
            public float unk23C;
            public float unk240;
            public float unk244;
            public float unk248;
            public float unk24C;
            public int FaceGroup1;
            public int FaceGroup2;
            public int FaceGroup3;
            public int FaceGroup4;
            public int FaceGroup5;
            public int FaceGroup6;
            public int FaceGroup7;
            public int FaceGroup8;
            public int FaceGroup9;
            public float unk274;
            public float unk278;
            public float unk27C;
            public float unk280;
            public float unk284;
            public float unk288;
            public float unk28C;
            public float unk290;
            public float unk294;
            public int unk298;
            public float unk29C;
            public float unk2A0;
            public float unk2A4;
            public float unk2A8;
            public float unk2AC;
            public float unk2B0;
            public float unk2B4;
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
            public float unk324;
            public float unk328;
            public float unk32C;
            public float unk330;
            public float unk334;
            public float unk338;
            public float unk33C;
            public float unk340;
            public int unk344;
            public int unk348;
            public int unk34C;
            public int unk350;
        }
        [Flags]
        public enum TrapTransition : uint
        {
            None = 0,
            Unk0x01 = 0x00000001,
            TimeUp = 0x00000002,
            WhenDestroyed = 0x00000004,
            Unk0x08 = 0x00000008,
            HitBlockorDestroyed = 0x00000010,
            GroundImpact = 0x00000020,
            Unk0x40 = 0x00000040,
            Unk0x80 = 0x00000080,
            Unk0x0100 = 0x00000100,
            WhenOwnerHit = 0x00000200,
            Unk0x0400 = 0x00000400,
            Unk0x0800 = 0x00000800,
            Unk0x1000 = 0x00001000,
            Unk0x2000 = 0x00002000,
            Unk0x4000 = 0x00004000,
            Unk0x8000 = 0x00008000,
            Unk0x10000 = 0x00010000,
            Unk0x20000 = 0x00020000,
            Unk0x40000 = 0x00040000,
            Unk0x80000 = 0x00080000,
            Unk0x100000 = 0x00100000,
            Unk0x200000 = 0x00200000,
            Unk0x400000 = 0x00400000,
            Unk0x800000 = 0x00800000,
            Unkx01000000 = 0x01000000,
            Unk0x02000000 = 0x02000000,
            Unk0x04000000 = 0x04000000,
            Unk0x08000000 = 0x08000000,
            Unk0x10000000 = 0x10000000,
            Unk0x20000000 = 0x20000000,
            Unk0x40000000 = 0x40000000,
            Unk0x80000000 = 0x80000000
        }

        [Flags]
        public enum StatusFlags : uint
        {
            Male = 0x00000001,
            Female = 0x00000002,
            AmmyUnk = 0x00000004,
            NoLandJumpEffects = 0x00000008,
            NoHurtbox = 0x00000010,
            AirBlockBounce = 0x00000020,
            NoHyperDrainGain = 0x00000040,
            NoHitstop = 0x00000080,
            BonneBreathingOff = 0x00000100,
            AirUnk = 0x00000200,
            ShumaUnk = 0x00000400,
            AmmyShumaUnk = 0x00000800,
            LockCharacter = 0x00001000,
            NoSnapBackNoTAC = 0x00002000,
            Unk0x4000 = 0x00004000,
            Unk0x8000 = 0x00008000,
            FriendlyFire = 0x00010000,
            NoJump = 0x00020000,
            NoDoubleJump = 0x00040000,
            Unk0x80000 = 0x00080000,
            Unk0x100000 = 0x00100000,
            NoTagIn = 0x00200000,
            Unk0x400000 = 0x00400000,
            FrankUnk = 0x00800000
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ATKInfoChunk
        {
            public int index;
            public int startup;
            public int activeframes;
            public int unk00C;
            public int unk010;
            public int multiHit;
            public int unk018;
            public int multiHitFrequency;
            public int unk020;
            public int HitsparkFrequency;
            public int unk028;
            public int kdBounceSize;
            public float unk030;
            public float unk034;
            public float unk038;
            public AtkFlagsA atkflags;
            public AtkFlagsB atkflags2;
            public AtkFlagsC atkflags3;
            public AttackLevel AttackLevel;
            public GuardType GuardType;
            public int unk050;
            public OppHitAnim OppHitAnim;
            public OppHitAnim OppHitAnimCounter;
            public OppHitAnim OppHitAnimAir;
            public int damage;
            public float damageScaling;
            public float damageMult;
            public float ChipDamage;
            public int unk070;
            public float MeterGain;
            public float MeterGainOnHit;
            public int OppMeterGain;
            public int meterSteal;
            public int hitboxDestructionUnk;
            public int hiddenStunUnk;
            public int AddedGroundHitstun;
            public int AddedCounterhitStun;
            public int AddedBlockstun;
            public int AddedHardKDTime;
            public float GroundHitPushbackWallBounceXSpeed;
            public float GroundHitPushbackWallBounceXAccel;
            public float BlockPushbackXSpeed;
            public float BlockPushbackXAccel;
            public float SelfYForceAgainstAirOpp;
            public float SelfYAccAgainstAirOpp;
            public float SJSelfYForceAgainstAirOpp;
            public float SJSelfYAccAgainstAirOpp;
            public float GroundWallBounceYSpeed;
            public float GroundWallBounceYAccel;
            public int hitstop;
            public int unk0C8;
            public int RemoveAllHealthAndMeterTest;
            public int sjCancelDelay;
            public int juggleHeight;
            public int JuggleGravityDelay;
            public float juggleCarry;
            public float juggleSpeed;
            public int AddedAirHitstun;
            public int SJJuggleHeight;
            public int SJJuggleGravityDelay;
            public float SJJuggleCarry;
            public float SJJuggleSpeed;
            public int AddedSJAirHitstun;
            public int PlayerCmdSPAtkClassOnHit;
            public int PlayerCmdSPAtkIndexOnHit;
            public int EnemyCmdSPAtkClassOnHit;
            public int EnemyCmdSPAtkIndexOnHit;
            public int AmmyThrowModifier;
            public int AmmyAnmchrEntryOnHit;
            public int AmmyAnmtdownEntryOnHit;
            public int Hitspark1;
            public int unk11C;
            public HitEffectOnEnemy OnHitEffectOnEnemy;
            public HitEffectOnEnemy OnBlockEffectOnEnemy;
            public int tacCounterUnk;
            public int unk12C;
            public int unk130;
            public int HitSpark2;
            public int unk138;
            public int unk13C;
            public int unk140;
            public int unk144;
            public int unk148;
            public int unk14C;
            public HitSFXGroup hitSFXGroup;
            public HitSFXSubGroup hitSFXSubGroup;
            public HitSFXEntry hitSFXEntry;
            public PlayWhiffSFXOnNormals playWhiffSFXOnNormals;
            public int launcherUnk;
            public float unk164;
            public float unk168;
            public float unk16C;
            public int unk170;
            public int unk174;
            public int IDReference2;
            public int FramesToIDReference2;
            public int unk180;
            public int HitsToIDReference2;
            public int unk188;
        }

        [Flags]
        public enum AtkFlagsA : uint
        {
            None = 0,
            Unk0x01 = 0x00000001,
            LauncherSpecialHyperCancel = 0x00000002,
            JumpCancel = 0x00000004,
            CantHitGround = 0x00000008,
            CantHitCrouch = 0x00000010,
            Unk0x20 = 0x00000020,
            CantHitAir = 0x00000040,
            NoPushbackUnkA = 0x00000080,
            NoPushbackUnkB = 0x00000100,
            KeepMomentumX = 0x00000200,
            KeepMomentumY = 0x00000400,
            FixedHitstunDuration = 0x00000800,
            NoGroundBounceLimit = 0x00001000,
            JuggledInvinc = 0x00002000,
            Unk0x4000 = 0x00004000,
            Unk0x8000 = 0x00008000,
            Unk0x10000 = 0x00010000,
            PreventPushback = 0x00020000,
            Unk0x40000 = 0x00040000,
            FlyingScreen = 0x00080000,
            CanWallBounce = 0x00100000,
            OTG = 0x00200000,
            ForceAirReset = 0x00400000,
            SoftKD = 0x00800000,
            HardKD = 0x01000000,
            Unk0x02000000 = 0x02000000,
            ForceWallBounce = 0x04000000,
            NegatePushBlock = 0x08000000,
            OTGOnly = 0x10000000,
            NegatePushBlockAirUnk = 0x20000000,
            Unk0x40000000 = 0x20000000,
            Unk0x80000000 = 0x80000000
        }

        [Flags]
        public enum AtkFlagsB : uint
        {
            None = 0,
            SpecialScaling = 0x00000001,
            HyperScaling = 0x00000002,
            ProjectileHitboxJuggleAway = 0x00000004,
            NeverCounterhit = 0x00000008,
            EnableTransition = 0x00000010,
            Unk0x20 = 0x00000020,
            ChipDamage = 0x00000040,
            Unblockable = 0x00000080,
            Unk0x100 = 0x00000100,
            NoHitboxUnk = 0x00000200,
            NoHyperMeterBuild = 0x00000400,
            NoComboCounter = 0x00000800,
            Unk0x1000 = 0x00001000,
            ProjectileReflection = 0x00002000,
            NoPushbackAttacker = 0x00004000,
            PartnerTargeting = 0x00008000,
            Unk0x10000 = 0x00010000,
            Unk0x20000 = 0x00020000,
            Unk0x40000 = 0x00040000,
            TACGlow = 0x00080000,
            Mashable = 0x00100000,
            Unk0x200000 = 0x00200000,
            Unk0x400000 = 0x00400000,
            Unk0x800000 = 0x00800000,
            Unk0x1000000 = 0x01000000,
            Unk0x2000000 = 0x02000000,
            Unk0x4000000 = 0x04000000,
            Unk0x8000000 = 0x08000000,
            Unk0x10000000 = 0x10000000,
            Unk0x20000000 = 0x20000000,
            Unk0x40000000 = 0x20000000,
            Unk0x80000000 = 0x80000000
    }
        [Flags]
        public enum AtkFlagsC : uint
        {
            None = 0,
            Unk0x01 = 0x00000001,
            TechGrabs = 0x00000002,
            HitsAssist = 0x00000004,
            Unk0x08 = 0x00000008,
            Unk0x10 = 0x00000010,
            ThrowGroundedOpp = 0x00000020,
            ThrowAirborneOpp = 0x00000040,
            DisableRecapture = 0x00000080,
            Unk0x100 = 0x00000100,
            Unk0x200 = 0x00000200,
            Unk0x400 = 0x00000400,
            CounterProjectile = 0x00000800,
            CounterAllPhysical = 0x00001000,
            CounterLows = 0x00002000,
            CounterHighMid = 0x00004000,
            CounterHighMidLow = 0x00008000,
            Unk0x10000 = 0x00010000,
            Unk0x20000 = 0x00020000,
            Unk0x40000 = 0x00040000,
            PlayerCmdSPAtkXOnHitOn = 0x00080000,
            Unk0x100000 = 0x00100000,
            Unk0x200000 = 0x00200000,
            Unk0x400000 = 0x00400000,
            FirstHitDmgs = 0x00800000,
            Unk0x1000000 = 0x01000000,
            TechTAC1 = 0x02000000,
            HitComboGrab = 0x04000000,
            Unk0x8000000 = 0x08000000,
            TechTAC2 = 0x10000000,
            Unk0x20000000 = 0x20000000,
            Unk0x40000000 = 0x20000000,
            Unk0x80000000 = 0x80000000
    }

        public enum HitEffectOnEnemy : int
        {
            YellowLSparks = 0,
            YellowMSparks = 1,
            YellowHSparks = 2,
            BladeSlash01 = 3,
            BladeSlash02 = 4,
            GuardBlue01 = 5,
            GuardRed01 = 6,
            PurpleRings = 7,
            RedImpactSpreadingSpark = 9,
            RisingGroundSpark = 10,
            YellowFire = 11,
            YellowElectricity = 12,
            IceAndScreenShake = 13,
            HiddienMissileExplosion = 14,
            GroundImpactFlyingShards = 15,
            GuardBlue02 = 17,
            GuardRed03 = 18,
            TripleSlash01 = 19,
            DoubleSlash01 = 20,
            RisingYellowCircle = 21,
            ScreenShake00 = 22,
            ScreenShake01 = 23,
            ScreenShake02 = 24,
            ScreenShake03 = 25,
            ScreenShake04 = 26,
            BlueFire = 27,
            PurpleFire = 28,
            BlueElectricity = 30,
            PurpleElectricity = 31,
            ElectricSound = 32,
            IceSound = 33,
            IceSoundCrunch = 34,
            Magnetic = 35,
            //Don't use - Game Crashes = 37     ,
            FullScreenFlair01 = 38,
            FullScreenFlair02 = 39,
            FallingBlueLightBeams = 40,
            AlphaCounter01 = 41,
            ComicBookScreenTear = 43,
            YellowJaggedOverlay = 44,
            GunShot = 46,
            ComicBookScreenRedBurn = 47,
            ComicBookScreenBlueBurn = 48,
            ComicBookScreenPurpleBurn = 49,
            GreyScreenShake01 = 50,
            GreyScreenShake02 = 51,
            GreyScreenShake03 = 52,
            GroundImpactSplash = 54,
            TripleSlash02 = 55,
            DoubleSlash03 = 56,
            AlphaCounter02 = 57,
            TACUp = 59,
            TACHorizontal = 60,
            TACDown = 61,
            AlphaCounter03 = 64,
            FilmStrip = 1005,
        }

        public enum GuardType : int
        {
            mid = 0,
            high = 1,
            low = 2
        }

        public enum AttackLevel : int
        {
            light = 0,
            medium = 1,
            heavy = 2,
            noPushBlock
        }

        [Flags]
        public enum InputCode : uint
        {
            None = 0,
            Forward = 0x00000001,
            Back = 0x00000002,
            Up = 0x00000004,
            Down = 0x00000008,
            L = 0x00000010,
            M = 0x00000020,
            H = 0x00000040,
            S = 0x00000080,
            A1 = 0x00000100,
            A2 = 0x00000200,
            Unk0x400 = 0x00000400,
            Unk0x800 = 0x00000800,
            Unk0x1000 = 0x00001000,
            Unk0x2000 = 0x00002000,
            Unk0x4000 = 0x00004000,
            Unk0x8000 = 0x00008000,
            Unk0x10000 = 0x00010000,
            Unk0x20000 = 0x00020000,
            Unk0x40000 = 0x00040000,
            Unk0x80000 = 0x00080000,
            Taunt = 0x00100000,
            Unk0x200000 = 0x00200000,
            Unk0x400000 = 0x00400000,
            Unk0x800000 = 0x00800000,
            Unk0x1000000 = 0x01000000,
            Unk0x2000000 = 0x000200000,
            Unk0x4000000 = 0x000400000,
            Unk0x8000000 = 0x000800000
        }

        [Flags]
        public enum OppHitAnim : int
        {
            normal1 = 0,
            normal2 = 1,
            noHitstunUnk = 02,
            stagger = 3,
            fallBack1 = 4,
            crumple = 5,
            wallBounce = 6,
            fallFaceFirst = 7,
            groundBounce = 8,
            airJuggle = 9,
            spinningJuggle = 10,
            launch = 11,
            FlyingScreenHK1 = 12,
            flyingScreenHK2 = 13,
            forceGuard = 14,
            fallBack3 = 15
        }

        [Flags]
        public enum HitSFXGroup : int 
        {
                
        }

        [Flags]
        public enum HitSFXSubGroup : int 
        { 
            generic = 0,
            handSwing = 1,
            footSwing = 2,
            swordSwing = 3,
            gunShotUnk = 15
        }

        [Flags]
        public enum HitSFXEntry : int 
        {
            l = 0,
            m = 1,
            h = 2,
        }

        [Flags]
        public enum PlayWhiffSFXOnNormals : int
        {
            no = 1551001600,
            yes = 1551001601,
        }

        [Flags]
        public enum cmdFlags : uint
        {
            None = 0,
            Unk0x01 = 0x00000001,
            Unk0x02 = 0x00000002,
            Unk0x04 = 0x00000004,
            Unk0x08 = 0x00000008,
            Unk0x10 = 0x00000010,
            Unk0x20 = 0x00000020,
            Unk0x40 = 0x00000040,
            Unk0x80 = 0x00000080,
            Unk0x0100 = 0x00000100,
            Unk0x0200 = 0x00000200,
            Unk0x0400 = 0x00000400,
            Unk0x0800 = 0x00000800,
            Unk0x1000 = 0x00001000,
            Unk0x2000 = 0x00002000,
            Unk0x4000 = 0x00004000,
            Unk0x8000 = 0x00008000,
            Unk0x10000 = 0x00010000,
            Unk0x20000 = 0x00020000,
            Unk0x40000 = 0x00040000,
            Unk0x80000 = 0x00080000,
            Unk0x100000 = 0x00100000,
            Unk0x200000 = 0x00200000,
            Unk0x400000 = 0x00400000,
            Unk0x800000 = 0x00800000,
            Unk0x01000000 = 0x01000000,
            Unk0x02000000 = 0x02000000,
            Unk0x04000000 = 0x04000000,
            Unk0x08000000 = 0x08000000,
            Unk0x10000000 = 0x10000000,
            Unk0x20000000 = 0x20000000,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BaseActChunk
        {
            public int index;
            public int anmchrAction;
            public InputCode inputCodeDirectionLeniency;
            public InputCode inputCodeDirection;
            public InputCode inputCodeButton;
            public BaseActState state;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CmdComboHeaderChunk
        {
            public int index;
            public int size;
            public int unk08;
            public float meterRequirement;
            public CmdDisabled disabled;
            public int windowStart;
            public int windowEnd;
            public int delay;
            public int anmChrAction;
            public int anmChrAction2;
            public int anmChrAction3;
            public int anmChrAction4;
            public int anmChrAction5;
            public int anmChrAction6;
            public int anmChrAction7;
            public int anmChrAction8;
            public int unk40;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkHeaderChunk
        {
            public int index;
            public int size;
            public int unk08;
            public float meterRequirement;
            public SpatkDisabled disable;
            public int cancelHierarchyThresh;
            public PositionState positionState;
            public ComboState comboState;
            public cmdFlags flags;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct CollisionHeaderChunk
        {
            public int index;
            public int size;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CollisionStandardChunk // hitbox / hurtbox ??
        {
            public int objectReferenceId; //ffff = default/char body, 01/02 etc are props
            public int unk04;
            public BoneReferenceId boneReferenceId;
            public float zAxis;
            public float yAxis;
            public float xAxis;
            public float HitHurtBoxRadius;
            public CLIProperties specialProperties;
        }
        public struct ProfileSelfChunk
        {
        public CPIChar SelfID;
        //public byte SelfID;
        public byte unk04;
        public byte unk08;
        public byte unk0C;
        //public ProfileFlagsA IdentityFlags;
        //public ProfileFlagsB IdentityFlags2;
        public ProfileFlags IdentityFlags;
        //public byte unk18;
        //public byte unk1C;
        }
        public struct ProfileChunk //profile WIP here
        {
        public byte introID;
        public byte introProbability;
        public byte soundID;
        public byte unk0C;
        public CPIChar CharacterA;
        public CPIChar CharacterB;
        public CPIChar CharacterC;
        public CPIChar CharacterD;
        }
    public enum CPIChar : byte
    {
        Generic = 00,
        Ryu = 01,
        ChunLi = 02,
        Akuma = 03,
        Chris = 04,
        Wesker = 05,
        ViewtifulJoe = 06,
        Dante = 07,
        Trish = 08,
        FrankWest = 09,
        Spencer = 10,
        Arthur = 11,
        Amaterasu = 12,
        Zero = 13,
        Tron = 14,
        Morrigan = 15,
        HsienKo = 16,
        Felicia = 17,
        CViper = 18,
        Haggar = 19,
        Jill = 20,
        Strider = 21,
        Vergil = 22,
        PhoenixWright = 23,
        Firebrand = 24,
        Nemesis = 25,
        SpiderMan = 26,
        CapAmerica = 27,
        Wolverine = 28,
        Magneto = 29,
        Hulk = 30,
        SheHulk = 31,
        Taskmaster = 32,
        IronMan = 33,
        Thor = 34,
        DrDoom = 35,
        Phoenix = 36,
        Shuma = 37,
        Modok = 38,
        Dormammu = 39,
        Deadpool = 40,
        Storm = 41,
        Skrull = 42,
        Sentinel = 43,
        X23 = 44,
        Nova = 45,
        Rocket = 46,
        GhostRider = 47,
        IronFist = 48,
        DrStrange = 49,
        Hawkeye = 50,
        Galactus = 51,
        flag52 = 52,
        flag53 = 53,
        flag54 = 54,
        flag55 = 55,
        flag56 = 56,
        flag57 = 57,
        flag58 = 58,
        flag59 = 59,
        flag60 = 60,
        flag61 = 61,
        flag62 = 62,
        flag63 = 63,
        flag64 = 64,
        flag65 = 65,
        flag66 = 66,
        flag67 = 67,
        flag68 = 68,
        flag69 = 69,
        Male = 70,
        Female = 71,
        Good = 72,
        Evil = 73,
        flag74 = 74,
        flag75 = 75,
        Hero = 76,
        Villain = 77,
        flag78 = 78,
        flag79 = 79,
        flag80 = 80,
        Mutant = 81,
        StreetFighter = 82,
        DarkStalkers = 83,
        XMen = 84,
        Avenger = 85,
        flag86 = 86,
        flag87 = 87,
        flag88 = 88,
        flag89 = 89,
        flag90 = 90,
        flag91 = 91,
        flag92 = 92,
        flag93 = 93,
        flag94 = 94,
        flag95 = 95,
        flag96 = 96,
        flag97 = 97,
        flag98 = 98,
        flag99 = 99,
        flag100 = 100,
        flag101 = 101,
        flag102 = 102,
        flag103 = 103,
        flag104 = 104,
        flag105 = 105,
        flag106 = 106,
        flag107 = 107,
        flag108 = 108,
        flag109 = 109,
        flag110 = 110,
        flag111 = 111,
        flag112 = 112,
        flag113 = 113,
        XmenLeader = 114,
        AvengersLeader = 115,
        flag116 = 116,
        flag117 = 117,
        flag118 = 118,
        flag119 = 119,
        flag120 = 120,
        flag121 = 121,
        flag122 = 122,
        flag123 = 123,
        flag124 = 124,
        flag125 = 125,
        flag126 = 126,
        flag127 = 127,
        flag128 = 128,
        flag129 = 129,
        flag130 = 130,
        flag131 = 131,
        flag132 = 132,
        flag133 = 133,
        flag134 = 134,
        flag135 = 135,
        flag136 = 136,
        flag137 = 137,
        flag138 = 138,
        flag139 = 139,
        flag140 = 140,
        flag141 = 141,
        flag142 = 142,
        flag143 = 143,
        flag144 = 144,
        flag145 = 145,
        flag146 = 146,
        flag147 = 147,
        flag148 = 148,
        flag149 = 149,
        flag150 = 150,
        flag151 = 151,
        flag152 = 152,
        flag153 = 153,
        flag154 = 154,
        flag155 = 155,
        flag156 = 156,
        flag157 = 157,
        flag158 = 158,
        flag159 = 159,
        flag160 = 160,
        flag161 = 161,
        flag162 = 162,
        flag163 = 163,
        flag164 = 164,
        flag165 = 165,
        flag166 = 166,
        flag167 = 167,
        flag168 = 168,
        flag169 = 169,
        flag170 = 170,
        flag171 = 171,
        flag172 = 172,
        flag173 = 173,
        flag174 = 174,
        flag175 = 175,
        flag176 = 176,
        flag177 = 177,
        flag178 = 178,
        flag179 = 179,
        flag180 = 180,
        flag181 = 181,
        flag182 = 182,
        flag183 = 183,
        flag184 = 184,
        flag185 = 185,
        flag186 = 186,
        flag187 = 187,
        flag188 = 188,
        flag189 = 189,
        flag190 = 190,
        flag191 = 191,
        flag192 = 192,
        flag193 = 193,
        flag194 = 194,
        flag195 = 195,
        flag196 = 196,
        flag197 = 197,
        flag198 = 198,
        flag199 = 199,
        flag200 = 200,
        flag201 = 201,
        flag202 = 202,
        flag203 = 203,
        flag204 = 204,
        flag205 = 205,
        flag206 = 206,
        flag207 = 207,
        flag208 = 208,
        flag209 = 209,
        flag210 = 210,
        flag211 = 211,
        flag212 = 212,
        flag213 = 213,
        SelfColor1 = 214,
        SelfColor2 = 215,
        SelfColor3 = 216,
        SelfColor4 = 217,
        SelfColor5 = 218,
        SelfColor6 = 219,
        SelfColorH = 190,
        SelfColorAlt = 191,
        flag222 = 192,
        flag223 = 193,
        flag224 = 194,
        flag225 = 195,
        flag226 = 196,
        flag227 = 197,
        flag228 = 198,
        flag229 = 199,
        flag230 = 230,
        flag231 = 231,
        flag232 = 232,
        flag233 = 233,
        flag234 = 234,
        flag235 = 235,
        flag236 = 236,
        flag237 = 237,
        flag238 = 238,
        flag239 = 239,
        flag240 = 240,
        flag241 = 241,
        flag242 = 242,
        flag243 = 243,
        flag244 = 244,
        flag245 = 245,
        flag246 = 246,
        flag247 = 247,
        flag248 = 248,
        flag249 = 249,
        flag250 = 250,
        flag251 = 251,
        flag252 = 252,
        flag253 = 253,
        flag254 = 254,
        flag255 = 255
    }

    [Flags]
    public enum ProfileFlags : uint
    {
        None = 0x00,
        Male = 0x01,
        Female = 0x02,
        Good = 0x04,
        Evil = 0x08,
        CapcomGoodUnk = 0x10,
        CapcomEvilUnk = 0x20,
        MarvelGoodUnk = 0x40,
        MarvelEvilUnk = 0x80,
        NonMutant = 0x0100,
        NonHumanUnk = 0x0200,
        RobotUnk = 0x0400,
        Mutant = 0x0800,
        StreetFighter = 0x1000,
        DarkStalkers = 0x2000,
        XMen = 0x4000,
        Avenger = 0x8000,
    }
    [Flags]
    public enum ProfileFlagsA : byte
    {
        None = 0x00,
        Male = 0x01,
        Female = 0x02,
        Good = 0x04,
        Evil = 0x08,
        CapcomGoodUnk = 0x10,
        CapcomEvilUnk = 0x20,
        MarvelGoodUnk = 0x40,
        MarvelEvilUnk = 0x80
    }
    [Flags]
    public enum ProfileFlagsB : byte
    {
        None = 0x00,
        NonMutant = 0x01,
        NonHumanUnk = 0x02,
        RobotUnk = 0x04,
        Mutant = 0x08,
        StreetFighter = 0x10,
        DarkStalkers = 0x20,
        XMen = 0x40,
        Avenger = 0x80,
    }
    public enum BoneReferenceId : uint
    {
        Detached = 4294967295,
        Origin1 = 01,
        Origin2 = 02,
        Spine3 = 03,
        Spine2 = 04,
        Chest = 05,
        Neck = 06,
        Head = 07,
        LeftShoulderBlade = 08,
        LeftShoulder = 09,
        LeftElbow = 10,
        LeftWrist = 11,
        RightShoulderBlade = 12,
        RightShoulder = 13,
        RightElbow = 14,
        RightWrist = 15,
        LeftLeg = 16,
        LeftKnee = 17,
        LeftFoot = 18,
        LeftToe = 19,
        RightLeg = 20,
        RightKnee = 21,
        RightFoot = 22,
        RightToe = 23,
        Bone24 = 24,
        Bone25 = 25,
        Bone26 = 26,
        Bone27 = 27,
        Bone28 = 28,
        Bone29 = 29,
        Bone30 = 30,
        Bone31 = 31,
        Bone32 = 32,
        Bone33 = 33,
        Bone34 = 34,
        Bone35 = 35,
        Bone36 = 36,
        Bone37 = 37,
        Bone38 = 38,
        Bone39 = 39,
        Bone40 = 40,
        Bone41 = 41,
        Bone42 = 42,
        Bone43 = 43,
        Bone44 = 44,
        Bone45 = 45,
        Bone46 = 46,
        Bone47 = 47,
        Bone48 = 48,
        Bone49 = 49,
        Bone50 = 50,
        Bone51 = 51,
        Bone52 = 52,
        Bone53 = 53,
        Bone54 = 54,
        Bone55 = 55,
        Bone56 = 56,
        Bone57 = 57,
        Bone58 = 58,
        Bone59 = 59,
        Bone60 = 60,
        Bone61 = 61,
        Bone62 = 62,
        Bone63 = 63,
        Bone64 = 64,
        Bone65 = 65,
        Bone66 = 66,
        Bone67 = 67,
        Bone68 = 68,
        Bone69 = 69,
        Bone70 = 70,
        Bone71 = 71,
        Bone72 = 72,
        Bone73 = 73,
        Bone74 = 74,
        Bone75 = 75,
        Bone76 = 76,
        Bone77 = 77,
        Bone78 = 78,
        Bone79 = 79,
        Bone80 = 80,
        Bone81 = 81,
        Bone82 = 82,
        Bone83 = 83,
        Bone84 = 84,
        Bone85 = 85,
        Bone86 = 86,
        Bone87 = 87,
        Bone88 = 88,
        Bone89 = 89,
        Bone90 = 90,
        Bone91 = 91,
        Bone92 = 92,
        Bone93 = 93,
        Bone94 = 94,
        Bone95 = 95,
        Bone96 = 96,
        Bone97 = 97,
        Bone98 = 98,
        Bone99 = 99,
        Bone100 = 100,
        Bone101 = 101,
        Bone102 = 102,
        Bone103 = 103,
        Bone104 = 104,
        Bone105 = 105,
        Bone106 = 106,
        Bone107 = 107,
        Bone108 = 108,
        Bone109 = 109,
        Bone110 = 110,
        Bone111 = 111,
        Bone112 = 112,
        Bone113 = 113,
        Bone114 = 114,
        Bone115 = 115,
        Bone116 = 116,
        Bone117 = 117,
        Bone118 = 118,
        Bone119 = 119,
        Bone120 = 120,
        Bone121 = 121,
        Bone122 = 122,
        Bone123 = 123,
        Bone124 = 124,
        Bone125 = 125,
        Bone126 = 126,
        Bone127 = 127,
        Bone128 = 128,
        Bone129 = 129,
        Bone130 = 130,
        Bone131 = 131,
        Bone132 = 132,
        Bone133 = 133,
        Bone134 = 134,
        Bone135 = 135,
        Bone136 = 136,
        Bone137 = 137,
        Bone138 = 138,
        Bone139 = 139,
        Bone140 = 140,
        Bone141 = 141,
        Bone142 = 142,
        Bone143 = 143,
        Bone144 = 144,
        Bone145 = 145,
        Bone146 = 146,
        Bone147 = 147,
        Bone148 = 148,
        Bone149 = 149,
        Bone150 = 150,
        Bone151 = 151,
        Bone152 = 152,
        Bone153 = 153,
        Bone154 = 154,
        Bone155 = 155,
        Bone156 = 156,
        Bone157 = 157,
        Bone158 = 158,
        Bone159 = 159,
        Bone160 = 160,
        Bone161 = 161,
        Bone162 = 162,
        Bone163 = 163,
        Bone164 = 164,
        Bone165 = 165,
        Bone166 = 166,
        Bone167 = 167,
        Bone168 = 168,
        Bone169 = 169,
        Bone170 = 170,
        Bone171 = 171,
        Bone172 = 172,
        Bone173 = 173,
        Bone174 = 174,
        Bone175 = 175,
        Bone176 = 176,
        Bone177 = 177,
        Bone178 = 178,
        Bone179 = 179,
        Bone180 = 180,
        Bone181 = 181,
        Bone182 = 182,
        Bone183 = 183,
        Bone184 = 184,
        Bone185 = 185,
        Bone186 = 186,
        Bone187 = 187,
        Bone188 = 188,
        Bone189 = 189,
        UsuallyWeapon = 190,
        UsuallyOffHand = 191,
        Bone192 = 192,
        Bone193 = 193,
        Bone194 = 194,
        Bone195 = 195,
        Bone196 = 196,
        Bone197 = 197,
        Bone198 = 198,
        Bone199 = 199,
        Bone200 = 200,
        Bone201 = 201,
        Bone202 = 202,
        Bone203 = 203,
        Bone204 = 204,
        Bone205 = 205,
        Bone206 = 206,
        Bone207 = 207,
        Bone208 = 208,
        Bone209 = 209,
        Bone210 = 210,
        Bone211 = 211,
        Bone212 = 212,
        Bone213 = 213,
        Bone214 = 214,
        Bone215 = 215,
        Bone216 = 216,
        Bone217 = 217,
        Bone218 = 218,
        Bone219 = 219,
        Bone220 = 190,
        Bone221 = 191,
        Bone222 = 192,
        Bone223 = 193,
        Bone224 = 194,
        Bone225 = 195,
        Bone226 = 196,
        Bone227 = 197,
        Bone228 = 198,
        Bone229 = 199,
        Bone230 = 230,
        Bone231 = 231,
        Bone232 = 232,
        Bone233 = 233,
        Bone234 = 234,
        Bone235 = 235,
        Bone236 = 236,
        Bone237 = 237,
        Bone238 = 238,
        Bone239 = 239,
        Bone240 = 240,
        Bone241 = 241,
        Bone242 = 242,
        Bone243 = 243,
        Bone244 = 244,
        Bone245 = 245,
        Bone246 = 246,
        Bone247 = 247,
        Bone248 = 248,
        Bone249 = 249,
        Bone250 = 250,
        Bone251 = 251,
        Bone252 = 252,
        Bone253 = 253,
        Bone254 = 254,
        Origin = 255
    }

    [Flags]
    public enum CLIProperties : uint
    {
        None = 0,
        Unk0x01 = 0x00000001,
        Unk0x02 = 0x00000002,
        Unk0x04 = 0x00000004,
        Unk0x08 = 0x00000008,
        Unk0x10 = 0x00000010,
        Unk0x20 = 0x00000020,
        Unk0x40 = 0x00000040,
        Unk0x80 = 0x00000080,
        Unk0x0100 = 0x00000100,
        Unk0x0200 = 0x00000200,
        Unk0x0400 = 0x00000400,
        Unk0x0 = 0x00000800,
        Unk0x1000 = 0x00001000,
        Unk0x2000 = 0x00002000,
        Unk0x4000 = 0x00004000,
        Unk0x8000 = 0x00008000,
        Unk0x10000 = 0x00010000,
        Unk0x20000 = 0x00020000,
        Unk0x40000 = 0x00040000,
        Unk0x80000 = 0x00080000,
        Unk0x100000 = 0x00100000,
        Unk0x200000 = 0x00200000,
        Unk0x400000 = 0x00400000,
        Unk0x800000 = 0x00800000,
        Unkx01000000 = 0x01000000,
        Unk0x02000000 = 0x02000000,
        Unk0x04000000 = 0x04000000,
        Unk0x08000000 = 0x08000000,
        Unk0x10000000 = 0x10000000,
        Unk0x20000000 = 0x20000000,
        Unk0x40000000 = 0x40000000,
        Unk0x80000000 = 0x80000000
    }

        public enum SpecialProperties
        {
            normal = 1769234688,
            disabled = 1769234689
        }

        public enum CmdDisabled
        {
            enabled = 1769234688,
            disabled = 1769234689
        }

        public enum SpatkDisabled
        {
            enabled = 0,
            disabled = 1
        }

        public enum PositionState : int
        {
            Ground = 0,
            Air = 1,
            Either = 2
        }

        public enum ComboState : int
        {
            NeutralAndCombos = 0,
            NeutralOnly = 1,
            ComboOnly = 2,
            Unk3 = 3,
            GuardCancel = 4,
            GuardAndDamageCancel = 5
        }

        public enum BaseActState : int
        {
            Ground = 00,
            Air = 32
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkStandardChunk // 02
        {
            public SubChunkType subChunkType; // 02
            public int cancelWindow;
            public int chargeTime;
            public int holdButtonUnk;
            public int negativeEdge;
            public InputCode inputCodeLeniencyUnk;
            public InputCode inputCode;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkDirectionalDashChunk // 03
        {
            public SubChunkType subChunkType; // 03
            public int cancelWindow;
            public int unk08;
            public int unk0C;
            public int negativeEdge;
            public InputCode inputCodeLeniencyUnk;
            public InputCode inputCode;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkTwoButtonChunk // 04
        {
            public SubChunkType subChunkType; // 04
            public int cancelWindow;
            public int unk08;
            public int atkS;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkDirButtonChunk // 05
        {
            public SubChunkType subChunkType; // 05
            public int cancelWindow;
            public InputCode inputCodeLeniencyUnk;
            public InputCode inputCodeDirection;
            public InputCode inputCodeButton;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkTwoButtonAirdashChunk // 07
        {
            public SubChunkType subChunkType; // 07
            public int cancelWindow;
            public int chargeTimeUnk;
            public InputCode inputCodeLeniency;
            public InputCode inputCodeDirection;
            public int AtkSInput;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkActionChunk // 09
        {
            public SubChunkType subChunkType; // 09
            public int actionClass;
            public int actionIndex;
            public int actionStorageBuffer;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        public struct SpatkRequiredStateUnk // 17
        {
            public SubChunkType subChunkType; // 17
            public int stateID;
            public int unk08;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkChrisStateChunk // 18
        {
            public SubChunkType subChunkType; //18
            public int stateID;
            public int unk08;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkModeRequiredChunk // 1E
        {
            public SubChunkType subChunkType; // 1E
            public int modeNumber;
            public int unk08;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkTACDHCChunk // 23
        {
            public SubChunkType subChunkType; //23
            public int anmChrAction;
            public int unk08;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkSuperJumpAction // 25
        {
            public SubChunkType subChunkType; //25
            public int NeutralSJAnmchrAction;
            public int ForwardSJAnmchrAction;
            public int BackwardsSJAnmchrAction;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkSnapBack // 26
        {
            public EnumUnk flags; // 26
            public int unk08;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkRestrictedStateChunk // 2F
        {
            public SubChunkType subChunkType; //2F
            public int stateID;
            public int unk08;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkProhibitedChunk // 31
        {
            public SubChunkType subChunkType; //31
            public int prohibitedCategory;
            public int prohibitedID;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkAirdashChunk // 34
        {
            public SubChunkType subChunkType; //34
            public int unk04;
            public int unk08;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkAirSpecialLimiterChunk // 35
        {
            public SubChunkType subChunkType; //35
            public int limit;
            public int unk08;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkGuardTACChunk // 38
        {
            public SubChunkType subChunkType; //38
            public int unk04;
            public int unk08;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkHyperChunk // 3A
        {
            public SubChunkType subChunkType; //3A
            public int unk04;
            public int unk08;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkAllowedChainChunk // 3F
        {
            public SubChunkType subChunkType; //3F
            public int validityFlags;
            public int unk08;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkAdvGuardUnk // 49
        {
            public SubChunkType subChunkType; //49
            public int validityFlags;
            public int unk08;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkHaggarFlagsUnk // 55
        {
            public SubChunkType subChunkType; //55
            public EnumUnk flags;
            public int unk08;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkWhiffCancelUnk // 5A
        {
            public SubChunkType subChunkType; //5A
            public EnumUnk flags;
            public int unk08;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkHasPropActive // 5B
        {
            public SubChunkType subChunkType; //5B
            public EnumUnk flags;
            public int unk08;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SpatkUnkChunk // ??
        {
            public SubChunkType subChunkType; //??
            public int unk04;
            public int unk08;
            public int unk0C;
            public int unk10;
            public int unk14;
            public int unk18;
            public int unk1C;
        }
        public enum EnumUnk : uint
        {
            None = 0,
            Unk0x01 = 0x00000001,
            Unk0x02 = 0x00000002,
            Unk0x04 = 0x00000004,
            Unk0x08 = 0x00000008,
            Unk0x10 = 0x00000010,
            Unk0x20 = 0x00000020,
            Unk0x40 = 0x00000040,
            Unk0x80 = 0x00000080,
            Unk0x0100 = 0x00000100,
            Unk0x0200 = 0x00000200,
            Unk0x0400 = 0x00000400,
            Unk0x0800 = 0x00000800,
            Unk0x1000 = 0x00001000,
            Unk0x2000 = 0x00002000,
            Unk0x4000 = 0x00004000,
            Unk0x8000 = 0x00008000,
            Unk0x10000 = 0x00010000,
            Unk0x20000 = 0x00020000,
            Unk0x40000 = 0x00040000,
            Unk0x80000 = 0x00080000,
            Unk0x100000 = 0x00100000,
            Unk0x200000 = 0x00200000,
            Unk0x400000 = 0x00400000,
            Unk0x800000 = 0x00800000,
            Unkx01000000 = 0x01000000,
            Unk0x02000000 = 0x02000000,
            Unk0x04000000 = 0x04000000,
            Unk0x08000000 = 0x08000000,
            Unk0x10000000 = 0x10000000,
            Unk0x20000000 = 0x20000000,
            Unk0x40000000 = 0x40000000,
            Unk0x80000000 = 0x80000000
        }
        public enum SubChunkType : uint
        {
            [Description("0 None")]
            none_0 = 0,
            [Description("1 unk1")]
            unk1_1 = 01,
            [Description("2 Standard Input")]
            standardInput_2 = 02,
            [Description("3 Dash Direction Input")]
            dashDirectionInput_3 = 03,
            [Description("4 Two Button Input")]
            twoButtonInput1_4 = 04,
            [Description("5 Direction and Button Input")]
            directionAndButtonInput = 05,
            [Description("6 unk6")]
            unk6_6 = 06,
            [Description("7 Two Button Input")]
            twoButtonInput2_7 = 07,
            [Description("9 Execute Action")]
            executeAction_9 = 09,
            [Description("10 Capture State")]
            captureState_10 = 10, //0A
            [Description("11 State Restriction")]
            stateRestriction_11 = 11, //0B
            [Description("13 Simple Mode Air Combo Unk")]
            simpleModeAirComboUnk_13 = 13, //0D
            [Description("23 Jill Stance Check?")]
            stateRequirementUnk_23 = 23, //17
            [Description("24 Chris Stance Check?")]
            chrisInstallCheck_24 = 24, //18
            [Description("26 Taskmaster Air Arrows Unk")]
            taskmasterFlags_26 = 26, //1A
            [Description("30 Mode Required")]
            modeRequired_30 = 30, //1E
            [Description("33 TAC Unk")]
            TACUnk_33 = 33, //21
            [Description("34 Air Action Limit")]
            airActionLimit_34 = 34, //22
            [Description("35 TAC/DHC Action")]
            TACDHCAction_35 = 35, //23
            [Description("37 Super Jump Action")]
            superJumpAction_37 = 37, //25
            [Description("38 Snap Back Character")]
            snapBackChar_38 = 38, //26
            [Description("41 Easy Mode Unk?")]
            easyModeUnk_41 = 41, //29
            [Description("47 Restricted State")]
            restrictedState_47 = 47, //2F
            [Description("48 S Unk")]
            SUnk_48 = 48, //30
            [Description("49 Prohibited Follow Up Action")]
            prohibitedFollowUpAction_49 = 49, //31
            [Description("50 Height Restriction")]
            heightRestriction_50 = 50, //32
            [Description("52 Air Dash")]
            airDash_52 = 52, //34
            [Description("53 Air Special Action Limit")]
            airSpecialActionLimit_53 = 53, //35
            [Description("56 Guard TAC Action")]
            guardTACAction_56 = 56, //38
            [Description("58 Hypers")]
            hypers_58 = 58, //3A
            [Description("60 Unk3C")]
            unk3C_60 = 60, //3C
            [Description("61 Unk3D")]
            unk3D_61 = 61, //3D
            [Description("63 Allowed Chain Canceling State")]
            allowedChainCancelingState_63 = 63, //3F
            [Description("73 Advancing Guard Unk")]
            advGuardUnk_73 = 73, //49
            [Description("85 Haggar Flags Unk")]
            haggarFlags_85 = 85, //55
            [Description("90 Whiff Cancel Unk")]
            whiffCancelUnk_90 = 90,
            [Description("91 Is Prop Active")]
            hasPropActive_91 = 91,
        }


        public class MVC3DataStructures
        {
            public static string[] NumpadDirections = { "5", "6", "4", "?", "8", "9", "7", "?", "2", "3", "1" };
            public static List<string> SubChunkTypeList = new List<string>(new string[] { "standardInput", "dashDirectionInput", "twoButtonInput1", "directionAndButtonInput", "twoButtonInput2", "executeAction", "modeRequired", "TACDHCAction", "restrictedState", "chrisStateCheck", "prohibitedFollowUpAction", "airDash", "airSpecialActionLimit", "guardTACAction", "hypers", "allowedChainOnState" });

            //FIXME: fugly implementation :s
            public static Type[] SpatkChunkTypes =
            {
            typeof(SpatkUnkChunk), // 00                  [0] 
            typeof(SpatkUnkChunk), // 01                  [1] 
            typeof(SpatkStandardChunk), // 02             [2] 
            typeof(SpatkDirectionalDashChunk), // 03      [3] 
            typeof(SpatkTwoButtonChunk), // 04            [4] 
            typeof(SpatkDirButtonChunk), // 05            [5] 
            typeof(SpatkUnkChunk), // 06                  [6] 
            typeof(SpatkTwoButtonAirdashChunk), // 07     [7] 
            typeof(SpatkUnkChunk), // 08                  [8] 
            typeof(SpatkActionChunk), // 09               [9]
            typeof(SpatkUnkChunk), // 00                  [10]
            typeof(SpatkUnkChunk), // 00                  [11]
            typeof(SpatkUnkChunk), // 00                  [12]
            typeof(SpatkUnkChunk), // 00                  [13]
            typeof(SpatkUnkChunk), // 00                  [14]
            typeof(SpatkUnkChunk), // 00                  [15]
            typeof(SpatkUnkChunk), // 00                  [16]
            typeof(SpatkUnkChunk), // 00                  [17]
            typeof(SpatkUnkChunk), // 00                  [18]
            typeof(SpatkUnkChunk), // 00                  [19]
            typeof(SpatkUnkChunk), // 00                  [20]
            typeof(SpatkUnkChunk), // 00                  [21]
            typeof(SpatkUnkChunk), // 00                  [22]
            typeof(SpatkRequiredStateUnk), // 17          [23]
            typeof(SpatkChrisStateChunk), // 00           [24]
            typeof(SpatkUnkChunk), // 00                  [25]
            typeof(SpatkSnapBack), // 00                  [26]
            typeof(SpatkUnkChunk), // 00                  [27]
            typeof(SpatkUnkChunk), // 00                  [28]
            typeof(SpatkUnkChunk), // 00                  [29]
            typeof(SpatkModeRequiredChunk), // 1E         [30]
            typeof(SpatkUnkChunk), // 00                  [31]
            typeof(SpatkUnkChunk), // 00                  [32]
            typeof(SpatkUnkChunk), // 00                  [33]
            typeof(SpatkUnkChunk), // 00                  [34]
            typeof(SpatkTACDHCChunk), // 23               [35]
            typeof(SpatkUnkChunk), // 00                  [36]
            typeof(SpatkSuperJumpAction), // 00           [37]
            typeof(SpatkUnkChunk), // 00                  [38]
            typeof(SpatkUnkChunk), // 00                  [39]
            typeof(SpatkUnkChunk), // 00                  [40]
            typeof(SpatkUnkChunk), // 00                  [41]
            typeof(SpatkUnkChunk), // 00                  [42]
            typeof(SpatkUnkChunk), // 00                  [43]
            typeof(SpatkUnkChunk), // 00                  [44]
            typeof(SpatkUnkChunk), // 00                  [45]
            typeof(SpatkUnkChunk), //                     [46]
            typeof(SpatkRestrictedStateChunk), // 2F      [47]
            typeof(SpatkUnkChunk), // 00                  [48]
            typeof(SpatkProhibitedChunk), // 31           [49]
            typeof(SpatkUnkChunk), // 00                  [50]
            typeof(SpatkUnkChunk), // 00                  [51]
            typeof(SpatkAirdashChunk), // 34              [52]
            typeof(SpatkAirSpecialLimiterChunk), // 35    [53]
            typeof(SpatkUnkChunk), // 00                  [54]
            typeof(SpatkUnkChunk), // 00                  [55]
            typeof(SpatkGuardTACChunk), // 38             [56]
            typeof(SpatkUnkChunk), // 00                  [57]
            typeof(SpatkHyperChunk), // 3A                [58]
            typeof(SpatkUnkChunk), // 00                  [59]
            typeof(SpatkUnkChunk), // 00                  [60]
            typeof(SpatkUnkChunk), // 00                  [61]
            typeof(SpatkUnkChunk), // 00                  [62]
            typeof(SpatkAllowedChainChunk), // 3F         [63]
            typeof(SpatkUnkChunk), // 00                  [64]
            typeof(SpatkUnkChunk), // 00                  [65]
            typeof(SpatkUnkChunk), // 00                  [66]
            typeof(SpatkUnkChunk), // 00                  [67]
            typeof(SpatkUnkChunk), // 00                  [68]
            typeof(SpatkUnkChunk), // 00                  [69]
            typeof(SpatkUnkChunk), // 46                  [70]

            typeof(SpatkUnkChunk), // 00                  [71]
            typeof(SpatkUnkChunk), // 00                  [72]
            typeof(SpatkAdvGuardUnk), // 00               [73]
            typeof(SpatkUnkChunk), // 00                  [74]
            typeof(SpatkUnkChunk), // 00                  [75]
            typeof(SpatkUnkChunk), // 00                  [76]
            typeof(SpatkUnkChunk), // 00                  [77]
            typeof(SpatkUnkChunk), // 00                  [78]
            typeof(SpatkUnkChunk), // 00                  [79]
            typeof(SpatkUnkChunk), // 50                  [80]
            typeof(SpatkUnkChunk), // 00                  [81]
            typeof(SpatkUnkChunk), // 00                  [82]
            typeof(SpatkUnkChunk), // 00                  [83]
            typeof(SpatkUnkChunk), // 00                  [84]
            typeof(SpatkHaggarFlagsUnk),  // 55           [85]
            typeof(SpatkUnkChunk), // 00                  [86]
            typeof(SpatkUnkChunk), // 00                  [87]
            typeof(SpatkUnkChunk), // 00                  [88]
            typeof(SpatkUnkChunk), // 00                  [89]
            typeof(SpatkWhiffCancelUnk), // 5A            [90]
            typeof(SpatkHasPropActive), // 00             [91]

        }; // if it's past the end of this list, it'll default to SpatkUnkChunk
        }
    }