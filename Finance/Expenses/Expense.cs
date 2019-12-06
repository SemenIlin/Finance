namespace Finance.Expenses
{
    public class Expense
    {
        public Expense(int numberOfDay, decimal value, string resource)
        {
            NumberOfDay = numberOfDay;
            ValueExpenses = value;
            Resource = resource;
        }

        public int NumberOfDay { get; }
        public decimal ValueExpenses { get; }
        public string Resource { get; }
    }
}
