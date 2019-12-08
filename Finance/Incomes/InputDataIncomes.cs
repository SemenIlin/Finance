using System;
using System.Collections.Generic;
using Finance.Interfaces.DataInput;
using Finance.Interfaces.Operations;

namespace Finance.Incomes
{
    public class InputDataIncomes : ICommand
    {
        private readonly IInputData inputData;

        private int day;
        private decimal money;
        private string resource = String.Empty;

        private Income income;
        private RecordsOfIncomes Records;


        public InputDataIncomes(ICollection<Income> incomes, IInputData inputData)
        {
            this.inputData = inputData;
            Records = RecordsOfIncomes.GetInstance(incomes);
        }

        public void Execute()
        {

            day = inputData.AddDay();
            money = inputData.AddMoney();
            resource = inputData.AddResource();

            CreateIncome();
            AddIncome(CreateIncome());        
        }

        public RecordsOfIncomes GetRecords()
        {
            return Records;
        }

        private Income CreateIncome()
        {
            income = new Income(day, money, resource);
            return income;
        }

        private void AddIncome(Income income)
        {
            Records.AddIncome(income);
        }
    }
}