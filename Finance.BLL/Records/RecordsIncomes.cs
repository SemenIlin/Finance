﻿using Finance.BLL.BusinessModel;
using Finance.BLL.DTO;
using Finance.BLL.Infrastructure;
using Finance.BLL.Interfaces;
using Finance.DAL.Interfaces;
using Finance.DAL.Models;
using System.Collections.Generic;
using System.Linq;



namespace Finance.BLL.Records
{
    public class RecordsIncomes : IRecordMoneyOperation
    {
        private IUnitOfWork Incomes { get; set; }

        public RecordsIncomes(IUnitOfWork uow)
        {
            Incomes = uow;
        }

        public void MakeRecords(IMoneyOperationDTO recordDto)
        {     
            var result = new Tax(recordDto.Tax).GetMoneyAfterRecalculation(recordDto.Money);
            Incomes.Income.Create(new Income(recordDto.Day, result.Tax, result.Money, recordDto.Resource));
            
        }

        public IMoneyOperationDTO GetRecord(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id записи дохода", "");
            }

            var income = Incomes.Income.Get(id.Value);
            if (income == null)
            {
                throw new ValidationException("Запись дохода не найдена", "");
            }

            return new IncomeDTO { Day = income.Day, Money = income.Money, Resource = income.Resource, Tax = income.Tax };
        }

        public IEnumerable<IMoneyOperationDTO> GetRecords()
        {
            return CopyValue(Incomes.Income);
        }

        private List<IncomeDTO> CopyValue(IRepository<Income> repository)
        {
            var listIncomesDTO = new List<IncomeDTO>();
            var incomes = repository.GetAll().ToList();
            foreach (var income in incomes)
            {
                listIncomesDTO.Add(new IncomeDTO {Id = income.Id, Day = income.Day, Money = income.Money, Resource = income.Resource, Tax = income.Tax });            
            }

            return listIncomesDTO;
        }
    }
}