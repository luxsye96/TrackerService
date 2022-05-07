using System;
using System.Collections.Generic;
using TrackingService.DTO;
using TrackingService.Model;

namespace TrackingService.Interface
{
    public interface IExpenseService
    {
        string CreateExpense(ExpenseDTO expenseDTO);
        string EditExpense(ExpenseDTO expenseDTO);
        string DeleteExpense(int id);
        List<Expense> GetAllExpense();
        List<Expense> GetAllExpByDate(DateTime date);

        List<Expense> GetAllExpByDateRange(DateTime startDate, DateTime endDate);

        ForcastDTO GetAvgExpense();
    }
}
