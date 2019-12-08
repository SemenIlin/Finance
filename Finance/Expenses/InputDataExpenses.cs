using System;
using System.Collections.Generic;
using Finance.Interfaces;

namespace Finance.Expenses
{
    public class InputDataExpenses : ICommand
    {
        private int day;
        private decimal money;
        private string resource = String.Empty;

        private readonly IInputData inputData;
        private Expense expense;
        private RecordsOfExpenses records;
       

        public InputDataExpenses(ICollection<Expense> expenses, IInputData inputData)
        {            
            this.inputData = inputData; 
            records = RecordsOfExpenses.GetInstance(expenses);
        }

        public void Execute()
        {
            day = inputData.AddDay();
            money = inputData.AddMoney();
            resource = inputData.AddResource();

            CreateExpense();            
            AddExpense(CreateExpense());                    
        }

        public RecordsOfExpenses GetRecords()
        {
            return records;
        }

        private Expense CreateExpense()
        {
            expense = new Expense(day, money, resource);
            return expense;
        }

        private void AddExpense(Expense expense)
        {
            records.AddExpense(expense);
        }        
    }
}
