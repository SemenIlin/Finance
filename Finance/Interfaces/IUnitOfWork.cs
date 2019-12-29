using Finance.DAL.Models;
using System;

namespace Finance.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Income> Income { get; }
        IRepository<Expense> Expense { get; }
    }
}
