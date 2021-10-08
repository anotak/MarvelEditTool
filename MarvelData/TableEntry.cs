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
        public string name; // DONT SAVE THIS (??)
        public int size;

        public static StringBuilder nameSB;

        public TableEntry()
        {
            name = "";
        }

        public virtual void GuessName()
        {
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
                    name = "unknown";
                    break;
            }
        }

        //TODO: try and implement to use char name
        public virtual string GuessStatusFieldName()
        {
            if (index >= 0)
            {
                return "Form #" + (index +1);
            }
            return "unknown";
        }

        public virtual string GuessFieldName()
        {
            switch (index)
            {

                case 0:
                    name = "Tag-in";
                    break;
                case 1:
                    name = "TAC partner tag-in";
                    break;
                /*case 2:
                    name = "";
                    break;*/
                case 3:
                    name = "Snap Back";
                    break;
                case 4:
                    name = "st.S";
                    break;
                case 5:
                    name = "Team Aerial Counter";
                    break;
                case 6:
                    name = "TAC Up";
                    break;
                case 7:
                    name = "TAC Side";
                    break;
                 case 8:
                    name = "TAC Down";
                    break; 
                /*case 9:
                    name = "Fall";
                    break;
                case 10:
                    name = "Crouch";
                    break;
                case 11:
                    name = "";
                    break;*/
                case 30:
                    name = "st.L";
                    break;
                case 31:
                    name = "st.M";
                    break;
                case 32:
                    name = "st.H";
                    break;
                case 33:
                    name = "cr.L";
                    break;
                case 34:
                    name = "cr.M";
                    break;
                case 35:
                    name = "cr.H";
                    break;
                case 36:
                    name = "j.L";
                    break;
                case 37:
                    name = "j.M";
                    break;
                case 38:
                    name = "j.H";
                    break;
                case 39:
                    name = "j.S";
                    break;

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
                    name = "unknown";
                    break;
            }

            if ((index >= 40 && index <= 49) && HasAtkFlags())
            {
                return "Command Move " + (index - 39);
            }

            if ((index >= 50 && index <= 79) && HasAtkFlags())
            {
                return "Special Move " + (index - 49);
            }

            if ((index >= 80 && index <= 99) && HasAtkFlags())
            {
                return "Hyper Move " + (index - 79);
            }

            if (index >= 100 && HasAtkFlags())
            {
                return "Assist " + (index - 99);
            }

            return name;
        }

        public virtual string GetFancyName()
        {
            if(nameSB == null)
            {
                nameSB = new StringBuilder();
            }
            else
            {
                nameSB.Clear();
            }
            nameSB.Append(index.ToString("X3"));
            nameSB.Append("h: ");
            //if (tabletype != null && tabletype.Contains("ATKInfo"))
            if (this.GetType().ToString().Contains("ATKInfo"))
            {
                nameSB.Append(GuessFieldName());
            }
            //else if (tabletype != null && tabletype.Contains("Status"))
            else if (this.GetType().ToString().Contains("Status"))
            {
                nameSB.Append(GuessStatusFieldName());
            }
            else
            {
            nameSB.Append(name);
            }
            return  nameSB.ToString();
        }

        public virtual string GetFilename()
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

        public virtual byte[] GetData()
        {
            throw new NotImplementedException();
        }

        public virtual void SetData(byte[] newdata)
        {
            // need to set size here too
            throw new NotImplementedException();
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

            b.Write(GetData());

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
                        if (!bHasData)
                        {
                            bHasData = true;
                            try
                            {
                                name = Path.GetFileNameWithoutExtension(filename);
                            }
                            catch
                            {
                                GuessName();
                            }
                        }
                        ImportBytes(reader.ReadBytes((int)reader.BaseStream.Length));
                    }
                }
            }
            else
            {
                AELogger.Log("attempted import of nonexistent file " + filename + " to " + GetFancyName());
            }
        }

        public virtual void ImportBytes(byte[] bytes)
        {
            SetData(bytes);
        }

        public virtual TableEntry Duplicate()
        {
            TableEntry dupe = (TableEntry)Activator.CreateInstance(GetType());
            dupe.name = "duplicate " + name;
            dupe.size = size;
            dupe.ImportBytes(GetData());
            return dupe;
        }

        public virtual void UpdateSize()
        {

        }

        public virtual Boolean HasAtkFlags()
        {
            if ((((MarvelData.StructEntry<MarvelData.ATKInfoChunk>)this).@data).atkflags != 0)
            {
                return true;
            }
            return false;
        }

    }
}
