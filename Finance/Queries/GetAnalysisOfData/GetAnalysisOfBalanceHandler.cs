using System.Collections.Generic;
using System.Linq;
using Finance.Models;
using Finance.Storage;

namespace Finance.Queries.GetAnalysisOfData
{
    public class GetAnalysisOfBalanceHandler : IQueryHandler<GetAnalysisOfBalanceQuery, AnalysisOfData>
    {
        private readonly List<MoneyOperation> storage;

        public GetAnalysisOfBalanceHandler()
        {
            storage = RecordsStorage.GetInstance().GetStorage();
        }

        public AnalysisOfData Handle(GetAnalysisOfBalanceQuery query)
        {
            return new AnalysisOfData
            {
                Tax = GetTotalTax(),

                Delta = GetDelta(),
                TotalValueExpense = GetTotalExpense(),
                TotalValueIncome = GetTotalIncome(),
                Income = GetIncome(),
                Expense = GetExpense()
            };
        }

        private decimal GetTotalIncome()
        {
            return storage.Where(t => t.TypeOperation == TypeOperation.Income).Sum(v => v.Balance);            
        }

        private decimal GetTotalExpense()
        {
            return storage.Where(t => t.TypeOperation == TypeOperation.Expense).Sum(v => v.Value);           
        }

        private decimal GetDelta()
        {
            return GetTotalIncome() - GetTotalExpense();
        }

        private List<ResourceMoneyValue> GetExpense()
        {
            var expense = storage.Where(t => t.TypeOperation == TypeOperation.Expense)
                .ToLookup(s => s.Resource)
                .Select(t => new ResourceMoneyValue()
                {
                    Resource = t.Key,
                    Balance = t.Sum(v => v.Value)
                }).OrderByDescending(v => v.Balance).ToList();
            return expense;            
        }

        private List<ResourceMoneyValue> GetIncome()
        {
            var income = storage.Where(t => t.TypeOperation == TypeOperation.Income)
                .ToLookup(s => s.Resource)
                .Select(t => new ResourceMoneyValue()
                {
                    Resource = t.Key,
                    Balance = t.Sum(v => v.Balance),
                    Tax = t.Sum(v => v.Tax)
                }).OrderByDescending(v => v.Balance).ToList();
            return income;            
        }

        private decimal GetTotalTax()
        {
            var totalTax = storage.Where(t => t.TypeOperation == TypeOperation.Income).Sum(n => n.Tax);
            return totalTax;
        }
    }
}
