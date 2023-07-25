using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Screen = Story_Crafter.Knytt.Screen;

namespace Story_Crafter.Panes {
    interface IEditorPane {
        void ChangeScreen(Screen screen);
    }
}
