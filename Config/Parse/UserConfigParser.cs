using System;
using System.IO;
using Tommy;

namespace Story_Crafter.Config.Parse {
    public static class UserConfigParser {
        public static UserConfig Parse(string path) {
            TomlTable props;
            using (var reader = new StreamReader(path)) {
                props = TOML.Parse(reader);
            }

            return new UserConfig {
                KsDirectory = props["ksdirectory"].AsString,
            };
        }
    }
}
