using System;
using System.Collections.Generic;
using System.Linq;
using Finance.Models;


namespace expenses_revenue
{
    public class ConsoleTable
    {
        private readonly AnalysisOfData storage;

        public ConsoleTable(AnalysisOfData storage)
        {
            this.storage = storage;
        }

        public void CreateTableExpense()
        {
            var resourceCount = storage.Expense.Count();

            for (int i = 0; i < resourceCount; i++)
            {
                Console.WriteLine("|{0,15}|{1,8}|", storage.Expense[i].Resource , storage.Expense[i].Value);
                string text = new string('_', 23);
                Console.WriteLine(text);
            }        
        }

    }
}
