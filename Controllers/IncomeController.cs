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
    public class IncomeController : ControllerBase
    {
        private IIncomeService _incomeService;

        private ICategoryService categoryService;

        public IncomeController(ICategoryService categorySvc, IIncomeService incomeSvc)
        {
            categoryService = categorySvc;
            _incomeService = incomeSvc;

        }

        [HttpPost]
        public ReponseWrapper AddIncome(IncomeDTO income)
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                string msg = _incomeService.CreateIncome(income);
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
        public ReponseWrapper EditIncome(IncomeDTO income)
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                string msg = _incomeService.EditIncome(income);
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
        public ReponseWrapper DeleteIncome(int id)
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                string msg = _incomeService.DeleteIncome(id);
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
        public ReponseWrapper ViewIncome()
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                List<Income> incomes = _incomeService.GetAllIncome();
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

        [HttpGet("{date}")]
        public ReponseWrapper GetIncomeByDate(DateTime date)
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                List<Income> incomes = _incomeService.GetAllIncomeByDate(date);
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


        [HttpGet("{sDate}/{eDate}")]
        public ReponseWrapper GetIncomeByDateRange(DateTime sDate, DateTime eDate)
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                List<Income> incomes = _incomeService.GetAllIncomeByDateRange(sDate, eDate);
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

        [HttpGet("avgIncome")]
        public ReponseWrapper GetAvgExpense()
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                ForcastDTO forcastDTOs = _incomeService.GetAvgIncome();
                reponseWrapper.StatusCode = 200;
                reponseWrapper.Message = "Sucessfully Added Income";
                reponseWrapper.Result = forcastDTOs;
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
