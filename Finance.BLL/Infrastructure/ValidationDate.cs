using System;
using System.Diagnostics.Contracts;

namespace Finance.BLL.Infrastructure
{
    public static class ValidationDate
    {
        private static readonly int[] DaysToMonth365 = {
            0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365};

        private static readonly int[] DaysToMonth366 = {
            0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366};

        public static bool IsLeapYear(int year)
        {
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException("year");
            }
            Contract.EndContractBlock();
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }

        public static int DaysInMonth(int year, int month)
        {
            if (month < 1 || month > 12) throw new ArgumentOutOfRangeException("month");
            Contract.EndContractBlock();
            // IsLeapYear checks the year argument
            int[] days = IsLeapYear(year) ? DaysToMonth366 : DaysToMonth365;
            return days[month] - days[month - 1];
        }
    }
}
