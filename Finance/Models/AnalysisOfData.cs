using System.Collections.Generic;

namespace Finance.Models
{
    public class AnalysisOfData
    {
        public decimal TotalValueIncome { get; set; }
        public decimal TotalValueExpense { get; set; }
        public decimal Delta { get; set; }
        public List<ResourceMoneyValue> Expense { get; set; }
        public List<ResourceMoneyValue> Income { get; set; }
    }
}
