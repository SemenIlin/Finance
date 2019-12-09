namespace Finance.Interfaces.Operations
{
    public class InputDataMoneyOperationHandler : IQueryHandler<InputDataMoneyOperation, string>
    {
        public string Handle(InputDataMoneyOperation input)
        {
            input.AddMoneyOperation();
            return "Данные успешно добавленны.";
        }
    }
}
