using System.Collections.Generic;

namespace Finance.Expenses
{
    public class RecordsOfExpenses
    {
        private readonly ICollection<Expense> expenses;
        private static RecordsOfExpenses instance;

        private RecordsOfExpenses(ICollection<Expense> expenses)
        {
            this.expenses = expenses;
        }

        public static RecordsOfExpenses GetInstance(ICollection<Expense> expenses)
        {
            if (instance == null)
            {
                instance = new RecordsOfExpenses(expenses);
            }

            return instance;
        }

        public void AddExpense(Expense expense)
        {
            expenses.Add(expense);
        }

        public ICollection<Expense> GetExpenses()
        {
            return expenses;
        }
    }
}
