using System;
using System.Collections.Generic;
using Finance;
using Finance.Incomes;
using Finance.Expenses;
using Finance.Commands;
using Finance.Interfaces;

namespace expenses_revenue
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = new RecordsOfCommand(new List<Command>());
            var inputIncome = new InputDataIncomes(new List<Income>(), new ConsoleInputDataIncome());
            var inputExpense = new InputDataExpenses(new List<Expense>(), new ConsoleInputDataExpense());
            var getCommand = new GetCommandByIdQuery(commands);

            Console.WriteLine("Анализ доходов и расходов");

            commands.AddCommand("Записать доход.", inputIncome);
            commands.AddCommand("Вывести список доходов.", new OutputDataIncomes(new ConsoleCount(), inputIncome.GetRecords()));
            commands.AddCommand("Записать расход.", inputExpense);
            commands.AddCommand("Вывести список расходов.", new OutputDataExpenses(new ConsoleCount(), inputExpense.GetRecords()));

            while (true)
            {
                Console.WriteLine();
                foreach (var command in commands)
                {
                    Console.WriteLine("{0}.  {1}", command.Id, command.Text);                    
                }
                int commandId;
                try
                {
                    int.TryParse(Console.ReadLine(), out commandId);
                    getCommand.Execute(commandId);
                }
                catch 
                { }

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
