parser grammar CalculatorParser;

options
{
    tokenVocab=CalculatorLexer;
}

calc: expr+;

expr
    : left=expr op=('*'|'/') right=expr # MulDiv
    | left=expr op=('+'|'-') right=expr # AddSub
    | constant # Const
    | '(' expr ')' # Paren
    ;

constant: INT | DOUBLE;
// (5*5+5)/2