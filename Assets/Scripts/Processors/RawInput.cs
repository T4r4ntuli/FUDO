using UnityEngine;
using System.Collections.Generic;

namespace Fudo.Processor
{
    public static class RawInput
    {
        public static void Update(GenericDictionary<Components.BufferedInputs> inputs) {
            foreach (KeyValuePair<int, Components.BufferedInputs> input in inputs) {
                Components.BufferedInputs bufferedInputs;

                if (inputs.TryGetValue(input.Key, out bufferedInputs)) {
                    if (UnityEngine.Input.GetKeyDown(KeyCode.W)) {
                        bufferedInputs.inputs.Add(new BufferedInput(Enums.Key.Up, Enums.KeyState.Down));
                    } else if (UnityEngine.Input.GetKeyUp(KeyCode.W)) {
                        bufferedInputs.inputs.Add(new BufferedInput(Enums.Key.Up, Enums.KeyState.Up));
                    }
                    if (UnityEngine.Input.GetKeyDown(KeyCode.S)) {
                        bufferedInputs.inputs.Add(new BufferedInput(Enums.Key.Down, Enums.KeyState.Down));
                    } else if (UnityEngine.Input.GetKeyUp(KeyCode.S)) {
                        bufferedInputs.inputs.Add(new BufferedInput(Enums.Key.Down, Enums.KeyState.Up));
                    }
                    if (UnityEngine.Input.GetKeyDown(KeyCode.A)) {
                        bufferedInputs.inputs.Add(new BufferedInput(Enums.Key.Left, Enums.KeyState.Down));
                    } else if (UnityEngine.Input.GetKeyUp(KeyCode.A)) {
                        bufferedInputs.inputs.Add(new BufferedInput(Enums.Key.Left, Enums.KeyState.Up));
                    }
                    if (UnityEngine.Input.GetKeyDown(KeyCode.D)) {
                        bufferedInputs.inputs.Add(new BufferedInput(Enums.Key.Right, Enums.KeyState.Down));
                    } else if (UnityEngine.Input.GetKeyUp(KeyCode.D)) {
                        bufferedInputs.inputs.Add(new BufferedInput(Enums.Key.Right, Enums.KeyState.Up));
                    }
                }
            }
        }
    }
}