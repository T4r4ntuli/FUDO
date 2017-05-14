using UnityEngine;

namespace Profiler
{
    public class PlayerVelocity : MonoBehaviour
    {
        public float movementSpeed;
        public Vector3 velocity;
        public Vector3 direction;
        public Quaternion rotation;

        // Use this for initialization
        void Start() {

            direction = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2));
            while (direction.magnitude == 0) {
                direction = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2));
            }
        }

        void Update() {
            direction = direction.normalized;
            velocity = rotation * direction * movementSpeed;
        }
    }
}
