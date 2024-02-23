using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Story_Crafter.Assets {
    public class GlobalAssetSource : BaseAssetSource {
        string tilesetsDir;
        string gradientsDir;
        string objectsDir;

        public GlobalAssetSource(string ksDir) {
            tilesetsDir = Path.Combine(ksDir, "Data/Tilesets");
            gradientsDir = Path.Combine(ksDir, "Data/Gradients");
            objectsDir = Path.Combine(ksDir, "Data/Objects");
        }

        public override string GradientPath(uint index) {
            string path = Path.Combine(gradientsDir, $"Gradient{index}.png");
            return File.Exists(path) ? path : null;
        }

        public override string ObjectPath(uint bank, uint index) {
            string path = Path.Combine(objectsDir, $"Bank{bank}/Object{index}.png");
            return File.Exists(path) ? path : null;
        }

        public override string TilesetPath(uint index) {
            string path = Path.Combine(tilesetsDir, $"Tileset{index}.png");
            return File.Exists(path) ? path : null;
        }
    }
}
