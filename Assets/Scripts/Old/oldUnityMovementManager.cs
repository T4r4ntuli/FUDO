using UnityEngine;
using System.Collections.Generic;

namespace Fudo.Logic {
    public class oldUnityMovementProcessorManager : MonoBehaviour /*Replace with static class*/ {

        ComponentManager componentManager;
        Dictionary<int, Transform> transforms;
        Dictionary<int, Vector3> positions;
        Dictionary<int, Rigidbody> rigidbodies;

        void Start() {
            componentManager = ComponentManager.Instance;
            transforms = componentManager.entityTransforms;
            positions = componentManager.positions;
            rigidbodies = componentManager.rigidbodies;
        }

        void Update() {
            foreach (KeyValuePair<int, Vector3> position in positions) {
                Rigidbody rgBody;
                if (rigidbodies.TryGetValue(position.Key, out rgBody)) {
                    rgBody.MovePosition(position.Value);
                } else {
                    transforms[position.Key].position = position.Value;
                }
            }
        }
    }
}