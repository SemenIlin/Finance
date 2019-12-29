using System;

namespace Finance.DAL.Interfaces
{
    public interface IMoneyOperation
    {
        decimal Tax { get; }
        decimal Money { get; }
        DateTime Day { get; }
        string Resource { get; }
    }
}
