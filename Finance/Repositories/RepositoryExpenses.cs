using Finance.DAL.Interfaces;
using Finance.DAL.Models;
using Finance.DAL.Storages;
using System.Collections.Generic;
using System.Linq;

namespace Finance.DAL.Repositories
{
    public class RepositoryExpenses : IRepository<Expense>
    {
        private readonly Storage<Expense> storages;

        public RepositoryExpenses()
        {
            storages = Storage<Expense>.GetStorages();
        }

        public void Create(Expense expense)
        {
            storages.Storages.Add(expense) ;          
        }

        public void Delete(int id)
        {
            storages.Storages.RemoveAt(id);
        }

        public Expense Get(int id)
        {
            return storages.Storages.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Expense> GetAll()
        {
            return storages.Storages.ToList();
        }

        public void Update(Expense item)
        {
            storages.Storages[item.Id] = item;
        }
    }
}
