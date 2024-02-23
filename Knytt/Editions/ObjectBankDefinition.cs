using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Crafter.Knytt.Editions {
    public partial struct ObjectBankDefinition {
        public struct Range {
            public uint Start;
            public uint End;
            public string Path;
        }

        public uint Index;
        public string Name;
        public Range[] Ranges;
    }
}
