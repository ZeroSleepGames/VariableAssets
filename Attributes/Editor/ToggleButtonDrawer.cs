using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects, CustomPropertyDrawer(typeof(ToggleButtonAttribute))]
public class ToggleButtonDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		if (property.propertyType != SerializedPropertyType.Boolean)
			return;

		position = EditorGUI.PrefixLabel(position, label);
		Color preColor = GUI.color;
		bool bEnabled = property.boolValue;
		GUI.color = bEnabled ? Color.green : Color.red;

		ToggleButtonAttribute toggleAttribute = attribute as ToggleButtonAttribute;
		if (GUI.Button(position, bEnabled ? toggleAttribute.m_Enabled : toggleAttribute.m_Disabled))
			property.boolValue = !bEnabled;

		GUI.color = preColor;
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return EditorGUI.GetPropertyHeight(property, label, true);
	}
}

