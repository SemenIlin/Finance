namespace Finance.Interfaces.DataInput
{
    public interface IInputData
    {
        int AddDay();
        decimal AddMoney();
        string AddResource();
        TypeOperation Type();
    }
}