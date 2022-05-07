using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TrackingService.DTO;
using TrackingService.Interface;
using TrackingService.Model;

namespace TrackingService.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly TrackerContext _context;

        public ExpenseRepository(TrackerContext trackerContext)
        {
            _context = trackerContext;
        }

        public void Delete(int id)
        {
            Expense expense = _context.Expense.Find(id);
            _context.Expense.Remove(expense);
            _context.SaveChanges();
        }

        public IEnumerable<Expense> GetAll()
        {
            IEnumerable<Expense> exp;

            try
            {
                exp = _context.Expense.ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);

            }
            exp = _context.Expense.ToList();
            return exp;
        }

        public Expense GetById(int id)
        {
            return _context.Expense.Find(id);
        }

        public void Insert(Expense expense)
        {

            try
            {
                _context.Expense.Add(expense);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);

            }
        }

        public void Save()
        {

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);

            }
        }

        public void Update(Expense expense)
        {
            Expense expToUpdate = _context.Expense
        .Where(p => p.ID == expense.ID).FirstOrDefault();

            if (expToUpdate != null)
            {
                _context.Entry(expToUpdate).CurrentValues.SetValues(expense);
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

        public List<Expense> GetAllByDate(DateTime date)
        {

            return (from x in _context.Expense
                    where (x.Date.Date == date.Date)
                    select new Expense
                    {
                        ID = x.ID,
                        ExpenseName = x.ExpenseName,
                        ExpenseType = x.ExpenseType,
                        Amount = x.Amount,
                        Date = x.Date,
                        Description = x.Description,
                    }).ToList();


        }

        public List<Expense> GetAllExpByDateRange(DateTime startDate, DateTime endDate)
        {
            return (from x in _context.Expense
                    where (x.Date >= startDate) && (x.Date <= endDate)
                    select new Expense
                    {
                        ID = x.ID,
                        ExpenseName = x.ExpenseName,
                        ExpenseType = x.ExpenseType,
                        Amount = x.Amount,
                        Date = x.Date,
                        Description = x.Description,
                    }).ToList();

        }

        public ForcastDTO GetAvgExpense()
        {
            ForcastDTO forcast = new ForcastDTO();
            DateTime date = DateTime.Now;

            double amount = _context.Expense.Where(x => x.Date.Date <= date.Date).Sum(x => x.Amount);
            forcast.TotalAmount = amount;
            DateTime da = _context.Expense.OrderBy(x => x.Date).FirstOrDefault().Date;
            forcast.StartDate = da;
            double days = (date - da).TotalDays;
            forcast.AvgAmount = amount / days;
            return forcast;
        }

    }
}
