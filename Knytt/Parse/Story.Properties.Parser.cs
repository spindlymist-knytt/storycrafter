using System;
using System.Collections.Generic;
using System.Text;

using IniParser;
using IniParser.Parser;
using IniParser.Model;

using Story_Crafter.Knytt.Primitives;
using Story_Crafter.Utility;

namespace Story_Crafter.Knytt {
    public partial class Story {
        public partial class Properties {
            public static class Parser {
                public static Properties Parse(string path) {
                    IniDataParser dataParser = new();
                    dataParser.Configuration.CaseInsensitive = true;
                    dataParser.Configuration.AllowDuplicateKeys = true;
                    dataParser.Configuration.AllowDuplicateSections = true;
                    dataParser.Configuration.SkipInvalidLines = true;

                    FileIniDataParser fileParser = new(dataParser);
                    IniData ini = fileParser.ReadFile(path, Encoding.Latin1);
                    var world = ini["World"];

                    return new Properties {
                        Author = world["Author"],
                        Name = world["Name"],
                        Description = world["Description"],
                        CategoryA = world["Category A"],
                        CategoryB = world["Category B"],
                        DifficultyA = world["Difficulty A"],
                        DifficultyB = world["Difficulty B"],
                        DifficultyC = world["Difficulty C"],
                        Size = world["Size"],
                        ClothesColor = ParseColor(world["Clothes"], Metrics.DefaultClothes),
                        SkinColor = ParseColor(world["Skin"], Metrics.DefaultSkin),
                        Format = world.ReadInt("Format", 1),
                    };
                }

                public static Color ParseColor(string prop, Color defaultColor) {
                    if (int.TryParse(prop, out int value)) {
                        return Color.FromKnyttColor(value);
                    }
                    else {
                        return defaultColor;
                    }
                }
            }
        }
    }
}
