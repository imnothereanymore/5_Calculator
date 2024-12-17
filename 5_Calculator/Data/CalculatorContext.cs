using _5_Calculator.Data;
using Microsoft.EntityFrameworkCore;

namespace _5_Calculator.Data
{
    public class CalculatorContext : DbContext
    {
        public DbSet<DataInputVariant> DataInputVariants { get; set; }

        public CalculatorContext(DbContextOptions<CalculatorContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //OnModelCreating(modelBuilder);
        }
    }
}