using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class HomeViewModel
    {
        public int Id { get; set; }
        public List<Employee> employees { get; set; }
        public List<Meeting> meetings { get; set; }
        public List<Meeting_Employee> empMeetings { get; set; }
    }
}
