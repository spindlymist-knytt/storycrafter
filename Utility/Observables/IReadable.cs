using System;

namespace Story_Crafter.Utility.Observables {
    public interface IReadable<T> {
        T Value { get; }
        IDisposable Subscribe(Action<T> onValueChanged);
    }
}
