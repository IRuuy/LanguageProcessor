namespace WindowsFormsApp1.Core.Tokens
{
    public class Range
    {
        public int Start {  get; set; }
        public int End { get; set; }
        public Range(int Start, int End)
        {
            this.Start = Start;
            this.End = End;
        }
    }
}
