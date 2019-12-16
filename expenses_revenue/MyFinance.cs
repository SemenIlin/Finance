using Finance.Commands.CreateMoneyOperationWithTax;
using Finance.Commands.CreateMoneyOperation;
using Finance.Models;
using Finance.Queries.GetAnalysisOfData;
using Finance.Queries.GetStoreMoneyOperation;
using System.Collections.Generic;
using System.Linq;
using Finance.Modifications.Tax;
using Finance.Queries.GetAnalysisDataWithTax;

namespace expenses_revenue
{
    public class MyFinance
    {
        public void AddIncome()
        {           
            System.Console.WriteLine("Введите день:");
            int day = int.TryParse(System.Console.ReadLine(), out day) ? (day > 0 ? day : 1) : 1;

            System.Console.WriteLine("Введите величину дохода:");
            decimal money = decimal.TryParse(System.Console.ReadLine(), out money) ? (money > 0 ? money : 0) : 0;

            System.Console.WriteLine("Введите источник:");
            string resource = System.Console.ReadLine();

            var createIncome = new CreateMoneyOperationCommand(day, money, resource, TypeOperation.Income);
            var handler = new CreateMoneyOperationHandler();
            handler.Handle(createIncome);

            System.Console.WriteLine("Запись добавлена");
        }

        public void AddIncomeWithTax()
        {
            System.Console.WriteLine("Введите день:");
            int day = int.TryParse(System.Console.ReadLine(), out day) ? (day > 0 ? day : 1) : 1;

            System.Console.WriteLine("Введите величину дохода:");
            decimal money = decimal.TryParse(System.Console.ReadLine(), out money) ? (money > 0 ? money : 0) : 0;

            System.Console.WriteLine("Введите источник:");
            string resource = System.Console.ReadLine();

            var createIncome = new CreateMoneyOperationWithTaxCommand(day, money, resource, TypeOperation.Income, new IncomeTax(13));
            var handler = new CreateMoneyOperationWithTaxHandler();
            handler.Handle(createIncome);

            System.Console.WriteLine("Запись добавлена");

        }

        public void AddExpense()
        {

            System.Console.WriteLine("Введите день:");
            int day = int.TryParse(System.Console.ReadLine(), out day) ? (day > 0 ? day : 1) : 1;

            System.Console.WriteLine("Введите величину расхода:");
            decimal money = decimal.TryParse(System.Console.ReadLine(), out money) ? (money > 0 ? money : 0) : 0;

            System.Console.WriteLine("Введите причину:");
            string resource = System.Console.ReadLine();

            var createExpense = new CreateMoneyOperationCommand(day, money, resource, TypeOperation.Expense);
            var handler = new CreateMoneyOperationHandler();
            handler.Handle(createExpense);

            System.Console.WriteLine("Запись добавлена");
        }

        public void GetTableOfIncomes()
        {
            var incomes = GetListIncomes();

            var tableIncome = new ConsoleTable("Номер дня ", "Величина", "Источник");

            foreach (var item in incomes)
            {
                tableIncome.AddRow(item.NumberOfDay.ToString(), item.Value.ToString(), item.Resource.ToString());
            }
            System.Console.WriteLine("Доходы");
            tableIncome.Print();
        }

        public void GetTableOfIncomesWithTax()
        {
            var incomes = GetListIncomes();

            var tableIncome = new ConsoleTable("Номер дня ", "Источник", "Величина", "Налог");

            foreach (var item in incomes)
            {
                tableIncome.AddRow(item.NumberOfDay.ToString(), item.Resource.ToString(), item.Balance.ToString(), item.Tax.ToString());
            }

            System.Console.WriteLine("Доходы");
            tableIncome.Print();
        }

        public void GetTableOfExpenses()
        {
            var expenses = GetListExpenses();

            var tableExpense = new ConsoleTable("Номер дня ", "Величина", "Причина");

            foreach (var item in expenses)
            {
                tableExpense.AddRow(item.NumberOfDay.ToString(), item.Value.ToString(), item.Resource.ToString());
            }
            System.Console.WriteLine("Расходы");
            tableExpense.Print(); 
        }

        public void GetTableOfAnalysis()
        {
            var analysis = GetAnalysisOfData();
            var tableExpenses = new ConsoleTable("Причина траты", "Величина");

            foreach (var item in analysis.Expense)
            {
                tableExpenses.AddRow(item.Resource, item.Value.ToString());
            }
            System.Console.WriteLine("Затраты");
            tableExpenses.Print();

            System.Console.WriteLine();

            var tableIncomes = new ConsoleTable("Источник дохода", "Величина");
            foreach (var item in analysis.Income)
            {
                tableIncomes.AddRow(item.Resource, item.Value.ToString());
            }
            System.Console.WriteLine("Доходы");
            tableIncomes.Print();

            System.Console.WriteLine("Доход: {0}, Расход: {1}, Дельта:{2}", analysis.TotalValueIncome, analysis.TotalValueExpense, analysis.Delta);
        }

        public void GetTableOfAnalysisWithTax()
        {
            var analysis = GetAnalysisOfDataWithTax();
            var tableExpenses = new ConsoleTable("Причина траты", "Величина");

            foreach (var item in analysis.Expense)
            {
                tableExpenses.AddRow(item.Resource, item.Value.ToString());
            }
            System.Console.WriteLine("Затраты");
            tableExpenses.Print();

            System.Console.WriteLine();

            var tableIncomes = new ConsoleTable("Источник дохода", "Величина", "Налоги");
            foreach (var item in analysis.Income)
            {
                tableIncomes.AddRow(item.Resource, item.Value.ToString(), item.Tax.ToString() );
            }
            System.Console.WriteLine("Доходы");
            tableIncomes.Print();

            System.Console.WriteLine("Доход: {0}, Расход: {1}, Дельта:{2}", analysis.TotalValueIncome, analysis.TotalValueExpense, analysis.Delta);
        }

        private AnalysisOfData GetAnalysisOfData()
        {
            var maxIncome = new GetAnalysisOfBalanceQuery();
            var handler = new GetAnalysisOfBalanceHandler();
            var result = handler.Handle(maxIncome);

            return result;
        }

        private AnalysisOfData GetAnalysisOfDataWithTax()
        {
            var maxIncome = new GetAnalysisOfBalanceQuery();
            var handler = new GetAnalysisOfBalanceWithTaxHandler();
            var result = handler.Handle(maxIncome);

            return result;
        }

        private List<MoneyOperation> GetListIncomes()
        {
            int countRecords = 1;
            var allCountIncomes = GetCountIncomes();

            if (allCountIncomes > 0)
            {
                System.Console.WriteLine($"Введите количество строчек не больше {allCountIncomes}:");
                countRecords = int.TryParse(System.Console.ReadLine(), out countRecords) ? (countRecords > 0 ? countRecords : 1) : 1;
            }

            var getStoreIncomes = new GetStoreMoneyOperationQuery(TypeOperation.Income, countRecords);
            var handler = new GetStoreMoneyOperationHandler();
            var incomes = handler.Handle(getStoreIncomes);

            return incomes;
        }

        private List<MoneyOperation> GetListExpenses()
        {
            int countRecords = 1;
            var allCountExpenses = GetCountExpenses();
            if (allCountExpenses != 0)
            {
                System.Console.WriteLine($"Введите количество строчек не больше {allCountExpenses}:");
                countRecords = int.TryParse(System.Console.ReadLine(), out countRecords) ? (countRecords > 0 ? countRecords : 1) : 1;
            }   

            var getStoreExpenses = new GetStoreMoneyOperationQuery(TypeOperation.Expense, countRecords);
            var handler = new GetStoreMoneyOperationHandler();
            var result = handler.Handle(getStoreExpenses);

            return result;
        }

        private int GetCountIncomes()
        {
            var getStoreIncomes = new GetStoreMoneyOperationQuery(TypeOperation.Income);
            var handler = new GetCountStoreMoneyOperationHandler();
            var result = handler.Handle(getStoreIncomes);

            return result.Count();
        }

        private int GetCountExpenses()
        {
            var getStoreExpenses = new GetStoreMoneyOperationQuery(TypeOperation.Expense);
            var handler = new GetCountStoreMoneyOperationHandler();
            var result = handler.Handle(getStoreExpenses);

            return result.Count();
        }
    }
}
