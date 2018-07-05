using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Story_Crafter {
    public class ListViewItemComparer: System.Collections.IComparer {
        public int Column;
        public SortOrder Order;

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        private static extern int StrCmpLogicalW(string psz1, string psz2);

        public ListViewItemComparer() {
            this.Column = 0;
            this.Order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int col, SortOrder order = SortOrder.Ascending) {
            this.Column = col;
            this.Order = order;
        }
        public int Compare(object a, object b) {
            string first = ((ListViewItem)a).SubItems[this.Column].Text;
            string second = ((ListViewItem)b).SubItems[this.Column].Text;
            int compare = StrCmpLogicalW(first, second);
            return this.Order == SortOrder.Ascending ? compare : -compare;
        }
    }
}
