using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace MarvelData
{
    public class AnmChrSubEntry
    {
        public int tableindex;
        public int localindex;
        public int size;
        public int unk08;
        public int unk0C;
        public uint originalPointer; // DONT SAVE THIS
        public List<uint> subsubPointers; // DONT SAVE THIS
        public List<byte[]> subsubEntries;
        public List<int> subsubIndices;
        public bool bEdited;

        #region STATIC
        public static StringBuilder sb = new StringBuilder();
        public static Dictionary<long, string> cmdNames;

        public static string InitCmdNames(string filename = "AnmChrCmds.cfg")
        {
            AELogger.Log("InitCmdNames " + filename);
            if (!File.Exists(filename))
            {
                AELogger.Log("warning: command label file " + filename + " does not exist!");
                return "command label file " + filename + " does not exist!";
            }

            if (cmdNames == null)
            {
                cmdNames = new Dictionary<long, string>();
            }
            else
            {
                AELogger.Log("odd? cmdNames already initialized?");
            }

            using (StreamReader reader = new StreamReader(File.OpenRead(filename)))
            {
                string line;
                line = reader.ReadLine();
                int i = 0;
                while (line != null)
                {
                    i++;
                    if (line.IndexOf('#') >= 0)
                    {
                        AELogger.Log("comment found " + line);
                        line = line.Substring(0,line.IndexOf('#'));
                    }

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        line = reader.ReadLine();
                        continue;
                    }

                    line = line.Trim();
                    long key = 0;
                    if (line.IndexOf(',') >= 0)
                    {
                        try
                        {
                            key = long.Parse(line.Substring(0, line.IndexOf(',')), System.Globalization.NumberStyles.HexNumber) << 32;
                        }
                        catch(Exception e)
                        {
                            AELogger.Log("PARSE ERROR 1ST AROUND LINE " + i + ": " + line + "\nDETAILS: " + e.Message);
                            return "PARSE ERROR 1ST AROUND LINE " + i + ": " + line + "\nDETAILS: " + e.Message;
                        }
                    }
                    else
                    {
                        AELogger.Log("PARSE ERROR 1ST AROUND LINE " + i + ": NO 1ST COMMA DETECTED: " + line);
                        return "PARSE ERROR 1ST AROUND LINE " + i + ": NO 1ST COMMA DETECTED: " + line;
                    }
                    line = line.Substring(line.IndexOf(',') + 1);

                    if (line.IndexOf(',') >= 0)
                    {
                        try
                        {
                            key += long.Parse(line.Substring(0, line.IndexOf(',')), System.Globalization.NumberStyles.HexNumber);
                        }
                        catch (Exception e)
                        {
                            AELogger.Log("PARSE ERROR 2ND AROUND LINE " + i + ": " + line + "\nDETAILS: " + e.Message);
                            return "PARSE ERROR 2ND AROUND LINE " + i + ": " + line + "\nDETAILS: " + e.Message;
                        }
                    }
                    else
                    {
                        AELogger.Log("PARSE ERROR 2ND AROUND LINE " + i + ": NO 2ND COMMA DETECTED: " + line);
                        return "PARSE ERROR 2ND AROUND LINE " + i + ": NO 2ND COMMA DETECTED: " + line;
                    }

                    line = line.Substring(line.IndexOf(',') + 1);
                    line = line.TrimStart();
                    if (cmdNames.ContainsKey(key))
                    {
                        AELogger.Log("warning, duplicate key " + key.ToString("X") + " with old value '" + cmdNames[key] + "' overwritten with '" + line + "' on line number " + i);
                        cmdNames[key] = line;
                    }
                    else
                    {
                        AELogger.Log("line " + i + ": " + key.ToString("X") + " set to '" + line + "'");
                        cmdNames.Add(key, line);
                    }

                    line = reader.ReadLine();
                } // while 
            } // using
            AELogger.Log("end InitCmdNames");
            return string.Empty;
        }
        #endregion

        public AnmChrSubEntry()
        {
            subsubEntries = new List<byte[]>();
            subsubIndices = new List<int>();
            subsubPointers = new List<uint>();
            bEdited = false;
        }

        public void SetData(BinaryReader reader, uint nextPointer)
        {
            reader.BaseStream.Seek(originalPointer, SeekOrigin.Begin);

            localindex = reader.ReadInt32();
            if (localindex != tableindex)
            {
                AELogger.Log(" localindex " + localindex + " != tableindex " + tableindex);
            }
            int subcount = reader.ReadInt32();
            unk08 = reader.ReadInt32();
            unk0C = reader.ReadInt32();
            subsubEntries.Clear();
            subsubIndices.Clear();
            subsubPointers.Clear();

            for (int i = 0; i < subcount; i++)
            {
                subsubPointers.Add(reader.ReadUInt32());
                subsubIndices.Add(reader.ReadInt32());
            }

            for (int i = 0; i < subcount; i++)
            {
                int currentSize;
                if (i == subcount - 1)
                {
                    currentSize = (int)nextPointer - ((int)subsubPointers[i] + (int)originalPointer);
                }
                else
                {
                    currentSize = (int)subsubPointers[i+1] - (int)subsubPointers[i];
                }
                reader.BaseStream.Seek(originalPointer + subsubPointers[i], SeekOrigin.Begin);

                subsubEntries.Add(reader.ReadBytes(currentSize));
            }
        }

        public void WriteData(BinaryWriter writer)
        {
            int subcount = subsubEntries.Count;
            if (localindex != tableindex)
            {
                AELogger.Log(" localindex " + localindex + " != tableindex " + tableindex);
            }

            writer.Write(localindex);
            writer.Write(subcount);
            writer.Write(unk08);
            writer.Write(unk0C);
            int pointer = 16 + (subcount * 8);
            for (int i = 0; i < subcount; i++)
            {
                writer.Write(pointer);
                writer.Write(subsubIndices[i]);
                pointer += subsubEntries[i].Length;
            }
            for (int i = 0; i < subcount; i++)
            {
#if DEBUG
                AELogger.Log("position is: " + writer.BaseStream.Position + " / " + writer.BaseStream.Length + " and about to write " + subsubEntries[i].Length);
#endif
                writer.Write(subsubEntries[i]);
            }
        }

        public int GetSize()
        {
            int subsubcount = subsubEntries.Count;
            size = 16 + (subsubcount * 8);
            for (int i = 0; i < subsubcount; i++)
            {
                size += subsubEntries[i].Length;
            }
            return size;
        }

        public AnmChrSubEntry Copy()
        {
            AnmChrSubEntry output = new AnmChrSubEntry();
            output.localindex = localindex;
            output.tableindex = localindex;
            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter writer=  new BinaryWriter(stream))
                {
                    WriteData(writer);
                    writer.Flush();
                    stream.Seek(0, SeekOrigin.Begin);
                    // dont close writer
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        output.SetData(reader, (uint)GetSize());
                    }
                }
            }
            output.bEdited = true;
            return output;
        }

        public BindingList<string> GetCommandList()
        {
            int subsubcount = subsubEntries.Count;
            BindingList<string> output = new BindingList<string>();
            
            for (int i = 0; i < subsubcount; i++)
            {
                output.Add(GetSubSubName(i));
            }
            return output;
        }

        public string GetName()
        {
            sb.Clear();

            sb.Append("time ");
            sb.Append(localindex.ToString("000;-00"));

            sb.Append(": ");
            sb.Append(subsubEntries.Count);
            sb.Append(" cmds");

            return sb.ToString();
        }

        public String GetSubSubName(int i)
        {
            sb.Clear();
            int currentCount = subsubEntries[i].Length;
            if (currentCount > 4)
            {
                if (cmdNames != null)
                {
                    long header = ((long)subsubEntries[i][0] << 32) + (long)subsubEntries[i][4];
                    if (cmdNames.ContainsKey(header))
                    {
                        return cmdNames[header];
                    }
                }
                
                //sb.Append("cmd ");
                sb.Append(subsubEntries[i][0].ToString("X"));
                sb.Append("_");
                sb.Append(subsubEntries[i][4].ToString("X2"));
            }
            else
            {
                sb.Append("unk");
                sb.Append(subsubPointers[i]);
                sb.Append(" w size ");
                sb.Append(currentCount);
            }
            return sb.ToString();
        }
    }
}
