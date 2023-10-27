using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForGym.Models
{
    public class Client
    {
        public int IDClient { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public int MarkDatesCount { get; set; }
        public int IDTariff { get; set; }
    }
}
