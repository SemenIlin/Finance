namespace Finance.Models
{
    public class MoneyOperation
    {
        public MoneyOperation(int numberOfDay, decimal value, decimal tax, decimal balance, string resource, TypeOperation operation)
        {
            NumberOfDay = numberOfDay;
            Value = value;
            Resource = resource;
            TypeOperation = operation;

            Tax = tax;
            Balance = balance;
        }

        public decimal Tax { get; }
        public decimal Balance { get; }

        public int NumberOfDay { get; }
        public decimal Value { get; }
        public string Resource { get; }
        public TypeOperation TypeOperation { get; }
    }
}
