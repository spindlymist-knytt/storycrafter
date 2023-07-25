using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;

namespace Story_Crafter.Knytt {
    class Profile {
        private struct BankDef {
            public int Index;
            public string Name;
            public string[] Paths;
            public string[] Indices;

            public BankDef(int index, string name, string path, string indices) {
                Index = index;
                Name = name;
                Paths = new string[1] { path };
                Indices = new string[1] { indices };
            }
            public BankDef(int index, string name, string[] paths, string[] indices) {
                Index = index;
                Name = name;
                Paths = paths;
                Indices = indices;
            }
        }

        public static List<Profile> Profiles = new List<Profile>();

        public string ID;
        public string Name;

        //private string baseProfiles;
        private List<BankDef> banks = new List<BankDef>();

        public Profile(XmlElement el) {
            this.ID = el.Attributes["id"].Value;
            this.Name = el.Attributes["name"].Value;

            foreach(XmlElement bank in el["banks"].GetElementsByTagName("bank")) {
                int index = int.Parse(bank.Attributes["index"].Value);
                if(bank.HasChildNodes) {
                    XmlNodeList srcs = bank.GetElementsByTagName("src");
                    string[] paths = new string[srcs.Count];
                    string[] indices = new string[srcs.Count];
                    for(int i = 0; i < srcs.Count; i++) {
                        paths[i] = srcs[i].Attributes["path"].Value.Replace("%ks%", Program.Path);
                        indices[i] = srcs[i].Attributes["objects"].Value;
                    }
                    banks.Add(new BankDef(index, bank.Attributes["name"].Value, paths, indices));
                }
                else {
                    banks.Add(new BankDef(index, bank.Attributes["name"].Value, Program.ObjectsPath + @"\Bank" + index, bank.Attributes["objects"].Value));
                }
            }
            //baseProfiles = el.Attributes["base"].Value;
            Profile.Profiles.Add(this);
        }

        public ObjectBankList Load() {
            ObjectBankList bankList = new ObjectBankList();

            /*foreach(string b in baseProfiles.Split(' ')) {
              foreach(Profile p in Profile.Profiles) {
                if(p.ID == b) bankList.Merge(p.Load());
              }
            }

            ObjectBankList newList = new ObjectBankList();*/
            foreach(BankDef def in banks) {
                List<Tuple<int, Bitmap>> objects = new List<Tuple<int, Bitmap>>();
                for(int i = 0; i < def.Paths.Length; i++) {
                    List<int> bounds = new List<int>();
                    string[] unparsed = def.Indices[i].Split(new char[] { ' ', '-' });
                    foreach(string s in unparsed) {
                        bounds.Add(int.Parse(s));
                    }
                    for(int r = 0; r < bounds.Count; r += 2) {
                        for(int j = bounds[r]; j <= bounds[r + 1]; j++) {
                            Bitmap b = Program.LoadBitmap(def.Paths[i] + @"\Object" + j + ".png");
                            b.MakeTransparent(Color.Magenta);
                            objects.Add(Tuple.Create<int, Bitmap>(j, b));
                        }
                    }
                }
                bankList.Add(new ObjectBank(def.Index, def.Name, objects));
            }
            bankList.SortBanks();
            //bankList.Merge(newList);

            return bankList;
        }
    }
}
