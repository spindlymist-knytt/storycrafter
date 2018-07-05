using System;
using System.Collections.Generic;

using System.Text;

namespace Story_Crafter {
    // A custom MemoryStream that works more like I think it ought to:
    //  * ReadByte() throws an IOException at the end of the stream.
    //  * Read returns a buffer rather than taking one as an argument.
    class MemoryStream: System.IO.MemoryStream {
        public override int ReadByte() {
            int b = base.ReadByte();
            if(b == -1) throw new System.IO.IOException();
            return b;
        }
        public byte[] Read(int len) {
            byte[] bytes = new byte[len];
            base.Read(bytes, 0, len);
            return bytes;
        }

        public void Write(string val) {
        }
    }
}
