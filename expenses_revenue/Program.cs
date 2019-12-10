using System;

namespace expenses_revenue
{
    class Program
    {
        static void Main()
        {
            var myFinanse = new MyFinance();

            Console.WriteLine("Анализ доходов и расходов");


            while (true)
            {
                Console.WriteLine("1. Введите доход. \n" +
                                  "2. Вывести список доходов.\n" +
                                  "3. Введите расход.\n" +
                                  "4. Вывести список расходов. ");
                try
                {
                    int.TryParse(Console.ReadLine(), out int selectCommand);
                    switch (selectCommand)
                    {
                        case 1:
                            Console.WriteLine("Введите день:");
                            int day = int.TryParse(Console.ReadLine(), out day) ? (day > 0 ? day : 1) : 1;

                            Console.WriteLine("Введите величину дохода:");
                            decimal money = decimal.TryParse(Console.ReadLine(), out money) ? (money > 0 ? money : 0) : 0;

                            Console.WriteLine("Введите источник:");
                            string resource = Console.ReadLine();

                            myFinanse.AddIncome(day, money, resource);

                            break;

                        case 2:
                            Console.WriteLine("Введите количество строчек:");
                            int countRecords = int.TryParse(Console.ReadLine(), out countRecords) ? (countRecords > 0 ? countRecords : 1) : 1;

                            foreach (var item in myFinanse.GetListIncomes(countRecords))
                            {
                                Console.WriteLine("Номер дня: {0} \t Величина: {1} \t Источник {2}", item.NumberOfDay, item.Value, item.Resource);                            
                            }

                            break;

                        case 3:
                            Console.WriteLine("Введите день:");
                            day = int.TryParse(Console.ReadLine(), out day) ? (day > 0 ? day : 1) : 1;

                            Console.WriteLine("Введите величину расхода:");
                            money = decimal.TryParse(Console.ReadLine(), out money) ? (money > 0 ? money : 0) : 0;

                            Console.WriteLine("Введите причину:");
                            resource = Console.ReadLine();

                            myFinanse.AddExpense(day, money, resource);

                            break;

                        case 4:
                            Console.WriteLine("Введите количество строчек:");
                            countRecords = int.TryParse(Console.ReadLine(), out countRecords) ? (countRecords > 0 ? countRecords : 1) : 1;

                            foreach (var item in myFinanse.GetListExpenses(countRecords))
                            {
                                Console.WriteLine("Номер дня: {0} \t Величина: {1} \t Причина: {2}", item.NumberOfDay, item.Value, item.Resource);
                            }

                            break;

                        case 5:

                            Console.WriteLine("Номер дня: {0} \t Величина: {1} \t Причина: {2}", myFinanse.GetMaxValueIncome().NumberOfDay, myFinanse.GetMaxValueIncome().Value, myFinanse.GetMaxValueIncome().Resource); ;

                            break;

                        default:
                            Console.WriteLine("Неизвестная команда, попробуйте ещё раз. ) ");
                            break;
                    }
                }
                catch { }


                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
