using Finance.DAL.Interfaces;
using Finance.DAL.Models;

namespace Finance.DAL.Repositories
{
    public class ListExpenseUnitOfWork : IUnitOfWork<Expense>
    {
        private RepositoryExpenses repositoryExpenses;
        
        public IRepository<Expense> Repository
        {
            get
            {
                if (repositoryExpenses == null)
                {
                    repositoryExpenses = new RepositoryExpenses();
                }

                return repositoryExpenses;
            }
        }
    }
}
