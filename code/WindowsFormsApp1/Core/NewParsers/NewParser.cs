using System.Collections.Generic;
using WindowsFormsApp1.Core.AST;
using WindowsFormsApp1.Core.ASTs;
using WindowsFormsApp1.Core.Parser.exception;
using WindowsFormsApp1.Core.Tokens;

namespace WindowsFormsApp1.Core.NewParser
{
    internal class NewParser
    {
        private Requirer Requirer { get; set; }
        public List<ParserException> ParserExceptions { get; set; }
        public NewParser()
        {
            Requirer = new Requirer();
            ParserExceptions = new List<ParserException>();
        }

        public INode parseSTMT(TokenStream stream)
        {
            INode node = createProd(stream);
            Requirer.requireByType(ParserExceptions, stream, TokenTypeEnum.EOF);
            return node;
        }
        public INode createProd(TokenStream stream)
        {
           Token token = Requirer.requireByType(ParserExceptions, stream, TokenTypeEnum.CREATE);
           return new CreateNode(token?.Value, typeProd(stream));
        }
        public INode typeProd(TokenStream stream)
        {
            Token value = Requirer.requireByType(ParserExceptions, stream, TokenTypeEnum.TYPE);
            Token id = Requirer.requireByType(ParserExceptions, stream, TokenTypeEnum.IDENTIFIER);

            return new TypeNode(value?.Value, id?.Value, asProd(stream));
        }
        public INode asProd(TokenStream stream)
        {
            Token token = Requirer.requireByType(ParserExceptions, stream, TokenTypeEnum.AS);
            return new AsNode(token?.Value, enumProd(stream));
        }
        public INode enumProd(TokenStream stream)
        {
            Token token = Requirer.requireByType(ParserExceptions, stream, TokenTypeEnum.ENUM);

            Requirer.requireByType(ParserExceptions, stream, TokenTypeEnum.LPAR);
            INode node = argsProd(stream);
            Requirer.requireByType(ParserExceptions, stream, TokenTypeEnum.RPAR);

            return new AsNode(token?.Value, node);
        }

        public INode argsProd(TokenStream stream)
        {
            List<Token> args = new List<Token>();
            while (true)
            {
                if(Requirer.requireByType(ParserExceptions, stream, TokenTypeEnum.STRING, false) != null)
                    args.Add(stream.Next());

                if (!stream.hasNext() || !stream.GetNext().TokenType.Type.Equals(TokenTypeEnum.COMMA))
                    break;

                stream.CurrentIndex++;
            }

            return new ArgsNode(args);
        }
    }
}
