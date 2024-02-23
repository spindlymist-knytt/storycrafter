using System;

using Story_Crafter.Knytt;
using Story_Crafter.Knytt.Editions;
using Story_Crafter.Forms;
using Story_Crafter.Config;
using Story_Crafter.Rendering;
using Story_Crafter.Assets;
using Story_Crafter.Utility.Observables;

namespace Story_Crafter {
    public class Editor {
        public EditorForm Form { get; private set; }
        public UserConfig Config { get; private set; }
        public KsPaths Paths { get; private set; }
        public KsEditions Editions { get; private set; }
        public IReadable<Story> Story => currentStory;
        public IAssetSource Assets { get; private set; }
        public RenderingContext RenderContext { get; private set; }

        ObservableValue<Story> currentStory = new();

        public Editor() {
            LoadData();
            Form = new EditorForm(this);
            Form.RenderingContextReady += OnRenderingContextReady;
            Form.StorySelected += OnStorySelected;
        }

        public void LoadData() {
            Config = UserConfig.Parser.Parse("Resources/Config/user.toml");
            Paths = new KsPaths(Config.KsDirectory);
            Editions = KsEditions.Parser.Parse("Resources/Data/Editions");
        }

        public void SetKsDirectory(string path) {
            Config.KsDirectory = path;
            Paths = new KsPaths(Config.KsDirectory);
        }

        void OnRenderingContextReady(object sender, RenderingContext renderContext) {
            RenderContext = renderContext;
        }

        void OnStorySelected(object sender, string path) {
            Story story = Knytt.Story.Parser.FromDirectory(path);
            Assets = new AssetSourceChain(
                new GlobalAssetSource(Paths.KS),
                new StoryAssetSource(story));
            RenderContext.UploadAssets(Assets, Editions.Editions["plus"].ObjectBanks);

            currentStory.Value = story;
        }
    }
}
