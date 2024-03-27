using FastColoredTextBoxNS;
using System.Collections.Generic;
using WindowsFormsApp1.Core.Parser;
using WindowsFormsApp1.Core.Parser.exception;
using WindowsFormsApp1.Core.Tokens;

namespace WindowsFormsApp1.Core.NewParser
{
    public class Requirer
    {
        public Token requireByType(
            List<ParserException> errors,
            TokenStream stream,
            TokenTypeEnum expectedType,
            bool stepShift = true
        ) => requireByAnyType(errors, stream, new List<TokenTypeEnum>() { expectedType }, stepShift);

        public Token requireByAnyType(
            List<ParserException> errors,
            TokenStream stream,
            List<TokenTypeEnum> expectedTypes,
            bool stepShift = true
        ) {
            if (stream.hasNext())
            {
                Token nextToken = stepShift ? stream.Next() : stream.GetNext();
                foreach(TokenTypeEnum expectedType in expectedTypes)
                    if (nextToken.TokenType.Type.Equals(expectedType))
                        return nextToken;
            }

/*            if (stepShift)
                stream.CurrentIndex--;*/

            errors.Add(new RequireAnotherTokenException("Ожидался другой токен!", stream.GetPrev().Range.Start, expectedTypes));
            return null;
        }
    }
}
