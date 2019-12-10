using Finance.Models;

namespace Finance.Commands.CreateMoneyOperation
{
    public class CreateMoneyOperationCommand : ICommand
    {
        public CreateMoneyOperationCommand(int day, decimal money, string resource, TypeOperation operation)
        {
            Day = day;
            Money = money;
            Resource = resource;
            Operation = operation;
        }

        public int Day { get; }
        public decimal Money { get; }
        public string Resource { get; }
        public TypeOperation Operation { get; }   
    }
}
