using UnityEngine;
using System.Collections.Generic;

namespace Fudo.Processor
{
    public static class RawInputToAxis
    {
        public static void Update(GenericDictionary<Components.Controllable> controllables, Components.BufferedInputs inputs) {
            foreach (KeyValuePair<int, Components.Controllable> controllable in controllables) {
                
                for (int i = 0; i < inputs.buffered.Count; i++) {
                    float x = controllable.Value.inputAxis.x;
                    float y = controllable.Value.inputAxis.y;

                    if (inputs.buffered[i].key == Enums.Key.Up &&
                        inputs.buffered[i].state == Enums.KeyState.Down) {
                        y += 1.0f;
                    }
                    if (inputs.buffered[i].key == Enums.Key.Up &&
                        inputs.buffered[i].state == Enums.KeyState.Up) {
                        y -= 1.0f;
                    }
                    if (inputs.buffered[i].key == Enums.Key.Down &&
                        inputs.buffered[i].state == Enums.KeyState.Down) {
                        y -= 1.0f;
                    }
                    if (inputs.buffered[i].key == Enums.Key.Down &&
                        inputs.buffered[i].state == Enums.KeyState.Up) {
                        y += 1.0f;
                    }
                    if (inputs.buffered[i].key == Enums.Key.Left &&
                        inputs.buffered[i].state == Enums.KeyState.Down) {
                        x -= 1.0f;
                    }
                    if (inputs.buffered[i].key == Enums.Key.Left &&
                        inputs.buffered[i].state == Enums.KeyState.Up) {
                        x += 1.0f;
                    }
                    if (inputs.buffered[i].key == Enums.Key.Right &&
                        inputs.buffered[i].state == Enums.KeyState.Down) {
                        x += 1.0f;
                    }
                    if (inputs.buffered[i].key == Enums.Key.Right &&
                        inputs.buffered[i].state == Enums.KeyState.Up) {
                        x -= 1.0f;
                    }
                    x = Mathf.Clamp(x, -1.0f, 1.0f);
                    y = Mathf.Clamp(y, -1.0f, 1.0f);
                    controllable.Value.inputAxis.x = x;
                    controllable.Value.inputAxis.y = y;
                }
                
            }
            inputs.buffered.Clear();
        }
    }
}
