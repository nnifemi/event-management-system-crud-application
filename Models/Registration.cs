using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event_Management_System_CRUD_Application.Models
{
    public class Registration
    {
        public int RegistrationID { get; set; }
        public int EventID { get; set; }
        public string ParticipantName { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string PaymentStatus { get; set; }
        public Event Event { get; set; }
    }
}