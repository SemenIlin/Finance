using System;

namespace Finance.Interfaces.DataOutput
{
    public class ConsolePrint : IPrint
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
