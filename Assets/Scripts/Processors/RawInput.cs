using UnityEngine;
using System.Collections.Generic;

namespace Fudo.Processor
{
    public static class RawInput
    {
        public static void Update(Components.BufferedInputs inputs) {
            if (UnityEngine.Input.GetButtonDown("Forward")) {
                inputs.buffered.Add(new BufferedInput(Enums.Key.Up, Enums.KeyState.Down));
            } else if (UnityEngine.Input.GetButtonUp("Forward")) {
                inputs.buffered.Add(new BufferedInput(Enums.Key.Up, Enums.KeyState.Up));
            }
            if (UnityEngine.Input.GetButtonDown("Backward")) {
                inputs.buffered.Add(new BufferedInput(Enums.Key.Down, Enums.KeyState.Down));
            } else if (UnityEngine.Input.GetButtonUp("Backward")) {
                inputs.buffered.Add(new BufferedInput(Enums.Key.Down, Enums.KeyState.Up));
            }
            if (UnityEngine.Input.GetButtonDown("Left")) {
                inputs.buffered.Add(new BufferedInput(Enums.Key.Left, Enums.KeyState.Down));
            } else if (UnityEngine.Input.GetButtonUp("Left")) {
                inputs.buffered.Add(new BufferedInput(Enums.Key.Left, Enums.KeyState.Up));
            }
            if (UnityEngine.Input.GetButtonDown("Right")) {
                inputs.buffered.Add(new BufferedInput(Enums.Key.Right, Enums.KeyState.Down));
            } else if (UnityEngine.Input.GetButtonUp("Right")) {
                inputs.buffered.Add(new BufferedInput(Enums.Key.Right, Enums.KeyState.Up));
            }
        }
    }
}