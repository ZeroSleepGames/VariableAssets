using UnityEngine;

[CreateAssetMenu(menuName = c_MenuName + "Vector3Int")]
public class Vector3IntAsset : VariableAsset<Vector3Int>
{
	public Vector3Int GetValue()
	{
		return Get();
	}

	public void SetValue(Vector3Int vValue)
	{
		Set(vValue);
	}

	public void Add(Vector3Int vAdd)
	{
		Set(Get() + vAdd);
	}

	public void Subtract(Vector3Int vSubtract)
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

