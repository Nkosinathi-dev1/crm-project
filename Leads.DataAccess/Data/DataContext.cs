using Leads.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Leads.DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Lead> Leads { get; set; }
    }
}
