using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace MarvelData
{
    public class StructEntryBase : TableEntry
    {
        // NO IMPLEMENTATION
        public virtual object GetDataObject()
        {
            throw new NotImplementedException();
        }

        public virtual void SetDataObject(object o)
        {
            throw new NotImplementedException();
        }
    }

    public class StructEntry<T> : StructEntryBase where T : struct
    {
        public T data;

        public override byte[] GetData()
        {
            byte[] output = new byte[size];
            IntPtr dataPtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(data, dataPtr, true);
            Marshal.Copy(dataPtr, output, 0, size);
            Marshal.FreeHGlobal(dataPtr);

            return output;
        }

        public override void SetData(byte[] bytes)
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            data = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
        }

        public override object GetDataObject()
        {
            return (object)data;
        }

        public override void SetDataObject(object o)
        {
            if (o is T)
            {
                data = (T)o;
            }
            else
            {
                throw new Exception("WRONG DATA, BIG ERROR");
            }
        }

        /*
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
        */

        /*
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
        */

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
