using Finance.DAL.Interfaces;
using System;

namespace Finance.DAL.Models
{
    public class Expense: IMoneyOperation
    {
        private static int id;

        public Expense(DateTime day, decimal cost, string resource, decimal tax = 0)
        {
            Day = day;
            Resource = resource;

            Tax = tax;
            Money = cost;
            Id = id;
            ++id;
        }

        public int Id { get; }
        public DateTime Day { get; }
        public decimal Money { get; }
        public decimal Tax { get; }
        public string Resource { get; }
    }
}
