// evaluator.lex
%namespace PreoccupiedGames.Evaluator

white_space [\t ]

digit       [0-9]
alpha       [a-zA-Z]

dot         "."

number      {digit}+({dot}{digit}+)?
identifier  {alpha}({alpha}|{digit})*

%%

{white_space}+	{;}

"("				{ return (int)Tokens.LEFTPAREN; }
")"				{ return (int)Tokens.RIGHTPAREN; }

"+"				{ return (int)Tokens.PLUS; }
"-"				{ return (int)Tokens.MINUS; }
"*"				{ return (int)Tokens.MULT; }
"/"				{ return (int)Tokens.DIV; }

","             { return (int)Tokens.COMMA; }

{identifier}    {
                    yylval.valString = yytext;
                    return (int)Tokens.IDENTIFIER;
                }

{number}        {
                    yylval.valFloat = float.Parse(yytext);
                    return (int)Tokens.NUMBER;
                }

%%
