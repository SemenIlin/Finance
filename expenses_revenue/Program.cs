using System;

namespace expenses_revenue
{
    class Program
    {
        static void Main()
        {
            var myFinance = new MyFinance();

            Console.WriteLine("Анализ доходов и расходов");


            while (true)
            {
                Console.WriteLine("1. Введите доход. \n" +
                                  "2. Вывести список доходов.\n" +
                                  "3. Введите расход.\n" +
                                  "4. Вывести список расходов. \n" +
                                  "5. Анализ данных. ");
                try
                {
                    int.TryParse(Console.ReadLine(), out int selectCommand);
                    switch (selectCommand)
                    {
                        case 1:
                            CreateIncome(myFinance);                            

                            break;

                        case 2:
                            GetRecordsIncome(myFinance);

                            break;

                        case 3:
                            CreateExpense(myFinance);

                            break;

                        case 4:
                            GetRecordsExpense(myFinance);

                            break;

                        case 5:
                            GetAnalysisBalance(myFinance);
                            break;

                        default:
                            Console.WriteLine("Неизвестная команда, попробуйте ещё раз. ) ");
                            break;
                    }
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);                
                }

                Console.WriteLine("Для выхода нажмите ESC.");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        static void CreateIncome(MyFinance myFinance)
        {
            Console.WriteLine("Введите день:");
            int day = int.TryParse(Console.ReadLine(), out day) ? (day > 0 ? day : 1) : 1;

            Console.WriteLine("Введите величину дохода:");
            decimal money = decimal.TryParse(Console.ReadLine(), out money) ? (money > 0 ? money : 0) : 0;

            Console.WriteLine("Введите источник:");
            string resource = Console.ReadLine();

            myFinance.AddIncome(day, money, resource);
        }

        static void GetRecordsIncome(MyFinance myFinance)
        {
            var allCountIncomes = myFinance.GetCountIncomes();
            if (allCountIncomes == 0)
            {
                Console.WriteLine("Нет данных");
                return;
            }

            Console.WriteLine($"Введите количество строчек не больше {allCountIncomes}:");

            int countRecords = int.TryParse(Console.ReadLine(), out countRecords) ? (countRecords > 0 ? countRecords : 1) : 1;
            var incomes = myFinance.GetListIncomes(countRecords);
            var tableIncome = new ConsoleTable("Номер дня ", "Величина", "Источник");

            foreach (var item in incomes)
            {
                tableIncome.AddRow(item.NumberOfDay, item.Value, item.Resource);
            }
            Console.WriteLine("Доходы");
            tableIncome.Print();
        }

        static void CreateExpense(MyFinance myFinance)
        {
            Console.WriteLine("Введите день:");
            int day = int.TryParse(Console.ReadLine(), out day) ? (day > 0 ? day : 1) : 1;

            Console.WriteLine("Введите величину расхода:");
            decimal money = decimal.TryParse(Console.ReadLine(), out money) ? (money > 0 ? money : 0) : 0;

            Console.WriteLine("Введите причину:");
            string resource = Console.ReadLine();

            myFinance.AddExpense(day, money, resource);
        }

        static void GetRecordsExpense(MyFinance myFinance)
        {
            var allCountExpenses = myFinance.GetCountExpenses();
            if (allCountExpenses == 0)
            {
                Console.WriteLine("Нет данных");
                return;               
            }

            Console.WriteLine($"Введите количество строчек не больше {allCountExpenses}:");

            int countRecords = int.TryParse(Console.ReadLine(), out countRecords) ? (countRecords > 0 ? countRecords : 1) : 1;
            var expenses = myFinance.GetListExpenses(countRecords);

            var tableExpense = new ConsoleTable("Номер дня ", "Величина", "Причина");

            foreach (var item in expenses)
            {
                tableExpense.AddRow(item.NumberOfDay, item.Value, item.Resource);
            }
            Console.WriteLine("Расходы");
            tableExpense.Print();
        }

        static void GetAnalysisBalance(MyFinance myFinance)
        {
            var analysis = myFinance.GetAnalysisOfData();
            var tableExpenses = new ConsoleTable("Причина траты", "Величина");
            foreach (var item in analysis.Expense)
            {
                tableExpenses.AddRow(item.Resource, item.Value);
            }
            Console.WriteLine("Затраты");
            tableExpenses.Print();
            
            Console.WriteLine();

            var tableIncomes = new ConsoleTable("Источник дохода", "Величина");
            foreach (var item in analysis.Income)
            {
                tableIncomes.AddRow(item.Resource, item.Value);
            }
            Console.WriteLine("Доходы");
            tableIncomes.Print();
            
            Console.WriteLine("Доход: {0}, Расход: {1}, Дельта:{2}", analysis.TotalValueIncome, analysis.TotalValueExpense, analysis.Delta);
        }
    }
}
