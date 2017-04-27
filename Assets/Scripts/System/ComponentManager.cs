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
        //User made component lists
        public Dictionary<int, Components.Controllable> controllables;
        public Dictionary<int, Components.Movement> movementComponents, previousFrameMovementComponents;

        public override void Init() {
            entityGameObjects = new Dictionary<int, GameObject>();
            entityTransforms = new Dictionary<int, Transform>();
            rigidbodies = new Dictionary<int, Rigidbody>();
            controllables = new Dictionary<int, Components.Controllable>();
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

namespace Fudo.Enums {
    public enum ComponentType {
        Position,
        Scale,
        Direction,
        Rotation,
        MaxSpeed,
        Controllable,
        Movement,
        PreviousFrameMovement,
        Count
    }
}