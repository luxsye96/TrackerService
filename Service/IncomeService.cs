using System;
using System.Collections.Generic;
using System.Linq;
using TrackingService.DTO;
using TrackingService.Interface;
using TrackingService.Model;

namespace TrackingService.Service
{
    public class IncomeService : IIncomeService
    {

        private IIncomeRepository _incomeRepository;
        private ICategoryRepository _categoryRepository;

        public IncomeService(ICategoryRepository categoryRepository, IIncomeRepository incomeRepo)
        {
            _categoryRepository = categoryRepository;
            _incomeRepository = incomeRepo;
        }

        public string CreateIncome(IncomeDTO incomeDTO)
        {
            if (IsvalidToProceed(incomeDTO))
            {
                Category category = _categoryRepository.GetById(incomeDTO.IncomeType);
                if (category.CategoryType == "Income")
                {
                    Income incomeModel = IncomeDTO.ToIncome(incomeDTO, category);

                    _incomeRepository.Insert(incomeModel);
                    _incomeRepository.Save();
                    return "Successful Income Added";

                }
                else
                {
                    return "Income cannot be created with this Category Type";
                }
            }

            return "Unable to create Income. Please try again";
        }

        public string EditIncome(IncomeDTO incomeDTO)
        {

            if (IsvalidToProceed(incomeDTO))
            {
                Category category = _categoryRepository.GetById(incomeDTO.IncomeType);
                Income incomeModel = IncomeDTO.ToIncome(incomeDTO, category);
                if (category.CategoryType == "Income")
                {
                    _incomeRepository.Update(incomeModel);
                    _incomeRepository.Save();
                    return "Successful Income Updated";
                }
                else
                {
                    return "Income cannot be updated with this Category Type";
                }
            }

            return "";
        }

        public string DeleteIncome(int id)
        {
            _incomeRepository.Delete(id);
            return "Your income details deleted Succesfully";
        }

        public List<Income> GetAllIncome()
        {
            IEnumerable<Income> model = _incomeRepository.GetAll();
            List<Income> asList = model.ToList();
            return asList;
        }



        public Boolean IsvalidToProceed(IncomeDTO incomeModel)
        {
            if (String.IsNullOrEmpty(incomeModel.IncomeName))
            {
                return false;
            }
            else if (incomeModel.Amount <= 0)
            {
                return false;
            }
            else if (incomeModel.Date == DateTime.MinValue)
            {
                return false;
            }

            return true;
        }

        public List<Income> GetAllIncomeByDate(DateTime date)
        {
            List<Income> model = _incomeRepository.GetAllByDate(date);
            return model;
        }

        public List<Income> GetAllIncomeByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Income> model = _incomeRepository.GetAllByDateRange(startDate, endDate);
            return model;
        }


        public ForcastDTO GetAvgIncome()
        {
            return _incomeRepository.GetAvgIncome();
        }
    }
}