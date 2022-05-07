using Microsoft.EntityFrameworkCore;
using TrackingService.Model;

namespace TrackingService
{
    public class TrackerContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public TrackerContext(DbContextOptions<TrackerContext> option)
           : base(option)
        {
        }
        public Microsoft.EntityFrameworkCore.DbSet<Income> Income { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Category> Category { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Expense> Expense { get; set; }
    }
}