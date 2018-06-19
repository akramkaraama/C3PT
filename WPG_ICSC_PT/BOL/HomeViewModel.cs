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
        public Role role { get; set; }
        public List<Note> notes { get; set; }
        public List<Meeting> meetings { get; set; }
        public List<Meeting_Employee> employee_Meetings { get; set; }
        public MeetingStatu meetingStatus { get; set; }
        public MeetingType meetingType { get; set; }
        public List<Employee_Guest> employee_Guests { get; set; }
        public List<Guest> guests { get; set; }
        public Company company { get; set; }


    }
}
