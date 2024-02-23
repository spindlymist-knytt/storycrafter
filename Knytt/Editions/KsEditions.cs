using System;
using System.Collections.Generic;
using Microsoft.Collections.Extensions;
using Story_Crafter.Knytt.Editions;

namespace Story_Crafter.Knytt.Editions
{
    public partial class KsEditions {
        public IReadOnlyDictionary<string, Edition> Editions => editions;

        readonly OrderedDictionary<string, Edition> editions = new();

        public KsEditions() {
        }

        public void AddEdition(Edition item) {
            editions.Add(item.Key, item);
        }

        public struct Edition {
            public string Key;
            public string Name;
            public ObjectBankDefinition[] ObjectBanks;
        }
    }
}
