using Story_Crafter.Editing.Tools;
using Story_Crafter.Editing;
using Story_Crafter.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Story_Crafter.Knytt;
using SharpDX.Direct3D9;

namespace Story_Crafter.Panes {
    class EditingContext {
        public delegate void ToolChangedDelegate(ToolChangedArgs args);
        public delegate void TilesetSelectionChangedDelegate(TilesetSelectionChangedArgs args);
        public delegate void ObjectSelectionChangedDelegate(ObjectSelectionChangedArgs args);
        public delegate void ActiveScreenChangedDelegate(ActiveScreenChangedArgs args);
        public delegate void StoryChangedDelegate(StoryChangedArgs args);

        public event ToolChangedDelegate ToolChanged;
        public event TilesetSelectionChangedDelegate TilesetSelectionChanged;
        public event ObjectSelectionChangedDelegate ObjectSelectionChanged;
        public event ActiveScreenChangedDelegate ActiveScreenChanged;
        public event StoryChangedDelegate StoryChanged;

        public IEditingTool Tool {
            get { return tool; }
            set {
                tool = value;
                ToolChanged?.Invoke(new ToolChangedArgs {
                    tool = value,
                });
            }
        }
        public Tuple<int, Selection> TilesetSelection {
            get { return tilesetSelection ; }
            set {
                tilesetSelection = value;
                TilesetSelectionChanged?.Invoke(new TilesetSelectionChangedArgs {
                    selection = value,
                });
            }
        }
        public Tuple<int, int> ObjectSelection {
            get { return objectSelection; }
            set {
                objectSelection = value;
                ObjectSelectionChanged?.Invoke(new ObjectSelectionChangedArgs {
                    selection = value,
                });
            }
        }
        public Screen ActiveScreen {
            get { return activeScreen; }
            set {
                activeScreen = value;
                ActiveScreenChanged?.Invoke(new ActiveScreenChangedArgs {
                    screen = value,
                });
            }
        }
        public Story Story {
            get { return story; }
            set {
                story = value;
                StoryChanged?.Invoke(new StoryChangedArgs {
                    story = value,
                });
            }
        }

        IEditingTool tool;
        Tuple<int, Selection> tilesetSelection;
        Tuple<int, int> objectSelection;
        Screen activeScreen;
        Story story;

        public EditingContext() {
        }
    }

    struct ToolChangedArgs {
        public IEditingTool tool;
    }
    
    struct TilesetSelectionChangedArgs {
        public Tuple<int, Selection> selection;
    }
    
    struct ObjectSelectionChangedArgs {
        public Tuple<int, int> selection;
    }
    
    struct ActiveScreenChangedArgs {
        public Screen screen;
    }

    struct StoryChangedArgs {
        public Story story;
    }
}
