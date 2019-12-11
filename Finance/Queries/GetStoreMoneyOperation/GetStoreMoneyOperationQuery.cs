using Finance.Models;
using System.Collections.Generic;

namespace Finance.Queries.GetStoreMoneyOperation
{
    public class GetStoreMoneyOperationQuery : IQuery<List<MoneyOperation>>
    {
        public GetStoreMoneyOperationQuery(TypeOperation type)
        {
            Type = type;
        }

        public GetStoreMoneyOperationQuery(TypeOperation type, int countOutputRecords)
        {
            CountOutputRecords = countOutputRecords;
            Type = type;   
        }

        public TypeOperation Type { get; }
        public int CountOutputRecords { get; }     
    }
}
