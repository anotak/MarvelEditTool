using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MarvelData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StatusChunk
    {
        public int index;
        public StatusFlags statusflags;
        public int totalhealth;
        public float metergain;
        public float damagegiven;
        public float damagetaken;
        public float speedself;
        public float speedreceived;
        public float minlaunchheight;
        public float comboweight;
        public int unk28;
        public float unk2C;
        public float CameraSizeX;
        public float partner2offsetIntro;
        public float partner1offsetIntro;
        public float unk3C;
        public float unk40;
        public int airActions;
        public float unk48;
        public float dashAccelAfter;
        public float unk50;
        public float dashTraction;
        public int unk58;
        public float flightaccel;
        public float flightmaxspeed;
        public float flightClearance;
        public float flightMaxHeight;
        public int unk6C; // 0x6c
        public int unk70;
        public int unk74;
        public int unk78;
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
        public float unk15C;
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
        public float unk18C;
        public float unk190;
        public float unk194;
        public float unk198;
        public int unk19C;
        public int unk1A0;
        public int unk1A4;
        public int unk1A8;
        public int unk1AC;
        public int unk1B0;
        public int unk1B4;
        public int unk1B8;
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
        public int unk250;
        public int unk254;
        public int unk258;
        public int unk25C;
        public int unk260;
        public int unk264;
        public int unk268;
        public int unk26C;
        public int unk270;
        public float unk274;
        public float unk278;
        public float unk27C;
        public float unk280;
        public float unk284;
        public float unk288;
        public int unk28C;
        public float unk290;
        public float unk294;
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
    }

    [Flags]
    public enum StatusFlags : int
    {
        Male = 0x00000001,
        Female = 0x00000002,
        AmmyUnk = 0x00000004,
        MagStormModokUnk = 0x00000008,
        NoHurtbox = 0x00000010,
        AirBlockBounce = 0x00000020,
        NoHyperDrain = 0x00000040,
        NoHitstop = 0x00000080,
        IMSentShumaUnk = 0x00000100,
        AirUnk = 0x00000200,
        ShumaUnk = 0x00000400,
        AmmyShumaUnk = 0x00000800,
        LockCharacter = 0x00001000,
        NoSnapoutNoTAC = 0x00002000,
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
        public int unk02c;
        public float unk030;
        public float unk034;
        public float unk038;
        public AtkFlagsA atkflags;
        public AtkFlagsB atkflags2;
        public int atkflags3;
        public int AttackLevel;
        public int GuardType;
        public int unk050;
        public int HitAnim;
        public int HitAnimCounter;
        public int HitAnimAir;
        public int damage;
        public float damageScaling;
        public float damageMult;
        public float ChipDamage;
        public int unk070;
        public float meterGain;
        public float unk078;
        public int unk07c;
        public int unk080;
        public int unk084;
        public int unk088;
        public int AddedHitstun;
        public int unk090;
        public int AddedBlockstun;
        public int hardKDTime;
        public float enemyPushbackandWallBouncedist;
        public float cornerPushInverse;
        public float playerBlockPushCorner;
        public float playerBlockPushInverse;
        public float unk0AC;
        public float unk0B0;
        public float unk0B4;
        public float unk0B8;
        public float GroundBounceHeight;
        public float unk0C0;
        public int hitstop;
        public int unk0C8;
        public int unk0CC;
        public int sjCancelDelay;
        public int juggleHeight;
        public int unk0D8;
        public float juggleCarry;
        public float juggleSpeed;
        public int FixedHitstunIfFlagOn;
        public int SJJuggleHeight;
        public int unk0EC;
        public float SJJuggleCarry;
        public float SJJuggleSpeed;
        public int SJFixedHitstun;
        public int PlayerCmdSPAtkClassOnHit;
        public int PlayerCmdSPAtkIndexOnHit;
        public int EnemyCmdSPAtkClassOnHit;
        public int EnemyCmdSPAtkIndexOnHit;
        public int unk10C;
        public int unk110;
        public int unk114;
        public int Hitspark1;
        public int unk11C;
        public int OnHitEffectOnEnemy;
        public int OnBlockEffectOnEnemy;
        public int unk128;
        public int unk12C;
        public int unk130;
        public int HitSpark2;
        public int unk138;
        public int unk13C;
        public int unk140;
        public int unk144;
        public int unk148;
        public int unk14C;
        public int hitSFXGroup;
        public int hitSFX;
        public int unk158;
        public int unk15C;
        public int unk160;
        public int unk164;
        public float unk168;
        public float unk16C;
        public int unk170;
        public int unk174;
        public int unk178;
        public int unk17c;
        public int unk180;
        public int unk184;
        public int unk188;
    }

    [Flags]
    public enum AtkFlagsA : int
    {
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
        Unk0x800 = 0x00000800,
        NoGroundBounceLimit = 0x00001000,
        JuggledInvinc = 0x00002000,
        Unk0x4000 = 0x00004000,
        Unk0x8000 = 0x00008000,
        Unk0x10000 = 0x00010000,
        Unk0x20000 = 0x00020000,
        Unk0x40000 = 0x00040000,
        FlyingScreen = 0x00080000,
        CanWallBounce = 0x00100000,
        OTG = 0x00200000,
        ForceAirReset = 0x00400000,
        KnocksDown = 0x00800000,
        HardKD = 0x01000000,
        Unk0x2000000 = 0x0002000000,
        Unk0x4000000 = 0x0004000000,
        Unk0x8000000 = 0x0008000000,
        OTGOnly = 0x10000000,
    }

    [Flags]
    public enum AtkFlagsB : int
    {
        Unk0x01 = 0x00000001,
        Unk0x02 = 0x00000002,
        Unk0x04 = 0x00000004,
        NeverCounterhit = 0x00000008,
        Unk0x10 = 0x00000010,
        Unk0x20 = 0x00000020,
        ChipDamage = 0x00000040,
        Unblockable = 0x00000080,
        Unk0x100 = 0x00000100,
        NoHitboxUnk = 0x00000200,
        Unk0x400 = 0x00000400,
        NoComboCounter = 0x00000800,
        Unk0x1000 = 0x00001000,
        Unk0x2000 = 0x00002000,
        NoPushbackAttacker = 0x00004000,
        PartnerTargeting = 0x00008000,
        Unk0x10000 = 0x00010000,
        Unk0x20000 = 0x00020000,
        Unk0x40000 = 0x00040000,
        TACGlow = 0x00080000,
        Unk0x100000 = 0x00100000,
        Unk0x200000 = 0x00200000,
        Unk0x400000 = 0x00400000,
        Unk0x800000 = 0x00800000,
        Unk0x1000000 = 0x01000000,
        Unk0x2000000 = 0x000200000,
        Unk0x4000000 = 0x000400000,
        Unk0x8000000 = 0x000800000
    }

    [Flags]
    public enum InputCode : int
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
        Taunt = 0x00001000,
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
        Unk0x1000000 = 0x01000000,
        Unk0x2000000 = 0x000200000,
        Unk0x4000000 = 0x000400000,
        Unk0x8000000 = 0x000800000
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BaseActChunk
    {
        public int index;
        public int anmchrAction;
        public InputCode directionLeniency;
        public InputCode direction2;
        public InputCode button;
        public int state;
        public int unk18;
        public float unk1C;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CmdComboHeaderChunk
    {
        public int index;
        public int size;
        public int unk08;
        public float meterRequirement;
        public int disable;
        public int unk14;
        public int unk18;
        public int delay;
        public int anmChrAction;
        public int anmChrAction2;
        public int anmChrAction3;
        public int unk2C;
        public int unk30;
        public int unk34;
        public int unk38;
        public int unk3C;
        public int unk40;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpatkHeaderChunk
    {
        public int index;
        public int size;
        public int unk08;
        public float meterrequirement;
        public int disable;
        public int cancelHierarchyThresh;
        public PositionState positionState;
        public int comboState;
        public int flags;
    }

    public enum PositionState : int
    {
        Ground = 0,
        Air = 1,
        Either = 2
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpatkStandardChunk // 02
    {
        public int subChunkType; // 02
        public int cancelWindow;
        public int chargeTime;
        public int unk0C;
        public int negativeEdge;
        public InputCode leniencyMaybe;
        public InputCode inputCode;
        public int unk1C;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpatkDirectionalDashChunk // 03
    {
        public int subChunkType; // 03
        public int cancelWindow;
        public int unk08;
        public int unk0C;
        public int negativeEdge;
        public InputCode leniencyMaybe;
        public InputCode inputCode;
        public int unk1C;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpatkTwoButtonChunk // 04
    {
        public int subChunkType; // 04
        public int cancelWindow;
        public int unk08;
        public int unk0C;
        public int unk10;
        public int unk14;
        public int unk18;
        public int unk1C;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpatkDirButtonChunk // 05
    {
        public int subChunkType; // 05
        public int cancelWindow;
        public int leniencyMaybe;
        public InputCode inputCodeDirection;
        public InputCode inputCodeButton;
        public int unk14;
        public int unk18;
        public int unk1C;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpatkTwoButtonAirdashChunk // 07
    {
        public int subChunkType; // 07
        public int cancelWindow;
        public int chargeTimeMaybe;
        public InputCode inputCodeLeniency;
        public InputCode inputCodeDirection;
        public int unk14;
        public int unk18;
        public int unk1C;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpatkActionChunk // 09
    {
        public int subChunkType; // 09
        public int actionClass;
        public int actionIndex;
        public int unk0C;
        public int unk10;
        public int unk14;
        public int unk18;
        public int unk1C;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpatkModeRequiredChunk // 1E
    {
        public int subChunkType; // 1E
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
        public int subChunkType; //23
        public int anmChrAction;
        public int unk08;
        public int unk0C;
        public int unk10;
        public int unk14;
        public int unk18;
        public int unk1C;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpatkStateChangeChunk // 2F
    {
        public int subChunkType; //2F
        public int unk04;
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
        public int subChunkType; //31
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
        public int subChunkType; //34
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
        public int subChunkType; //35
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
        public int subChunkType; //38
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
        public int subChunkType; //3A
        public int unk04;
        public int unk08;
        public int unk0C;
        public int unk10;
        public int unk14;
        public int unk18;
        public int unk1C;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpatkPermitChainChunk // 3F
    {
        public int subChunkType; //3F
        public int validityFlags;
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
        public int subChunkType; //??
        public int unk04;
        public int unk08;
        public int unk0C;
        public int unk10;
        public int unk14;
        public int unk18;
        public int unk1C;
    }

    public class MVC3DataStructures
    {
        public static string[] NumpadDirections = { "5", "6", "4", "?", "8", "9", "7", "?", "2", "3", "1" };

        public static Type[] SpatkChunkTypes =
        {
            typeof(SpatkUnkChunk), // 00
            typeof(SpatkUnkChunk), // 01
            typeof(SpatkStandardChunk), // 02
            typeof(SpatkDirectionalDashChunk), // 03
            typeof(SpatkTwoButtonChunk), // 04
            typeof(SpatkDirButtonChunk), // 05
            typeof(SpatkUnkChunk), // 06
            typeof(SpatkTwoButtonAirdashChunk), // 07
            typeof(SpatkUnkChunk), // 08
            typeof(SpatkActionChunk), // 09
        }; // if it's past the end of this list, it'll default to SpatkUnkChunk
    }
}