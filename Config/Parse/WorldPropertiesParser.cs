using System;
using System.IO;
using Tommy;

namespace Story_Crafter.Config.Parse {
    public static class WorldPropertiesParser {
        public static WorldProperties Parse(string path) {
            TomlTable props;
            using (var reader = new StreamReader(path)) {
                props = TOML.Parse(reader);
            }

            WorldProperties worldProps = new();

            TomlTable entries = props["difficulties"].AsTable;
            foreach (string key in entries.Keys) {
                worldProps.AddDifficulty(new WorldProperties.Difficulty {
                    Name = key,
                    Description = entries[key]["description"].AsString,
                });
            }

            entries = props["categories"].AsTable;
            foreach (string key in entries.Keys) {
                worldProps.AddCategory(new WorldProperties.Category {
                    Name = key,
                    Description = entries[key]["description"].AsString,
                });
            }

            entries = props["sizes"].AsTable;
            foreach (string key in entries.Keys) {
                worldProps.AddSize(new WorldProperties.Size {
                    Name = key,
                    Description = entries[key]["description"].AsString,
                });
            }

            return worldProps;
        }
    }
}
