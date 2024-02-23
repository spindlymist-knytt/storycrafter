using System;

namespace Story_Crafter.Utility.Observables {
    public interface IWritable<T> {
        T Value { get; set; }
        IDisposable Subscribe(Action<T> onValueChanged);
    }
}
