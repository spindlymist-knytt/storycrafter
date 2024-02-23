using System;
using System.Collections.Generic;

namespace Story_Crafter.Utility.Observables {
    public class ObservableValue<T> : IReadable<T>, IWritable<T>, IDisposable {
        List<Subscription> subscriptions = new();
        T currentValue;

        public T Value {
            get {
                return currentValue;
            }
            set {
                currentValue = value;
                for (int i = 0; i < subscriptions.Count; i++) {
                    subscriptions[i].observer.OnNext(currentValue);
                }
            }
        }

        public ObservableValue(T value = default) {
            currentValue = value;
        }

        public void Dispose() {
            if (subscriptions == null) return;

            for (int i = 0; i < subscriptions.Count; i++) {
                subscriptions[i].End();
            }

            subscriptions = null;
        }

        public IDisposable Subscribe(IObserver<T> observer) {
            Subscription sub = new(observer, Unsubscribe);
            subscriptions.Add(sub);
            return sub;
        }

        public IDisposable Subscribe(Action<T> onValueChanged) {
            Observer observer = new(onValueChanged);
            return Subscribe(observer);
        }

        void Unsubscribe(Subscription sub) {
            subscriptions.Remove(sub);
        }

        class Subscription : IDisposable {
            internal IObserver<T> observer;
            Action<Subscription> unsubscribe;

            public Subscription(IObserver<T> observer, Action<Subscription> unsubscribe) {
                this.observer = observer;
                this.unsubscribe = unsubscribe;
            }

            public void Dispose() {
                observer = null;
                unsubscribe?.Invoke(this);
                unsubscribe = null;
            }

            internal void End() {
                observer.OnCompleted();
                observer = null;
                unsubscribe = null;
            }
        }

        class Observer : IObserver<T> {
            readonly Action<T> onValueChanged;

            public Observer(Action<T> onValueChanged) {
                this.onValueChanged = onValueChanged;
            }

            public void OnCompleted() { }

            public void OnError(Exception error) { }

            public void OnNext(T value) {
                onValueChanged(value);
            }
        }
    }
}
