using Finance.BLL.DTO;
using Finance.DAL.Interfaces;
using Finance.DAL.Models;
using Finance.DAL.Repositories;
using System.Linq;

namespace Finance.BLL.BusinessModel
{
    public class Analytics
    {
        private readonly IUnitOfWork<Income> incomeUOW;
        private readonly IUnitOfWork<Expense> expenseUOW;

        public Analytics()
        {
            this.incomeUOW = new ListIncomeUnitOfWork();
            this.expenseUOW = new ListExpenseUnitOfWork();
        }

        public AnalyticsOfMoneyOperation AnalyticsOfMoneyOperation => new AnalyticsOfMoneyOperation { TotalExpenses = GetTotalExpenses(),
                                                                                                      TotalTax = GetTotalTax(), 
                                                                                                      TotalIncomes=GetTotalIncomes(),
                                                                                                      Delta = GetDelta() };
        private decimal GetTotalIncomes()
        {
            return incomeUOW.Repository.GetAll().Sum(m => m.Money);
        }

        private decimal GetTotalExpenses()
        {
            return expenseUOW.Repository.GetAll().Sum(m => m.Money);
        }

        private decimal GetTotalTax()
        {
            return incomeUOW.Repository.GetAll().Sum(t => t.Tax);
        }

        private decimal GetDelta()
        {
            return GetTotalIncomes() - GetTotalExpenses();
        }
    }
}
