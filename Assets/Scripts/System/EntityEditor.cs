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
            foreach (Enums.ComponentType componentType in System.Enum.GetValues(typeof(Enums.ComponentType))) { //This optimizable :)
                var component = ComponentManager.Instance.ReturnComponent(componentType, e.id);
                
                if (component != null) {
                    EditorGUILayout.Separator();
                    //EditorGUI.DrawRect()
                    if (component.GetType() == typeof(Vector3)) {
                        EditorGUILayout.Vector3Field(componentType.ToString(), (Vector3)component);
                    } else if (component.GetType() == typeof(Quaternion)) {
                        EditorGUILayout.Vector3Field(componentType.ToString(), ((Quaternion)component).eulerAngles);
                    } else if (component.GetType() == typeof(float)) {
                        EditorGUILayout.FloatField(componentType.ToString(), (float)component);
                    } else if (component.GetType() == typeof(int)) {
                        EditorGUILayout.IntField(componentType.ToString(), (int)component);
                    } else if (component.GetType() == typeof(bool)) {
                        EditorGUILayout.Toggle(componentType.ToString(), (bool)component);
                    } else if (component.GetType() == typeof(Components.Movement)) {
                        EditorGUILayout.LabelField("Movement");
                        Components.Movement mv = (Components.Movement)component;
                        EditorGUILayout.Vector3Field("Velocity", mv.velocity);
                    } else if (component.GetType() == typeof(Components.Controllable)) {
                        EditorGUILayout.LabelField("Controllable");
                    }
                }
            }
            //if (GUILayout.Button((showTools) ? "Hide Transform Tools" : "Show Transform Tools")) {
            //    showTools = !showTools;
            //    EditorPrefs.SetBool("ShowTools", showTools);
            //}
        }
    }


}
