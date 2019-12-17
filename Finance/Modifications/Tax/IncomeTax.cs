namespace Finance.Modifications.Tax
{
    public class IncomeTax: ITax
    {
        public IncomeTax(decimal tax)
        {
            ValueTax = tax;        
        }

        public decimal ValueTax { get; }
    }
}
