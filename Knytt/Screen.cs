using System;

using Story_Crafter.Knytt.Primitives;

namespace Story_Crafter.Knytt {
    public partial class Screen {
        Int2 position;
        byte[] data;

        const uint DATA_LENGTH = 3006;
        const uint TILESET_A_OFFSET  = (DATA_LENGTH - 1) - 5;
        const uint TILESET_B_OFFSET  = (DATA_LENGTH - 1) - 4;
        const uint MUSIC_OFFSET      = (DATA_LENGTH - 1) - 3;
        const uint AMBIANCE_A_OFFSET = (DATA_LENGTH - 1) - 2;
        const uint AMBIANCE_B_OFFSET = (DATA_LENGTH - 1) - 1;
        const uint GRADIENT_OFFSET   = (DATA_LENGTH - 1) - 0;

        public Int2 Position {
            get { return position; }
            set { position = value; }
        }

        public byte[] Data {
            get { return data; }
            set {
                if (value != null && value.Length == DATA_LENGTH) {
                    data = value;
                }
            }
        }

        public int X {
            get { return position.X; }
            set { position.X = value; }
        }

        public int Y {
            get { return position.Y; }
            set { position.Y = value; }
        }

        public byte TilesetA {
            get { return Data[TILESET_A_OFFSET]; }
            set { Data[TILESET_A_OFFSET] = value; }
        }

        public byte TilesetB {
            get { return Data[TILESET_B_OFFSET]; }
            set { Data[TILESET_B_OFFSET] = value; }
        }

        public byte Music {
            get { return Data[MUSIC_OFFSET]; }
            set { Data[MUSIC_OFFSET] = value; }
        }

        public byte AmbianceA {
            get { return Data[AMBIANCE_A_OFFSET]; }
            set { Data[AMBIANCE_A_OFFSET] = value; }
        }

        public byte AmbianceB {
            get { return Data[AMBIANCE_B_OFFSET]; }
            set { Data[AMBIANCE_B_OFFSET] = value; }
        }

        public byte Gradient {
            get { return Data[GRADIENT_OFFSET]; }
            set { Data[GRADIENT_OFFSET] = value; }
        }

        public Screen() {
            Position = Int2.Zero;
            Data = new byte[3006];
        }

        public Screen(int x, int y) : this(new Int2(x, y)) { }

        public Screen(Int2 position) {
            Position = position;
            Data = new byte[3006];
        }

        public Screen(Int2 position, byte[] data) {
            Position = position;
            Data = data;
        }
    }
}
