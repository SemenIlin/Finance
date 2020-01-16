using DAL.Interfaces;
using System;

namespace DAL.Models
{
    public class Income : IMoneyOperation
    {
        private static int id = 1;

        public Income()
        {
            Id = id;
            ++id;
        }

        public int Id { get; set; }
        public DateTime Day { get; set; }
        public decimal Money { get; set; }
        public decimal Tax { get; set; }
        public string Resource { get; set; }
    }
}
