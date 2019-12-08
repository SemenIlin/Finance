using System.Collections.Generic;

namespace Finance.Money
{
    public class RecordsOfMoneyOperations
    {
        private readonly ICollection<MoneyOperation> expenses;
        private static RecordsOfMoneyOperations instance;

        private RecordsOfMoneyOperations(ICollection<MoneyOperation> expenses)
        {
            this.expenses = expenses;
        }

        public static RecordsOfMoneyOperations GetInstance(ICollection<MoneyOperation> expenses)
        {
            if (instance == null)
            {
                instance = new RecordsOfMoneyOperations(expenses);
            }

            return instance;
        }

        public void AddExpense(MoneyOperation expense)
        {
            expenses.Add(expense);
        }

        public ICollection<MoneyOperation> GetExpenses()
        {
            return expenses;
        }
    }
}
