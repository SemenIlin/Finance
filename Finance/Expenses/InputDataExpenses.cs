using System;

namespace Finance.Expenses
{
    public class InputDataExpenses
    {
        private int day;
        private decimal money;
        private string resource = String.Empty;
        private RecordsOfExpenses Records { get; }

        public InputDataExpenses()
        {
            AddDay();
            AddMoney();
            AddResource();
            Expense expense = new Expense(day, money, resource);
            Records = RecordsOfExpenses.GetInstance();
            Records.AddIncome(expense);
        }
        public RecordsOfExpenses GetRecords()
        {
            return Records;
        }

        private void AddDay()
        {
            Console.WriteLine("Введите день");
            day = int.TryParse(Console.ReadLine(), out day) ? (day >= 0 ? day : 0) : 0;
        }

        private void AddMoney()
        {
            Console.WriteLine("Введите величину расхода");
            money = decimal.TryParse(Console.ReadLine(), out money) ? (money >= 0 ? money : 0) : 0;
        }
        private void AddResource()
        {
            Console.WriteLine("Введите причину");
            resource = Console.ReadLine();
        }
    }
}
