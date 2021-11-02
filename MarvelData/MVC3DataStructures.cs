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
        public int unk6C; // 0x6c
        public int unk70;
        public int unk74;
        public int unk78;
        public int unk7C;
        public int meterSteal;
        public int unk84;
        public int stunTimer;
        public int unk8C;
        public ComboType comboType;
        public int unk94;
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
        public int XF1Unk;
        public float XF1Damage;
        public float XF1Speed;
        public float XF1Duration;
        public int unkE4;
        public int unkE8;
        public int unkEC;
        public int unkF0;
        public float XF1MeterGAin;
        public float XF1DmgTaken;
        public int unkFC;
        public int XF2YellowHealthRegen;
        public int XF2Unk;
        public float XF2Damage;
        public float XF2Speed;
        public float XF2Duration;
        public int unk114;
        public int unk118;
        public int unk11C;
        public int unk120;
        public float XF2MeterGAin;
        public float XF2DmgTaken;
        public int unk12C;
        public int XF3YellowHealthRegen;
        public int XF3Unk;
        public float XF3Damage;
        public float XF3Speed;
        public float XF3Duration;
        public int unk144;
        public int unk148;
        public int unk150;
        public float unk154;
        public float XF3MeterGAin;
        public float XF3DmgTaken;
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
    public enum StatusFlags : uint
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
        public float meterGain;
        public float unk078;
        public int unk07c;
        public int meterSteal;
        public int hitboxDestructionUnk;
        public int hiddenStunUnk;
        public int AddedHitstun;
        public int unk090;
        public int AddedBlockstun;
        public int hardKDTime;
        public float enemyPushbackAndWallBounceDist;
        public float opponentBlockPushCornerInverse;
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
        public int throwUnk1;
        public int unk110;
        public int throwUnk2;
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
        public int hitSFXGroup;
        public int hitSFX;
        public int unk158;
        public int unk15C;
        public int launcherUnk;
        public int unk164;
        public float unk168;
        public float unk16C;
        public int unk170;
        public int unk174;
        public int IdReference2;
        public int delayIdReference2;
        public int unk180;
        public int unk184;
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
        FixedHitstunDuration    = 0x00000800,
        NoGroundBounceLimit     = 0x00001000,
        JuggledInvinc           = 0x00002000,
        Unk0x4000               = 0x00004000,
        Unk0x8000               = 0x00008000,
        Unk0x10000              = 0x00010000,
        Unk0x20000              = 0x00020000,
        Unk0x40000              = 0x00040000,
        FlyingScreen            = 0x00080000,
        CanWallBounce           = 0x00100000,
        OTG                     = 0x00200000,
        ForceAirReset           = 0x00400000,
        SoftKD                  = 0x00800000,
        HardKD                  = 0x01000000,
        Unk0x02000000           = 0x02000000,
        ForceWallBounce         = 0x04000000,
        NegatePushBlock         = 0x08000000,
        OTGOnly                 = 0x10000000,
        NegatePushBlockAirUnk   = 0x20000000,
    }

    [Flags]
    public enum AtkFlagsB : uint
    {
        None = 0,
        SpecialScalingUnk = 0x00000001,
        HyperScalingUnk = 0x00000002,
        Unk0x04 = 0x00000004,
        NeverCounterhit = 0x00000008,
        Unk0x10 = 0x00000010,
        Unk0x20 = 0x00000020,
        ChipDamage = 0x00000040,
        Unblockable = 0x00000080,
        Unk0x100 = 0x00000100,
        NoHitboxUnk = 0x00000200,
        NoHyperMeterBuild = 0x00000400,
        NoComboCounter = 0x00000800,
        Unk0x1000 = 0x00001000,
        Unk0x2000 = 0x00002000,
        NoPushbackAttacker = 0x00004000,
        PartnerTargeting = 0x00008000,
        Unk0x10000 = 0x00010000,
        Unk0x20000 = 0x00020000,
        Unk0x40000 = 0x00040000,
        TACGlow      = 0x00080000,
        Unk0x100000  = 0x00100000,
        Unk0x200000  = 0x00200000,
        Unk0x400000  = 0x00400000,
        Unk0x800000  = 0x00800000,
        Unk0x1000000 = 0x01000000,
        Unk0x2000000 = 0x02000000,
        Unk0x4000000 = 0x04000000,
        Unk0x8000000 = 0x08000000
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
        Unk0x80 = 0x00000080,
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
        Unk0x80000 = 0x00080000,
        Unk0x100000 = 0x00100000,
        Unk0x200000 = 0x00200000,
        Unk0x400000 = 0x00400000,
        FirstHitDmgs = 0x00800000,
        Unk0x1000000 = 0x01000000,
        TechTAC1     = 0x02000000,
        HitComboGrab = 0x04000000,
        Unk0x8000000 = 0x08000000,
        TechTAC2     = 0x10000000
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
        fallBack2 = 6,
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
        public float unk1C;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CmdComboHeaderChunk
    {
        public int index;
        public int size;
        public int unk08;
        public float meterRequirement;
        public CmdDisabled disable;
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
        public int flags;
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
        public int specialProperties;
    }

    public enum BoneReferenceId : uint
    {
      Unk01 = 01,
      Unk02 = 02,
      Stomach = 03,
      Unk04 = 04,
      Chest = 05,
      Unk06 = 06,
      Head = 07,
      Unk08 = 08,
      LeftShoulder = 09,
      LeftElbow = 10,
      LeftWrist = 11,
      Unk12 = 12,
      RightShoulder = 13,
      RightElbow = 14,
      RightWrist = 15,
      RighHand = 16,
      LeftKnee = 17,
      LeftFoot = 18,
      Unk19 = 19,
      Unk20 = 20,
      RightKnee = 21,
      RightFoot = 22,
      Detached = 4294967295
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
       enabled  = 0,
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
        Ukn3 = 3,
        GuardCancel = 4,
        GuardAndDamageCancel = 5
    }

    public enum ComboType : int
    {
        Restrictive = 1,
        Lenient = 2
    }
    public enum BaseActState : int
    {
        Ground = 00,
        Air = 20
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
        public int unk0C;
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
        public int unk14;
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
    public struct SpatkStateChangeChunk // 2F
    {
        public SubChunkType subChunkType; //2F
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

    public enum SubChunkType : uint
    {
        none = 0,
        unk1 = 01,
        standardInput = 02,
        dashDirectionInput = 03,
        twoButtonInput1 = 04,
        directionAndButtonInput = 05,
        unk6 = 06,
        twoButtonInput2 = 07,
        executeAction = 09,
        captureState = 10, //0A
        stateRestriction = 11, //0B
        simpleModeAirComboUnk = 13, //0D
        modeRequired = 30, //1E
        TACUnk = 33, //21
        airActionLimit = 34, //22
        TACDHCAction = 35, //23
        superJumpAction = 37, //25
        snapBackChar = 38, //26
        stateChange = 47, //2F
        SUnk = 48, //30
        prohibitedFollowUpAction = 49, //31
        heightRestriction = 50, //32
        airDash = 52, //34
        airSpecialActionLimit = 53, //35
        guardTACAction = 56, //38
        hypers = 58, //3A
        unk3C = 60, //3C
        unk3D = 61, //3D
        allowedChainCancelingState = 63, //3F
        advGuardUnk = 73, //49
        whiffCancelUnk = 90,
    }


    public class MVC3DataStructures
    {
        public static string[] NumpadDirections = { "5", "6", "4", "?", "8", "9", "7", "?", "2", "3", "1" };
        public static List<string> SubChunkTypeList = new List<string>(new string[] { "standardInput", "dashDirectionInput", "twoButtonInput1", "directionAndButtonInput", "twoButtonInput2", "executeAction", "modeRequired", "TACDHCAction", "stateChange", "prohibitedFollowUpAction", "airDash", "airSpecialActionLimit", "guardTACAction", "hypers", "allowedChainOnState" });

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
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkModeRequiredChunk), // 1E        [30]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkTACDHCChunk), // 23              [35]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkStateChangeChunk), // 2F         [47]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkProhibitedChunk), // 31          [49]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkAirdashChunk), // 34             [52]
            typeof(SpatkAirSpecialLimiterChunk), // 35   [53]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkGuardTACChunk), // 38            [56]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkHyperChunk), // 3A               [58]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkUnkChunk), // 00                  [0]
            typeof(SpatkAllowedChainChunk), // 3F        [63]
        }; // if it's past the end of this list, it'll default to SpatkUnkChunk
    }
}