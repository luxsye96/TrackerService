using System;
using System.Collections.Generic;
using System.Linq;
using TrackingService.DTO;
using TrackingService.Interface;
using TrackingService.Model;

namespace TrackingService.Service
{
    public class ExpenseService : IExpenseService
    {
        private IExpenseRepository _expRepository;
        private ICategoryRepository _categoryRepository;

        public ExpenseService(ICategoryRepository categoryRepository, IExpenseRepository expRepo)
        {
            _categoryRepository = categoryRepository;
            _expRepository = expRepo;
        }

        public string CreateExpense(ExpenseDTO expenseDTO)
        {
            if (IsvalidToProceed(expenseDTO))
            {
                Category category = _categoryRepository.GetById(expenseDTO.ExpenseType);
                Expense expense = ExpenseDTO.ToExpense(expenseDTO, category);
                if (category.CategoryType == "Expense")
                {
                    _expRepository.Insert(expense);
                    _expRepository.Save();
                    return "Successfully Expense Added";
                }
                else
                {
                    return "Expense cannot be created with this Category Type";
                }
            }

            return "Unable to create Income. Please try again";
        }

        public string EditExpense(ExpenseDTO expenseDTO)
        {


            if (IsvalidToProceed(expenseDTO))
            {
                Category category = _categoryRepository.GetById(expenseDTO.ExpenseType);
                Expense expense = ExpenseDTO.ToExpense(expenseDTO, category);
                if (category.CategoryType == "Expense")
                {
                    _expRepository.Update(expense);
                    _expRepository.Save();
                    return "Successfully Expense Updated";
                }
                else
                {
                    return "Expense cannot be created with this Category Type";
                }
            }

            return "Unable to update Income. Please try again";
        }

        public string DeleteExpense(int id)
        {
            _expRepository.Delete(id);
            return "Your expense details deleted Succesfully";
        }

        public List<Expense> GetAllExpense()
        {
            IEnumerable<Expense> model = _expRepository.GetAll();
            List<Expense> asList = model.ToList();
            return asList;
        }

        public Boolean IsvalidToProceed(ExpenseDTO expenseDTO)
        {
            if (String.IsNullOrEmpty(expenseDTO.ExpenseName))
            {
                return false;
            }
            else if (expenseDTO.Amount <= 0)
            {
                return false;
            }
            else if (expenseDTO.Date == DateTime.MinValue)
            {
                return false;
            }

            return true;
        }

        public List<Expense> GetAllExpByDate(DateTime date)
        {
            List<Expense> model = _expRepository.GetAllByDate(date);
            return model;
        }

        public List<Expense> GetAllExpByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Expense> model = _expRepository.GetAllExpByDateRange(startDate, endDate);
            return model;
        }

        public ForcastDTO GetAvgExpense()
        {
            return _expRepository.GetAvgExpense();
        }

    }

}
