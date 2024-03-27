using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1.Core.Tokens
{
    public class TokenStream
    {
        private List<Token> Tokens { get; set; }
        public int CurrentIndex { get; set; }

        public TokenStream(List<Token> _tokens)
        {
            this.Tokens = _tokens;
            this.CurrentIndex = 0;
        }
        public bool hasNext() => CurrentIndex < Tokens.Count;
        public Token Next() => Tokens[CurrentIndex++];
        public Token GetNext() => Tokens[CurrentIndex];
        public Token GetPrev() => Tokens[Math.Max(CurrentIndex - 1, 0)];
    }
}
