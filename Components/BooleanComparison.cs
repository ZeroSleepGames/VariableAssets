using UnityEngine;
using System;

[Serializable]
public class BooleanComparison
{
	[SerializeField]
	private BooleanAsset m_BooleanAsset;
	[SerializeField, ToggleButton("True", "False")]
	private bool m_CompareValue;

	private Action m_OnValueChanged;

	//Returns whether the evaluation is valid.
	public bool Evaluate(out bool bResult)
	{
		if (m_BooleanAsset == null)
		{
			bResult = false;
			return false;
		}

		bResult = m_BooleanAsset.Get() == m_CompareValue;
		return true;
	}

	private void OnValueChanged(object bNewValue, object bOldValue, UnityEngine.Object changedBy)
	{
		if (m_OnValueChanged != null)
		{
			m_OnValueChanged.Invoke();
		}
	}

	public bool Register(Action onUpdated)
	{
		if (m_BooleanAsset == null)
		{
			return false;
		}

		//First registrar makes us register to the BooleanAsset
		if (m_OnValueChanged == null && onUpdated != null)
		{
			m_BooleanAsset.Register(OnValueChanged);
		}

		m_OnValueChanged += onUpdated;
		return true;
	}

	public void Unregister(Action onUpdated)
	{
		if (m_BooleanAsset == null)
		{
			return;
		}

		m_OnValueChanged -= onUpdated;

		//If no registrars are left, unregister from the asset
		if (m_OnValueChanged == null)
		{
			m_BooleanAsset.Unregister(OnValueChanged);
		}
	}
}
