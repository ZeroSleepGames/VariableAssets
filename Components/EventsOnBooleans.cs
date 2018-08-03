using UnityEngine;
using UnityEngine.Events;

public class EventsOnBooleans : MonoBehaviour
{
	private enum InvokeOn { STATE_CHANGED, EVERY_EVALUATION }

	[Header("Settings"), SerializeField, ToggleButton("True", "False")]
	private bool m_InitialState = false;
	[SerializeField, ToggleButton]
	private bool m_EvaluateOnStart = false;
	[SerializeField]
	private InvokeOn m_InvokeOn;
	[Header("Events"),SerializeField]
	private UnityEvent m_OnTrue;
	[SerializeField]
	private UnityEvent m_OnFalse;
	[SerializeField]
	private BooleanComparison[] m_BooleanComparison;

	private bool m_InternalState;

	private void Awake()
	{
		m_InternalState = m_InitialState;

		foreach (BooleanComparison comparison in m_BooleanComparison)
		{
			if (!comparison.Register(OnComparisonUpdated))
			{
				Debug.LogError("Registration has been skipped for a BooleanComparison with missing Boolean Asset reference at GameObject: " + name);
			}
		}
	}

	private void Start()
	{
		if (m_EvaluateOnStart)
		{
			OnComparisonUpdated();
		}
	}

	private void OnComparisonUpdated()
	{
		bool bResult = true;

		foreach (BooleanComparison comparison in m_BooleanComparison)
		{
			bool bComparison;
			if (comparison.Evaluate(out bComparison) && !bComparison)
			{
				bResult = false;
				break;
			}
		}

		if ((m_InvokeOn == InvokeOn.STATE_CHANGED && bResult != m_InternalState) || m_InvokeOn == InvokeOn.EVERY_EVALUATION)
		{
			if (bResult)
			{
				m_OnTrue.Invoke();
			}
			else
			{
				m_OnFalse.Invoke();
			}
		}

		m_InternalState = bResult;
	}
}
