using System;
using System.Collections.Generic;
using WindowsFormsApp1.Core.Parser.exception;

namespace WindowsFormsApp1.Core.Parser
{
    internal class Parser : ParserAbstract
    {
        string LETTER = "[A-Za-z]";
        public List<ParserException> errors = new List<ParserException>();
        public string Result = "";

        public override void parse(string statement)
        {
            int position = 0;
            executeProd(statement, ref position, "^create", createProd, errors, ref Result);
        }

        public void createProd(string statement, int position)
            => executeProd(statement, ref position, "^type", typeProd, errors, ref Result);
         
        public void typeProd(string statement, int position)
        => executeProd(statement, ref position, "^" + LETTER, idProd, errors, ref Result);

        public void idProd(string statement, int position)
            => executeProd(
                statement,
                ref position,
                new string[] { "^as", "^" + LETTER, },
                new Action<string, int>[] { asProd, idProd },
                errors,
                ref Result
            );

        public void asProd(string statement, int position)
            => executeProd(statement, ref position, "^enum", enumProd, errors, ref Result);

        public void enumProd(string statement, int position)
            => executeProd(statement, ref position, "^\\(", openProd, errors, ref Result);

        public void openProd(string statement, int position)
            => executeProd(statement, ref position, "^'", stringProd, errors, ref Result);

        public void stringProd(string statement, int position)
            => executeProd(statement, ref position, "^" + LETTER, stringProdRem, errors, ref Result);

        public void stringProdRem(string statement, int position)
            => executeProd(
                statement,
                ref position,
                new string[] { "^" + LETTER, "^'", },
                new Action<string, int>[] { stringProdRem, endStringProd },
                errors,
                ref Result
            );

        public void endStringProd(string statement, int position)
            => executeProd(
                statement,
                ref position,
                new string[] { "^,", "^\\)", },
                new Action<string, int>[] { openProd, closeProd },
                errors,
                ref Result
            );

        public void closeProd(string statement, int position)
            =>  executeProd(statement, ref position, "^;", null, errors, ref Result);
    }
}
