using System.Linq;
using System.Globalization;
using Finance.PL;

namespace expenses_revenue
{
    public class MyFinance 
    { 
        private readonly NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
        private readonly CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");

        private readonly FinanceAnalytic financeAnalytic;

        public MyFinance()
        {
            financeAnalytic = new FinanceAnalytic();
        }

        public void AddIncome()
        {           
            System.Console.WriteLine("Введите день:");
            int.TryParse(System.Console.ReadLine(), out int day);
            System.Console.WriteLine("Введите месяц:");
            int.TryParse(System.Console.ReadLine(), out int month); 
            System.Console.WriteLine("Введите год:");
            int.TryParse(System.Console.ReadLine(), out int year);

            if (!financeAnalytic.IsCorrectDate(year, month, day))
            {
                return;
            }

            System.Console.WriteLine("Введите величину дохода:");
            decimal money = decimal.TryParse(System.Console.ReadLine().Replace(',', '.'), style, culture, out money) ? (money > 0 ? money : 0) : 0;

            System.Console.WriteLine("Введите источник:");
            string resource = System.Console.ReadLine();

            financeAnalytic.AddIncome(year, month, day, money, resource);          

            System.Console.WriteLine("Запись добавлена");
        }
        
        public void AddExpense()
        {
            System.Console.WriteLine("Введите день:");
            int.TryParse(System.Console.ReadLine(), out int day);
            System.Console.WriteLine("Введите месяц:");
            int.TryParse(System.Console.ReadLine(), out int month);
            System.Console.WriteLine("Введите год:");
            int.TryParse(System.Console.ReadLine(), out int year);

            if(!financeAnalytic. IsCorrectDate(year, month, day))
            {
                return;
            }

            System.Console.WriteLine("Введите величину расхода:");
            decimal money = decimal.TryParse(System.Console.ReadLine().Replace(',', '.'), style, culture, out money) ? (money > 0 ? money : 0) : 0;

            System.Console.WriteLine("Введите причину:");
            string resource = System.Console.ReadLine();

            financeAnalytic.AddExpense(year, month, day, money, resource);
            
            System.Console.WriteLine("Запись добавлена");
        }

        public void GetTableOfIncomes()
        {
            decimal totalValue = 0;

            var incomes = financeAnalytic.GetIncomeRecords();
            var tableIncome = new ConsoleTable("День", "Источник", "Доход","Налог", "Итоговый доход");
            
            foreach (var item in incomes)
            {
                decimal value = item.Money + item.Tax;
                totalValue += value;
                tableIncome.AddRow(item.Day.ToLongDateString(), item.Resource.ToString(), item.Money.ToString(), item.Tax.ToString(), value.ToString());                
            }
            tableIncome.AddRow("Итого",System.String.Empty, incomes.Sum(balance => balance.Money).ToString(), incomes.Sum(tax => tax.Tax).ToString(), totalValue.ToString());

            System.Console.WriteLine("Доходы");
            tableIncome.Print();
        }
       
        public void GetTableOfExpenses()
        {
            var expenses = financeAnalytic.GetExpenseRecords();

            var tableExpense = new ConsoleTable("День", "Причина", "Расход");

            foreach (var item in expenses)
            {
                tableExpense.AddRow(item.Day.ToLongDateString(), item.Resource.ToString(), item.Money.ToString());
            }
            tableExpense.AddRow("Итого", System.String.Empty, expenses.Sum(total => total.Money).ToString());

            System.Console.WriteLine("Расходы");
            tableExpense.Print(); 
        }

        public void GetTableOfAnalysis()
        {
            var analysis = financeAnalytic.GetExpenseRecords();
            var tableExpenses = new ConsoleTable("Причина траты", "Величина траты");

            foreach (var item in analysis)
            {
                tableExpenses.AddRow(item.Resource, item.Money.ToString());
            }
            tableExpenses.AddRow("Итого", analysis.Sum(v=>v.Money).ToString());

            System.Console.WriteLine("Затраты");
            tableExpenses.Print();

            System.Console.WriteLine();

            analysis = financeAnalytic.GetIncomeRecords();
            var tableIncomes = new ConsoleTable("Источник дохода", "Доход","Налог","Итоговый доход");
            foreach (var item in analysis)
            {
                tableIncomes.AddRow(item.Resource, item.Money.ToString(), item.Tax.ToString(), (item.Tax + item.Money).ToString());
            }

            decimal totalTax = analysis.Sum(tax => tax.Tax);
            decimal totalBalance = analysis.Sum(balance => balance.Money);
            decimal totalValue = totalTax + totalBalance;
            tableIncomes.AddRow("Итого", totalBalance.ToString(), totalTax.ToString(), totalValue.ToString());

            System.Console.WriteLine("Доходы");
            tableIncomes.Print();

            System.Console.WriteLine("Доход: {0}, Расход: {1}, Дельта:{2}", 
                                      financeAnalytic.GetAnalytics().AnalyticsOfMoneyOperation.TotalIncomes,
                                      financeAnalytic.GetAnalytics().AnalyticsOfMoneyOperation.TotalExpenses,
                                      financeAnalytic.GetAnalytics().AnalyticsOfMoneyOperation.Delta);
        }

    }
}
