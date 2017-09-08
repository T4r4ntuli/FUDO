using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Fudo.Enums;
using UnityEngine;
using UnityEditor;

namespace Fudo.Drawer {
    [CustomEditor(typeof(Entity))]
    public class EntityEditor : Editor {
        public Enums.ComponentType componentTypeToSet;
        public override void OnInspectorGUI() {
            if (target == null)
                return;
            Entity e = (Entity)target;

            if (EntityManager.Instance == null || ComponentManager.Instance == null) {
                return;
            }

            PlayerManager playerManager = PlayerManager.Instance;
            EntityManager entityManager = EntityManager.Instance;
            ComponentManager componentManager = ComponentManager.Instance;
            
            if (e.id == 0 || entityManager.entities.ContainsKey(e.id) == false) {
                if (GUILayout.Button("Create Entity"))
                {
                    e.id = entityManager.GenerateEntityID();
                    e.components = new List<ComponentType>();
                    entityManager.entities.Add(e.id, e);
                    componentManager.entityGameObjects.Add(e.id, e.gameObject);
                    componentManager.entityTransforms.Add(e.id, e.transform);
                    componentManager.rigidbodies.Add(e.id, e.GetComponent<Rigidbody>());
                }
                return;
            }
            else {
                if (GUILayout.Button("Delete Entity")) {
                    entityManager.DeleteEntity(e.id);
                    return;
                }
            }

            EditorGUILayout.IntField("EntityID", e.id);
            EditorGUILayout.BeginHorizontal();
            componentTypeToSet = (Fudo.Enums.ComponentType)EditorGUILayout.EnumPopup("Component to create:", componentTypeToSet);
            if (GUILayout.Button("Create"))
            {
                if (e.components.Contains(componentTypeToSet) == false)
                {
                    switch (componentTypeToSet) {
                        case Enums.ComponentType.Position:
                            componentManager.AddComponent(Enums.ComponentType.Position, Vector3.zero, e.id);
                            break;
                        case Enums.ComponentType.Scale:
                            componentManager.AddComponent(Enums.ComponentType.Scale, Vector3.one, e.id);
                            break;
                        case Enums.ComponentType.Rotation:
                            componentManager.AddComponent(Enums.ComponentType.Rotation, Quaternion.identity, e.id);
                            break;
                        case Enums.ComponentType.Direction:
                            componentManager.AddComponent(Enums.ComponentType.Direction, Vector3.forward, e.id);
                            break;
                        case Enums.ComponentType.MaxSpeed:
                            componentManager.AddComponent(Enums.ComponentType.MaxSpeed, 5.0f, e.id);
                            break;
                        case Enums.ComponentType.Movement:
                            componentManager.AddComponent(Enums.ComponentType.Movement, new Components.Movement(),
                                e.id);
                            break;
                        case Enums.ComponentType.InputToMovement:
                            componentManager.AddComponent(Enums.ComponentType.InputToMovement,
                                new Components.MovementInput(), e.id);
                            break;
                    }
                }
            }

            if (GUILayout.Button("Remove"))
            {
                if (e.components.Contains(componentTypeToSet)) {
                    componentManager.RemoveComponent(componentTypeToSet, e.id);
                }
            }
            EditorGUILayout.EndHorizontal();

            foreach (Enums.ComponentType componentType in e.components) {
                EditorGUILayout.Space();
                Rect rect = EditorGUILayout.BeginVertical();
                EditorGUI.DrawRect(rect, Color.gray);
                switch (componentType) {
                    default:
                        Debug.LogWarning("Component draw not implemented for: " + componentType);
                        break;
                    case Enums.ComponentType.MaxSpeed:
                        float f = componentManager.ReturnFloatComponent(componentType, e.id);
                        f = EditorGUILayout.FloatField(componentType.ToString(), f);
                        componentManager.SetComponent(componentType, f, e.id);
                        break;
                    case Enums.ComponentType.IsVisible:
                        bool b = componentManager.ReturnBooleanComponent(componentType, e.id);
                        b = EditorGUILayout.Toggle(componentType.ToString(), b);
                        componentManager.SetComponent(componentType, b, e.id);
                        break;
                    case Enums.ComponentType.Position:
                    case Enums.ComponentType.Direction:
                    case Enums.ComponentType.Scale:
                        Vector3 v = componentManager.ReturnVector3Component(componentType, e.id);
                        v = EditorGUILayout.Vector3Field(componentType.ToString(), v);
                        componentManager.SetComponent(componentType, v, e.id);
                        break;
                    case Enums.ComponentType.Rotation:
                        Quaternion qt = componentManager.ReturnQuaternionComponent(componentType, e.id);
                        qt = Quaternion.Euler(EditorGUILayout.Vector3Field(componentType.ToString(), qt.eulerAngles));
                        componentManager.SetComponent(componentType, qt, e.id);
                        break;
                    case Enums.ComponentType.Movement:
                    case Enums.ComponentType.PreviousFrameMovement:
                        EditorGUILayout.LabelField(componentType.ToString());
                        Components.Movement mv = componentManager.ReturnMovementComponent(componentType, e.id);
                        mv.velocity = EditorGUILayout.Vector3Field("Velocity", mv.velocity);
                        break;
                    case Enums.ComponentType.Controllable:
                        Components.Controllable controllable;
                        if (componentManager.controllableComponents.TryGetValue(e.id, out controllable)) {
                            EditorGUILayout.LabelField(componentType.ToString());
                        }
                        break;
                }
                EditorGUILayout.EndVertical();
            }
        }
        //if (GUILayout.Button((showTools) ? "Hide Transform Tools" : "Show Transform Tools")) {
        //    showTools = !showTools;
        //    EditorPrefs.SetBool("ShowTools", showTools);
        //}
    }
}
