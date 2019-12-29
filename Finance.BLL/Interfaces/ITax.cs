namespace Finance.BLL.Interfaces
{
    public interface ITax
    {
        (decimal Money, decimal Tax) GetMoneyAfterRecalculation(decimal money);
        decimal ValueTax { get; }
    }
}
