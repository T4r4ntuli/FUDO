using UnityEngine;

namespace Fudo.Components {
    [System.Serializable]
    public class Movement {
        public Vector3 velocity;
        public Vector3 horizontalVelocity { get { return new Vector3(velocity.x, 0, velocity.z); } }
        public float verticalVelocity { get { return velocity.y; } }
    }
}
