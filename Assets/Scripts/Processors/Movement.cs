using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Fudo.Processor
{
    public static class Movement
    {
        private static UnityAction listener;

        public static void Start() {

            listener = OnEvent;
            EventManager.StartListening(Fudo.Enums.Event.Test, listener);
        }

        public static void OnEvent() {
            Debug.Log("YYYIEEEAHAAA");
        }

        public static void Update(GenericDictionary<Vector3> positions, GenericDictionary<Components.Movement> movements) {
            foreach (KeyValuePair<int, Components.Movement> movementComponent in movements) {
                Vector3 newPos;
                if (positions.TryGetValue(movementComponent.Key, out newPos)) {
                    Vector3 movePosition = newPos + movementComponent.Value.velocity * Time.deltaTime;
                    //IsGrounded check

                    if (false) { //collision check
                        Vector3 newVel = movementComponent.Value.velocity;
                        Vector3 moveAmount = movePosition - newPos;

                        while (true) {

                        }
                        movementComponent.Value.velocity = newVel;
                    } else {
                        newPos = movePosition;
                    }
                    positions[movementComponent.Key] = newPos;
                }
            }
        }
    }
}