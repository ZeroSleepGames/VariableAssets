using UnityEngine;
using System;

[CreateAssetMenu(menuName = c_MenuName + "Integer")]
public class IntegerAsset : VariableAsset<int>
{
	[Tooltip("Clamp value between x/y. Use (0,0) for no clamping")]
	public Vector2Int m_Range;
	[ToggleButton]
	public bool m_Wrap;

	private void OnValidate()
	{
		m_InitialValue = ValidateValue(m_InitialValue);
	}

	private int ValidateValue(int nValue)
	{
		if (m_Wrap && (nValue > m_Range.y || nValue < m_Range.x))
		{
			nValue = nValue % m_Range.y + m_Range.x;
		}
		if (m_Range != Vector2Int.zero)
		{
			nValue = Math.Max(m_Range.x, Math.Min(nValue, m_Range.y));
		}
		return nValue;
	}

	public int GetValue()
	{
		return Get();
	}

	public void SetValue(int nValue)
	{
		nValue = ValidateValue(nValue);
		Set(nValue);
	}

	public void Add(int nAdd)
	{
		SetValue(Get() + nAdd);
	}

	public void Subtract(int nSubtract)
	{
		SetValue(Get() - nSubtract);
	}

	public void Multiply(int nMultiplier)
	{
		SetValue(Get() * nMultiplier);
	}

	public void Divide(int nDivisor)
	{
		if (nDivisor == 0)
		{
			Debug.LogWarning("Cannot divide by zero on integer asset! " + name);
			return;
		}
		SetValue(Get() / nDivisor);
	}

	public void XOr(int nValue)
	{
		SetValue(Get() ^ nValue);
	}

	public void And(int nValue)
	{
		SetValue(Get() & nValue);
	}

	public void Or(int nValue)
	{
		SetValue(Get() | nValue);
	}

	public void Not()
	{
		SetValue(~Get());
	}

	public void ShiftLeft(int nPlaces)
	{
		SetValue(Get() << nPlaces);
	}

	public void ShiftRight(int nPlaces)
	{
		SetValue(Get() >> nPlaces);
	}
}

