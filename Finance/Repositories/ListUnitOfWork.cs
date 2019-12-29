using System.Collections.Generic;
using Finance.DAL.Interfaces;
using Finance.DAL.Models;

namespace Finance.DAL.Repositories
{
    public class ListUnitOfWork : IUnitOfWork
    {
        private readonly List<Income> incomes;
        private readonly List<Expense> expenses;

        private RepositoryExpenses repositoryExpenses;
        private RepositoryIncome repositoryIncome;

        public ListUnitOfWork()
        {
            incomes = new List<Income>();
            expenses = new List<Expense>();
        }

        public IRepository<Income> Income
        {
            get 
            {
                if (repositoryIncome == null)
                {
                    repositoryIncome = new RepositoryIncome(incomes);                
                }

                return repositoryIncome;            
            }
        }

        public IRepository<Expense> Expense
        {
            get 
            {
                if(repositoryExpenses == null)
                {
                    repositoryExpenses = new RepositoryExpenses(expenses);
                }

                return repositoryExpenses;
            }
        }

        public void Dispose(){ }
    }
}
