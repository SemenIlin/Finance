using System;
using System.Collections.Generic;
using Finance.Money;
using Finance.Interfaces.DataInput;

namespace Finance.Interfaces.Operations
{
    public class InputDataMoneyOperation : ICommand, IQuery<string>
    {
        private int day;
        private decimal money;
        private string resource = String.Empty;
        private TypeOperation operation;

        private readonly IInputData inputData;
        private MoneyOperation expense;
        private RecordsOfMoneyOperations records;
       

        public InputDataMoneyOperation(ICollection<MoneyOperation> expenses, IInputData inputData)
        {            
            this.inputData = inputData; 
            records = RecordsOfMoneyOperations.GetInstance(expenses);
        }

        public void Execute()
        {
            day = inputData.AddDay();
            money = inputData.AddMoney();
            resource = inputData.AddResource();
            operation = TypeOperation.Expense;

            CreateExpense();            
            AddExpense(CreateExpense());                    
        }

        public RecordsOfMoneyOperations GetRecords()
        {
            return records;
        }

        private MoneyOperation CreateExpense()
        {
            expense = new MoneyOperation(day, money, resource, operation);
            return expense;
        }

        private void AddExpense(MoneyOperation expense)
        {
            records.AddExpense(expense);
        }        
    }
}
