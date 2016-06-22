using System;
using System.Collections.Generic;

public class Context
{
	private Dictionary<string, float> _variables;
	private Dictionary<string, Delegate> _functions;

	public Context(Dictionary<string, float> variables, Dictionary<string, Delegate> functions)
	{
		_variables = new Dictionary<string, float>(variables);
		_functions = new Dictionary<string, Delegate>(functions);
	}

	public float Lookup(string variable)
	{
		return _variables[variable];
	}

	public void Set(string variable, float value)
	{
		if (_variables.ContainsKey(variable))
		{
			_variables[variable] = value;
		}
		else
		{
			_variables.Add(variable, value);
		}
	}

	public float Call(string functionName, object[] parameters)
	{
		return (float)_functions[functionName].DynamicInvoke(parameters);
	}
}
