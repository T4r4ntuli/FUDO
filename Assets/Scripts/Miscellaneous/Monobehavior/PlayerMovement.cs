using UnityEngine;

namespace Profiler
{
    public class PlayerMovement : MonoBehaviour
    {
        public Vector3 position;
        public PlayerVelocity playerVelocity;

        void Start() {
            playerVelocity = GetComponent<PlayerVelocity>();
        }

        void Update() {
            position = position + playerVelocity.velocity * Time.deltaTime;
        }
    }
}
