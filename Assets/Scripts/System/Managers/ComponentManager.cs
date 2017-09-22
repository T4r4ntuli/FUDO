using UnityEngine;
using System;

namespace Fudo {
    public class ComponentManager : Singleton<ComponentManager>
        {
        protected ComponentManager() { }
        EntityManager entityManager;
        //Unity Component lists
        public GenericDictionary<GameObject> entityGameObjects;
        public GenericDictionary<Transform> entityTransforms;
        public GenericDictionary<Rigidbody> rigidbodies;
        //Single type lists
        public GenericDictionary<float> maxSpeeds;
        public GenericDictionary<bool> isVisibles;
        //Unity classes/structs
        public GenericDictionary<Vector3> positions, scales, directions;
        public GenericDictionary<Quaternion> rotations;
        //User made component lists
        public GenericDictionary<Components.Controllable> controllableComponents;
        public GenericDictionary<Components.Movement> movementComponents, previousFrameMovementComponents;
        public GenericDictionary<Components.MovementInput> inputToMovement;

        // INPUT AXIS FROM CONTROLLABLE TO A SEPARATE COMPONENT
        public Components.BufferedInputs playerInput;


        public override void Init() {
            entityGameObjects = new GenericDictionary<GameObject>();
            entityTransforms = new GenericDictionary<Transform>();
            rigidbodies = new GenericDictionary<Rigidbody>();
            controllableComponents = new GenericDictionary<Components.Controllable>();
            positions = new GenericDictionary<Vector3>();
            scales = new GenericDictionary<Vector3>();
            directions = new GenericDictionary<Vector3>();
            rotations = new GenericDictionary<Quaternion>();
            maxSpeeds = new GenericDictionary<float>();
            movementComponents = new GenericDictionary<Components.Movement>();
            previousFrameMovementComponents = new GenericDictionary<Components.Movement>();
            inputToMovement = new GenericDictionary<Components.MovementInput>();
        }

        public override void ReferenceManager() {
            entityManager = EntityManager.Instance;
        }
        #region Add component functions
        public void AddComponent(Enums.ComponentType componentType, float component, int entityId) {
            if (componentType == Enums.ComponentType.MaxSpeed) {
                maxSpeeds.Add(entityId, component);
            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
            entityManager.entities[entityId].components.Add(componentType);
        }
        public void AddComponent(Enums.ComponentType componentType, bool component, int entityId) {
            if (componentType == Enums.ComponentType.IsVisible) {
                isVisibles.Add(entityId, component);
            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
            entityManager.entities[entityId].components.Add(componentType);
        }
        public void AddComponent(Enums.ComponentType componentType, Vector3 component, int entityId) {
            if (componentType == Enums.ComponentType.Position) {
                positions.Add(entityId, component);
            } else if (componentType == Enums.ComponentType.Direction) {
                directions.Add(entityId, component);
            } else if (componentType == Enums.ComponentType.Scale) {
                scales.Add(entityId, component);
            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
            entityManager.entities[entityId].components.Add(componentType);
        }
        public void  RemoveComponent(Enums.ComponentType componentType, int entityId) {

            switch (componentType)
            {
                default:
                    throw new ArgumentException("No component lists were found with the given type", "componentType");
                case Enums.ComponentType.Position:
                    positions.Remove(entityId);
                    break;
                case Enums.ComponentType.Scale:
                    scales.Remove(entityId);
                    break;
                case Enums.ComponentType.Rotation:
                    rotations.Remove(entityId);
                    break;
                case Enums.ComponentType.Direction:
                    directions.Remove(entityId);
                    break;
                case Enums.ComponentType.MaxSpeed:
                    maxSpeeds.Remove(entityId);
                    break;
                case Enums.ComponentType.Movement:
                    movementComponents.Remove(entityId);
                    break;
                case Enums.ComponentType.InputToMovement:
                    inputToMovement.Remove(entityId);
                    break;
            }
            entityManager.entities[entityId].components.Remove(componentType);
        }
        public void AddComponent(Enums.ComponentType componentType, Quaternion component, int entityId) {
            if (componentType == Enums.ComponentType.Rotation) {
                rotations.Add(entityId, component);
            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
            entityManager.entities[entityId].components.Add(componentType);
        }
        public void AddComponent(Enums.ComponentType componentType, Components.Movement component, int entityId) {
            if (componentType == Enums.ComponentType.Movement) {
                movementComponents.Add(entityId, component);
            } else if (componentType == Enums.ComponentType.PreviousFrameMovement) {
                previousFrameMovementComponents.Add(entityId, component);
            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
            entityManager.entities[entityId].components.Add(componentType);
        }
        public void AddComponent(Enums.ComponentType componentType, Components.Controllable component, int entityId) {
            if (componentType == Enums.ComponentType.Controllable) {
                controllableComponents.Add(entityId, component);
            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
            entityManager.entities[entityId].components.Add(componentType);
        }
        public void AddComponent(Enums.ComponentType componentType, Components.MovementInput component, int entityId) {
            if (componentType == Enums.ComponentType.InputToMovement) {
                inputToMovement.Add(entityId, component);
            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
            entityManager.entities[entityId].components.Add(componentType);
        }
        #endregion
        #region Search component functions
        public int ReturnIntComponent(Enums.ComponentType componentType, int entityId) {
            int integer;
            if (false) {

            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
            Debug.LogWarning(string.Format("Entity doesn't have component in the wanted component list, entity id : {0} component type: {1}", entityId, componentType));
            return 0;
        }
        public float ReturnFloatComponent(Enums.ComponentType componentType, int entityId) {
            float fl;
            if (componentType == Enums.ComponentType.MaxSpeed) {
                if (maxSpeeds.TryGetValue(entityId, out fl)) {
                    return fl;
                }
            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
            Debug.LogWarning(string.Format("Entity doesn't have component in the wanted component list, entity id : {0} component type: {1}", entityId, componentType));
            return 0;
        }
        public bool ReturnBooleanComponent(Enums.ComponentType componentType, int entityId) {
            bool bl;
            if (componentType == Enums.ComponentType.IsVisible) {
                if (isVisibles.TryGetValue(entityId, out bl)) {
                    return bl;
                }
            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
            Debug.LogWarning(string.Format("Entity doesn't have component in the wanted component list, entity id : {0} component type: {1}", entityId, componentType));
            return false;
        }
        public Vector3 ReturnVector3Component(Enums.ComponentType componentType, int entityId) {
            Vector3 vc;
            if (componentType == Enums.ComponentType.Position) {
                if (positions.TryGetValue(entityId, out vc)) {
                    return vc;
                }
            } else if (componentType == Enums.ComponentType.Scale) {
                if (scales.TryGetValue(entityId, out vc)) {
                    return vc;
                }
            } else if (componentType == Enums.ComponentType.Direction) {
                if (directions.TryGetValue(entityId, out vc)) {
                    return vc;
                }
            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
            Debug.LogWarning(string.Format("Entity doesn't have component in the wanted component list, entity id : {0} component type: {1}", entityId, componentType));
            return Vector3.zero;
        }
        public Quaternion ReturnQuaternionComponent(Enums.ComponentType componentType, int entityId) {
            Quaternion qt;
            if (componentType == Enums.ComponentType.Rotation) {
                if (rotations.TryGetValue(entityId, out qt)) {
                    return qt;
                }
            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
            Debug.LogWarning(string.Format("Entity doesn't have component in the wanted component list, entity id : {0} component type: {1}", entityId, componentType));
            return Quaternion.identity;
        }
        public Components.Movement ReturnMovementComponent(Enums.ComponentType componentType, int entityId) {
            Components.Movement mc;
            if (componentType == Enums.ComponentType.Movement) {
                if (movementComponents.TryGetValue(entityId, out mc)) {
                    return mc;
                }
            } else if (componentType == Enums.ComponentType.PreviousFrameMovement) {
                if (previousFrameMovementComponents.TryGetValue(entityId, out mc)) {
                    return mc;
                }
            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
            Debug.LogWarning(string.Format("Entity doesn't have component in the wanted component list, entity id : {0} component type: {1}", entityId, componentType));
            return null;
        }
        #endregion
        #region Set component functions

        public void SetComponent(Enums.ComponentType componentType, float component, int entityId) {
            if(componentType == Enums.ComponentType.MaxSpeed) {
                maxSpeeds[entityId] = component;
            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
        }
        public void SetComponent(Enums.ComponentType componentType, bool component, int entityId) {
            if (componentType == Enums.ComponentType.IsVisible) {
                isVisibles[entityId] = component;
            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
        }
        public void SetComponent(Enums.ComponentType componentType, Vector3 component, int entityId) {
            if(componentType == Enums.ComponentType.Position) {
                positions[entityId] = component;
            } else if (componentType == Enums.ComponentType.Direction) { 
                directions[entityId] = component;
            } else if (componentType == Enums.ComponentType.Scale){
                scales[entityId] = component;
            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
        }
        public void SetComponent(Enums.ComponentType componentType, Quaternion component, int entityId) {
            if(componentType == Enums.ComponentType.Rotation) {
                rotations[entityId] = component;
            } else {
                throw new ArgumentException("No component lists were found with the given type", "componentType");
            }
        }
        #endregion
    }
}

