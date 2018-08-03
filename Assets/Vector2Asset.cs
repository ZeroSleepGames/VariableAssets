using UnityEngine;

[CreateAssetMenu(menuName = c_MenuName + "Vector2")]
public class Vector2Asset : VariableAsset<Vector2>
{
	public Vector2 GetValue()
	{
		return Get();
	}

	public void SetValue(Vector2 vValue)
	{
		Set(vValue);
	}

	public void Add(Vector2 vAdd)
	{
		Set(Get() + vAdd);
	}

	public void Subtract(Vector2 vSubtract)
	{
		Set(Get() - vSubtract);
	}

	public void Multiply(float fMultiplier)
	{
		Set(Get() * fMultiplier);
	}

	public void Divide(float fDivisor)
	{
		if (fDivisor == 0)
		{
			Debug.LogWarning("Cannot divide by zero on Vector2 asset! " + name);
			return;
		}
		Set(Get() / fDivisor);
	}

	public void Normalize()
	{
		Set(Get().normalized);
	}

	public float GetMagnitude()
	{
		return Get().magnitude;
	}
}

