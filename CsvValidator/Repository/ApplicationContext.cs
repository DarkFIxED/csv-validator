using CsvValidator.Domain;
using Microsoft.EntityFrameworkCore;

namespace CsvValidator.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<FailedPropertyValidation> FailedPropertyValidations { get; set; }
    }
}