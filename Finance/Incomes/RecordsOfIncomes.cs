using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Incomes
{
    public class RecordsOfIncomes
    {
        private readonly List<Income> incomes;
        private static RecordsOfIncomes instance;

        private RecordsOfIncomes()
        {
            incomes = new List<Income>();
        }

        public static RecordsOfIncomes GetInstance()
        {
            if (instance == null)
            {
                instance = new RecordsOfIncomes();            
            }

            return instance;
        }

        public void AddIncome(Income income)
        {
            incomes.Add(income);
        }

        public List<Income> GetIncomes()
        {
            return incomes;
        }
    }
}
