using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Story_Crafter.Assets {
    public class AssetSourceChain : IAssetSource {
        List<IAssetSource> sources = new List<IAssetSource>();

        public AssetSourceChain() { }

        public AssetSourceChain(IEnumerable<IAssetSource> sources) {
            this.sources.AddRange(sources.Reverse());
        }

        public AssetSourceChain(params IAssetSource[] sources) {
            this.sources.AddRange(sources.Reverse());
        }

        public void AddPrioritySource(IAssetSource source) {
            sources.Prepend(source);
        }

        public void AddFallbackSource(IAssetSource source) {
            sources.Append(source);
        }

        public string GradientPath(uint index) {
            return sources
                .Select(source => source.GradientPath(index))
                .FirstOrDefault(value => value != null, null);
        }

        public FileStream GradientStream(uint index) {
            return sources
                .Select(source => source.GradientStream(index))
                .FirstOrDefault(value => value != null, null);
        }

        public string ObjectPath(uint bank, uint index) {
            return sources
                .Select(source => source.ObjectPath(bank, index))
                .FirstOrDefault(value => value != null, null);
        }

        public FileStream ObjectStream(uint bank, uint index) {
            return sources
                .Select(source => source.ObjectStream(bank, index))
                .FirstOrDefault(value => value != null, null);
        }

        public string TilesetPath(uint index) {
            return sources
                .Select(source => source.TilesetPath(index))
                .FirstOrDefault(value => value != null, null);
        }

        public FileStream TilesetStream(uint index) {
            return sources
                .Select(source => source.TilesetStream(index))
                .FirstOrDefault(value => value != null, null);
        }

        public Image TilesetRGBA(uint index, bool withInfo = false) {
            return sources
                .Select(source => source.TilesetRGBA(index, withInfo))
                .FirstOrDefault(value => value.Data != null, Image.None);
        }

        public Image GradientRGBA(uint index) {
            return sources
                .Select(source => source.GradientRGBA(index))
                .FirstOrDefault(value => value.Data != null, Image.None);
        }

        public Image ObjectRGBA(uint bank, uint index) {
            return sources
                .Select(source => source.ObjectRGBA(bank, index))
                .FirstOrDefault(value => value.Data != null, Image.None);
        }
    }
}
