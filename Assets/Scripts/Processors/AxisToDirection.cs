using UnityEngine;
using System.Collections.Generic;

namespace Fudo.Processor
{
    public static class AxisToDirection
    {
        public static void Update(GenericDictionary<Components.Controllable> controllables, GenericDictionary<Vector3> directions) {
            foreach (KeyValuePair<int, Components.Controllable> controllable in controllables) {
                Vector3 direction;
                if (directions.TryGetValue(controllable.Key, out direction)) {
                    direction = new Vector3(controllable.Value.inputAxis.x, 0, controllable.Value.inputAxis.y);
                    directions[controllable.Key] = direction;
                }
            }
        }
    }
}
