using UnityEngine;

namespace Profiler
{
    public class PlayerUnityMovement : MonoBehaviour
    {
        private PlayerMovement playerMovement;
        private Rigidbody rigidbody;

        void Start() {
            playerMovement = GetComponent<PlayerMovement>();
            rigidbody = GetComponent<Rigidbody>();
        }

        void Update() {
            if (rigidbody != null) {
                rigidbody.MovePosition(playerMovement.position);
            } else {
                transform.position = playerMovement.position;
            }
        }
    }
}
