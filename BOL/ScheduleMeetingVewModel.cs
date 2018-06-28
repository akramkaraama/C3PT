using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class ScheduleMeetingVewModel
    {
        public Employee Employee { get; set; }
        public Note Note { get; set; }
        
        public Meeting Meeting { get; set; }
        public Guest Guest { get; set; }
        public List<Company> Company { get; set; }
        //public Meeting_Employee empMeetings { get; set; }

    }
}
