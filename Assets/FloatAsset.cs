using UnityEngine;

[CreateAssetMenu(menuName = c_MenuName + "Float")]
public class FloatAsset : VariableAsset<float>
{
	[Tooltip("Clamp value between x/y. Use (0,0) for no clamping")]
	public Vector2 m_Range;
	[ToggleButton]
	public bool m_Wrap;

	public float GetValue()
	{
		return Get();
	}

	private void OnValidate()
	{
		m_InitialValue = ValidateValue(m_InitialValue);
	}

	private float ValidateValue(float fValue)
	{
		if (m_Wrap && (fValue > m_Range.y || fValue < m_Range.x))
		{
			fValue = fValue % m_Range.y + m_Range.x;
		}
		if (m_Range != Vector2Int.zero)
		{
			fValue = Mathf.Max(m_Range.x, Mathf.Min(fValue, m_Range.y));
		}
		return fValue;
	}

	public void SetValue(float fValue)
	{
		fValue = ValidateValue(fValue);
		Set(fValue);
	}

	public void Add(float fAdd)
	{
		SetValue(Get() + fAdd);
	}

	public void Subtract(float fSubtract)
	{
		SetValue(Get() - fSubtract);
	}

	public void Multiply(float fMultiplier)
	{
		SetValue(Get() * fMultiplier);
	}

	public void Divide(float fDivisor)
	{
		if (fDivisor == 0)
		{
			Debug.LogWarning("Cannot divide by zero on float asset! " + name);
			return;
		}
		SetValue(Get() / fDivisor);
	}
}

