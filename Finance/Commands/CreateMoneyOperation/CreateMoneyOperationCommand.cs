using Finance.Models;
using Finance.Modifications.Tax;

namespace Finance.Commands.CreateMoneyOperation
{
    public class CreateMoneyOperationCommand : ICommand
    {
        public CreateMoneyOperationCommand(int day, decimal money, string resource, TypeOperation operation, ITax tax)
        {
            Day = day;
            Money = money;
            Resource = resource;
            Operation = operation;

            Tax = System.Math.Round((tax.ValueTax * money / 100), 2);
            Balance = Money - Tax;
        }

        public int Day { get; }
        public decimal Money { get; }
        public string Resource { get; }
        public TypeOperation Operation { get; }

        public decimal Tax { get; }
        public decimal Balance { get; }
    }
}
