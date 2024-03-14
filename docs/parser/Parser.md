# Лексический анализатор

[Код Синтаксического анализатора](/code/WindowsFormsApp1/Core/Parser)

## Грамматика ANTLR

```
grammar EnumGrammar;
options
{
language=CSharp;
}

// LEXEMES
DIGIT       : [0-9];
LETTER      : [a-z];

SPACE       : [ \t\r\n]+ -> skip;

UNDER_LINE  : '_';
COMMA       : ',';
EOS         : ';';
QOUTE       : '\'';
LPAR        : '(';
RPAR        : ')';

CREATE      : 'create' | 'CREATE';
AS          : 'as' | 'AS';
ENUM        : 'enum' | 'ENUM';
TYPE        : 'type' | 'TYPE';

// RULES
stmt        : CREATE create;

create      : TYPE type;
type        : LETTER id;

id          : LETTER id
            | AS as;

as          : ENUM enum;

enum        : LPAR open;
open        : QOUTE string;
string      : LETTER stringRem;

stringRem   : LETTER stringRem
              | QOUTE endString;

endString   : RPAR close
              | (COMMA open);

close       : EOS;
```
## АСД

Для выражения: `create type test as enum ('approved');`

![three](https://github.com/IRuuy/LanguageProcessor/assets/86529035/737545be-d963-4ca0-a1e6-77d2151a1691)

## Граф конечного автомата 
![Диаграмма сканера](stateMachineGraph.jpg)

## Тестовые запросы
`create type test as enum ('approved', 'finshed');`
![Пример работы](success.png)

`create sdsd`

![Пример работы](warning.png)


