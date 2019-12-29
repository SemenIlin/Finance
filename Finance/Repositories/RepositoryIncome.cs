using Finance.DAL.Interfaces;
using Finance.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finance.DAL.Repositories
{
    public class RepositoryIncome : IRepository<Income>
    {
        private readonly List<Income> incomes;

        public RepositoryIncome(List<Income> incomes)
        {
            this.incomes = incomes;        
        }

        public void Create(Income item)
        {
            incomes.Add(item);
        }

        public void Delete(int id)
        {
            incomes.RemoveAt(id);
        }

        public IEnumerable<Income> Find(Func<Income, bool> predicate)
        {
            return incomes.Where(predicate).ToList();          
        }

        public Income Get(int id)
        {
            return incomes.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Income> GetAll()
        {
            return incomes.ToList();
        }

        public void Update(Income item)
        {
            incomes[item.Id] = item;
        }
    }
}
