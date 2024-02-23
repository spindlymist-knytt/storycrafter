using System;
using System.Collections.Generic;
using System.IO;
using Tommy;

namespace Story_Crafter.Config.Parse {
    public static class KsEditionsParser {
        public static KsEditions Parse(string directory) {
            KsEditions editions = new();
            foreach (string path in Directory.EnumerateFiles(directory)) {
                editions.AddEdition(ParseEdition(path));
            }

            return editions;
        }

        static KsEditions.Edition ParseEdition(string path) {
            TomlTable props;
            using (var reader = new StreamReader(path)) {
                props = TOML.Parse(reader);
            }

            List<ObjectBankDefinition> banks = new();
            TomlTable entries = props["banks"].AsTable;
            foreach (string key in entries.Keys) {
                uint index = uint.Parse(key);
                banks.Add(ParseObjectBank(index, entries[key].AsTable));
            }

            return new KsEditions.Edition {
                Key = props["key"].AsString,
                Name = props["name"].AsString,
                ObjectBanks = banks.ToArray(),
            };
        }

        static ObjectBankDefinition ParseObjectBank(uint index, TomlTable props) {
            List<ObjectBankDefinition.Range> ranges = new();

            foreach (TomlArray range in props["ranges"].AsArray) {
                ranges.Add(new ObjectBankDefinition.Range {
                    Start = (uint) range[0].AsInteger,
                    End = (uint) range[1].AsInteger,
                    Path = range[2].AsString ?? $"%data%/Objects/Bank{index}",
                });
            }

            return new ObjectBankDefinition {
                Index = index,
                Name = props["name"].AsString,
                Ranges = ranges.ToArray(),
            };
        }
    }
}
