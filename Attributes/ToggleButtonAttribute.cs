using UnityEngine;
using System;

[AttributeUsage(AttributeTargets.Field)]
public class ToggleButtonAttribute : PropertyAttribute
{
	public string m_Enabled;
	public string m_Disabled;

	public ToggleButtonAttribute()
	{
		m_Disabled = "Disabled";
		m_Enabled = "Enabled";
	}

	public ToggleButtonAttribute(string sEnabled, string sDisabled)
	{
		m_Enabled = sEnabled;
		m_Disabled = sDisabled;
	}
}
