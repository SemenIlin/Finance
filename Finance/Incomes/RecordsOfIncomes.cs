using System.Collections.Generic;

namespace Finance.Incomes
{
    public class RecordsOfIncomes
    {
        private readonly ICollection<Income> incomes;
        private static RecordsOfIncomes instance;

        private RecordsOfIncomes(ICollection<Income> incomes)
        {
            this.incomes = incomes;
        }

        public static RecordsOfIncomes GetInstance(ICollection<Income> incomes)
        {
            if (instance == null)
            {
                instance = new RecordsOfIncomes(incomes);            
            }

            return instance;
        }

        public void AddIncome(Income income)
        {
            incomes.Add(income);
        }

        public ICollection<Income> GetIncomes()
        {
            return incomes;
        }
    }
}
