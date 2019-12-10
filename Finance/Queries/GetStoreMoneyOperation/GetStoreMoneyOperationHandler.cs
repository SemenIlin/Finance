using Finance.Money;
using System.Linq;
using System.Collections.Generic;

namespace Finance.Queries.GetStoreMoneyOperation
{
    public class GetStoreMoneyOperationHandler: IQueryHandler<GetStoreMoneyOperationQuery, List<MoneyOperation>>
    {
        public List<MoneyOperation> Handle(GetStoreMoneyOperationQuery query)
        {
            return query.MoneyOperation.Where(t => t.TypeOperation == query.Type).OrderBy(d => d.NumberOfDay).Take(query.CountRecords).ToList();
        }
    }
}
