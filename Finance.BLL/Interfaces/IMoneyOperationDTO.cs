using System;

namespace Finance.BLL.Interfaces
{
    public interface IMoneyOperationDTO
    {
        DateTime Day { get; set; }
        decimal Money { get; set; }
        decimal Tax { get; set; }
        string Resource { get; set; }
    }
}
