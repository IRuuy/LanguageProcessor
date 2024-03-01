rm -R target
rm -R out

mkdir target
flex -s -o ./target/lex.yy.cpp --header-file=./target/lex.yy.h ./create.l

mkdir out
# g++ -w -Wall main.cpp ./target/lex.yy.cpp -o ./out/create
g++ -Wall main.cpp ./target/lex.yy.cpp -o ./out/create
./out/create "create 'asfd' fds"