using Finance.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Finance.Expenses
{
    public class OutputDataExpenses
    {
        private List<Expense> expense;
        private List<Expense> tempExpense;

        public OutputDataExpenses(int count, RecordsOfExpenses records)
        {
            expense = records.GetExpenses();
            GetListExpenses(count);
        }

        public void Print(IPrint print)
        {
            print.Print(ToString());
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var expense in tempExpense)
                sb.AppendFormat("Номер дня: {0} \t Сумма: {1} \t Источник: {2}\n", expense.NumberOfDay, expense.ValueExpenses, expense.Resource);

            return sb.ToString();
        }

        private List<Expense> GetListExpenses(int count)
        {
            tempExpense = new List<Expense>();

            if (expense.Count != 0)
            {
                if (expense.Count > count)
                {
                    for (int i = 0; i < count; i++)
                    {
                        tempExpense.Add(expense[count]);
                    }
                }

                else if (expense.Count <= 3)
                {
                    tempExpense = expense;
                }
            }

            return tempExpense;
        }
    }
}
