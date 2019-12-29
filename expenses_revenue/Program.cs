using Finance.BLL.Infrastructure;
using System;
using System.Collections.Generic;

namespace expenses_revenue
{
    class Program
    {
        static void Main()
        {
            
            var myFinance = new MyFinance();
            Console.WriteLine("Анализ доходов и расходов");
            Dictionary<Commands, Action > commands = new Dictionary<Commands, Action>()
            {
                { Commands.AddIncome, myFinance.AddIncome},
                { Commands.GetStorageIncomes, myFinance.GetTableOfIncomes },
                { Commands.AddExpense,  myFinance.AddExpense},
                { Commands.GetStorageExpenses, myFinance.GetTableOfExpenses },
                { Commands.GetAnalysis,  myFinance.GetTableOfAnalysis}
            };

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
                    commands[(Commands)selectCommand].Invoke();
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NotImplementedException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ValidationException ex)
                {
                    Console.WriteLine(ex.Message);
                    //Console.WriteLine("Неизвестная команда.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);

                }
                catch (Exception ex)
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
    }
}
