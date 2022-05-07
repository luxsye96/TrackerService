using System;
using System.Collections.Generic;
using TrackingService.DTO;
using TrackingService.Model;

namespace TrackingService.Interface
{
    public interface IExpenseRepository
    {
        IEnumerable<Expense> GetAll();
        List<Expense> GetAllByDate(DateTime date);
        Expense GetById(int id);
        void Insert(Expense expense);
        void Update(Expense expense);
        void Delete(int ID);
        void Save();

        List<Expense> GetAllExpByDateRange(DateTime startDate, DateTime endDate);
        ForcastDTO GetAvgExpense();
    }
}
