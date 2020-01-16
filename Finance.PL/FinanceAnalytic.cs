
using Finance.BLL.Interfaces;
using Finance.BLL.Records;
using Finance.BLL.DTO;
using Finance.BLL.BusinessModel;
using Finance.BLL.Infrastructure;
using Finance.DAL.Repositories;
using System.Collections.Generic;

namespace Finance.PL
{
    public class FinanceAnalytic
    {
        private readonly IRecordMoneyOperation[] records = new IRecordMoneyOperation[2];
        private readonly Analytics analytics;

        public FinanceAnalytic()
        {
            records[0] = new RecordsExpenses(new RepositoryExpenses());
            records[1] = new RecordsIncomes(new RepositoryIncome());
            analytics = new Analytics();
        }

        public void AddExpense(int year, int month, int day, decimal money, string resource)
        {
            if(!IsCorrectDate(year, month, day))
            {
                return;
            }

            records[0].MakeRecords(new IncomeDTO { Day = new System.DateTime(year, month, day), Money = money, Resource = resource });
        }

        public void AddIncome(int year, int month, int day, decimal money, string resource, int tax = 13)
        {
            if (!IsCorrectDate(year, month, day))
            {
                return;
            }

            records[1].MakeRecords(new IncomeDTO { Day = new System.DateTime(year, month, day), Money = money, Resource = resource, Tax = tax });
        }


        public IEnumerable<IMoneyOperationDTO> GetExpenseRecords()
        {
            return records[0].GetRecords();
        }

        public IEnumerable<IMoneyOperationDTO> GetIncomeRecords()
        {
            return records[1].GetRecords();
        }

        public IMoneyOperationDTO GetIncomeRecord(int id)
        {
            return records[1].GetRecord(id);
        }

        public IMoneyOperationDTO GetExpenseRecord(int id)
        {
            return records[0].GetRecord(id);
        }

        public Analytics GetAnalytics()
        {
            return analytics;        
        }

        public bool IsCorrectDate(int year, int month, int day)
        {
            if (ValidationDate.DaysInMonth(year, month) >= day)
            {
                return true;
            }

            return false;
        }
    }
}
