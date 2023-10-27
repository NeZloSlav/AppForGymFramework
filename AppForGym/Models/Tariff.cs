using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForGym.Models
{
    public class Tariff
    {
        public int IDTariff { get; set; }
        public string Name { get; set; }
        public int CountOfDays { get; set; }
        public string Description { get; set; }

    }
}
