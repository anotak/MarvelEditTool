using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MarvelData
{
    public class MSDFile
    {
        public byte[] header;
        public List<string> data;

        public static MSDFile LoadFile(string filename)
        {
            AELogger.Log("attempting to open msd " + filename);

            if (!File.Exists(filename))
            {
                AELogger.Log("FILE " + filename + " NOT FOUND!!!");
                return null;
            }

            MSDFile outfile = new MSDFile();

            using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
            {
                long length = reader.BaseStream.Length;
                AELogger.Log("filesize is " + length);

                if (length < 8)
                {
                    // FIXME THIS SUCKS
                    AELogger.Log("TOO SHORT FILE HEADEr " + length + " < " + 8);
                    throw new Exception();
                }

                outfile.header = reader.ReadBytes(4);
                int count = reader.ReadInt32();

                outfile.data = new List<string>(count);
                StringBuilder builder = new StringBuilder();
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int stringlength = reader.ReadInt16();

                    builder.Clear();
                    for (int i = 0; i < stringlength; i++)
                    {
                        byte byteA = (byte)(reader.ReadByte() + 0x20);
                        byte byteB = reader.ReadByte();
                        if (byteB != 0)
                        {
                            AELogger.Log("nonzero byteB " + byteB);
                        }
                        builder.Append((char)byteA);
                    }
#if DEBUG
                    AELogger.Log(builder.ToString());
#endif

                    outfile.data.Add(builder.ToString());

                    short ender = reader.ReadInt16();
                    if (ender != -1)
                    {
                        AELogger.Log("ender error?");
                    }
                }
                AELogger.Log(outfile.data.Count + " vs " + count);
            } // using
            return outfile;
        } // loadfile


        public void WriteFile(string filename, bool bDoNames = false)
        {
            if (File.Exists(filename))
            {
                try
                {
                    File.Copy(filename, "savebackup", true);
                }
                catch (UnauthorizedAccessException e)
                {
                    AELogger.Log("unable to access backup: " + e.Message);
                }
            }

            FileStream t = new FileStream(filename + ".temp", FileMode.Create);
            BinaryWriter b = new BinaryWriter(t);

            AELogger.Log("writing " + filename + ".temp");

            AELogger.Log("writing header ");
            b.Write(header);
            int count = data.Count;
            b.Write(count);
            AELogger.Log("writing files");
            for (int i = 0; i < count; i++)
            {
#if DEBUG
                AELogger.Log("writing string #" + i + ": " + data[i]);
#endif
                int strlen = data[i].Length;
                char[] str = data[i].ToCharArray();
                b.Write((short)strlen);
                for (int j = 0; j < strlen; j++)
                {
                    b.Write((byte)(str[j] - 0x20));
                    b.Write((byte)0);
                }
                b.Write((byte)0xFF);
                b.Write((byte)0xFF);
            }

            b.Close();
            t.Close();
            File.Copy(filename + ".temp", filename, true);
            File.Delete(filename + ".temp");
        }

    } // class
}
