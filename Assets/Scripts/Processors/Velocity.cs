using UnityEngine;
using System.Collections.Generic;

namespace Fudo.Processor
{
    public static class Velocity
    {
        public static void Update(GenericDictionary<Components.Movement> movements, GenericDictionary<Vector3> directions, GenericDictionary<Quaternion> rotations, GenericDictionary<float> maxSpeeds) {
            foreach (KeyValuePair<int, Components.Movement> movement in movements) {
                float maxSpeed;
                Quaternion rotation;
                Vector3 direction;
                if (maxSpeeds.TryGetValue(movement.Key, out maxSpeed) && rotations.TryGetValue(movement.Key, out rotation) && directions.TryGetValue(movement.Key, out direction)) {
                    movement.Value.velocity = rotation * direction * maxSpeed;
                }
            }
        }
    }
}