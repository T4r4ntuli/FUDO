using UnityEngine;
using System.Collections.Generic;

namespace Fudo {
    public class ComponentManager : Singleton<ComponentManager> {
        protected ComponentManager() { }

        EntityManager entityManager;

        //Unity Component lists
        public Dictionary<int, GameObject> entityGameObjects;
        public Dictionary<int, Transform> entityTransforms;
        public Dictionary<int, Rigidbody> rigidbodies;
        //Single type lists
        public Dictionary<int, float> maxSpeeds;
        public Dictionary<int, bool> isVisibles;
        //Unity classes/structs
        public GenericDictionary<Vector3> positions, scales, directions;
        public Dictionary<int, Quaternion> rotations;
        //User made component lists
        public Dictionary<int, Components.Controllable> controllables;
        public GenericDictionary<Components.Movement> movementComponents, previousFrameMovementComponents;

        public override void Init() {
            entityGameObjects = new Dictionary<int, GameObject>();
            entityTransforms = new Dictionary<int, Transform>();
            rigidbodies = new Dictionary<int, Rigidbody>();
            controllables = new Dictionary<int, Components.Controllable>();
            positions = new GenericDictionary<Vector3>();
            scales = new GenericDictionary<Vector3>();
            directions = new GenericDictionary<Vector3>();
            rotations = new Dictionary<int, Quaternion>();
            maxSpeeds = new Dictionary<int, float>();
            movementComponents = new GenericDictionary<Components.Movement>();
            previousFrameMovementComponents = new GenericDictionary<Components.Movement>();
        }

        public override void ReferenceManager() {
            entityManager = EntityManager.Instance;

            entityManager.vectorDictionaries.Add(positions);
            entityManager.vectorDictionaries.Add(scales);
            entityManager.vectorDictionaries.Add(directions);
            entityManager.quaternionDictionaries.Add(rotations);
            entityManager.floatDictionaries.Add(maxSpeeds);
            entityManager.movementDictionaries.Add(movementComponents);
            entityManager.movementDictionaries.Add(previousFrameMovementComponents);
        }

        public object ReturnComponent(Enums.ComponentType componentType, int entityId) {
            switch (componentType) {
                case Enums.ComponentType.Position:
                case Enums.ComponentType.Direction:
                case Enums.ComponentType.Scale:
                    {
                        Vector3 vc;
                        if (componentType == Enums.ComponentType.Position) {
                            if (positions.TryGetValue(entityId, out vc)) {
                                return vc;
                            }
                        } else if (componentType == Enums.ComponentType.Direction) {
                            if (directions.TryGetValue(entityId, out vc)) {
                                return vc;
                            }
                        } else if (componentType == Enums.ComponentType.Scale) {
                            if (scales.TryGetValue(entityId, out vc)) {
                                return vc;
                            }
                        }
                    }
                    break;
                case Enums.ComponentType.Rotation:
                    {
                        Quaternion qt;
                        if (rotations.TryGetValue(entityId, out qt)) {
                            return qt;
                        }
                    }
                    break;
                case Enums.ComponentType.MaxSpeed:
                    {
                        float fl;
                        if (maxSpeeds.TryGetValue(entityId, out fl)) {
                            return fl;
                        }
                    }
                    break;
                case Enums.ComponentType.Movement:
                case Enums.ComponentType.PreviousFrameMovement:
                    {
                        Components.Movement mv;
                        if (componentType == Enums.ComponentType.Movement) {
                            if (movementComponents.TryGetValue(entityId, out mv)) {
                                return mv;
                            }
                        } else if(componentType == Enums.ComponentType.PreviousFrameMovement) {
                            if (previousFrameMovementComponents.TryGetValue(entityId, out mv)) {
                                return mv;
                            }
                        }
                    }
                    break;
                case Enums.ComponentType.Controllable:
                    {
                        Components.Controllable cr;
                        if (controllables.TryGetValue(entityId, out cr)) {
                            return cr;
                        }
                    }
                    break;

            }
            return null;
        }
        //Replace this with correct type functions, it's slow to unbox and box values with this function
        public void SetComponent(Enums.ComponentType componentType, object component, int entityId) {
            switch (componentType) {
                case Enums.ComponentType.Position:
                case Enums.ComponentType.Direction:
                case Enums.ComponentType.Scale:
                    {
                        if (componentType == Enums.ComponentType.Position) {
                            positions[entityId] = (Vector3)component;
                        } else if (componentType == Enums.ComponentType.Direction) {
                            directions[entityId] = (Vector3)component;
                        } else if (componentType == Enums.ComponentType.Scale) {
                            scales[entityId] = (Vector3)component;
                        }
                    }
                    break;
                case Enums.ComponentType.Rotation:
                    {
                        rotations[entityId] = (Quaternion)component;
                    }
                    break;
                case Enums.ComponentType.MaxSpeed:
                    {
                        maxSpeeds[entityId] = (float)component;
                    }
                    break;
            }
        }
    }
}

