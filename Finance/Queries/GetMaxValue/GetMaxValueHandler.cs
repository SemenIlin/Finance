using System.Linq;
using Finance.Money;

namespace Finance.Queries.GetMaxValue
{
    public class GetMaxValueHandler:IQueryHandler<GetMaxValueOperationQuery, MoneyOperation>
    {
        public MoneyOperation Handle(GetMaxValueOperationQuery query)
        {
            return query.MoneyOperation.Where(t => t.TypeOperation == query.Type).Max();  
        }
    }
}
