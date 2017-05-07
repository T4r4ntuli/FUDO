using UnityEngine;
using System.Collections.Generic;

namespace Fudo.Processor
{
    public static class InputToMovement
    {
        public static void Update(GenericDictionary<Components.BufferedInputs> inputs, GenericDictionary<Components.MovementInput> inputToMovements) {
            foreach (KeyValuePair<int, Components.BufferedInputs> input in inputs) {
                Components.MovementInput movementInput;
                if (inputToMovements.TryGetValue(input.Key, out movementInput)) {
                    for (int i = 0; i < input.Value.inputs.Count; i++) {
                        if (input.Value.inputs[i].key == Enums.Key.Up &&
                            input.Value.inputs[i].state == Enums.KeyState.Down) {
                            movementInput.forward += 1.0f;
                        }
                        if (input.Value.inputs[i].key == Enums.Key.Up &&
                            input.Value.inputs[i].state == Enums.KeyState.Up) {
                            movementInput.forward -= 1.0f;
                        }
                        if (input.Value.inputs[i].key == Enums.Key.Down &&
                            input.Value.inputs[i].state == Enums.KeyState.Down) {
                            movementInput.forward -= 1.0f;
                        }
                        if (input.Value.inputs[i].key == Enums.Key.Down &&
                            input.Value.inputs[i].state == Enums.KeyState.Up) {
                            movementInput.forward += 1.0f;
                        }
                        if (input.Value.inputs[i].key == Enums.Key.Left &&
                            input.Value.inputs[i].state == Enums.KeyState.Down) {
                            movementInput.right -= 1.0f;
                        }
                        if (input.Value.inputs[i].key == Enums.Key.Left &&
                            input.Value.inputs[i].state == Enums.KeyState.Up) {
                            movementInput.right += 1.0f;
                        }
                        if (input.Value.inputs[i].key == Enums.Key.Right &&
                            input.Value.inputs[i].state == Enums.KeyState.Down) {
                            movementInput.right += 1.0f;
                        }
                        if (input.Value.inputs[i].key == Enums.Key.Right &&
                            input.Value.inputs[i].state == Enums.KeyState.Up) {
                            movementInput.right -= 1.0f;
                        }
                        movementInput.forward = Mathf.Clamp(movementInput.forward, -1.0f, 1.0f);
                        movementInput.right = Mathf.Clamp(movementInput.right, -1.0f, 1.0f);
                    }
                    input.Value.inputs.Clear();
                    input.Value.inputs.Clear();
                }
            }
        }
    }
}