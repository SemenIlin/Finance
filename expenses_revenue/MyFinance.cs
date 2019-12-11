using System;
using System.Collections.Generic;
using Finance.Commands.CreateMoneyOperation;
using Finance.Queries.GetStoreMoneyOperation;
using Finance.Queries.GetMaxValue;
using Finance.Models;
using System.Linq;

namespace expenses_revenue
{
    public class MyFinance
    {   
        public void AddIncome(int day, decimal money, string resource)
        {
            var createIncome = new CreateMoneyOperationCommand(day, money, resource, TypeOperation.Income);
            var handler = new CreateMoneyOperationHandler();
            handler.Handle(createIncome);

            Console.WriteLine("Запись добавлена");
        }

        public void AddExpense(int day, decimal money, string resource)
        {
            var createExpense = new CreateMoneyOperationCommand( day, money, resource, TypeOperation.Expense);
            var handler = new CreateMoneyOperationHandler();
            handler.Handle(createExpense);

            Console.WriteLine("Запись добавлена");
        }

        public int GetCountIncomes()
        {
            var getStoreIncomes = new GetStoreMoneyOperationQuery(TypeOperation.Income);
            var handler = new GetCountStoreMoneyOperationHandler();
            var result = handler.Handle(getStoreIncomes);

            return result.Count();
        }

        public int GetCountExpenses()
        {
            var getStoreExpenses = new GetStoreMoneyOperationQuery(TypeOperation.Expense);
            var handler = new GetCountStoreMoneyOperationHandler();
            var result = handler.Handle(getStoreExpenses);

            return result.Count();
        }

        public List<MoneyOperation> GetListIncomes(int countRecords)
        {
            var getStoreIncomes = new GetStoreMoneyOperationQuery(TypeOperation.Income, countRecords);
            var handler = new GetStoreMoneyOperationHandler();
            var result = handler.Handle(getStoreIncomes);

            return result;
        }

        public List<MoneyOperation> GetListExpenses(int countRecords)
        {
            var getStoreExpenses = new GetStoreMoneyOperationQuery(TypeOperation.Expense, countRecords);
            var handler = new GetStoreMoneyOperationHandler();
            var result = handler.Handle(getStoreExpenses);

            return result;
        }

        public AnalysisOfData GetAnalysisOfData()
        {
            var maxIncome = new GetAnalysisOfBalanceQuery();
            var handler = new GetAnalysisOfBalanceHandler();
            var result = handler.Handle(maxIncome);

            return result;
        }
    }
}
