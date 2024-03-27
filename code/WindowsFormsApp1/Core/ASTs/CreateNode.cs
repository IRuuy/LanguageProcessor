
namespace WindowsFormsApp1.Core.AST
{
    internal class CreateNode : INode
    {
        public CreateNode(string Value, INode child)
        {
            this.Value = Value;
            this.child = child;
        }

        public string Value { get; set; }
        public INode child { get; set; }
    }
}
