using System;
using System.Collections.Generic;
using System.Text;
using Finance.Commands.CreateMoneyOperation;
using Finance.Queries.GetStoreMoneyOperation;
using Finance.Queries.GetMaxValue;
using Finance.Money;

namespace expenses_revenue
{
    public class MyFinance
    {   
        public void AddIncome(int day, decimal money, string resource)
        {
            var crateIncome = new CreateMoneyOperationCommand(day, money, resource, Finance.TypeOperation.Income);
            var handler = new CreateMoneyOperationHandler();
            handler.Handle(crateIncome);

            Console.WriteLine("Запись добавлена");
        }

        public void AddExpense(int day, decimal money, string resource)
        {
            var createExpense = new CreateMoneyOperationCommand( day, money, resource, Finance.TypeOperation.Expense);
            var handler = new CreateMoneyOperationHandler();
            handler.Handle(createExpense);

            Console.WriteLine("Запись добавлена");
        }

        public List<MoneyOperation> GetListIncomes(int countRecords)
        {
            var getStoreIncomes = new GetStoreMoneyOperationQuery(Finance.TypeOperation.Income, countRecords);
            var handler = new GetStoreMoneyOperationHandler();
            var result = handler.Handle(getStoreIncomes);

            return result;
        }

        public List<MoneyOperation> GetListExpenses(int countRecords)
        {
            var getStoreExpenses = new GetStoreMoneyOperationQuery(Finance.TypeOperation.Expense, countRecords);
            var handler = new GetStoreMoneyOperationHandler();
            var result = handler.Handle(getStoreExpenses);

            return result;
        }

        public MoneyOperation GetMaxValueIncome()
        {
            var maxIncome = new GetMaxValueOperationQuery(Finance.TypeOperation.Income);
            var handler = new GetMaxValueHandler();
            var result = handler.Handle(maxIncome);

            return result;
        }
    }
}
