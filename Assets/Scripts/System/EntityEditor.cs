using UnityEngine;
using UnityEditor;

namespace Fudo.Drawer {
    [CustomEditor(typeof(Entity))]
    public class EntityEditor : Editor {
        //Basicly draws components in it, gives choices to add or delete component from it
        public override void OnInspectorGUI() { //Replace with property drawer
            Entity e = (Entity)target;
            EditorGUILayout.IntField("EntityID", e.id);

            if (ComponentManager.Instance == null) {
                return;
            }
            ComponentManager componentManager = ComponentManager.Instance;

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
