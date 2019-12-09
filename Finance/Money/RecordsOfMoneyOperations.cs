using System.Collections.Generic;

namespace Finance.Money
{
    public class RecordsOfMoneyOperations
    {
        private readonly ICollection<MoneyOperation> moneyOperations;
        private static RecordsOfMoneyOperations instance;

        private RecordsOfMoneyOperations(ICollection<MoneyOperation> moneyOperations)
        {
            this.moneyOperations = moneyOperations;
        }

        public static RecordsOfMoneyOperations GetInstance(ICollection<MoneyOperation> moneyOperations)
        {
            if (instance == null)
            {
                instance = new RecordsOfMoneyOperations(moneyOperations);
            }

            return instance;
        }

        public void AddMoneyOperation(MoneyOperation moneyOperation)
        {
            moneyOperations.Add(moneyOperation);
        }

        public ICollection<MoneyOperation> GetMoneyOperations()
        {
            return moneyOperations;
        }
    }
}