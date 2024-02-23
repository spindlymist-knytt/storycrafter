using System;
using System.Collections.Generic;

using IniParser.Model;

namespace Story_Crafter.Utility {
    public static class IniDataExtensions {
        public static int ReadInt(this IniData ini, string sectionKey, string propertyKey, int defaultValue) {
            var section = ini[sectionKey];
            return section?.ReadInt(propertyKey, defaultValue) ?? defaultValue;
        }
    }

    public static class KeyDataCollectionExtensions {
        public static int ReadInt(this KeyDataCollection section, string propertyKey, int defaultValue) {
            if (int.TryParse(section[propertyKey], out int value)) {
                return value;
            }
            else {
                return defaultValue;
            }
        }
    }
}
