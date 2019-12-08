using System;
using System.Collections.Generic;
using Finance.Money;
using Finance.Commands;
using Finance.Interfaces.Operations;
using Finance.Interfaces.DataInput;

namespace expenses_revenue
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = new RecordsOfCommand(new List<Command>());

            var inputIncome = new InputDataMoneyOperation(new List<MoneyOperation>(), new ConsoleInputDataIncome());
            var inputExpense = new InputDataMoneyOperation(new List<MoneyOperation>(), new ConsoleInputDataExpense());
            var getCommand = new GetCommandByIdQuery(commands);

            var handler = new InputDataMoneyOperationHandler();
            var rezult = handler.Handle(inputIncome);
            Console.WriteLine(rezult);
            // Как добавить Запрос/Ответ в список, и можно ли это сделать?

            Console.WriteLine("Анализ доходов и расходов");

            commands.AddCommand("Записать доход.", inputIncome);
            commands.AddCommand("Вывести список доходов.", new OutputDataMoneyOperation(new ConsoleCount(), inputIncome.GetRecords()));
            commands.AddCommand("Записать расход.", inputExpense);
            commands.AddCommand("Вывести список расходов.", new OutputDataMoneyOperation(new ConsoleCount(), inputExpense.GetRecords()));

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
