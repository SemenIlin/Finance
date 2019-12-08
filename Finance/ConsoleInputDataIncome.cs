using System;
using Finance.Interfaces;

namespace Finance
{
    public class ConsoleInputDataIncome : IInputData
    {
        public int AddDay()
        {
            Console.WriteLine("Введите день");
            return int.TryParse(Console.ReadLine(), out int day) ? (day >= 0 ? day : 0) : 0;
        }

        public decimal AddMoney()
        {
            Console.WriteLine("Введите величину дохода");
            return decimal.TryParse(Console.ReadLine(), out decimal money) ? (money >= 0 ? money : 0) : 0;
        }

        public string AddResource()
        {
            Console.WriteLine("Введите источник");
            return  Console.ReadLine();
        }
    }
}
