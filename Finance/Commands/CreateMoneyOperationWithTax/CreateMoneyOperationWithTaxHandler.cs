using Finance.Models;
using Finance.Storage;

namespace Finance.Commands.CreateMoneyOperationWithTax
{
    public class CreateMoneyOperationWithTaxHandler:ICommandHandler<CreateMoneyOperationWithTaxCommand>
    {
        private readonly RecordsStorage storage;

        public CreateMoneyOperationWithTaxHandler()
        {
            storage = RecordsStorage.GetInstance();
        }

        public void Handle(CreateMoneyOperationWithTaxCommand command)
        {
            var moneyOperation = new MoneyOperation(command.Day, command.Money,command.Tax, command.Balance, command.Resource, command.Operation);
            storage.AddMoneyOperation(moneyOperation);
        }
    }
}
