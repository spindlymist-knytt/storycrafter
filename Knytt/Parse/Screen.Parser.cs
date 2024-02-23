using System;
using System.IO;

using Story_Crafter.Knytt.Primitives;
using Story_Crafter.Utility;

namespace Story_Crafter.Knytt {

    /** 
     * Format of Map.bin data:   
     * 
     *    1 byte     x
     *   ?? bytes    X coordinate (ASCII)
     *    1 byte     y
     *   ?? bytes    Y coordinate (ASCII)
     *    5 bytes    00 BE 0B 00 00
     *  250 bytes    Layer 0 tile indices (80-FF is tileset B)
     *  250 bytes    Layer 1 tile indices
     *  250 bytes    Layer 2 tile indices
     *  250 bytes    Layer 3 tile indices
     *  250 bytes    Layer 4 object indices
     *  250 bytes    Layer 4 banks
     *  250 bytes    Layer 5 object indices
     *  250 bytes    Layer 5 banks
     *  250 bytes    Layer 6 object indices
     *  250 bytes    Layer 6 banks
     *  250 bytes    Layer 7 object indices
     *  250 bytes    Layer 7 banks
     *    1 byte     Tileset A
     *    1 byte     Tileset B
     *    1 byte     Music
     *    1 byte     Ambiance A
     *    1 byte     Ambiance B
     *    1 byte     Gradient
     */

    public partial class Screen {
        public static class Parser {
            public static bool Parse(BinaryReader reader, out Screen screen) {
                screen = null;

                string key = reader.ReadStringNullTerminated();
                if (key == null) return false;

                uint byteLength;
                try {
                    byteLength = reader.ReadUInt32();
                }
                catch (EndOfStreamException) {
                    throw new FileCorruptException("Byte length is missing.");
                }

                if (!Int2.TryFromString(key, out Int2 position)) {
                    byte[] buffer = new byte[byteLength];
                    reader.Read(buffer, 0, (int) byteLength);
                    return true;
                }

                if (byteLength < DATA_LENGTH) {
                    throw new FileCorruptException("Byte length is less than the minimum.");
                }

                byte[] data = reader.ReadBytes((int) DATA_LENGTH);
                if (data.Length < DATA_LENGTH) {
                    throw new FileCorruptException("Not enough data.");
                }

                uint extraBytes = byteLength - DATA_LENGTH;
                if (extraBytes > 0) {
                    byte[] buffer = new byte[extraBytes];
                    reader.Read(buffer, 0, (int) extraBytes);
                }

                screen = new Screen(position, data);

                return true;
            }
        }
    }
}
