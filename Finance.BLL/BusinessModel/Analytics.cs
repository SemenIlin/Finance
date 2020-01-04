using Finance.BLL.DTO;
using Finance.DAL.Interfaces;
using Finance.DAL.Models;
using Finance.DAL.Repositories;
using System.Linq;

namespace Finance.BLL.BusinessModel
{
    public class Analytics
    {
        private readonly IRepository<Income> income;
        private readonly IRepository<Expense> expense;

        public Analytics()
        {
            income = new RepositoryIncome();
            expense= new RepositoryExpenses();
        }

        public AnalyticsOfMoneyOperation AnalyticsOfMoneyOperation => new AnalyticsOfMoneyOperation { TotalExpenses = GetTotalExpenses(),
                                                                                                      TotalTax = GetTotalTax(), 
                                                                                                      TotalIncomes=GetTotalIncomes(),
                                                                                                      Delta = GetDelta() };
        private decimal GetTotalIncomes()
        {
            return income.GetAll().Sum(m => m.Money);
        }

        private decimal GetTotalExpenses()
        {
            return expense.GetAll().Sum(m => m.Money);
        }

        private decimal GetTotalTax()
        {
            return income.GetAll().Sum(t => t.Tax);
        }

        private decimal GetDelta()
        {
            return GetTotalIncomes() - GetTotalExpenses();
        }
    }
}
