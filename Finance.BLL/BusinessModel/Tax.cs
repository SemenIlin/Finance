﻿using Finance.BLL.Interfaces;

namespace Finance.BLL.BusinessModel
{
    public class Tax :ITax
    {

        public Tax(decimal val)
        {
            ValueTax = val;
        }

        public decimal ValueTax  { get; private set; }

        public (decimal Money,decimal Tax) GetMoneyAfterRecalculation(decimal money)
        {
            decimal tax = money * ValueTax / 100;
            money -= tax;

            var result = (Money: money, Tax: tax);

            return result;
        }
    }
}
