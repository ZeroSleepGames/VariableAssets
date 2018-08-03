using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EventsOnBooleans))]
public class EventsOnBooleansEditor : Editor
{
	private SerializedProperty m_PropertyInitialState;
	private SerializedProperty m_PropertyEvaluateOnStart;
	private SerializedProperty m_PropertyInvokeOn;
	private SerializedProperty m_PropertyOnTrue;
	private SerializedProperty m_PropertyOnFalse;
	private SerializedProperty m_PropertyBooleanComparison;

	private void OnEnable()
	{
		m_PropertyInitialState = serializedObject.FindProperty("m_InitialState");
		m_PropertyEvaluateOnStart = serializedObject.FindProperty("m_EvaluateOnStart");
		m_PropertyInvokeOn = serializedObject.FindProperty("m_InvokeOn");
		m_PropertyOnTrue = serializedObject.FindProperty("m_OnTrue");
		m_PropertyOnFalse = serializedObject.FindProperty("m_OnFalse");
		m_PropertyBooleanComparison = serializedObject.FindProperty("m_BooleanComparison");
	}

	public override void OnInspectorGUI()
	{
		EditorGUI.BeginChangeCheck();

		EditorGUILayout.PropertyField(m_PropertyInitialState);
		EditorGUILayout.PropertyField(m_PropertyEvaluateOnStart);
		EditorGUILayout.PropertyField(m_PropertyInvokeOn);
		EditorGUILayout.PropertyField(m_PropertyOnTrue);
		EditorGUILayout.PropertyField(m_PropertyOnFalse);
		EditorGUILayout.Space();
		DrawBooleanComparison();

		if (EditorGUI.EndChangeCheck())
		{
			serializedObject.ApplyModifiedProperties();
		}
	}

	private void DrawBooleanComparison()
	{
		EditorGUILayout.LabelField("Boolean Checks", EditorStyles.boldLabel);

		for (int i = 0; i < m_PropertyBooleanComparison.arraySize; i++)
		{
			SerializedProperty comparison = m_PropertyBooleanComparison.GetArrayElementAtIndex(i);
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PropertyField(comparison.FindPropertyRelative("m_BooleanAsset"));

			GUI.color = Color.red;
			if (GUILayout.Button("X", GUILayout.MaxWidth(30)))
			{
				m_PropertyBooleanComparison.DeleteArrayElementAtIndex(i);
				i--;
				EditorGUILayout.EndHorizontal();
				break;
			}
			GUI.color = Color.white;
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.PropertyField(comparison.FindPropertyRelative("m_CompareValue"));
			EditorGUILayout.Space();
		}

		if (GUILayout.Button("+ Add Check"))
		{
			m_PropertyBooleanComparison.InsertArrayElementAtIndex(Mathf.Max(m_PropertyBooleanComparison.arraySize - 1,0));
		}
	}
}