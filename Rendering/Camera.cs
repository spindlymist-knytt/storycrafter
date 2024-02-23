using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Crafter.Rendering {
    public class Camera {
        public Matrix Matrix {
            get { return matrix; }
        }
        Matrix matrix = Matrix.Identity;

        public float Zoom {
            get { return zoom; }
            set {
                zoom = value;
                RecalculateMatrix();
            }
        }
        float zoom = 1.0f;

        public Vector2 Position {
            get { return position; }
            set {
                position = value;
                RecalculateMatrix();
            }
        }
        Vector2 position = Vector2.Zero;

        public Camera() {
        }

        public void SetPosition(float x, float y) {
            this.position.X = x;
            this.position.Y = y;
            RecalculateMatrix();
        }

        public void Translate(float x, float y) {
            position.X += x;
            position.Y += y;
        }

        void RecalculateMatrix() {
            Matrix translation = Matrix.CreateTranslation(position.X, position.Y, 0f);
            Matrix scale = Matrix.CreateScale(zoom, zoom, 1f);
            matrix = translation * scale;
        }
    }
}
