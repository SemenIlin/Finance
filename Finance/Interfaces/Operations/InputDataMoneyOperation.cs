using System;
using System.Collections.Generic;
using Finance.Money;

namespace Finance.Interfaces.Operations
{
    public class InputDataMoneyOperation : IQuery<string>
    {
        private readonly int day;
        private readonly decimal money;
        private readonly string resource = String.Empty;
        private readonly TypeOperation operation;

        private readonly RecordsOfMoneyOperations records;
        private MoneyOperation moneyOperation; 

        public InputDataMoneyOperation(ICollection<MoneyOperation> moneyOperations, int day, decimal money, string resource, TypeOperation operation)
        {
            this.day = day;
            this.money = money;
            this.resource = resource;
            this.operation = operation;

            records = RecordsOfMoneyOperations.GetInstance(moneyOperations);
        }

        public void AddMoneyOperation() 
        {
            AddMoneyOperation(CreateMoneyOperation());                    
        }

        public RecordsOfMoneyOperations GetRecords()
        {
            return records;
        }

        private MoneyOperation CreateMoneyOperation()
        {
            moneyOperation = new MoneyOperation(day, money, resource, operation);
            return moneyOperation;
        }

        private void AddMoneyOperation(MoneyOperation moneyOperation)
        {
            records.AddMoneyOperation(moneyOperation);
        }        
    }
}
