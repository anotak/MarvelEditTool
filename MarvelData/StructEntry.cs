using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace MarvelData
{
    public unsafe class StructEntry<T> : TableEntry where T : struct
    {
        public T data;
        public IntPtr dataPtr;

        public StructEntry() : base()
        {
            
        }

        public override byte[] GetData()
        {
            if (size == 0)
            {
                throw new Exception("SIZE IS 0");
            }
            byte[] output = new byte[size];

            byte* ptr = (byte*)dataPtr;
            for (int i = 0; i < size; i++)
            {
                output[i] = *ptr;
                ptr++;
            }

            return output;
        }

        public override void SetData(byte[] newdata)
        {
            if (size == 0)
            {
                throw new Exception("SIZE IS 0");
            }
            if (dataPtr == IntPtr.Zero)
            {
                dataPtr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(data, dataPtr, true);
            }
            bHasData = true;
            
            byte* ptr = (byte*)dataPtr;
            for (int i = 0; i < size; i++)
            {
                //AELogger.Log(i + " ASDF " + sizeof(StatusChunk));
                //AELogger.Log(newdata[i] + " is data");
                *ptr = newdata[i];
                ptr++;
            }
        }

        public override string GetFilename()
        {
            if (name == "unknown")
            {
                return index.ToString("X3") + typeof(T).Name;
            }
            else
            {
                return base.GetFilename();
            }
        }
    }
}
