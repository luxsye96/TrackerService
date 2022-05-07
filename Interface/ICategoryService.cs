using System.Collections.Generic;
using TrackingService.Model;

namespace TrackingService.Interface
{
    public interface ICategoryService
    {
        string CreateCategory(Category category);
        string EditCategory(Category category);
        string DeleteCategory(int id);
        List<Category> GetAllCategoryByType(string type);
        List<Category> GetAllCategory();
    }
}
