using System;
using TrackingService.Model;

namespace TrackingService.DTO
{
    public class ExpenseDTO
    {

        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int ExpenseType { get; set; }
        public String ExpenseName { get; set; }
        public Double Amount { get; set; }
        public String Description { get; set; }


        public static Expense ToExpense(ExpenseDTO expenseDTO, Category category)
        {
            Expense exp = new Expense();
            exp.ID = expenseDTO.ID;
            exp.Date = expenseDTO.Date;
            exp.ExpenseName = expenseDTO.ExpenseName;
            exp.ExpenseType = category.ID;
            exp.Amount = expenseDTO.Amount;
            exp.Description = expenseDTO.Description;
            return exp;
        }
    }

}
