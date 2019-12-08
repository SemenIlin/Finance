namespace Finance.Money
{
    public class MoneyOperation
    {
        public MoneyOperation(int numberOfDay, decimal value, string resource, TypeOperation operation)
        {
            NumberOfDay = numberOfDay;
            Value = value;
            Resource = resource;
            TypeOperation = operation;
        }

        public int NumberOfDay { get; }
        public decimal Value { get; }
        public string Resource { get; }
        public TypeOperation TypeOperation { get; }
    }
}
