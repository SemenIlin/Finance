using Finance.Models;
using System.Linq;
using System.Collections.Generic;
using Finance.Storage;

namespace Finance.Queries.GetStoreMoneyOperation
{
    public class GetStoreMoneyOperationHandler: IQueryHandler<GetStoreMoneyOperationQuery, List<MoneyOperation>>
    {
        private readonly List<MoneyOperation> storage;

        public GetStoreMoneyOperationHandler()
        {
            storage = RecordsStorage.GetInstance().GetStorage();
        }

        public List<MoneyOperation> Handle(GetStoreMoneyOperationQuery query)
        {
            return storage.Where(t => t.TypeOperation == query.Type).OrderBy(d => d.NumberOfDay).Take(query.CountRecords).ToList();
        }
    }
}
