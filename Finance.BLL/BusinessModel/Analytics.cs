using Finance.BLL.DTO;
using Finance.DAL.Interfaces;
using System.Linq;

namespace Finance.BLL.BusinessModel
{
    public class Analytics
    {
        private readonly IUnitOfWork unitOfWorks;

        public Analytics(IUnitOfWork unitOfWorks)
        {
            this.unitOfWorks = unitOfWorks;
        }

        public AnalyticsOfMoneyOperation AnalyticsOfMoneyOperation => new AnalyticsOfMoneyOperation { TotalExpenses = GetTotalExpenses(),
                                                                                                      TotalTax = GetTotalTax(), 
                                                                                                      TotalIncomes=GetTotalIncomes(),
                                                                                                      Delta = GetDelta() };
        private decimal GetTotalIncomes()
        {
            return unitOfWorks.Income.GetAll().Sum(m => m.Money);
        }

        private decimal GetTotalExpenses()
        {
            return unitOfWorks.Expense.GetAll().Sum(m => m.Money);
        }

        private decimal GetTotalTax()
        {
            return unitOfWorks.Income.GetAll().Sum(t => t.Tax);
        }

        private decimal GetDelta()
        {
            return GetTotalIncomes() - GetTotalExpenses();
        }
    }
}
