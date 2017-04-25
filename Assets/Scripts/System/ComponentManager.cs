using UnityEngine;
using System.Collections.Generic;

namespace Fudo {
    public class ComponentManager : Singleton<ComponentManager> {
        protected ComponentManager() { }

        EntityManager entityManager;

        //Unity component lists
        public Dictionary<int, GameObject> entityGameObjects;
        public Dictionary<int, Transform> entityTransforms;
        public Dictionary<int, Rigidbody> rigidbodies;
        //Single type lists
        public Dictionary<int, Vector3> positions, scales, directions;
        public Dictionary<int, Quaternion> rotations;
        public Dictionary<int, float> maxSpeeds;
        public Dictionary<int, bool> controllable;
        //User made component lists
        public Dictionary<int, Components.Movement> movementComponents, previousFrameMovementComponents;

        public override void Init() {
            entityGameObjects = new Dictionary<int, GameObject>();
            entityTransforms = new Dictionary<int, Transform>();
            rigidbodies = new Dictionary<int, Rigidbody>();

            positions = new Dictionary<int, Vector3>();
            scales = new Dictionary<int, Vector3>();
            directions = new Dictionary<int, Vector3>();
            rotations = new Dictionary<int, Quaternion>();
            maxSpeeds = new Dictionary<int, float>();
            movementComponents = new Dictionary<int, Components.Movement>();
            previousFrameMovementComponents = new Dictionary<int, Components.Movement>();
        }

        public override void ReferenceManager() {
            entityManager = EntityManager.Instance;

            entityManager.vectorDictionaries.Add(positions);
            entityManager.vectorDictionaries.Add(scales);
            entityManager.vectorDictionaries.Add(directions);
            entityManager.quaternionDictionaries.Add(rotations);
            entityManager.floatDictionaries.Add(maxSpeeds);
            entityManager.boolDictionaries.Add(controllable);
            entityManager.movementDictionaries.Add(movementComponents);
            entityManager.movementDictionaries.Add(previousFrameMovementComponents);
        }
    }

    
}
namespace Fudo.Components {
    [System.Serializable]
    public class Movement {
        public Vector3 velocity;
        public Vector3 horizontalVelocity { get { return new Vector3(velocity.x, 0, velocity.z); } }
        public float verticalVelocity { get { return velocity.y; } }
    }
}