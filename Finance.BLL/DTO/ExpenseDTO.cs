using Finance.BLL.Interfaces;
using System;

namespace Finance.BLL.DTO
{
    public class ExpenseDTO : IMoneyOperationDTO
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public decimal Money { get; set; }
        public decimal Tax { get; set; }
        public string Resource { get; set; }        
    }
}
