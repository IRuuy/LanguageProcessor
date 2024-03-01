#include <iostream>
#include <string>

#include "Range.cpp"

using namespace std;

class Token
{
public:
    int getCode(){
        return _code;
    }
    string getValue(){
        return _value;
    }
    string toString(){
        return "Code:\t" + std::to_string(_code) +  "\t" + _range->toString() +  "\tValue:\t\"" + _value + "\"\t";
    }
    Token(int code, string value, Range* range) {
        _code = code;
        _value = value;
        _range = range;
    }
private:
    int _code;
    string _value;
    Range* _range;
};
