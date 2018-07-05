using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter {
    partial class EditorForm {
        class AmbianceTab {
            EditorForm form;

            public AmbianceTab(EditorForm parent) {
                form = parent;
            }
            public void StoryChanged() {
            }
            public void TabOpened() {
            }
            public bool ProcessCmdKey(ref Message msg, Keys keyData) {
                return false;
            }
        }
    }
}
