using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;


namespace MarvelData
{
    // this is from my old SSFIVAE tools, some of these are bad / useless
    public class SSFIVAEDataTools
    {
        public static string GetCompileDate()
        {
            System.Version MyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            return new DateTime(2000, 1, 1).AddDays(MyVersion.Build).AddSeconds(MyVersion.Revision * 2).ToString();
        }

        public static String SlurpString(BinaryReader bReader)
        {
            String output = "";
            Char c = bReader.ReadChar();
            while (c != Convert.ToChar(0x0))
            {
                output += c;
                c = bReader.ReadChar();
            }
            return output;
        }

        public static List<Byte> SlurpBytes(BinaryReader bReader, int length)
        {
            List<Byte> output = new List<Byte>();
            for (int i = 0; i < length; i += sizeof(byte))
            {
                output.Add(bReader.ReadByte());
            }
            return output;
        }

        public static List<UInt16> SlurpUInt16(BinaryReader bReader, int length)
        {
            List<UInt16> output = new List<UInt16>();
            for (int i = 0; i < length; i += sizeof(UInt16))
            {
                output.Add(bReader.ReadUInt16());
            }
            return output;
        }

        public static List<Boolean> GetBits(byte val)
        {
            int t;
            List<Boolean> b = new List<bool>();
            for (t = 128; t > 0; t = t / 2)
            {
                if ((val & t) != 0) b.Add(true);
                else if ((val & t) == 0) b.Add(false);
            }
            return b;
        }

        public static byte GetByteFromBits(List<Boolean> val, int index = 0)
        {
            byte output = 0;
            for (int i = 0; i < 8; i++)
            {
                if (val[i + index])
                {
                    output += (byte)IntPow(2, (7 - (uint)i));
                }
            }
            return output;
        }

        public static UInt16 FromBits(List<Boolean> val)
        {
            UInt16 output = 0;
            for (int i = 0; i < val.Count; i++)
            {
                if (val[i])
                {
                    output += (UInt16)IntPow(2, (15 - (uint)i));
                }
            }
            return output;
        }

        public static uint IntPow(uint x, uint pow)
        {
            uint ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }

        public static UInt32 UInt32FromData(List<Byte> data, int index)
        {
            byte[] output = new byte[4];
            output[0] = data[index];
            output[1] = data[index + 1];
            output[2] = data[index + 2];
            output[3] = data[index + 3];
            return BitConverter.ToUInt32(output, 0);
        }

        public static UInt16 UInt16FromData(List<Byte> data, int index)
        {
            byte[] output = new byte[2];
            AELogger.Log(index.ToString());
            output[0] = data[index];
            output[1] = data[index + 1];
            return BitConverter.ToUInt16(output, 0);
        }
    }
}
