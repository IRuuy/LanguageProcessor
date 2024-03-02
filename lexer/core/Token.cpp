#include <iostream>
#include <string>

#include "Range.cpp"

using namespace std;

class Token
{
public:
    const char* getCode(){
        return _type;
    }
    string getValue(){
        return _value;
    }
    string toString(){
        if( string(_type).length() > 7 )
            return "Type:\t" + string(_type) +  "\t" + _range->toString() +  "\tValue:\t\"" + _value + "\"\t";
        else
            return "Type:\t" + string(_type) +  "\t\t" + _range->toString() +  "\tValue:\t\"" + _value + "\"\t";
    }
    Token(const char* type, string value, Range* range) {
        _type = type;
        _value = value;
        _range = range;
    }
    
private:
    const char* _type;
    string _value;
    Range* _range;
};
