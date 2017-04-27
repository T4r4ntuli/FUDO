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

            foreach (Enums.ComponentType componentType in System.Enum.GetValues(typeof(Enums.ComponentType))) { //This optimizable :)
                var component = componentManager.ReturnComponent(componentType, e.id);
                
                if (component != null) {
                    EditorGUILayout.Space();
                    Rect rect = EditorGUILayout.BeginVertical();
                    EditorGUI.DrawRect(rect, Color.gray);
                    System.Type type = component.GetType(); 

                    if (type == typeof(Vector3)) {
                        Vector3 v = (Vector3)component;
                        v = EditorGUILayout.Vector3Field(componentType.ToString(), v);
                        componentManager.SetComponent(componentType, v, e.id);
                    } else if (type == typeof(Quaternion)) {
                        Quaternion qt = (Quaternion)component;
                        qt = Quaternion.Euler(EditorGUILayout.Vector3Field(componentType.ToString(), qt.eulerAngles));
                        componentManager.SetComponent(componentType, qt, e.id);
                    } else if (type == typeof(float)) {
                        float f = (float)component;
                        f = EditorGUILayout.FloatField(componentType.ToString(), f);
                        componentManager.SetComponent(componentType, f, e.id);
                    } else if (type == typeof(int)) {
                        int i = (int)component;
                        i = EditorGUILayout.IntField(componentType.ToString(), i);
                        componentManager.SetComponent(componentType, i, e.id);
                    } else if (type == typeof(bool)) {
                        bool b = (bool)component;
                        b = EditorGUILayout.Toggle(componentType.ToString(), b);
                        componentManager.SetComponent(componentType, b, e.id);
                    } else if (type == typeof(Components.Movement)) {
                        EditorGUILayout.LabelField("Movement");
                        Components.Movement mv = (Components.Movement)component;
                        mv.velocity = EditorGUILayout.Vector3Field("Velocity", mv.velocity);
                    } else if (type == typeof(Components.Controllable)) {
                        EditorGUILayout.LabelField("Controllable");
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


}
