namespace WindowsFormsApp1.Core.AST
{
    internal class TypeNode : INode
    {
        public TypeNode(string Value, string Identifier, INode Child)
        {
            this.Value = Value;
            this.Identifier = Identifier;
            this.Child = Child;
        }

        public string Value { get; set; }
        public string Identifier { get; set; }
        public INode Child { get; set; }
    }
}
