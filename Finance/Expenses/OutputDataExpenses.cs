using Finance.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Finance.Expenses
{
    public class OutputDataExpenses : ICommand
    {
        private readonly IInputCount inputCount;
        private readonly ICollection<Expense> expenses;
        private ICollection<Expense> tempExpense;

        private int countRecords;


        public OutputDataExpenses(IInputCount inputCount, RecordsOfExpenses records)
        {
            expenses = records.GetExpenses();           
            this.inputCount = inputCount;
        }

        public void Print(IPrint print)
        {
            print.Print(GetLest());
        }        

        public void Execute()
        {
            countRecords = inputCount.SetCount();
            GetListExpenses(countRecords);
            Print(new ConsolePrint());
        }

        private string GetLest()
        {
            var sb = new StringBuilder();

            foreach (var expense in tempExpense)
                sb.AppendFormat("Номер дня: {0} \t Сумма: {1} \t Источник: {2}\n", expense.NumberOfDay, expense.ValueExpenses, expense.Resource);

            return sb.ToString();
        }

        private ICollection<Expense> GetListExpenses(int count)
        {
            tempExpense = new List<Expense>();

            if (expenses.Count != 0)
            {
                if (expenses.Count > count)
                {
                    int counter = 0;
                    foreach(var expense in expenses) 
                    {
                        if (counter < count)
                        {
                            tempExpense.Add(expense);
                            counter++;
                        }
                    }
                }

                else if (expenses.Count <= count)
                {
                    tempExpense = expenses;
                }
            }

            return tempExpense;
        }
    }
}
