using System;
using System.Collections.Generic;
using Microsoft.Collections.Extensions;

namespace Story_Crafter.Config {
    public class WorldProperties {
        public IReadOnlyDictionary<string, Category> Categories => categories;
        public IReadOnlyDictionary<string, Difficulty> Difficulties => difficulties;
        public IReadOnlyDictionary<string, Size> Sizes => sizes;

        readonly OrderedDictionary<string, Category> categories = new();
        readonly OrderedDictionary<string, Difficulty> difficulties = new();
        readonly OrderedDictionary<string, Size> sizes = new();

        public WorldProperties() {
        }

        public void AddCategory(Category item) {
            categories.Add(item.Name, item);
        }

        public void AddDifficulty(Difficulty item) {
            difficulties.Add(item.Name, item);
        }

        public void AddSize(Size item) {
            sizes.Add(item.Name, item);
        }

        public struct Category {
            public string Name;
            public string Description;
        }

        public struct Difficulty {
            public string Name;
            public string Description;
        }

        public struct Size {
            public string Name;
            public string Description;
        }
    }
}
