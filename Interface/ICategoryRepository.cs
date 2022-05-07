using System.Collections.Generic;
using TrackingService.Model;

namespace TrackingService.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        List<Category> GetAllByType(string type);
        Category GetById(int id);
        void Insert(Category category);
        void Update(Category category);
        void Delete(int ID);
        void Save();
    }
}
