using System;
using System.Collections.Generic;

namespace WindowsFormsApp1.Core.Parser
{
    internal class Parser : ParserAbstract
    {
        string LETTER = "[A-Za-z]";
        public List<string> errors = new List<string>();
        public override void parse(string statement)
        {
            int position = 0;
            executeProd(statement, ref position, "^create", createProd, errors);
        }

        public void createProd(string statement, int position)
            => executeProd(statement, ref position, "^type", typeProd, errors);
         
        public void typeProd(string statement, int position)
        => executeProd(statement, ref position, "^" + LETTER, idProd, errors);

        public void idProd(string statement, int position)
            => executeProd(
                statement,
                ref position,
                new string[] { "^as", "^" + LETTER, },
                new Action<string, int>[] { asProd, idProd },
                errors
            );

        public void asProd(string statement, int position)
            => executeProd(statement, ref position, "^enum", enumProd, errors);

        public void enumProd(string statement, int position)
            => executeProd(statement, ref position, "^\\(", openProd, errors);

        public void openProd(string statement, int position)
            => executeProd(statement, ref position, "^'", stringProd, errors);

        public void stringProd(string statement, int position)
            => executeProd(statement, ref position, "^" + LETTER, stringProdRem, errors);

        public void stringProdRem(string statement, int position)
            => executeProd(
                statement,
                ref position,
                new string[] { "^" + LETTER, "^'", },
                new Action<string, int>[] { stringProdRem, endStringProd },
                errors
            );

        public void endStringProd(string statement, int position)
            => executeProd(
                statement,
                ref position,
                new string[] { "^,", "^\\)", },
                new Action<string, int>[] { openProd, closeProd },
                errors
            );

        public void closeProd(string statement, int position)
            =>  executeProd(statement, ref position, "^;", null, errors);
    }
}
