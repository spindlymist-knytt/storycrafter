using System;
using System.Collections.Generic;

using Story_Crafter.Config.Parse;

namespace Story_Crafter.Config {
    public class StoryCrafterConfiguration {
        readonly string configDir;

        KsEditions editions;
        WorldProperties worldProps;
        UserConfig user;

        public StoryCrafterConfiguration(string configDir) {
            this.configDir = configDir;
        }

        public void Load() {
            worldProps = WorldPropertiesParser.Parse(Path("world_properties.toml"));
            editions = KsEditionsParser.Parse(Path("editions"));
            user = UserConfigParser.Parse(Path("user.toml"));
        }

        string Path(string relPath) {
            return System.IO.Path.Combine(configDir, relPath);
        }
    }
}
