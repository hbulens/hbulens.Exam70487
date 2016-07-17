using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Common
{
    public class Audit
    {        
        public Audit()
        {
            this.Date = DateTime.Now;
        }

        public int Id { get; set; }
        public string Action { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
    }
}
