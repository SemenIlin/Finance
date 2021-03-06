﻿using System;
using Finance.BLL.DTO;
using Finance.BLL.Infrastructure;
using Finance.BLL.Interfaces;
using Finance.DAL.Interfaces;
using Finance.DAL.Models;
using System.Linq;
using System.Collections.Generic;

namespace Finance.BLL.Records
{
    public class RecordsExpenses:IRecordMoneyOperation
    {
        private IRepository<Expense> Expenses { get; set; }

        public RecordsExpenses(IRepository<Expense> uow)
        {
            Expenses = uow;
        }

        public void MakeRecords(IMoneyOperationDTO recordDto)
        {
            Expenses.Create(new Expense(recordDto.Day, recordDto.Money, recordDto.Resource));            
        }

        public IMoneyOperationDTO GetRecord(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("Не установлено id записи расхода");
            }

            var expense = Expenses.Get(id.Value);
            if (expense == null)
            {
                throw new NullReferenceException("Запись расхода не найдена");
            }

            return new ExpenseDTO { Day = expense.Day, Money = expense.Money, Resource = expense.Resource };
        }

        public IEnumerable<IMoneyOperationDTO> GetRecords()
        {
            return CopyValue(Expenses);
        }

        private List<ExpenseDTO> CopyValue(IRepository<Expense> repository)
        {
            var listExpensesDTO = new List<ExpenseDTO>();
            var expenses = repository.GetAll().ToList();
            foreach (var expense in expenses)
            {
                listExpensesDTO.Add(new ExpenseDTO {Id = expense.Id, Day = expense.Day, Money = expense.Money, Resource = expense.Resource});
            }

            return listExpensesDTO;
        }

       
    }
}
