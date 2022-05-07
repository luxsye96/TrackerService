using System;
using System.Collections.Generic;
using TrackingService.DTO;
using TrackingService.Model;

namespace TrackingService.Interface
{
    public interface IIncomeService
    {

        string CreateIncome(IncomeDTO incomeDTO);
        string EditIncome(IncomeDTO incomeDTO);
        string DeleteIncome(int id);
        List<Income> GetAllIncome();
        List<Income> GetAllIncomeByDate(DateTime date);
        List<Income> GetAllIncomeByDateRange(DateTime startDate, DateTime endDate);
        ForcastDTO GetAvgIncome();
    }
}
