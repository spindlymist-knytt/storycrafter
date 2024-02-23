using Story_Crafter.Utility;
using System;
using System.IO;

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

                var position = ParsePosition(key);
                if (position == null) {
                    byte[] buffer = new byte[byteLength];
                    reader.Read(buffer, 0, (int) byteLength);
                    return true;
                }
                if (byteLength < 3006) {
                    throw new FileCorruptException("Byte length is less than the minimum.");
                }

                screen = new Screen();
                screen.X = position.Item1;
                screen.Y = position.Item2;

                // Now begin reading actual tile data.
                screen.RawData = reader.ReadBytes(3000);
                if (screen.RawData.Length < 3000) {
                    throw new FileCorruptException("Not enough data.");
                }

                int offset = 0;
                for (int i = 0; i < 4; i++) { // Tile layers.
                    screen.Layers[i] = new TileLayer(i, screen.RawData, offset);
                    offset += 250;
                }
                for (int i = 4; i < 8; i++) { // Object layers.
                    screen.Layers[i] = new ObjectLayer(i, screen.RawData, offset);
                    offset += 500;
                }

                // Read which assets the screen uses.
                try {
                    screen.TilesetA = reader.ReadByte();
                    screen.TilesetB = reader.ReadByte();
                    screen.AmbianceA = reader.ReadByte();
                    screen.AmbianceB = reader.ReadByte();
                    screen.Music = reader.ReadByte();
                    screen.Gradient = reader.ReadByte();
                }
                catch (EndOfStreamException) {
                    throw new FileCorruptException("Assets are missing.");
                }

                return true;
            }

            private static Tuple<int, int> ParsePosition(string position) {
                if (position.Length < 4 || position[0] != 'x') return null;

                string[] parts = position[1..].Split('y');
                if (parts.Length != 2) return null;

                int x, y;
                if (!int.TryParse(parts[0], out x)) return null;
                if (!int.TryParse(parts[1], out y)) return null;

                return Tuple.Create(x, y);
            }
        }
    }
}
