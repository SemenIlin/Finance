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
            try
            {
                return storage.Where(t => t.TypeOperation == TypeOperation.Expense).Max(v => v.Value);
            }
            catch 
            {
                return 0.0M;
            }
        }

        private decimal GetMaxValueExpence()
        {
            try
            {
                return storage.Where(t => t.TypeOperation == TypeOperation.Income).Max(v => v.Value);
            }
            catch
            {
                return 0.0M;            
            }
        }

        private decimal GetTotalIncome()
        {
            try
            {
                return storage.Where(t => t.TypeOperation == TypeOperation.Income).Sum(v => v.Value);
            }
            catch 
            {
                return 0.0M;
            }
        }

        private decimal GetTotalExpense()
        {
            try
            {
                return storage.Where(t => t.TypeOperation == TypeOperation.Expense).Sum(v => v.Value);
            }
            catch 
            {
                return 0.0M;
            }
        }

        private decimal GetDelta()
        {
            return GetTotalIncome() - GetTotalExpense();
        }

        private List<ResourceMoneyValue> GetExpense()
        {
            List<ResourceMoneyValue> expense;
            try
            {
                expense = storage.Where(t => t.TypeOperation == TypeOperation.Expense).GroupBy(s => s.Resource)
                                                                                          .Select(t => new ResourceMoneyValue()
                                                                                          {
                                                                                              Resource = t.Key,
                                                                                              Value = t.Sum(v => v.Value)
                                                                                          }).OrderByDescending(v => v.Value).ToList();


                return expense;
            }
            catch
            {
                expense = new List<ResourceMoneyValue>
                {
                    new ResourceMoneyValue { Resource = System.String.Empty, Value = 0.0M }
                };

                return expense;            
            }
        }

        private List<ResourceMoneyValue> GetIncome()
        {
            List<ResourceMoneyValue> income;

            try
            {
                income = storage.Where(t => t.TypeOperation == TypeOperation.Income).GroupBy(s => s.Resource)
                                                                                          .Select(t => new ResourceMoneyValue()
                                                                                          {
                                                                                              Resource = t.Key,
                                                                                              Value = t.Sum(v => v.Value)
                                                                                          }).OrderByDescending(v => v.Value).ToList();

                return income;
            }
            catch
            {
                income = new List<ResourceMoneyValue>
                {
                    new ResourceMoneyValue{Resource = System.String.Empty , Value = 0.0M}
                };

                return income;
            }
        }
    }
}
