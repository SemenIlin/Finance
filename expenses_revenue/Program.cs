using System;
using Finance;
using Finance.Incomes;
using Finance.Expenses;

namespace expenses_revenue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Анализ доходов и расходов");
            InputDataIncomes input = null;
            InputDataExpenses expenses = null;
            while (true)
            {
                Console.WriteLine("1 Write Incomes\n" +
                                   "2 Read Incomes\n" +
                                   "3 Write Expenses\n" +
                                   "4 Read Expenses \n");

                string choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        input = new InputDataIncomes();

                        break;

                    case "2":
                        Console.WriteLine("Введите количество строчек.");
                        int count = int.TryParse(Console.ReadLine(), out count) ? (count > 0 ? count : 1) : 1;
                        if (input != null)
                        {
                            OutputDataIncomes output = new OutputDataIncomes(count, input.GetRecords());
                            output.Print(new ConsolePrint());
                        }
                        else 
                        {
                            Console.WriteLine("Данных нету");                        
                        }

                        break;

                    case "3":
                        expenses = new InputDataExpenses();
                        break;

                    case "4":
                        Console.WriteLine("Введите количество строчек.");
                        count = int.TryParse(Console.ReadLine(), out count) ? (count > 0 ? count : 1) : 1;
                        if (expenses != null)
                        {
                            OutputDataExpenses output = new OutputDataExpenses(count, expenses.GetRecords());
                            output.Print(new ConsolePrint());
                        }
                        else
                        {
                            Console.WriteLine("Данных нету");
                        }

                        break;

                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;    
                }

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
