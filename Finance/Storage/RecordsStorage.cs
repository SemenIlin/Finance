using System.Collections.Generic;
using Finance.Models;

namespace Finance.Storage
{
    public class RecordsStorage
    {
        private readonly List<MoneyOperation> storage;
        private static RecordsStorage instance;

        private RecordsStorage()
        {
            storage = new List<MoneyOperation>();
        }

        public static RecordsStorage GetInstance()
        {
            if (instance == null)
            {
                instance = new RecordsStorage();
               
            }

            return instance;
        }

        public void AddMoneyOperation(MoneyOperation moneyOperation)
        {
            storage.Add(moneyOperation);
        }

        public List<MoneyOperation> GetStorage()
        {
            return storage;
        }
    }
}