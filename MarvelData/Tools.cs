using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MarvelData
{
    public static class Tools
    {
        public static byte[] AddByteToArray(byte[] bArray, byte newByte)
        {
            byte[] newArray = new byte[bArray.Length + 1];
            bArray.CopyTo(newArray, 0);
            newArray[newArray.Length - 1] = newByte;
            return newArray;
        }

        internal static byte[] AddBytesToArray(byte[] bArray, byte[] newBytes)
        {
            byte[] newArray = new byte[bArray.Length + newBytes.Length];
            bArray.CopyTo(newArray, 0);
            newBytes.CopyTo(newArray, bArray.Length);
            return newArray;
        }

        // Reads Descriptions from Enums
        public static string GetDescription(this Enum value)
        {
            return ((DescriptionAttribute)Attribute.GetCustomAttribute(
                value.GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Single(x => x.GetValue(null).Equals(value)),
                typeof(DescriptionAttribute)))?.Description ?? value.ToString();
        }

        public static T GetEnumValue<T>(string str) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }
            T val = ((T[])Enum.GetValues(typeof(T)))[0];
            if (!string.IsNullOrEmpty(str))
            {
                foreach (T enumValue in (T[])Enum.GetValues(typeof(T)))
                {
                    if (enumValue.ToString().ToUpper().Equals(str.ToUpper()))
                    {
                        val = enumValue;
                        break;
                    }
                }
            }
            return val;
        }

        public static string GetUntilOrEmpty(this string text, string stopAt = "-")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }
            return String.Empty;
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            return String.Empty;
        }

        public static string FirstCharToUpper(this string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => input[0].ToString().ToUpper() + input.Substring(1)
            };

        public static string GuessSecondForm(this string input, uint index)
        {
            if (!String.IsNullOrWhiteSpace(input))
            {
                if (index > 0)
                {
                    if (input.Contains("vergil"))
                    {
                       return input += " DT";
                    }
                    else if (input.Contains("dante"))
                    {
                       return input += " DT";
                    }
                    else
                    {
                        return input += " #" + (index + 1);
                    }
                }
            }
            return input;
        }

        // Converts a decimal integer to a hex string in this convulted format
        // Used ie: for meter bars
        public static string DecimalToMVCHex(int value)
        {
            // Convert the integer to a byte array in little-endian order
            byte[] bytes = BitConverter.GetBytes(value);
            // Convert the byte array to a hex string
            string hex = BitConverter.ToString(bytes).Replace("-", "");
            // Reverse the byte pairs
            string reversedHex = string.Concat(Enumerable.Range(0, hex.Length / 2)
                .Select(i => hex.Substring(i * 2, 2)));
            return reversedHex;
        }

        // Converts a hex string in the mvc3 format to a decimal integer
        public static int MVCHexToDecimal(string hex)
        {
            // Reverse the byte pairs
            string reversedHex = string.Concat(Enumerable.Range(0, hex.Length / 2)
                .Select(i => hex.Substring(i * 2, 2)));
            // Convert the hex string to a byte array
            byte[] bytes = Enumerable.Range(0, reversedHex.Length / 2)
                .Select(i => Convert.ToByte(reversedHex.Substring(i * 2, 2), 16))
                .ToArray();
            // Convert the byte array to an integer
            int value = BitConverter.ToInt32(bytes, 0);
            return value;
        }
    }
}
