using Finance.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance
{
    public class ConsolePrint : IPrint
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
