using Finance.DAL.Interfaces;
using System;

namespace Finance.DAL.Models
{
    public class Income : IMoneyOperation
    {
        private static int id = 1;

        public Income(DateTime day, decimal tax, decimal money, string resource)
        {
            Day = day;
            Resource = resource;

            Tax = tax;
            Money = money;
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
