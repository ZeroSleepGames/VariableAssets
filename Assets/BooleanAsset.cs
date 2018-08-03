using UnityEngine;

[CreateAssetMenu(menuName = c_MenuName + "Boolean")]
public class BooleanAsset : VariableAsset<bool>
{
	public bool GetValue()
	{
		return Get();
	}

	public void SetValue(bool bValue)
	{
		Set(bValue);
	}

	public void Flip()
	{
		Set(!Get());
	}
}

