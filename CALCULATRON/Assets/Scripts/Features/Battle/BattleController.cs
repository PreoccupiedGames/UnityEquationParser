using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleController : MonoBehaviour 
{
	[SerializeField]
	private List<TargetData> _targets;

	[SerializeField]
	private Transform _field;

	private Target _currentTarget;

	private void Update()
	{
		if (_currentTarget == null)
		{
			_currentTarget = Target.Create(_targets[Random.Range(0, _targets.Count)]);
			_currentTarget.transform.SetParent(_field, true);
			_currentTarget.Update();
		}
	}
}
