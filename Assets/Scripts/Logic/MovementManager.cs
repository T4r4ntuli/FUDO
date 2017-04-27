using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Fudo.PRC;

namespace Fudo.Logic {
    public class MovementManager : MonoBehaviour /*Replace with static class*/
    {
        ComponentManager componentManager;


        void Start() {
            componentManager = ComponentManager.Instance;
            StaticMovementProcessor.Start();
        }

        void Update() {
            StaticMovementProcessor.Process(componentManager.positions, componentManager.movementComponents);
            //foreach (KeyValuePair<int, Components.Movement> movementComponent in movementComponents) {
            //    Vector3 newPos;
            //    if (positions.TryGetValue(movementComponent.Key, out newPos)) {
            //        Vector3 movePosition = newPos + movementComponent.Value.velocity * Time.deltaTime;
            //        //IsGrounded check

            //        if (false) { //collision check
            //            Vector3 newVel = movementComponent.Value.velocity;
            //            Vector3 moveAmount = movePosition - newPos;

            //            while (true) {

            //            }
            //            movementComponent.Value.velocity = newVel;
            //        } else {
            //            newPos = movePosition;
            //        }
            //        positions[movementComponent.Key] = newPos;
            //    }
            //}
        }
    }
}