using System;
using System.Collections.Generic;

namespace OpenWorldDriving.Shared
{
    /// <summary>
    /// Lightweight event bus for decoupled, event-driven messaging.
    /// </summary>
    public static class GameEventBus
    {
        private static readonly Dictionary<Type, Delegate> EventTable = new Dictionary<Type, Delegate>();

        /// <summary>
        /// Subscribe to a specific event type.
        /// </summary>
        public static void Subscribe<T>(Action<T> callback)
        {
            var type = typeof(T);
            if (EventTable.TryGetValue(type, out var existing))
            {
                EventTable[type] = Delegate.Combine(existing, callback);
                return;
            }

            EventTable[type] = callback;
        }

        /// <summary>
        /// Unsubscribe from a specific event type.
        /// </summary>
        public static void Unsubscribe<T>(Action<T> callback)
        {
            var type = typeof(T);
            if (!EventTable.TryGetValue(type, out var existing))
            {
                return;
            }

            var current = Delegate.Remove(existing, callback);
            if (current == null)
            {
                EventTable.Remove(type);
                return;
            }

            EventTable[type] = current;
        }

        /// <summary>
        /// Publish an event to all subscribers.
        /// </summary>
        public static void Publish<T>(T evt)
        {
            if (EventTable.TryGetValue(typeof(T), out var existing))
            {
                if (existing is Action<T> callback)
                {
                    callback.Invoke(evt);
                }
            }
        }
    }
}
