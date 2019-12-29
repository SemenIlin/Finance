using Finance.DAL.Interfaces;
using Finance.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finance.DAL.Repositories
{
    public class RepositoryExpenses : IRepository<Expense>
    {
        private readonly List<Expense> expenses;

        public RepositoryExpenses(List<Expense> expenses)
        {
            this.expenses = expenses;
        }
        public void Create(Expense expense)
        {
            expenses.Add(expense) ;          
        }

        public void Delete(int id)
        {
            expenses.RemoveAt(id);
        }

        public IEnumerable<Expense> Find(Func<Expense, bool> predicate)
        {
           return expenses.Where(predicate).ToList();
        }

        public Expense Get(int id)
        {
            return expenses.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Expense> GetAll()
        {
            return expenses.ToList();
        }

        public void Update(Expense item)
        {
            expenses[item.Id] = item;
        }
    }
}
