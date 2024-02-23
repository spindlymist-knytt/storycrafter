using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.NET.Controls;

using Story_Crafter.Rendering;

namespace Story_Crafter.Controls {
    public class RenderingContextProvider : MonoGameControl {
        public RenderingContext RenderingContext { get; private set; }
        public event EventHandler<RenderingContext> RenderingContextReady;

        public RenderingContextProvider() {
            this.Size = System.Drawing.Size.Empty;
            this.GraphicsProfile = GraphicsProfile.HiDef;
        }

        protected override void Draw() {
        }

        protected override void Initialize() {
            this.Components.Clear();
            this.RenderingContext = new RenderingContext(Editor.GraphicsDevice, Editor.Content);
            this.RenderingContext.Initialize();
            this.RenderingContextReady.Invoke(this, this.RenderingContext);
            this.Visible = false;
        }

        protected override void Update(GameTime gameTime) {
        }
    }
}
