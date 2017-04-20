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

        public virtual void SetData(byte[] bytes, int offset)
        {
            throw new NotImplementedException();
        }
    }

    public class StructEntry<T> : StructEntryBase where T : struct
    {
        public T data;

        public override byte[] GetData()
        {
            if (bHasData)
            {
                byte[] output = new byte[size];
                IntPtr dataPtr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(data, dataPtr, true);
                Marshal.Copy(dataPtr, output, 0, size);
                Marshal.FreeHGlobal(dataPtr);

                return output;
            }
            else
            {
                throw new Exception("NO DATA FOR GETDATA");
            }
        }

        public override void SetData(byte[] bytes, int offset)
        {
            if (bytes.Length - offset < size)
            {
                throw new Exception("WRONG SIZE IMPORT, IMPLODING " + (bytes.Length - offset) + " is real, vs expected " + size); // FIXME THIS SUCKS
            }
            bHasData = true;
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            data = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject() + offset, typeof(T));
            handle.Free();
        }

        public override void SetData(byte[] bytes)
        {
            if (bytes.Length != size)
            {
                throw new Exception("WRONG SIZE IMPORT, IMPLODING " + bytes.Length + " is real, vs expected " + size); // FIXME THIS SUCKS
            }
            bHasData = true;
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            data = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
        }

        public override object GetDataObject()
        {
            if (bHasData)
            {
                return (object)data;
            }
            else
            {
                throw new Exception("NO DATA FOR GETDATA");
            }
        }

        public override void SetDataObject(object o)
        {
            if (o is T)
            {
                bHasData = true;
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
