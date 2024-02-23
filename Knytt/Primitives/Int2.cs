using System;

namespace Story_Crafter.Knytt.Primitives {
    public struct Int2 {
        public int X = 0;
        public int Y = 0;

        public static readonly Int2 Zero = new() { X = 0, Y = 0 };

        public Int2() { }

        public Int2(int x, int y) {
            X = x;
            Y = y;
        }

        // Conversions

        public static implicit operator System.Drawing.Point(Int2 from) {
            return new System.Drawing.Point { X = from.X, Y = from.Y };
        }

        public static explicit operator Int2(System.Drawing.Point from) {
            return new Int2 { X = from.X, Y = from.Y };
        }

        public static implicit operator Microsoft.Xna.Framework.Point(Int2 from) {
            return new Microsoft.Xna.Framework.Point { X = from.X, Y = from.Y };
        }

        public static explicit operator Int2(Microsoft.Xna.Framework.Point from) {
            return new Int2 { X = from.X, Y = from.Y };
        }

        public override string ToString() {
            return $"x{X}y{Y}";
        }

        public static bool TryFromString(string value, out Int2 position) {
            position = Int2.Zero;

            if (value.Length < 4 || value[0] != 'x') return false;

            string[] parts = value[1..].Split('y');
            if (parts.Length != 2) return false;

            if (!int.TryParse(parts[0], out position.X)) return false;
            if (!int.TryParse(parts[1], out position.Y)) return false;

            return true;
        }

        // Equality

        public override bool Equals(object obj) {
            return obj is Int2 other && this.Equals(other);
        }

        public bool Equals(Int2 other) {
            return X == other.X && Y == other.Y;
        }

        public static bool operator ==(Int2 left, Int2 right) {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator !=(Int2 left, Int2 right) {
            return left.X != right.X || left.Y != right.Y;
        }

        public override int GetHashCode() {
            return HashCode.Combine(X, Y);
        }
    }
}
