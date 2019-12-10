using Finance.Money;

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
            var moneyOperation = new MoneyOperation(command.Day, command.Money, command.Resource, command.Operation);
            storage.AddMoneyOperation(moneyOperation);
        }
    }
}
