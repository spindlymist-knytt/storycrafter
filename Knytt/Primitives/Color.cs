using System;

namespace Story_Crafter.Knytt.Primitives {
    public struct Color {
        public uint ABGR = 0xFF000000;

        const int R_SHIFT = 0;
        const int G_SHIFT = 8;
        const int B_SHIFT = 16;
        const int A_SHIFT = 24;

        const uint R_MASK = (uint) 0xFF << R_SHIFT;
        const uint G_MASK = (uint) 0xFF << G_SHIFT;
        const uint B_MASK = (uint) 0xFF << B_SHIFT;
        const uint A_MASK = (uint) 0xFF << A_SHIFT;

        const uint CLEAR_R_MASK = ~R_MASK;
        const uint CLEAR_G_MASK = ~G_MASK;
        const uint CLEAR_B_MASK = ~B_MASK;
        const uint CLEAR_A_MASK = ~A_MASK;

        public byte R {
            get { return (byte) (ABGR >> R_SHIFT); }
            set {
                ABGR = (ABGR & CLEAR_R_MASK) | ((uint) value << R_SHIFT);
            }
        }

        public byte G {
            get { return (byte) (ABGR >> G_SHIFT); }
            set {
                ABGR = (ABGR & CLEAR_G_MASK) | ((uint) value << G_SHIFT);
            }
        }

        public byte B {
            get { return (byte) (ABGR >> B_SHIFT); }
            set {
                ABGR = (ABGR & CLEAR_B_MASK) | ((uint) value << B_SHIFT);
            }
        }

        public byte A {
            get { return (byte) (ABGR >> A_SHIFT); }
            set {
                ABGR = (ABGR & CLEAR_A_MASK) | ((uint) value << A_SHIFT);
            }
        }

        public Color() { }

        public Color(uint ABGR) {
            this.ABGR = ABGR;
        }

        public Color(byte r, byte g, byte b, byte a = 255) {
            ABGR = (uint) r << R_SHIFT
                | (uint) g << G_SHIFT
                | (uint) b << B_SHIFT
                | (uint) a << A_SHIFT;
        }

        public static Color FromRgb(byte r, byte g, byte b) {
            return new Color(r, g, b);
        }

        public static Color FromRgba(byte r, byte g, byte b, byte a) {
            return new Color(r, g, b, a);
        }

        public static Color FromKnyttColor(int color) {
            return new Color {
                ABGR = (uint) color,
            };
        }

        public int ToKnyttColor() {
            return (int) (ABGR & CLEAR_A_MASK);
        }

        // Conversions

        public static implicit operator System.Drawing.Color(Color from) {
            return System.Drawing.Color.FromArgb(from.A, from.R, from.G, from.B);
        }

        public static explicit operator Color(System.Drawing.Color from) {
            return new Color(from.R, from.G, from.B, from.A);
        }

        public static implicit operator Microsoft.Xna.Framework.Color(Color from) {
            return new Microsoft.Xna.Framework.Color(from.ABGR);
        }

        public static explicit operator Color(Microsoft.Xna.Framework.Color from) {
            return new Color(from.PackedValue);
        }

        // Equality

        public override bool Equals(object other) {
            return other is Color && Equals((Color) other);
        }

        public bool Equals(Color other) {
            return ABGR == other.ABGR;
        }

        public static bool operator ==(Color left, Color right) {
            return left.ABGR == right.ABGR;
        }

        public static bool operator !=(Color left, Color right) {
            return left.ABGR != right.ABGR;
        }

        public override int GetHashCode() {
            return ABGR.GetHashCode();
        }
    }
}
