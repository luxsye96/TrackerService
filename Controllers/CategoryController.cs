using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TrackingService.Interface;
using TrackingService.Model;


namespace TrackingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private ICategoryService categoryService;

        public CategoryController(ICategoryService categorySvc)
        {
            categoryService = categorySvc;
        }

        // POST: api/<CategoryController>
        [HttpPost]
        public ReponseWrapper AddCategory(Category category)
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                string msg = categoryService.CreateCategory(category);
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
        public ReponseWrapper EditIncome(Category category)
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                string msg = categoryService.EditCategory(category);
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
                string msg = categoryService.DeleteCategory(id);
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




        [HttpGet("type")]
        public ReponseWrapper GetCategoryByType(string type)
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                List<Category> categories = categoryService.GetAllCategoryByType(type);
                reponseWrapper.StatusCode = 200;
                reponseWrapper.Message = "Sucessfully Added Income";
                reponseWrapper.Result = categories;
            }
            catch (Exception exception)
            {
                reponseWrapper.Message = exception.Message;
                reponseWrapper.StatusCode = 500;
            }

            return reponseWrapper;
        }

        [HttpGet]
        public ReponseWrapper GetCategory()
        {
            ReponseWrapper reponseWrapper = new ReponseWrapper();
            try
            {
                List<Category> categories = categoryService.GetAllCategory();
                reponseWrapper.StatusCode = 200;
                reponseWrapper.Message = "Sucessfully Added Income";
                reponseWrapper.Result = categories;
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
