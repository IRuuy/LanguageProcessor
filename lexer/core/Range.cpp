#include <iostream>
#include <string>

using namespace std;

class Range
{
public:
    int getStart(){
        return _start;
    }
    int getEnd(){
        return _end;
    }
    string toString(){
        return "Start:\t" + to_string(_start) + "\tEnd:\t" + to_string(_end); 
    }
    Range(unsigned start, unsigned end) {
        _start = start;
        _end = end;
    }
private:
    unsigned _start;
    unsigned _end;
};
