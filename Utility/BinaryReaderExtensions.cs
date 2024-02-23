using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Story_Crafter.Utility {
    public static class BinaryReaderExtensions {
        public static string ReadStringNullTerminated(this BinaryReader reader) {
            List<byte> list = new(10);
            byte nextByte;

            try {
                nextByte = reader.ReadByte();
            }
            catch (EndOfStreamException) {
                return null;
            }

            while (nextByte != 0) {
                list.Add(nextByte);
                nextByte = reader.ReadByte();
            }

            return Encoding.UTF8.GetString(list.ToArray());
        }
    }
}
