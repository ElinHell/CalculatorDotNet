namespace GaiaProject.Database
{
    using Microsoft.EntityFrameworkCore;
    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) : base(options) { }

        public DbSet<OperationHistory> Operations { get; set; }
    }
}
