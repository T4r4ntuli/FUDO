using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DOD.Logic {
    public class MovementManager : MonoBehaviour /*Replace with static class*/ {

        ComponentManager componentManager;
        Dictionary<int, Vector3> positions;
        Dictionary<int, Components.Movement> movementComponents;

        void Start() {
            componentManager = ComponentManager.Instance;
            positions = componentManager.positions;
            movementComponents = componentManager.movementComponents;
        }

        void Update() {
            foreach (KeyValuePair<int, Components.Movement> movementComponent in movementComponents) {
                
                Vector3 movePosition = positions[movementComponent.Key] + movementComponent.Value.velocity * Time.deltaTime;

                //IsGrounded check

                Vector3 newPos = positions[movementComponent.Key];

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