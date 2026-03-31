namespace GaiaProject.Database
{
    using GaiaProject.Models;
    using Microsoft.EntityFrameworkCore;
    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) : base(options) { }

        public DbSet<OperationHistory> Operations { get; set; }
    }
}
