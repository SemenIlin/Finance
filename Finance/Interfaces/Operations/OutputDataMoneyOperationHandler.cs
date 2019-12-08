using Finance.Money;
using System.Collections.Generic;

namespace Finance.Interfaces.Operations
{
    public class OutputDataMoneyOperationHandler: IQueryHandler<OutputDataMoneyOperation, ICollection<MoneyOperation>>
    {
        public ICollection<MoneyOperation> Handle(OutputDataMoneyOperation outputData)
        {
            outputData.Execute();
            return outputData.GetListExpenses();
        }
    }
}
