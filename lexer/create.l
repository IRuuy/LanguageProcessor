%option noyywrap

%{
  #include <iostream>
  #include <vector>
  #include <stdexcept>

  #include "../core/TokenType.h"
  #include "../core/Token.cpp"


  #define stringify( name ) #name

  namespace std {
    template <typename _CharT, typename _Traits>
    inline basic_ostream<_CharT, _Traits> &
    tab(basic_ostream<_CharT, _Traits> &__os) {
      return __os.put(__os.widen('\t'));
    }
  }

  using namespace std;
%}

%%
[ \t\n]                         {   return SPACE;       }
"create"                        {   return KEYWORD;     }
"type"                          {   return KEYWORD;     }
"as"                            {   return KEYWORD;     }
"enum"                          {   return KEYWORD;     }

[a-zA-Z_][a-zA-Z0-9_]*          {   return IDENTIFIER;  }
'[a-zA-Z_][a-zA-Z0-9_]*'        {   return STRING;      }

","                             {   return COMMA;       }
"\("                            {   return LPAR;        }
"\)"                            {   return RPAR;        }
";"                             {   return EOS;         }

.                               {   return -1;           }

%%

const char* convert_enum_to_string[] = {
        stringify(),
        stringify(KEYWORD),
        stringify(IDENTIFIER),
        stringify(STRING),
        stringify(LPAR),
        stringify(RPAR),
        stringify(COMMA),
        stringify(SPACE),
        stringify(EOS)
};

const char* convertEnumToString(int value) {
    return convert_enum_to_string[value];
}

vector<Token> getTokens(char string[]) {
    yy_scan_string(string);
    int pos = 0;
    vector<Token> tokens;
    
    while(int token = yylex()){
        if(token == -1) {
          throw std::invalid_argument("Некорректный токен на позиции: " + to_string(pos));
        } else {
              Range* range = new Range(pos, pos+sizeof(yytext)/sizeof(char)-1);
              Token* tok = new Token(token, yytext, range);
              tokens.push_back(*tok);
              pos += sizeof(yytext)/sizeof(char);
        }
    }
    return tokens;
}