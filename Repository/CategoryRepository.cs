using System.Collections.Generic;
using System.Linq;
using TrackingService.Interface;
using TrackingService.Model;

namespace TrackingService.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TrackerContext _context;

        public CategoryRepository(TrackerContext trackerContext)
        {
            _context = trackerContext;
        }

        public void Delete(int ID)
        {
            Category category = _context.Category.Find(ID);
            _context.Category.Remove(category);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public List<Category> GetAllByType(string type)
        {
            return (from x in _context.Category
                    where x.CategoryType == type
                    select new Category
                    {
                        ID = x.ID,
                        CategoryName = x.CategoryName,
                        CategoryType = x.CategoryType
                    }).ToList();
        }

        public Category GetById(int id)
        {
            return _context.Category.Find(id);
        }

        public void Insert(Category category)
        {
            _context.Category.Add(category);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            Category categoryToUpdate = _context.Category
          .Where(p => p.ID == category.ID).FirstOrDefault();

            if (categoryToUpdate != null)
            {
                _context.Entry(categoryToUpdate).CurrentValues.SetValues(category);
            }
        }
    }
}