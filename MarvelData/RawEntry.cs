using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarvelData
{
    public class RawEntry : TableEntry
    {
        public byte[] data;

        public override byte[] GetData()
        {
            if(!bHasData)
            {
                throw new Exception("NO DATA HAD");
            }
            return data;
        }

        public override void SetData(byte[] newdata)
        {
            bHasData = true;
            data = newdata;
            size = data.Length;
        }
    }
}
