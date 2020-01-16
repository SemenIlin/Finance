using System;

namespace DAL.Interfaces
{
    public interface IMoneyOperation
    {
        decimal Tax { get; set; }
        decimal Money { get; set; }
        DateTime Day { get; set; }
        string Resource { get; set; }
    }
}
