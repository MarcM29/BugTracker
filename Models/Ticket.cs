using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Display(Name = "Ticket title:")]
        [Required(ErrorMessage = "Submitted tickets must have title")]
        public string TicketTitle { get; set; }

        [Display(Name = "Ticket description:")]
        [Required(ErrorMessage = "Submitted tickets must include a brief description")]
        public string TicketDescription { get; set; }

        [Display(Name = "Ticket priority:")]
        [Required(ErrorMessage = "Submitted tickets must be designated a priority")]
        public string TicketPriority { get; set; }

        [Display(Name = "Date of most recent edit:")]
        public string TicketDate { get; set; }

        [Display(Name = "Most recent edit by:")]
        public string UsersName { get; set; }

        public Ticket()
        {
        }
    }
}

