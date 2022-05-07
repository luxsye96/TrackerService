using System;
using System.Collections.Generic;
using TrackingService.DTO;
using TrackingService.Model;

namespace TrackingService.Interface
{
    public interface IIncomeRepository
    {
        IEnumerable<Income> GetAll();
        List<Income> GetAllByDate(DateTime date);

        List<Income> GetAllByDateRange(DateTime startDate, DateTime endDate);
        Income GetById(int id);
        void Insert(Income income);
        void Update(Income income);
        void Delete(int ID);
        void Save();
        ForcastDTO GetAvgIncome();
    }
}
