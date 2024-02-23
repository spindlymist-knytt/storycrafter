using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

using Story_Crafter.Knytt.Primitives;

namespace Story_Crafter.Knytt {
    public class FileCorruptException : Exception {
        public FileCorruptException(string message) : base(message) { }
    }

    public partial class Story {
        public static class Parser {
            public static Story FromDirectory(string path) {
                Story story = new();
                story.path = path;

                string worldIniPath = System.IO.Path.Combine(path, "World.ini");
                story.props = Properties.Parser.Parse(worldIniPath);

                string saveIniPath = System.IO.Path.Combine(path, "DefaultSavegame.ini");
                story.defaultSave = SaveData.Parser.Parse(saveIniPath);

                string mapBinPath = System.IO.Path.Combine(path, "Map.bin");
                story.screens = ParseScreens(mapBinPath);

                // If there are no screens, create a blank one to start on
                if (story.screens.Count == 0) {
                    story.AddScreen(new Screen(1000, 1000));
                }

                return story;
            }

            public static Dictionary<Int2, Screen> ParseScreens(string mapBinPath) {
                using FileStream fin = File.OpenRead(mapBinPath);
                using GZipStream gzipStream = new(fin, CompressionMode.Decompress);
                using BinaryReader reader = new(gzipStream);

                Dictionary<Int2, Screen> screens = new();

                while (Screen.Parser.Parse(reader, out Screen screen)) {
                    if (screen != null) {
                        screens.Add(new Int2(screen.X, screen.Y), screen);
                    }
                }

                return screens;
            }
        }
    }
}
