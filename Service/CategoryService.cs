using System;
using System.Collections.Generic;
using System.Linq;
using TrackingService.Interface;
using TrackingService.Model;

namespace TrackingService.Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;


        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public bool IsValidToProcess(Category category)
        {
            return true;
        }


        public string CreateCategory(Category category)
        {
            if (IsValidToProcess(category))
            {
                try
                {
                    _categoryRepository.Insert(category);
                    _categoryRepository.Save();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return "Successfully Category Added";
            }

            return "Unable to add category. Please try again";
        }

        public string EditCategory(Category category)
        {


            if (IsValidToProcess(category))
            {
                try
                {
                    _categoryRepository.Update(category);
                    _categoryRepository.Save();
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                return "Successfully Category Updated";
            }

            return "Unable to edit category. Please try again";
        }

        public string DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
            return "Your category details deleted Succesfully";
        }

        public List<Category> GetAllCategoryByType(string type)
        {
            List<Category> model = _categoryRepository.GetAllByType(type);
            return model;
        }

        public List<Category> GetAllCategory()
        {
            IEnumerable<Category> model = _categoryRepository.GetAll();
            List<Category> asList = model.ToList();
            return asList;
        }

    }
}