using Finance.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Incomes
{
    public class OutputDataIncomes
    {
        private List<Income> incomes;
        private List<Income> tempIncome;

        public OutputDataIncomes(int count, RecordsOfIncomes records)
        {
            incomes = records.GetIncomes();
            GetListIncomes(count);
        }

        public void Print(IPrint print)
        {
            print.Print(ToString());
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var income in tempIncome)
                sb.AppendFormat("Номер дня: {0} \t Сумма: {1} \t Источник: {2}\n", income.NumberOfDay, income.ValueIncome, income.Resource);

            return sb.ToString();
        }

        private List<Income> GetListIncomes(int count)
        {
            tempIncome = new List<Income>();

            if(incomes.Count != 0)
            {
                if (incomes.Count > count)
                {
                    for (int i = 0; i < count; i++)
                    {
                        tempIncome.Add(incomes[count]);                    
                    }                                    
                }

                else if( incomes.Count <= 3)
                {
                    tempIncome = incomes;
                }
            }
            
            return tempIncome;
        }
    }
}
