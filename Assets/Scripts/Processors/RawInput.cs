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
                    if (UnityEngine.Input.GetButtonDown("Forward")) {
                        bufferedInputs.inputs.Add(new BufferedInput(Enums.Key.Up, Enums.KeyState.Down));
                    } else if (UnityEngine.Input.GetButtonUp("Forward")) {
                        bufferedInputs.inputs.Add(new BufferedInput(Enums.Key.Up, Enums.KeyState.Up));
                    }
                    if (UnityEngine.Input.GetButtonDown("Backward")) {
                        bufferedInputs.inputs.Add(new BufferedInput(Enums.Key.Down, Enums.KeyState.Down));
                    } else if (UnityEngine.Input.GetButtonUp("Backward")) {
                        bufferedInputs.inputs.Add(new BufferedInput(Enums.Key.Down, Enums.KeyState.Up));
                    }
                    if (UnityEngine.Input.GetButtonDown("Left")) {
                        bufferedInputs.inputs.Add(new BufferedInput(Enums.Key.Left, Enums.KeyState.Down));
                    } else if (UnityEngine.Input.GetButtonUp("Left")) {
                        bufferedInputs.inputs.Add(new BufferedInput(Enums.Key.Left, Enums.KeyState.Up));
                    }
                    if (UnityEngine.Input.GetButtonDown("Right")) {
                        bufferedInputs.inputs.Add(new BufferedInput(Enums.Key.Right, Enums.KeyState.Down));
                    } else if (UnityEngine.Input.GetButtonUp("Right")) {
                        bufferedInputs.inputs.Add(new BufferedInput(Enums.Key.Right, Enums.KeyState.Up));
                    }
                }
            }
        }
    }
}