using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TrackingService.DTO;
using TrackingService.Interface;
using TrackingService.Model;

namespace TrackingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : Controller
    {
        private IExpenseService _expService;

        private ICategoryService categoryService;

        public ExpenseController(ICategoryService categorySvc, IExpenseService expSvc)
        {
            categoryService = categorySvc;
            _expService = expSvc;

        }


        [HttpPost]
        public ReponseWrapper AddExpense(ExpenseDTO expenseDto)
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                string msg = _expService.CreateExpense(expenseDto);
                reponseWrapper.StatusCode = 200;
                reponseWrapper.Message = "Sucessfully Added Income";
            }
            catch (Exception exception)
            {
                reponseWrapper.Message = exception.Message;
                reponseWrapper.StatusCode = 500;
            }

            return reponseWrapper;
        }


        [HttpPost("update")]
        public ReponseWrapper EditExpense(ExpenseDTO expenseDto)
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                string msg = _expService.EditExpense(expenseDto);
                reponseWrapper.StatusCode = 200;
                reponseWrapper.Message = "Sucessfully Added Income";
            }
            catch (Exception exception)
            {
                reponseWrapper.Message = exception.Message;
                reponseWrapper.StatusCode = 500;
            }

            return reponseWrapper;
        }



        [HttpDelete("{id}")]
        public ReponseWrapper DeleteExpense(int id)
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                string msg = _expService.DeleteExpense(id);
                reponseWrapper.StatusCode = 200;
                reponseWrapper.Message = "Sucessfully Added Income";
            }
            catch (Exception exception)
            {
                reponseWrapper.Message = exception.Message;
                reponseWrapper.StatusCode = 500;
            }

            return reponseWrapper;
        }


        [HttpGet]
        public ReponseWrapper ViewExpense()
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                List<Expense> expenseDtos = _expService.GetAllExpense();
                reponseWrapper.StatusCode = 200;
                reponseWrapper.Message = "Sucessfully Added Income";
                reponseWrapper.Result = expenseDtos;
            }
            catch (Exception exception)
            {
                reponseWrapper.Message = exception.Message;
                reponseWrapper.StatusCode = 500;
            }

            return reponseWrapper;
        }

        [HttpGet("{date}")]
        public ReponseWrapper GetExpenseByDate(DateTime date)
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                List<Expense> expenseDtos = _expService.GetAllExpByDate(date);
                reponseWrapper.StatusCode = 200;
                reponseWrapper.Message = "Sucessfully Added Income";
                reponseWrapper.Result = expenseDtos;
            }
            catch (Exception exception)
            {
                reponseWrapper.Message = exception.Message;
                reponseWrapper.StatusCode = 500;
            }

            return reponseWrapper;
        }

        [HttpGet("{sDate}/{eDate}")]
        public ReponseWrapper GetIncomeByDateRange(DateTime sDate, DateTime eDate)
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                List<Expense> incomes = _expService.GetAllExpByDateRange(sDate, eDate);
                reponseWrapper.StatusCode = 200;
                reponseWrapper.Message = "Sucessfully Added Income";
                reponseWrapper.Result = incomes;
            }
            catch (Exception exception)
            {
                reponseWrapper.Message = exception.Message;
                reponseWrapper.StatusCode = 500;
            }

            return reponseWrapper;
        }

        [HttpGet("avgExp")]
        public ReponseWrapper GetAvgExpense()
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {


                ForcastDTO forcastDTO = _expService.GetAvgExpense();

                reponseWrapper.StatusCode = 200;
                reponseWrapper.Message = "Sucessfully Added Income";
                reponseWrapper.Result = forcastDTO;
            }
            catch (Exception exception)
            {
                reponseWrapper.Message = exception.Message;
                reponseWrapper.StatusCode = 500;
            }

            return reponseWrapper;
        }

    }

}
