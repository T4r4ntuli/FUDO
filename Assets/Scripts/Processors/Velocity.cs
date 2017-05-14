using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;

namespace Fudo.Processor
{
    public static class Velocity
    {
        public static event PropertyChangedEventHandler Tested;

        public static void Start() {
            var handler = Tested;
            if (handler != null) handler(this, new PropertyChangedEventArgs("Beep!"));
        }

        public void Test() {

        }

        public static void Update(GenericDictionary<Components.Movement> movements, GenericDictionary<Vector3> directions, GenericDictionary<Quaternion> rotations, GenericDictionary<float> maxSpeeds) {
            foreach (KeyValuePair<int, Components.Movement> movement in movements) {
                float maxSpeed;
                Quaternion rotation;
                Vector3 direction;

                if (directions.TryGetValue(movement.Key, out direction)) {
                    if (maxSpeeds.TryGetValue(movement.Key, out maxSpeed)) {
                        if (rotations.TryGetValue(movement.Key, out rotation)) {
                            movement.Value.velocity = rotation * direction * maxSpeed;
                        } else {
                            movement.Value.velocity = direction * maxSpeed;
                        }
                    } else {
                        movement.Value.velocity = direction;
                    }
                } else {
                    movement.Value.velocity = Vector3.zero;
                }
            }
        }
    }
}