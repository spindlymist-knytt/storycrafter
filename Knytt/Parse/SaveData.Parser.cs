using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using IniParser;
using IniParser.Parser;
using IniParser.Model;

using Story_Crafter.Utility;

namespace Story_Crafter.Knytt {
    public partial struct SaveData {
        public static class Parser {
            public static SaveData Parse(string path) {
                IniDataParser dataParser = new();
                dataParser.Configuration.AllowCreateSectionsOnFly = true;
                dataParser.Configuration.CaseInsensitive = true;
                dataParser.Configuration.AllowDuplicateKeys = true;
                dataParser.Configuration.AllowDuplicateSections = true;
                dataParser.Configuration.SkipInvalidLines = true;

                FileIniDataParser fileParser = new(dataParser);
                IniData ini = fileParser.ReadFile(path, Encoding.Latin1);

                var powersSection = ini["Powers"];
                bool[] powers = new bool[12];
                for (int i = 0; i < powers.Length; i++) {
                    string key = $"Power{i}";
                    powers[i] = powersSection?[key] == "1";
                }

                var positions = ini["Positions"];

                return new SaveData {
                    MapX = positions.ReadInt("X Map", 1000),
                    MapY = positions.ReadInt("Y Map", 1000),
                    ScreenX = positions.ReadInt("X Pos", 0),
                    ScreenY = positions.ReadInt("Y Pos", 0),
                    Powers = powers,
                };
            }
        }
    }
}
