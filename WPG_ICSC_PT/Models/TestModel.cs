using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WPG_ICSC_PT.Models
{
    public class TestModel
    {
        public Meeting Meeting { get; set; }
        public Guest Guest { get; set; }
        public Employee Employee { get; set; }
        public Note Note { get; set; }
    }
}