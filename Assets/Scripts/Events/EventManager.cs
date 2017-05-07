using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Fudo
{
    public class SingleDataEvent : UnityEvent<int> { }
    public class DoubleDataEvent : UnityEvent<int, int> { }

    //public class EventCall : UnityEvent<byte[]> { }
    public class EventManager : Singleton<EventManager>
    {
        protected EventManager() { }

        private Dictionary<Fudo.Enums.Event, UnityEvent> eventDictionary;
        private Dictionary<Fudo.Enums.Event, SingleDataEvent> singleEventDataDictionary;
        private Dictionary<Fudo.Enums.Event, DoubleDataEvent> doubleEventDataDictionary;

        private static EventManager eventManager;

        public static EventManager instance {
            get {
                if (!eventManager) {
                    eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                    if (!eventManager) {
                        Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                    } else {
                        eventManager.Init();
                    }
                }

                return eventManager;
            }
        }

        void Init() {
            if (eventDictionary == null) {
                eventDictionary = new Dictionary<Fudo.Enums.Event, UnityEvent>();
                singleEventDataDictionary = new Dictionary<Fudo.Enums.Event, SingleDataEvent>();
                doubleEventDataDictionary = new Dictionary<Fudo.Enums.Event, DoubleDataEvent>();
            }
        }

        public static void StartListening(Fudo.Enums.Event eventType, UnityAction listener) {
            UnityEvent thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent.AddListener(listener);
            } else {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                instance.eventDictionary.Add(eventType, thisEvent);
            }
        }

        public static void StartListening(Fudo.Enums.Event eventType, UnityAction<int> listener) {
            SingleDataEvent thisEvent = null;
            if (instance.singleEventDataDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent.AddListener(listener);
            } else {
                thisEvent = new SingleDataEvent();
                thisEvent.AddListener(listener);
                instance.singleEventDataDictionary.Add(eventType, thisEvent);
            }
        }

        public static void StartListening(Fudo.Enums.Event eventType, UnityAction<int, int> listener) {
            DoubleDataEvent thisEvent = null;
            if (instance.doubleEventDataDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent.AddListener(listener);
            } else {
                thisEvent = new DoubleDataEvent();
                thisEvent.AddListener(listener);
                instance.doubleEventDataDictionary.Add(eventType, thisEvent);
            }
        }

        public static void StopListening(Fudo.Enums.Event eventType, UnityAction listener) {
            if (eventManager == null) return;
            UnityEvent thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent.RemoveListener(listener);
            }
        }
        public static void StopListening(Fudo.Enums.Event eventType, UnityAction<int> listener) {
            if (eventManager == null) return;
            SingleDataEvent thisEvent = null;
            if (instance.singleEventDataDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void StopListening(Fudo.Enums.Event eventType, UnityAction<int, int> listener) {
            if (eventManager == null) return;
            DoubleDataEvent thisEvent = null;
            if (instance.doubleEventDataDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void TriggerEvent(Fudo.Enums.Event eventType) {
            UnityEvent thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent.Invoke();
            }
        }
        public static void TriggerEvent(Fudo.Enums.Event eventType, int a) {
            SingleDataEvent thisEvent = null;
            if (instance.singleEventDataDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent.Invoke(a);
            }
        }
        public static void TriggerEvent(Fudo.Enums.Event eventType, int a, int b) {
            DoubleDataEvent thisEvent = null;
            if (instance.doubleEventDataDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent.Invoke(a, b);
            }
        }
    }
}