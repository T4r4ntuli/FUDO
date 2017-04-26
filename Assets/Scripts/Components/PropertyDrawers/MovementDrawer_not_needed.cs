using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;

namespace Fudo.Drawer {
    [CustomPropertyDrawer(typeof(Components.Movement))]
    public class MovementDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginProperty(position, label, property);

            // Draw label
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var velocityRect = new Rect(position.x, position.y, position.width, position.height);

            // Draw fields - passs GUIContent.none to each so they are drawn without labels
            EditorGUI.PropertyField(velocityRect, property.FindPropertyRelative("velocity"), GUIContent.none);

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}
