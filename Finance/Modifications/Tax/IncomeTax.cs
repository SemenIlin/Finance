namespace Finance.Modifications.Tax
{
    public class IncomeTax: ITax
    {
        public IncomeTax(double tax)
        {
            ValueTax = tax;        
        }

        public double ValueTax { get; }
    }
}
