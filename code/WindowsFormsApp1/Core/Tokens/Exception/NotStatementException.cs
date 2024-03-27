using System;

namespace WindowsFormsApp1.Core.Tokens
{
    internal class NotStatementException : Exception
    {
        public NotStatementException(int startPostion)
            : base("Неопознанный токен на позиции: " + startPostion) {}
    }
}
