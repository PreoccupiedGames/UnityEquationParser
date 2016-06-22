using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class TargetData : ScriptableObject 
{
	[SerializeField]
	private int _startingHealth;
	public int startingHealth {
		get { return _startingHealth; }
	}

	[SerializeField]
	private GameObject _prefab;
	public GameObject prefab {
		get { return _prefab; }
	}

	[SerializeField]
	private string _equation;
	public string equation {
		get { return _equation; }
	}

	[SerializeField]
	private float _speed = 0.1f;
	public float speed {
		get { return _speed; }
	}
}
