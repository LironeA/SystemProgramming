lexer grammar CalculatorLexer;

PLUS: '+';
MINUS: '-';
STAR: '*';
SLASH: '/';

PAREN_OPEN: '(';
PAREN_CLOSE: ')';

INT: ('-')? [0-9]+;
DOUBLE: ('-')? [0-9]+ '.' [0-9]+;

WS: [ \t\n\r] -> skip;