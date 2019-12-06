using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Incomes
{
    public class Income
    {
        public Income(int numberOfDay, decimal value, string resource)
        {
            NumberOfDay = numberOfDay;
            ValueIncome = value;
            Resource = resource;
        }

        public int NumberOfDay { get; }
        public decimal ValueIncome { get; }
        public string Resource { get; }
    }
}
