using Finance.DAL.Interfaces;
using Finance.DAL.Models;
using Finance.DAL.Storages;
using System.Collections.Generic;
using System.Linq;

namespace Finance.DAL.Repositories
{
    public class RepositoryIncome : IRepository<Income>
    {
        private readonly Storage<Income> storages;

        public RepositoryIncome()
        {
            storages = Storage<Income>.GetStorages();        
        }

        public void Create(Income item)
        {
            storages.Storages.Add(item);
        }

        public void Delete(int id)
        {
            storages.Storages.RemoveAt(id);
        }

        public Income Get(int id)
        {
            return storages.Storages.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Income> GetAll()
        {
            return storages.Storages.ToList();
        }

        public void Update(Income item)
        {
            storages.Storages[item.Id] = item;
        }
    }
}
