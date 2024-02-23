using System;
using System.Collections.Generic;
using Microsoft.Collections.Extensions;

namespace Story_Crafter.Config {
    public class KsEditions {
        public IReadOnlyDictionary<string, Edition> Editions => editions;

        readonly OrderedDictionary<string, Edition> editions = new();

        public KsEditions() {
        }

        public void AddEdition(Edition item) {
            editions.Add(item.Name, item);
        }

        public struct Edition {
            public string Key;
            public string Name;
            public ObjectBankDefinition[] ObjectBanks;
        }
    }
}
