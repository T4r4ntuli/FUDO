using UnityEngine;
using System.Collections.Generic;

namespace Fudo.Processor {
    public class Aim {

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