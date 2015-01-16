

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NumberToWord.DB
{
    public class CalculationDbContext : DbContext 
    {
        public CalculationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Calculation> Calculations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //prevent table name pluralized
        }
    }
}
