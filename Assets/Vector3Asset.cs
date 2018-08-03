using UnityEngine;

[CreateAssetMenu(menuName = c_MenuName + "Vector3")]
public class Vector3Asset : VariableAsset<Vector3>
{
	public Vector3 GetValue()
	{
		return Get();
	}

	public void SetValue(Vector3 vValue)
	{
		Set(vValue);
	}

	public void Add(Vector3 vAdd)
	{
		Set(Get() + vAdd);
	}

	public void Subtract(Vector3 vSubtract)
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
			Debug.LogWarning("Cannot divide by zero on Vector3 asset! " + name);
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