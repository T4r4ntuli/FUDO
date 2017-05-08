using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Fudo.Processor
{
    public static class CharacterMovement
    {
        public static void Update(GenericDictionary<Vector3> positions, GenericDictionary<Components.Movement> movements, GenericDictionary<Components.MovementInput> inputs) {
            foreach (KeyValuePair<int, Components.Movement> movementComponent in movements) {
                Vector3 newPos;
                Components.MovementInput input;
                if (positions.TryGetValue(movementComponent.Key, out newPos)) {
                    if (inputs.TryGetValue(movementComponent.Key, out input)) {
                        Vector3 movePosition = newPos + new Vector3(input.right, 0, input.forward) * Time.deltaTime;
                        newPos = movePosition;
                        positions[movementComponent.Key] = newPos;
                    }
                }
            }
        }
    }
}