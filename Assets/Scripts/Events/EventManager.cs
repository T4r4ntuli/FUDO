using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

namespace Fudo
{
    // http://geekswithblogs.net/BlackRabbitCoder/archive/2011/11/03/c.net-little-wonders-the-generic-action-delegates.aspx
    // https://www.dotnetperls.com/action
    // http://stackoverflow.com/questions/42034245/unity-eventmanager-with-delegate-instead-of-unityevent

    public class EventManager : Singleton<EventManager>
    {
        protected EventManager() { }

        private Dictionary<Enums.Event, Action> eventDictionary;
        private Dictionary<Enums.Event, Action<int[]>> intArrayEventDictionary;

        //public EventManager instance {
        //    get {
        //        if (!eventManager) {
        //            eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

        //            if (!eventManager) {
        //                Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
        //            } else {
        //                eventManager.Init();
        //            }
        //        }

        //        return eventManager;
        //    }
        //}

        public override void Init() {
            eventDictionary = new Dictionary<Enums.Event, Action>();
            intArrayEventDictionary = new Dictionary<Enums.Event, Action<int[]>>();
        }

        public void StartListening(Enums.Event eventType, Action listener) {
            Action thisEvent;
            if (eventDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent += listener;
            } else {
                thisEvent += listener;
                eventDictionary.Add(eventType, thisEvent);
            }
        }

        public void StartListening(Enums.Event eventType, Action<int[]> listener) {
            Action<int[]> thisEvent;
            if (intArrayEventDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent += listener;
            } else {
                thisEvent += listener;
                intArrayEventDictionary.Add(eventType, thisEvent);
            }
        }

        public void StopListening(Enums.Event eventType, Action listener) {
            Action thisEvent;
            if (eventDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent -= listener;
            }
        }
        public void StopListening(Enums.Event eventType, Action<int[]> listener) {
            Action<int[]> thisEvent;
            if (intArrayEventDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent -= listener;
            }
        }

        public void TriggerEvent(Enums.Event eventType) {
            Action thisEvent = null;
            if (eventDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent.Invoke();
            }
        }
        public void TriggerEvent(Enums.Event eventType, int[] eventData) {
            Action<int[]> thisEvent = null;
            if (intArrayEventDictionary.TryGetValue(eventType, out thisEvent)) {
                thisEvent.Invoke(eventData);
            }
        }
    }
}