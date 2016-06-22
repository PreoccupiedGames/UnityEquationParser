// evaluator.y

// set the namespace for the generated class
%namespace PreoccupiedGames.Evaluator

%partial

// this code is copied straight into the class
// the fields defined here can be accessed
// right in your parser code
%{
    public Parser(Scanner scanner) : base(scanner)
    {

    }

    public Expression result;
%}

// this defines the structure of the
// yylval variable in the Scanner.
// In combination with the %token and
// %type definitions, it also specifies the
// fields that $$ and $[n] refer to.
%union {
    public Expression expression;
    public List<Expression> expressionList;
    public string valString;
    public float valFloat;
}

// token definitions
// %left and %right determine precedence when operators
// are repeated
// <>'s tell the parser which yylval field to pull the token's
// value from when evaluating $$ and $[n]
%token COMMA
%token <valString> IDENTIFIER
%token <valFloat> NUMBER
%token LEFTPAREN RIGHTPAREN
%left MULT DIV
%left PLUS MINUS

// the yylval field specified in <> will determine
// where a result of the following types will be stored
%type <expression> expression operator_expression
%type <expressionList> parameters

%%

// the rule definitions
// these can be read as "is-a" relationships
// for example "an operator_expression is either
// MINUS expression or expression MULT expression or ..."
// when matches are found, the code on the left is executed
// the code on the left contains $$s and $[n].
// $$ will be replaced with the appropriate field
// for the target type
// $[n] refers to the nth element of the matching
// pattern
output
    : expression                        { result = $1; }
    ;

expression
    : operator_expression                           { $$ = $1; }
    | NUMBER                                        { $$ = new Constant($1); }
    | IDENTIFIER LEFTPAREN parameters RIGHTPAREN    { $$ = new FunctionCall($1, $3); }
    | IDENTIFIER                                    { $$ = new Identifier($1); }
    | LEFTPAREN expression RIGHTPAREN               { $$ = $2; }
    ;

parameters
    : expression                                    { $$ = new List<Expression>(); $$.Add($1); }
    | parameters COMMA expression               { $1.Add($3); $$ = $1; }
    ;

operator_expression
    : MINUS expression                  { $$ = new NegateExpression($2); }
    | expression MULT expression        { $$ = new OperatorExpression($1, OperatorExpressionType.Multiply, $3); }
    | expression DIV expression         { $$ = new OperatorExpression($1, OperatorExpressionType.Divide, $3);   }
    | expression PLUS expression        { $$ = new OperatorExpression($1, OperatorExpressionType.Add, $3);      }
    | expression MINUS expression       { $$ = new OperatorExpression($1, OperatorExpressionType.Subtract, $3); }
    ;

%%
