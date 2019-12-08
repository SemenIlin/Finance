using System;

namespace Finance.Interfaces.DataInput
{
    public class ConsoleInputDataExpense : IInputData
    {
        public int AddDay()
        {
            Console.WriteLine("Введите день");
            return int.TryParse(Console.ReadLine(), out int day) ? (day >= 0 ? day : 0) : 0;
        }

        public decimal AddMoney()
        {
            Console.WriteLine("Введите величину расхода");
            return decimal.TryParse(Console.ReadLine(), out decimal money) ? (money >= 0 ? money : 0) : 0;
        }

        public string AddResource()
        {
            Console.WriteLine("Введите причину");
            return Console.ReadLine();
        }

        public TypeOperation Type() 
        {
            return TypeOperation.Expense;        
        }
    }
}
