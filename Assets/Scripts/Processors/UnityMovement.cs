using UnityEngine;
using System.Collections.Generic;

namespace Fudo.Processor {
    public static class UnityMovement {

        static System.Action<int[]> listener;

        public static void Start() {
            listener = EventTest;
            EventManager.Instance.StartListening(Enums.Event.Test, listener);
        }

        private static void EventTest(int[] eventData) {
            foreach (int i in eventData) {
                Debug.Log("EVENTDATA " + i);
            }
        }

        public static void Update(Dictionary<int, Transform> transforms, Dictionary<int, Vector3> positions, Dictionary<int, Rigidbody> rigidbodies) {
            foreach (KeyValuePair<int, Vector3> position in positions) {
                Rigidbody rgBody;
                if (rigidbodies.TryGetValue(position.Key, out rgBody)) {
                    rgBody.MovePosition(position.Value);
                } else {
                    transforms[position.Key].position = position.Value;
                }
            }
        }
    }
}