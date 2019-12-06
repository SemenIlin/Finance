using System;
using System.Collections.Generic;

namespace Finance.Incomes
{
    public class InputDataIncomes
    {
        private int day;
        private decimal money;
        private string resource = String.Empty;
        private RecordsOfIncomes Records { get; }

        public InputDataIncomes()
        {
            AddDay();
            AddMoney();
            AddResource();
            Income income = new Income(day, money, resource);
            Records = RecordsOfIncomes.GetInstance();
            Records.AddIncome(income);
        }
        public RecordsOfIncomes GetRecords()
        {
            return Records;
        }

        private void AddDay()
        {
            Console.WriteLine("Введите день");
            day = int.TryParse(Console.ReadLine(), out day) ? (day >= 0 ? day : 0) : 0 ;
        }

        private void AddMoney()
        {
            Console.WriteLine("Введите величину дохода");
            money = decimal.TryParse(Console.ReadLine(), out money) ? (money >= 0 ? money : 0) : 0;
        }
        private void AddResource()
        {
            Console.WriteLine("Введите источник");
            resource = Console.ReadLine();
        }
    }
}
