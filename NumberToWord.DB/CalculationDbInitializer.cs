using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWord.DB
{
    public class CalculationDbInitializer : DropCreateDatabaseIfModelChanges<CalculationDbContext>
    {
        protected override void Seed(CalculationDbContext context)
        {
            var calculations = new List<Calculation>
            {
                new Calculation {CalculationId = 1, Result = "Twenty Three"},
                new Calculation {CalculationId = 2, Result = "One"}
            };
            calculations.ForEach(x => context.Calculations.Add(x));
            context.SaveChanges();
        }
    }
}
