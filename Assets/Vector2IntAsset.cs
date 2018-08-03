using UnityEngine;

[CreateAssetMenu(menuName = c_MenuName + "Vector2Int")]
public class Vector2IntAsset : VariableAsset<Vector2Int>
{
	public Vector2 GetValue()
	{
		return Get();
	}

	public void SetValue(Vector2Int vValue)
	{
		Set(vValue);
	}

	public void Add(Vector2Int vAdd)
	{
		Set(Get() + vAdd);
	}

	public void Subtract(Vector2Int vSubtract)
	{
		Set(Get() - vSubtract);
	}

	public void Multiply(int nMultiplier)
	{
		Set(Get() * nMultiplier);
	}

	public float GetMagnitude()
	{
		return Get().magnitude;
	}
}

