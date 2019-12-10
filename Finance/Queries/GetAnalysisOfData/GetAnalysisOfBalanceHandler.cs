using System.Collections.Generic;
using System.Linq;
using Finance.Models;
using Finance.Storage;

namespace Finance.Queries.GetMaxValue
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
                Delta = GetDelta(),
                MaxValueIncome = GetMaxValueIncome(),
                MaxValueExpence = GetMaxValueExpence(),
                TotalValueExpense = GetTotalExpense(),
                TotalValueIncome = GetTotalIncome(),
                Income = GetIncome(),
                Expense = GetExpense()
            };
        }

        private decimal GetMaxValueIncome()
        {
            return storage.Where(t => t.TypeOperation == TypeOperation.Expense).Max(v => v.Value);
        }

        private decimal GetMaxValueExpence()
        {
            return storage.Where(t => t.TypeOperation == TypeOperation.Income).Max(v => v.Value);
        }

        private decimal GetTotalIncome()
        {
            return storage.Where(t => t.TypeOperation == TypeOperation.Income).Sum(v => v.Value);
        }

        private decimal GetTotalExpense()
        {
            return storage.Where(t => t.TypeOperation == TypeOperation.Expense).Sum(v => v.Value);
        }

        private decimal GetDelta()
        {
            return (storage.Where(t => t.TypeOperation == TypeOperation.Income).Sum(v => v.Value) -
                   storage.Where(t => t.TypeOperation == TypeOperation.Expense).Sum(v => v.Value));
        }

        private List<ResourceMoneyValue> GetExpense()
        {
            var expense = storage.Where(t => t.TypeOperation == TypeOperation.Expense).GroupBy(s => s.Resource)                                                                                      
                                                                                      .Select(t => new ResourceMoneyValue()
                                                                                      {
                                                                                          Resource = t.Key,
                                                                                          Value = t.Sum(v => v.Value)
                                                                                      }).OrderByDescending(v => v.Value).ToList();


            return expense;
        }

        private List<ResourceMoneyValue> GetIncome()
        {
            var income = storage.Where(t => t.TypeOperation == TypeOperation.Income).GroupBy(s => s.Resource)
                                                                                      .Select(t => new ResourceMoneyValue()
                                                                                      {
                                                                                          Resource = t.Key,
                                                                                          Value = t.Sum(v => v.Value)
                                                                                      }).OrderByDescending(v => v.Value).ToList();

            return income;
        }
    }
}
