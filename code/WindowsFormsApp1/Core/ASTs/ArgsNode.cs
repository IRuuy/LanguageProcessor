using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Core.AST;
using WindowsFormsApp1.Core.Tokens;

namespace WindowsFormsApp1.Core.ASTs
{
    internal class ArgsNode : INode
    {
        public List<Token> Args { get; set; }
        public string Value { get; set; }

        public ArgsNode(List<Token> Args) {
            this.Args = Args;
        }
    }
}
