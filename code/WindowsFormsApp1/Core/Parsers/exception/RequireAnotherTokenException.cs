using System;
using System.Collections.Generic;
using WindowsFormsApp1.Core.Parser.exception;
using WindowsFormsApp1.Core.Tokens;

namespace WindowsFormsApp1.Core.Parser
{
    public class RequireAnotherTokenException : ParserException
    {
        public int Position { get; set; }
        public string Message { get;  set; }
        public List<TokenTypeEnum> ExpectedTypes { get; set; }
        public RequireAnotherTokenException(string Message, int Position)
        {
            this.Message = Message;
            this.Position = Position;
        }
        public RequireAnotherTokenException(string Message, int Position, List<TokenTypeEnum>  ExpectedTypes)
        {
            this.Message = Message;
            this.Position = Position;
            this.ExpectedTypes = ExpectedTypes;
        }
        public override string ToString()
        {
            return Message + ", Ожидаемые типы: " + String.Join(String.Empty, ExpectedTypes.ConvertAll(f => f.ToString()));
        }
    }
}
