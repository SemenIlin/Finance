using System.Linq;
using System.Globalization;
using Finance.BLL.Interfaces;
using Finance.BLL.Records;
using Finance.BLL.DTO;
using Finance.BLL.BusinessModel;
using Finance.BLL.Infrastructure;
using Finance.DAL.Repositories;

namespace expenses_revenue
{
    public class MyFinance
    {
        private readonly NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
        private readonly CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");
        private readonly IRecordMoneyOperation[] records = new IRecordMoneyOperation[2];
        private readonly ListUnitOfWork listUnitOfWork = new ListUnitOfWork();
        private readonly Analytics analytics;

        public MyFinance()
        {
            records[0] = new RecordsExpenses(listUnitOfWork);
            records[1] = new RecordsIncomes(listUnitOfWork);
            analytics = new Analytics(listUnitOfWork);
        }

        public void AddIncome()
        {           
            System.Console.WriteLine("Введите день:");
            int.TryParse(System.Console.ReadLine(), out int day);
            System.Console.WriteLine("Введите месяц:");
            int.TryParse(System.Console.ReadLine(), out int month); 
            System.Console.WriteLine("Введите год:");
            int.TryParse(System.Console.ReadLine(), out int year);

            if (!IsCorrectDate(year, month, day))
            {
                return;
            }

            System.Console.WriteLine("Введите величину дохода:");
            decimal money = decimal.TryParse(System.Console.ReadLine().Replace(',', '.'), style, culture, out money) ? (money > 0 ? money : 0) : 0;

            System.Console.WriteLine("Введите источник:");
            string resource = System.Console.ReadLine();

            records[1].MakeRecords(new IncomeDTO { Day = new System.DateTime(year, month, day), Money = money, Resource = resource, Tax = 13 }); 

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

            if(!IsCorrectDate(year, month, day))
            {
                return;
            }

            System.Console.WriteLine("Введите величину расхода:");
            decimal money = decimal.TryParse(System.Console.ReadLine().Replace(',', '.'), style, culture, out money) ? (money > 0 ? money : 0) : 0;

            System.Console.WriteLine("Введите причину:");
            string resource = System.Console.ReadLine();

            records[0].MakeRecords(new ExpenseDTO { Day = new System.DateTime(year, month, day), Money = money, Resource = resource });
            System.Console.WriteLine("Запись добавлена");
        }

        public void GetTableOfIncomes()
        {
            decimal totalValue = 0;

            var incomes = records[1].GetRecords();
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
            var expenses = records[0].GetRecords();

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
            var analysis = records[0].GetRecords();
            var tableExpenses = new ConsoleTable("Причина траты", "Величина траты");

            foreach (var item in analysis)
            {
                tableExpenses.AddRow(item.Resource, item.Money.ToString());
            }
            tableExpenses.AddRow("Итого", analysis.Sum(v=>v.Money).ToString());

            System.Console.WriteLine("Затраты");
            tableExpenses.Print();

            System.Console.WriteLine();

            analysis = records[1].GetRecords();
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

            System.Console.WriteLine("Доход: {0}, Расход: {1}, Дельта:{2}", analytics.AnalyticsOfMoneyOperation.TotalIncomes, analytics.AnalyticsOfMoneyOperation.TotalExpenses, analytics.AnalyticsOfMoneyOperation.Delta);
        }

        private bool IsCorrectDate(int year, int month, int day)
        {
            if (ValidationDate.DaysInMonth(year, month) >= day)
            {
                return true;
            }

            return false;
        }
    }
}
