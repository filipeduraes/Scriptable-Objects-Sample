using UnityEditor;
using UnityEngine;
using ValueReferenceSample;

namespace Editor {
    
    [CustomPropertyDrawer(typeof(FloatReference))]
    public class FloatReferenceDrawer : PropertyDrawer {
        
        private readonly string[] popupOptions = {"Variable", "Constant"};
        private GUIStyle popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            if (popupStyle == null)
                PopulateStyle();

            int positionControlID = GUIUtility.GetControlID(FocusType.Passive);
            int indentLevel = EditorGUI.indentLevel;

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, positionControlID, label);
            
            SerializedProperty useConstant = property.FindPropertyRelative("useConstant");
            Rect buttonRect = GenerateRect(ref position);

            SelectOption(useConstant, buttonRect);
            DrawSelectedProperty(position, property, useConstant);
            ApplyChangesAndFinish(property, indentLevel);
        }

        private static void ApplyChangesAndFinish(SerializedProperty property, int indentLevel) {
            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = indentLevel;
            EditorGUI.EndProperty();
        }

        private Rect GenerateRect(ref Rect position) {
            Rect buttonRect = new Rect(position);
            buttonRect.yMin += popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            position.xMin = buttonRect.xMax;
            return buttonRect;
        }

        protected virtual void DrawSelectedProperty(Rect position, SerializedProperty property,
            SerializedProperty useConstant) {
            SerializedProperty selectedProperty = useConstant.boolValue
                ? property.FindPropertyRelative("constantValue")
                : property.FindPropertyRelative("variableValue");

            EditorGUI.PropertyField(position, selectedProperty, GUIContent.none);
        }

        private void SelectOption(SerializedProperty useConstant, Rect buttonRect) {
            EditorGUI.BeginChangeCheck();
            int selectedIndex = useConstant.boolValue ? 1 : 0;
            int result = EditorGUI.Popup(buttonRect, selectedIndex, popupOptions, popupStyle);
            useConstant.boolValue = result == 1;
        }

        private void PopulateStyle() {
            popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
                {imagePosition = ImagePosition.ImageOnly};
        }
    }
}