using Finance.Models;
using Finance.Storage;

namespace Finance.Commands.CreateMoneyOperation
{
    public class CreateMoneyOperationHandler : ICommandHandler<CreateMoneyOperationCommand>
    {
        private readonly RecordsStorage storage;

        public CreateMoneyOperationHandler()
        {
            storage = RecordsStorage.GetInstance();
        }

        public void Handle(CreateMoneyOperationCommand command)
        {
            var moneyOperation = new MoneyOperation(command.Day, command.Money, command.Tax, command.Balance, command.Resource, command.Operation);
            storage.AddMoneyOperation(moneyOperation);
        }
    }
}
