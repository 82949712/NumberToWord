using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberToWord.DB
{
    public class Calculation
    {
        public int CalculationId { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
