using Finance.Money;
using System.Collections.Generic;

namespace Finance.Queries.GetStoreMoneyOperation
{
    public class GetStoreMoneyOperationQuery : IQuery<List<MoneyOperation>>
    {
        public GetStoreMoneyOperationQuery(TypeOperation type, int countRecords)
        {
            CountRecords = countRecords;
            Type = type;
            MoneyOperation = RecordsStorage.GetInstance().GetMoneyOperations();        
        }

        public List<MoneyOperation> MoneyOperation { get; }
        public TypeOperation Type { get; }

        public int CountRecords { get; }        
    }
}
