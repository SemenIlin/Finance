using System;
using System.Collections.Generic;
using System.Text;
using Finance.Interfaces.Operations;
using Finance.Money;

namespace expenses_revenue
{
    public class MyFinance
    {   
        public string AddIncome(int day, decimal money, string resource)
        {
            var inputDataMoneyOperation = new InputDataMoneyOperation(new List<MoneyOperation>(), day, money, resource, Finance.TypeOperation.Income);
            var handler = new InputDataMoneyOperationHandler();
            var result = handler.Handle(inputDataMoneyOperation);

            return result;
        }

        public string AddExpense(int day, decimal money, string resource)
        {
            var inputDataMoneyOperation = new InputDataMoneyOperation(new List<MoneyOperation>(), day, money, resource, Finance.TypeOperation.Expense);
            var handler = new InputDataMoneyOperationHandler();
            var result = handler.Handle(inputDataMoneyOperation);

            return result;
        }

        public ICollection<MoneyOperation> GetListIncomes(int countRecords)
        {
            var outputDataMoneyOperation = new OutputDataMoneyOperation(RecordsOfMoneyOperations.GetInstance(new List<MoneyOperation>()),Finance.TypeOperation.Income, countRecords);
            var handler = new OutputDataMoneyOperationHandler();
            var result = handler.Handle(outputDataMoneyOperation);

            return result;
        }

        public ICollection<MoneyOperation> GetListExpenses(int countRecords)
        {
            var outputDataMoneyOperation = new OutputDataMoneyOperation(RecordsOfMoneyOperations.GetInstance(new List<MoneyOperation>()), Finance.TypeOperation.Expense, countRecords);
            var handler = new OutputDataMoneyOperationHandler();
            var result = handler.Handle(outputDataMoneyOperation);

            return result;
        }
    }
}
