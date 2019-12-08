using Finance.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Finance.Incomes
{
    public class OutputDataIncomes : ICommand
    {
        private readonly IInputCount inputCount;
        private readonly ICollection<Income> incomes;
        private ICollection<Income> tempIncome;

        private int countRecords;

        public OutputDataIncomes(IInputCount inputCount, RecordsOfIncomes records)
        {
            incomes = records.GetIncomes();            
            this.inputCount = inputCount; 
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

        public void Execute()
        {
            countRecords = inputCount.SetCount();
            GetListIncomes(countRecords);
            Print(new ConsolePrint());
        }

        private ICollection<Income> GetListIncomes(int count)
        {
            tempIncome = new List<Income>();

            if(incomes.Count != 0)
            {
                if (incomes.Count > count)
                {
                    int counter = 0;
                    foreach (var income in incomes)
                    {
                        if (counter < count)
                        {
                            tempIncome.Add(income);
                            counter++;
                        }
                    }                                 
                }

                else if( incomes.Count <= count)
                {
                    tempIncome = incomes;
                }
            }
            
            return tempIncome;
        }
    }
}
