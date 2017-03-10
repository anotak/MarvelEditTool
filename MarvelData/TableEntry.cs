using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelData
{
    public class TableEntry
    {
        public uint index;
        public uint originalPointer; // DONT SAVE THIS
        public bool bHasData;  // DONT SAVE THIS
        public string name; // DONT SAVE THIS
        public byte[] data;

        public static string GuessAnmChrName(uint index)
        {
            string output;
            switch(index)
            {
                /*case 0x0:
                    return "stand";
                case 0x1:
                    return "fwd walk";
                case 0x3:
                    return "fwd dash";
                case 0x4:
                    return "backdash";
                case 0x96:
                    return "5L";
                case 0x168:
                    return "5S";*/
                default:
                    output = "unknown";
                    break;
            }

            return output;
        }

        public string GetFancyName()
        {
            return index.ToString("X3") + "h: " + name;
        }

        public string GetFilename()
        {
            if(name == "unknown")
            {
                return index.ToString("X3") + "unk";
            }
            else
            {
                return name;
            }
        }

        public void Export(string filename)
        {
            AELogger.Log("exporting " + GetFancyName() + " to " + filename);
            if (File.Exists(filename))
            {
                try
                {
                    File.Copy(filename, "exportbackup", true);
                }
                catch (UnauthorizedAccessException e)
                {
                    AELogger.Log("unable to access export backup: " + e.Message);
                }

            }
            Stream t = new FileStream(filename + ".temp", FileMode.Create);
            BinaryWriter b = new BinaryWriter(t);

            b.Write(data);

            b.Close();
            t.Close();
            File.Copy(filename + ".temp", filename, true);
            File.Delete(filename + ".temp");
        }

        public void Import(string filename)
        {
            if (File.Exists(filename))
            {
                AELogger.Log("importing file " + filename + " to " + GetFancyName());
                using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
                {
                    if (reader.BaseStream.Length == 0)
                    {
                        bHasData = false;
                        name = "***EMPTY DATA ***";
                    }
                    else
                    {
                        bHasData = true;
                        data = reader.ReadBytes((int)reader.BaseStream.Length);
                        name = GuessAnmChrName(index);
                    }
                }
            }
            else
            {
                AELogger.Log("attempted import of nonexistent file " + filename + " to " + GetFancyName());
            }

        }
    }
}
