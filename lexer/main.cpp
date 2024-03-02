#include <iostream>
#include <string>
#include "core/Lexer.h"
#include <stdexcept>

using namespace std;

int main(int argc, char** argv){

    string statement;
    cout << "Input statenent: ";
    getline(cin, statement);

    try {
        vector<Token> vec = getTokens(statement.data());
        for(Token item : vec)
            cout << item.toString() << endl;
    }
    catch( const std::invalid_argument& e ) {
        std::cerr << "Ошибка: " << e.what() << std::endl;
    }
    return 0;
}
