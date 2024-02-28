namespace WindowsFormsApp1.Core.Token
{
    public class Token
    {
        public TokenType TokenType { get; set; }
        public string Value {  get; set; }
        public int Position { get; set; }
        public Token(TokenType TokenType, string Value, int Position) { 
            this.TokenType = TokenType;
            this.Value = Value;
            this.Position = Position;
        }
        public override string ToString()
        {
            return "Token(Value=\""+Value+"\", Position=" + Position + ", TokenType=" + TokenType.Type.ToString() + ")\r\n";
        }
    }
}
