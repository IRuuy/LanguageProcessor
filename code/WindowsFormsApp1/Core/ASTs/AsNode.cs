namespace WindowsFormsApp1.Core.AST
{
    internal class AsNode : INode
    {
        public AsNode(string Value, INode child)
        {
            this.Value = Value;
            this.child = child;
        }

        public string Value { get; set; }
        public INode child { get; set; }
    }
}
