using Finance.Models;
using System.Collections.Generic;

namespace Finance.Queries.GetStoreMoneyOperation
{
    public class GetStoreMoneyOperationQuery : IQuery<List<MoneyOperation>>
    {
        public GetStoreMoneyOperationQuery(TypeOperation type, int countRecords)
        {
            CountRecords = countRecords;
            Type = type;   
        }

        public TypeOperation Type { get; }
        public int CountRecords { get; }        
    }
}
