using UnityEngine;

public abstract class VariableAsset<T> : ScriptableObject
{
	protected const string c_MenuName = "Variable Assets/";
	public delegate void OnValueChanged(object toValue, object fromValue, Object changedBy);
	private OnValueChanged m_OnChanged;

	[SerializeField]
	protected T m_InitialValue;
	[SerializeField]
	protected T m_Value;

	private void OnEnable()
	{
		ResetValue();
	}

	public void ResetValue()
	{
		m_Value = m_InitialValue;
	}

	public T Get()
	{
		return m_Value;
	}

	public void Set(T newValue, bool bInvokeChanged = true, Object changedBy = null)
	{
		if ((m_Value != null && m_Value.Equals(newValue)) || (m_Value == null && newValue == null))
			return;

		T oldValue = m_Value;
		m_Value = newValue;

		if (m_OnChanged != null && bInvokeChanged)
			m_OnChanged.Invoke(m_Value, oldValue, changedBy);
	}

	public void Register(OnValueChanged onChanged)
	{
		m_OnChanged += onChanged;
	}

	public void Unregister(OnValueChanged onChanged)
	{
		m_OnChanged -= onChanged;
	}
}

