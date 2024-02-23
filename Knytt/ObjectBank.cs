using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Story_Crafter.Knytt {
    class ObjectBank: IEnumerable<Tuple<int, Bitmap>> {
        public int Index, AbsoluteIndex;
        public string Name;
        private List<Tuple<int, Bitmap>> Objects;
        public int Count {
            get { return Objects.Count; }
        }

        private static Tuple<int, Bitmap> ObjectZero = new Tuple<int, Bitmap>(0, null);

        public Bitmap this[int i] {
            get {
                foreach(Tuple<int, Bitmap> t in this.Objects) {
                    if(t.Item1 == i) return t.Item2;
                }
                return null;
            }
        }
        public int AbsoluteIndexOf(int i) {
            for(int j = 0; j < this.Objects.Count; j++) {
                if(this.Objects[j].Item1 == i) return j;
            }
            return -1;
        }
        public Tuple<int, Bitmap> ByAbsoluteIndex(int i) {
            return i < Objects.Count ? Objects[i] : null;
        }

        private static int doSort(Tuple<int, Bitmap> a, Tuple<int, Bitmap> b) {
            return a.Item1 - b.Item1;
        }
        public ObjectBank(int index, string name, List<Tuple<int, Bitmap>> objects) {
            this.Index = index;
            this.Name = name;
            this.Objects = objects;
            objects.Sort(ObjectBank.doSort);
            objects.Insert(0, ObjectBank.ObjectZero);
        }
        public IEnumerator<Tuple<int, Bitmap>> GetEnumerator() {
            return this.Objects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.Objects.GetEnumerator();
        }
    }
}
