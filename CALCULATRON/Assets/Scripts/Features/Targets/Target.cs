using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Target : MonoBehaviour
{
	public static Target Create(TargetData data)
	{
		var target = Instantiate(data.prefab).GetComponent<Target>();
		target._health = data.startingHealth;
		target._data = data;
		target._equation = EquationCompiler.Compile(data.equation);
		target._evaluationContext = new Context(
			new Dictionary<string, float>(),
			new Dictionary<string, Delegate>() { 
				{ "sin", (Func<float, float>)Mathf.Sin },
				{ "cos", (Func<float, float>)Mathf.Cos },
				{ "tan", (Func<float, float>)Mathf.Tan },
				{ "abs", (Func<float, float>)Mathf.Abs },
				{ "ceil", (Func<float, float>)Mathf.Ceil },
				{ "floor", (Func<float, float>)Mathf.Floor },
				{ "round", (Func<float, float>)Mathf.Round },
				{ "min", (Func<float, float, float>)Mathf.Min },
				{ "max", (Func<float, float, float>)Mathf.Max },
			}
		);
		return target;
	}

	[SerializeField]
	private Text _healthLabel;

	private Context _evaluationContext;
	private Expression _equation;
	private TargetData _data;
	private int _health;

	private float _t;

	public void Update()
	{
		_healthLabel.text = _health.ToString();

		_t += Time.deltaTime * _data.speed;

		_evaluationContext.Set("t", _t);

		var parentRect = this.transform.parent.GetComponent<RectTransform>().rect;
		var yPos = 0 + _equation.Evaluate(_evaluationContext) / 2.0f * parentRect.height;
		var xPos = 0 - parentRect.width / 2 + _t * parentRect.width;

		GetComponent<RectTransform>().anchoredPosition = new Vector3(xPos, yPos);

		if (_t > 1.0f)
		{
			Destroy(gameObject);
		}
	}

	public void HandleTouch()
	{
		_health--;

		if (_health <= 0)
		{
			Destroy(gameObject);
		}

		#if UNITY_EDITOR

		Selection.activeObject = _data;

		#endif
	}
}
