using System;
using Finance.Interfaces;

namespace Finance
{
    public class ConsoleCount: IInputCount
    {
        public int SetCount()
        {
            Console.WriteLine("Введите количество строчек");
            return int.TryParse(Console.ReadLine(), out int count) ? (count >= 0 ? count : 1) : 1;

        }
    }
}
