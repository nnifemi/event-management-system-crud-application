using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event_Management_System_CRUD_Application.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}