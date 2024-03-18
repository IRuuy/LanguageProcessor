using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WindowsFormsApp1.Core.Parser.exception;

namespace WindowsFormsApp1.Core.Parser
{
    internal abstract class ParserAbstract
    {
        public abstract void parse(string statement);
        protected void skipTabs(string statement, ref int position, ref string output)
        {
            string pattern = "^" + "[\\s\\t\\n\\r]";
            while (Regex.Match(statement.Substring(position), pattern).Success)
                position++;
        }

        protected void executeProd(
            string statement,
            ref int position,
            string pattern,
            Action<string, int> action,
            List<ParserException> errors,
            ref string output
        ) {
            Action<string, int>[] actions = { action };
            string[] patterns = { pattern };

            executeProd(statement, ref position, patterns, actions, errors, ref output);
        }

        protected void executeProd(
            string statement,
            ref int position,
            string[] patterns,
            Action<string, int>[] actions,
            List<ParserException> errors,
            ref string output
        )
        {
            while(position <= statement.Length)
            {
                for (int i = 0; i < patterns.Length; i++)
                {
                    skipTabs(statement, ref position, ref output);

                    string pattern = patterns[i];
                    var te = statement.Substring(position);
                    Match match = Regex.Match(statement.Substring(position), pattern);
                    if (match.Success)
                    {
                        output += match.Groups[0].Value + " ";
                        actions[i]?.Invoke(statement, position + match.Groups[0].Value.Length);
                        return;
                    }
                }
                errors.Add(new RequireAnotherTokenException("Ожидался другой токен!", position));
                position++;
            }
        }
    }
}
