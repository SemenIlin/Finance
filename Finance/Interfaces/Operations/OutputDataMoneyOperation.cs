using Finance.Money;
using Finance.Interfaces.DataOutput;
using Finance.Interfaces.DataInput;
using System.Collections.Generic;
using System.Text;

namespace Finance.Interfaces.Operations
{
    public class OutputDataMoneyOperation : ICommand, IQuery<ICollection<MoneyOperation>>
    {
        private readonly IInputCount inputCount;
        private readonly ICollection<MoneyOperation> expenses;
        private ICollection<MoneyOperation> outputData;

        private int countRecords;


        public OutputDataMoneyOperation(IInputCount inputCount, RecordsOfMoneyOperations records)
        {
            expenses = records.GetExpenses();           
            this.inputCount = inputCount;
        }

        public void Print(IPrint print)
        {
            print.Print(ToString());
        }        

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var expense in outputData)
                sb.AppendFormat("Номер дня: {0} \t Сумма: {1} \t Источник: {2}\n", expense.NumberOfDay, expense.Value, expense.Resource);

            return sb.ToString();
        }

        public void Execute()
        {
            countRecords = inputCount.SetCount();
            GetListExpenses(countRecords);
        }

        public ICollection<MoneyOperation> GetListExpenses()
        {
            return outputData;
        }

        private ICollection<MoneyOperation> GetListExpenses(int count)
        {
            outputData = new List<MoneyOperation>();

            if (expenses.Count != 0)
            {
                if (expenses.Count > count)
                {
                    int counter = 0;
                    foreach(var expense in expenses) 
                    {
                        if (counter < count)
                        {
                            outputData.Add(expense);
                            counter++;
                        }
                    }
                }

                else if (expenses.Count <= count)
                {
                    outputData = expenses;
                }
            }

            return outputData;
        }
    }
}
