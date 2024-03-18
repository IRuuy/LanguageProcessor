using WindowsFormsApp1.Core.Parser.exception;

namespace WindowsFormsApp1.Core.Parser
{
    internal class RequireAnotherTokenException : ParserException
    {
        public int Position { get; set; }
        public string Message {  get; set; }
        public RequireAnotherTokenException(string Message, int Position)
        {
            this.Message = Message;
            this.Position = Position;
        }
    }
}
