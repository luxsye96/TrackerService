using System;
using System.Collections.Generic;
using System.Linq;
using TrackingService.DTO;
using TrackingService.Interface;
using TrackingService.Model;

namespace TrackingService.Repository
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly TrackerContext _context;

        public IncomeRepository(TrackerContext trackerContext)
        {
            _context = trackerContext;
        }


        public void Delete(int id)
        {
            Income income = _context.Income.Find(id);
            _context.Income.Remove(income);
            _context.SaveChanges();
        }

        public IEnumerable<Income> GetAll()
        {
            return _context.Income.ToList();
        }

        public Income GetById(int id)
        {
            return _context.Income.Find(id);
        }

        public void Insert(Income income)
        {
            _context.Income.Add(income);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Income income)
        {
            Income incToUpdate = _context.Income
       .Where(p => p.ID == income.ID).FirstOrDefault();

            if (incToUpdate != null)
            {
                _context.Entry(incToUpdate).CurrentValues.SetValues(income);
            }
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public List<Income> GetAllByDate(DateTime date)
        {

            return (from x in _context.Income
                    where x.Date.Date == date.Date
                    select new Income
                    {
                        ID = x.ID,
                        IncomeName = x.IncomeName,
                        IncomeType = x.IncomeType,
                        Amount = x.Amount,
                        Date = x.Date,
                        Description = x.Description,
                    }).ToList();


        }

        public List<Income> GetAllByDateRange(DateTime startDate, DateTime endDate)
        {
            return (from y in _context.Income
                    where (y.Date >= startDate) && (y.Date <= endDate)
                    select new Income
                    {
                        ID = y.ID,
                        IncomeName = y.IncomeName,
                        IncomeType = y.IncomeType,
                        Amount = y.Amount,
                        Date = y.Date,
                        Description = y.Description,
                    }).ToList();

        }

        public ForcastDTO GetAvgIncome()
        {
            ForcastDTO forcast = new ForcastDTO();
            DateTime date = DateTime.Now;

            double amount = _context.Income.Where(x => x.Date.Date <= date.Date).Sum(x => x.Amount);
            forcast.TotalAmount = amount;
            DateTime da = _context.Income.OrderBy(x => x.Date).FirstOrDefault().Date;
            forcast.StartDate = da;

            double days = (date - da).TotalDays;
            forcast.AvgAmount = amount / days;

            return forcast;
        }
    }
}