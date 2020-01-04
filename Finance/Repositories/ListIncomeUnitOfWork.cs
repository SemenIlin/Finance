using Finance.DAL.Interfaces;
using Finance.DAL.Models;
namespace Finance.DAL.Repositories
{
    public class ListIncomeUnitOfWork : IUnitOfWork<Income>
    {
        private RepositoryIncome repositoryIncome;

        public IRepository<Income> Repository
        {
            get 
            {
                if (repositoryIncome == null)
                {
                    repositoryIncome = new RepositoryIncome();                
                }

                return repositoryIncome;            
            }
        }
    }
}
