using System;
using TrackingService.Model;

namespace TrackingService
{
    public class IncomeDTO
    {

        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int IncomeType { get; set; }
        public String IncomeName { get; set; }
        public Double Amount { get; set; }
        public String Description { get; set; }


        public static Income ToIncome(IncomeDTO incomeDt, Category category)
        {
            Income income = new Income();
            income.ID = incomeDt.ID;
            income.Date = incomeDt.Date;
            income.IncomeName = incomeDt.IncomeName;
            income.IncomeType = category.ID;
            income.Amount = incomeDt.Amount;
            income.Description = incomeDt.Description;
            return income;
        }
    }
}