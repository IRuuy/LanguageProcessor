using System;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1.Core.Parser
{
    internal abstract class ParserAbstract
    {
        public abstract void parse(string statement);
        protected void skipTabs(string statement, ref int position)
        {
            string pattern = "^" + "[\\s\\t]";

            while (Regex.Match(statement.Substring(position), pattern).Success)
                position++;
        }

        protected void executeProd(
            string statement,
            ref int position,
            string pattern,
            Action<string, int> action
        ) {
            Action<string, int>[] actions = { action };
            string[] patterns = { pattern };

            executeProd(statement, ref position, patterns, actions);
        }

        protected void executeProd(
            string statement,
            ref int position,
            string[] patterns,
            Action<string, int>[] actions
        )
        {
            for(int i = 0; i < patterns.Length; i++)
            {
                skipTabs(statement, ref position);

                string pattern = patterns[i];
                var te = statement.Substring(position);
                Match match = Regex.Match(statement.Substring(position), pattern);
                if(match.Success)
                {
                    actions[i]?.Invoke(statement, position + match.Groups[0].Value.Length);
                    return;
                }
            }

            throw new RequireAnotherTokenException(position);
        }
    }
}
