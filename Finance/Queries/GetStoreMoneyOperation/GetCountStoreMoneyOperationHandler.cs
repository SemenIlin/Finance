using System.Linq;
using System.Collections.Generic;
using Finance.Models;
using Finance.Storage;

namespace Finance.Queries.GetStoreMoneyOperation
{
    public class GetCountStoreMoneyOperationHandler:IQueryHandler<GetStoreMoneyOperationQuery, List<MoneyOperation>>
    {
        private readonly List<MoneyOperation> storage;

        public GetCountStoreMoneyOperationHandler()
        {
            storage = RecordsStorage.GetInstance().GetStorage();
        }

        public List<MoneyOperation> Handle(GetStoreMoneyOperationQuery query)
        {
            return storage.Where(t => t.TypeOperation == query.Type).OrderBy(d => d.NumberOfDay).ToList();
        }
    }
}
