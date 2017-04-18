using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace MarvelData
{
    /*
    public unsafe class StatusEntry : TableEntry
    {
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

        public override string GetFilename()
        {
            if (name == "unknown")
            {
                return index.ToString("X3") + "status";
            }
            else
            {
                return base.GetFilename();
            }
        }
    }
    */
}
