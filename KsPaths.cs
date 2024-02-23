using System;
using System.IO;

namespace Story_Crafter {
    public class KsPaths {
        public string KS { get; private set; }
        public string Worlds { get; private set; }
        public string Data { get; private set; }

        public KsPaths(string ksDirectory) {
            KS = ksDirectory;
            Worlds = Path.Combine(ksDirectory, "Worlds");
            Data = Path.Combine(ksDirectory, "Data");
        }
    }
}
