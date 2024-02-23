using System.IO;

namespace Story_Crafter.Assets {
    public interface IAssetSource {
        string TilesetPath(uint index);
        string GradientPath(uint index);
        string ObjectPath(uint bank, uint index);
        FileStream TilesetStream(uint index);
        FileStream GradientStream(uint index);
        FileStream ObjectStream(uint bank, uint index);
        Image TilesetRGBA(uint index, bool withInfo = false);
        Image GradientRGBA(uint index);
        Image ObjectRGBA(uint bank, uint index);
    }
}
