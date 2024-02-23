using Story_Crafter.Knytt;
using System;
using System.Collections.Generic;
using System.IO;

namespace Story_Crafter.Assets {
    class StoryAssetSource : BaseAssetSource {
        string tilesetsDir;
        string gradientsDir;

        public StoryAssetSource(Story story) {
            tilesetsDir = Path.Combine(story.Path, "Tilesets");
            gradientsDir = Path.Combine(story.Path, "Gradients");
        }

        public override string GradientPath(uint index) {
            string path = Path.Combine(gradientsDir, $"Gradient{index}.png");
            return File.Exists(path) ? path : null;
        }

        public override string ObjectPath(uint bank, uint index) {
            return null;
        }

        public override string TilesetPath(uint index) {
            string path = Path.Combine(tilesetsDir, $"Tileset{index}.png");
            return File.Exists(path) ? path : null;
        }
    }
}
