// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, John Gough, QUT 2005-2014
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.2
// Machine:  Tims-MacBook-Pro.local
// DateTime: 2016-05-19 12:19:37 AM
// UserName: tdmann
// Input file <EvaluatorParser.y - 2016-05-19 12:19:29 AM>

// options: lines gplex

using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;
using QUT.Gppg;

namespace PreoccupiedGames.Evaluator
{
public enum Tokens {error=2,EOF=3,DOT=4,COMMA=5,IDENTIFIER=6,
    NUMBER=7,LEFTPAREN=8,RIGHTPAREN=9,MULT=10,DIV=11,PLUS=12,
    MINUS=13};

public partial struct ValueType
#line 15 "EvaluatorParser.y"
       {
    public Expression expression;
    public List<Expression> expressionList;
    public string valString;
    public float valFloat;
}
#line default
// Abstract base class for GPLEX scanners
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

// Utility class for encapsulating token information
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class ScanObj {
  public int token;
  public ValueType yylval;
  public LexLocation yylloc;
  public ScanObj( int t, ValueType val, LexLocation loc ) {
    this.token = t; this.yylval = val; this.yylloc = loc;
  }
}

[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public partial class Parser: ShiftReduceParser<ValueType, LexLocation>
{
  // Verbatim content from EvaluatorParser.y - 2016-05-19 12:19:29 AM
#line 7 "EvaluatorParser.y"
    public Parser(Scanner scanner) : base(scanner)
    {

    }

    public Expression result;
#line default
  // End verbatim content from EvaluatorParser.y - 2016-05-19 12:19:29 AM

#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[15];
  private static State[] states = new State[26];
  private static string[] nonTerms = new string[] {
      "expression", "operator_expression", "parameters", "output", "$accept", 
      };

  static Parser() {
    states[0] = new State(new int[]{13,13,7,15,6,16,8,22},new int[]{-4,1,-1,3,-2,12});
    states[1] = new State(new int[]{3,2});
    states[2] = new State(-1);
    states[3] = new State(new int[]{10,4,11,6,12,8,13,10,3,-2});
    states[4] = new State(new int[]{13,13,7,15,6,16,8,22},new int[]{-1,5,-2,12});
    states[5] = new State(new int[]{10,-11,11,-11,12,8,13,10,3,-11,9,-11,5,-11});
    states[6] = new State(new int[]{13,13,7,15,6,16,8,22},new int[]{-1,7,-2,12});
    states[7] = new State(new int[]{10,-12,11,-12,12,8,13,10,3,-12,9,-12,5,-12});
    states[8] = new State(new int[]{13,13,7,15,6,16,8,22},new int[]{-1,9,-2,12});
    states[9] = new State(-13);
    states[10] = new State(new int[]{13,13,7,15,6,16,8,22},new int[]{-1,11,-2,12});
    states[11] = new State(-14);
    states[12] = new State(-3);
    states[13] = new State(new int[]{13,13,7,15,6,16,8,22},new int[]{-1,14,-2,12});
    states[14] = new State(-10);
    states[15] = new State(-4);
    states[16] = new State(new int[]{8,17,10,-6,11,-6,12,-6,13,-6,3,-6,9,-6,5,-6});
    states[17] = new State(new int[]{13,13,7,15,6,16,8,22},new int[]{-3,18,-1,25,-2,12});
    states[18] = new State(new int[]{9,19,5,20});
    states[19] = new State(-5);
    states[20] = new State(new int[]{13,13,7,15,6,16,8,22},new int[]{-1,21,-2,12});
    states[21] = new State(new int[]{10,4,11,6,12,8,13,10,9,-9,5,-9});
    states[22] = new State(new int[]{13,13,7,15,6,16,8,22},new int[]{-1,23,-2,12});
    states[23] = new State(new int[]{9,24,10,4,11,6,12,8,13,10});
    states[24] = new State(-7);
    states[25] = new State(new int[]{10,4,11,6,12,8,13,10,9,-8,5,-8});

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-5, new int[]{-4,3});
    rules[2] = new Rule(-4, new int[]{-1});
    rules[3] = new Rule(-1, new int[]{-2});
    rules[4] = new Rule(-1, new int[]{7});
    rules[5] = new Rule(-1, new int[]{6,8,-3,9});
    rules[6] = new Rule(-1, new int[]{6});
    rules[7] = new Rule(-1, new int[]{8,-1,9});
    rules[8] = new Rule(-3, new int[]{-1});
    rules[9] = new Rule(-3, new int[]{-3,5,-1});
    rules[10] = new Rule(-2, new int[]{13,-1});
    rules[11] = new Rule(-2, new int[]{-1,10,-1});
    rules[12] = new Rule(-2, new int[]{-1,11,-1});
    rules[13] = new Rule(-2, new int[]{-1,12,-1});
    rules[14] = new Rule(-2, new int[]{-1,13,-1});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
#pragma warning disable 162, 1522
    switch (action)
    {
      case 2: // output -> expression
#line 35 "EvaluatorParser.y"
                                        { result = ValueStack[ValueStack.Depth-1].expression; }
#line default
        break;
      case 3: // expression -> operator_expression
#line 39 "EvaluatorParser.y"
                                                    { CurrentSemanticValue.expression = ValueStack[ValueStack.Depth-1].expression; }
#line default
        break;
      case 4: // expression -> NUMBER
#line 40 "EvaluatorParser.y"
                                                    { CurrentSemanticValue.expression = new Constant(ValueStack[ValueStack.Depth-1].valFloat); }
#line default
        break;
      case 5: // expression -> IDENTIFIER, LEFTPAREN, parameters, RIGHTPAREN
#line 41 "EvaluatorParser.y"
                                                    { CurrentSemanticValue.expression = new FunctionCall(ValueStack[ValueStack.Depth-4].valString, ValueStack[ValueStack.Depth-2].expressionList); }
#line default
        break;
      case 6: // expression -> IDENTIFIER
#line 42 "EvaluatorParser.y"
                                                    { CurrentSemanticValue.expression = new Identifier(ValueStack[ValueStack.Depth-1].valString); }
#line default
        break;
      case 7: // expression -> LEFTPAREN, expression, RIGHTPAREN
#line 43 "EvaluatorParser.y"
                                                    { CurrentSemanticValue.expression = ValueStack[ValueStack.Depth-2].expression; }
#line default
        break;
      case 8: // parameters -> expression
#line 47 "EvaluatorParser.y"
                                                    { CurrentSemanticValue.expressionList = new List<Expression>(); CurrentSemanticValue.expressionList.Add(ValueStack[ValueStack.Depth-1].expression); }
#line default
        break;
      case 9: // parameters -> parameters, COMMA, expression
#line 48 "EvaluatorParser.y"
                                                { ValueStack[ValueStack.Depth-3].expressionList.Add(ValueStack[ValueStack.Depth-1].expression); CurrentSemanticValue.expressionList = ValueStack[ValueStack.Depth-3].expressionList; }
#line default
        break;
      case 10: // operator_expression -> MINUS, expression
#line 52 "EvaluatorParser.y"
                                        { CurrentSemanticValue.expression = new NegateExpression(ValueStack[ValueStack.Depth-1].expression); }
#line default
        break;
      case 11: // operator_expression -> expression, MULT, expression
#line 53 "EvaluatorParser.y"
                                        { CurrentSemanticValue.expression = new OperatorExpression(ValueStack[ValueStack.Depth-3].expression, OperatorExpressionType.Multiply, ValueStack[ValueStack.Depth-1].expression); }
#line default
        break;
      case 12: // operator_expression -> expression, DIV, expression
#line 54 "EvaluatorParser.y"
                                        { CurrentSemanticValue.expression = new OperatorExpression(ValueStack[ValueStack.Depth-3].expression, OperatorExpressionType.Divide, ValueStack[ValueStack.Depth-1].expression);   }
#line default
        break;
      case 13: // operator_expression -> expression, PLUS, expression
#line 55 "EvaluatorParser.y"
                                        { CurrentSemanticValue.expression = new OperatorExpression(ValueStack[ValueStack.Depth-3].expression, OperatorExpressionType.Add, ValueStack[ValueStack.Depth-1].expression);      }
#line default
        break;
      case 14: // operator_expression -> expression, MINUS, expression
#line 56 "EvaluatorParser.y"
                                        { CurrentSemanticValue.expression = new OperatorExpression(ValueStack[ValueStack.Depth-3].expression, OperatorExpressionType.Subtract, ValueStack[ValueStack.Depth-1].expression); }
#line default
        break;
    }
#pragma warning restore 162, 1522
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliases != null && aliases.ContainsKey(terminal))
        return aliases[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

#line 60 "EvaluatorParser.y"
#line default
}
}
