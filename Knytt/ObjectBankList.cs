using System;
using System.Collections;
using System.Collections.Generic;

namespace Story_Crafter.Knytt {
    class ObjectBankList: IEnumerable<ObjectBank> {
        private List<ObjectBank> banks = new List<ObjectBank>();
        public int Count {
            get { return banks.Count; }
        }

        public ObjectBank this[int i] {
            get {
                foreach(ObjectBank b in this.banks) {
                    if(b.Index == i) return b;
                }
                return null;
            }
        }
        public ObjectBank ByAbsoluteIndex(int i) {
            return this.banks[i];
        }

        private static int doSort(ObjectBank a, ObjectBank b) {
            return a.Index - b.Index;
        }
        public void SortBanks() {
            this.banks.Sort(ObjectBankList.doSort);
            for(int i = 0; i < this.banks.Count; i++) {
                this.banks[i].AbsoluteIndex = i;
            }
        }

        public void Add(ObjectBank b) {
            b.AbsoluteIndex = this.banks.Count;
            this.banks.Add(b);
        }
        public void Clear() {
            this.banks.Clear();
        }
        /*public void Merge(ObjectBankList otherList) {
          foreach(ObjectBank other in otherList.banks) {
            ObjectBank b = this[other.Index];
            if(b != null) {
              b.Merge(other);
            }
            else {
              banks.Add(b);
            }
          }
        }*/

        IEnumerator IEnumerable.GetEnumerator() {
            return banks.GetEnumerator();
        }

        public IEnumerator<ObjectBank> GetEnumerator() {
            return banks.GetEnumerator();
        }
    }
}
