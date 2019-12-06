using System.Collections.Generic;

namespace Finance.Expenses
{
    public class RecordsOfExpenses
    {
        private readonly List<Expense> expenses = new List<Expense>();
        private static RecordsOfExpenses instance;

        private RecordsOfExpenses()
        {
            expenses = new List<Expense>();
        }

        public static RecordsOfExpenses GetInstance()
        {
            if (instance == null)
            {
                instance = new RecordsOfExpenses();
            }

            return instance;
        }

        public void AddIncome(Expense expense)
        {
            expenses.Add(expense);
        }

        public List<Expense> GetExpenses()
        {
            return expenses;
        }
    }
}
