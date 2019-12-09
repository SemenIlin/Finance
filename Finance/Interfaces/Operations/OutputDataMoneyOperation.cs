using Finance.Money;
using System.Collections.Generic;
using System.Linq;

namespace Finance.Interfaces.Operations
{
    public class OutputDataMoneyOperation : IQuery<ICollection<MoneyOperation>>
    {
        private ICollection<MoneyOperation> outputData;
        private readonly ICollection<MoneyOperation> moneyOperation;
        private readonly TypeOperation type;

        private readonly int countRecords;

        public OutputDataMoneyOperation(RecordsOfMoneyOperations records, TypeOperation type, int countRecords)
        {
            this.countRecords = countRecords;
            this.type = type;
            moneyOperation = records.GetMoneyOperations();        
        }

        public ICollection<MoneyOperation> GetListMoneyOperations()
        {            

            if (moneyOperation.Count != 0)
            {
                if (moneyOperation.Count > countRecords)
                {
                    outputData = moneyOperation.Where(t => t.TypeOperation == type).OrderBy(d => d.NumberOfDay).Take(countRecords).ToList(); 
                }

                else if (moneyOperation.Count <= countRecords)
                {
                    outputData =  moneyOperation.Where(t => t.TypeOperation == type).OrderBy(d => d.NumberOfDay).ToList();
                }
            }

            return outputData;
        }
    }
}
