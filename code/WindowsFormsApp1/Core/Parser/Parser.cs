using System;

namespace WindowsFormsApp1.Core.Parser
{
    internal class Parser : ParserAbstract
    {
        string LETTER = "[A-Za-z]";
        public override void parse(string statement)
        {
            int position = 0;
            executeProd(statement, ref position, "^create", createProd);
        }

        public void createProd(string statement, int position)
            => executeProd(statement, ref position, "^type", typeProd);

        public void typeProd(string statement, int position)
        => executeProd(statement, ref position, "^" + LETTER, idProd);

        public void idProd(string statement, int position)
            => executeProd(
                statement,
                ref position,
                new string[] { "^as", "^" + LETTER, },
                new Action<string, int>[] { asProd, idProd }
            );

        public void asProd(string statement, int position)
            => executeProd(statement, ref position, "^enum", enumProd);

        public void enumProd(string statement, int position)
            => executeProd(statement, ref position, "^\\(", openProd);

        public void openProd(string statement, int position)
            => executeProd(statement, ref position, "^'", stringProd);

        public void stringProd(string statement, int position)
            => executeProd(statement, ref position, "^" + LETTER, stringProdRem);

        public void stringProdRem(string statement, int position)
            => executeProd(
                statement,
                ref position,
                new string[] { "^" + LETTER, "^'", },
                new Action<string, int>[] { stringProdRem, endStringProd }
            );

        public void endStringProd(string statement, int position)
            => executeProd(
                statement,
                ref position,
                new string[] { "^,", "^\\)", },
                new Action<string, int>[] { openProd, closeProd }
            );

        public void closeProd(string statement, int position)
            =>  executeProd(statement, ref position, "^;", null);
    }
}
