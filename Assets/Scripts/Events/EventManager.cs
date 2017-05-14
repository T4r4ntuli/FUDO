using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Fudo
{
    using System;

    // http://geekswithblogs.net/BlackRabbitCoder/archive/2011/11/03/c.net-little-wonders-the-generic-action-delegates.aspx
    // https://www.dotnetperls.com/action
    // http://stackoverflow.com/questions/42034245/unity-eventmanager-with-delegate-instead-of-unityevent

    public class EventManager : MonoBehaviour
    {

        private Dictionary<Enums.Event, Action> eventDictionary;

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
                eventDictionary = new Dictionary<Enums.Event, Action>();
            }
        }

        public static void StartListening(Enums.Event eventType, Action listener) {

            Action thisEvent;
            if (instance.eventDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent += listener;
            } else {
                thisEvent += listener;
                instance.eventDictionary.Add(eventType, thisEvent);
            }
        }

        public static void StopListening(Enums.Event eventType, Action listener) {
            if (eventManager == null) return;
            Action thisEvent;
            if (instance.eventDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent -= listener;
            }
        }

        public static void TriggerEvent(Enums.Event eventType) {
            Action thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent.Invoke();
            }
        }
    }
}