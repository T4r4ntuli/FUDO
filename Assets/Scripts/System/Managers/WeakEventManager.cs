﻿

//      https://github.com/thomaslevesque/WeakEvent


using System;
using System.Reflection;

namespace WeakEvent
{
        public sealed class WeakEventHandler<TEventArgs> where TEventArgs : EventArgs
    {
        private readonly WeakReference _targetReference;
        private readonly MethodInfo _method;

        public WeakEventHandler(EventHandler<TEventArgs> callback) {
            _method = callback.Method;
            _targetReference = new WeakReference(callback.Target, true);
        }

        public void Handler(object sender, TEventArgs e) {
            var target = _targetReference.Target;
            if (target != null) {
                var callback = (Action<object, TEventArgs>)Delegate.CreateDelegate(typeof(Action<object, TEventArgs>), target, _method, true);
                if (callback != null) {
                    callback(sender, e);
                }
            }
        }
    }
}