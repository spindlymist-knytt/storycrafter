using System;
using System.ComponentModel;
using System.Windows.Forms;
using Story_Crafter.Utility;

namespace Story_Crafter.Controls.Tabs
{
    [TypeDescriptionProvider(typeof(BaseEditorTab.DescriptionProvider))]
    public abstract class BaseEditorTab : UserControl, IEditorTab {
        public abstract string Title { get; }
        public Control Control => this;

        protected Editor Editor;
        private readonly DisposableBag disposables = new();
        private bool isFirstTime = true;

        public BaseEditorTab(Editor editor) {
            Editor = editor;
        }

        public void EnterTab() {
            OnTabEntered(isFirstTime);
            isFirstTime = false;
        }

        public void LeaveTab() {
            OnTabLeft();
        }

        protected virtual void OnTabEntered(bool isFirstTime) {
        }

        protected virtual void OnTabLeft() {
        }

        protected override void OnControlRemoved(ControlEventArgs e) {
            base.OnControlRemoved(e);
            disposables.Dispose();
        }

        protected void Autodispose(IDisposable subscription) {
            disposables.Add(subscription);
        }

        public class DescriptionProvider : TypeDescriptionProvider {
            public DescriptionProvider() : base(TypeDescriptor.GetProvider(typeof(UserControl))) {
            }

            public override Type GetReflectionType(Type objectType, object instance) {
                return typeof(UserControl);
            }

            public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args) {
                objectType = typeof(UserControl);
                return base.CreateInstance(provider, objectType, argTypes, args);
            }
        }
    }
}
