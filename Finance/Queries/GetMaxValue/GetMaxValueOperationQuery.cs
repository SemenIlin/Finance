using System.Collections.Generic;
using Finance.Money;

namespace Finance.Queries.GetMaxValue
{
    public class GetMaxValueOperationQuery: IQuery<MoneyOperation>
    {
        public GetMaxValueOperationQuery(TypeOperation type)
        {
            Type = type;
            MoneyOperation = RecordsStorage.GetInstance().GetMoneyOperations();
        }

        public List<MoneyOperation> MoneyOperation { get; }
        public TypeOperation Type { get; }
    }
}
