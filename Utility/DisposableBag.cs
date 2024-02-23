using System;
using System.Collections.Generic;

namespace Story_Crafter.Utility {
    public sealed class DisposableBag : IDisposable {
        List<IDisposable> disposables = new();

        public DisposableBag() {
        }

        public void Add(IDisposable disposable) {
            disposables.Add(disposable);
        }

        public void Dispose() {
            disposables.ForEach(d => d.Dispose());
            disposables = null;
        }
    }
}
