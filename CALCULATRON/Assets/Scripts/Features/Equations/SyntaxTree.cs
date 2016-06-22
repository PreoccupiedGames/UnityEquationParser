using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public enum OperatorExpressionType
{
	Multiply,
	Divide,
	Add,
	Subtract
}

public abstract class Expression
{
	public abstract float Evaluate(Context context);
}

public class NegateExpression : Expression
{
	private Expression _subExpression;

	public NegateExpression(Expression subExpression)
	{
		_subExpression = subExpression;
	}

	public override float Evaluate(Context context)
	{
		return -_subExpression.Evaluate(context);
	}
}

public class FunctionCall : Expression
{
	private string _functionName;
	private List<Expression> _parameters;

	public FunctionCall(string functionName, List<Expression> parameters)
	{
		_functionName = functionName;
		_parameters = parameters;
	}

	public override float Evaluate(Context context)
	{
		return context.Call(_functionName, _parameters.Select(x => x.Evaluate(context)).Cast<object>().ToArray());
	}
}

public class OperatorExpression : Expression
{
	private Expression _left;
	private OperatorExpressionType _expressionType;
	private Expression _right;

	public OperatorExpression(Expression left, OperatorExpressionType expressionType, Expression right)
	{
		_left = left;
		_expressionType = expressionType;
		_right = right;
	}

	public override float Evaluate(Context context)
	{
		switch (_expressionType)
		{
		case OperatorExpressionType.Add:
			return _left.Evaluate(context) + _right.Evaluate(context);
		case OperatorExpressionType.Subtract:
			return _left.Evaluate(context) - _right.Evaluate(context);
		case OperatorExpressionType.Multiply:
			return _left.Evaluate(context) * _right.Evaluate(context);
		case OperatorExpressionType.Divide:
			return _left.Evaluate(context) / _right.Evaluate(context);
		}
		return float.NaN;
	}
}

public class Identifier : Expression
{
	private string _identifier;

	public Identifier(string identifier)
	{
		_identifier = identifier;
	}

	public override float Evaluate(Context context)
	{
		return context.Lookup(_identifier);
	}
}

public class Constant : Expression
{
	private float _value;

	public Constant(float value)
	{
		_value = value;
	}

	public override float Evaluate(Context context)
	{
		return _value;
	}
}