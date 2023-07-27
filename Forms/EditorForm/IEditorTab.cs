using Story_Crafter.Knytt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story_Crafter.Forms.EditorForm {
    interface IEditorTab {
        void TabOpened();
        void StoryChanged(Story story);
        void ScreenChanged(Screen screen);
    }
}
