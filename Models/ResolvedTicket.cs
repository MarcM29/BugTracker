using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class ResolvedTicket
    {
        public int Id { get; set; }

        [Display(Name = "Ticket title:")]
        [Required(ErrorMessage = "Submitted tickets must have title")]
        public string RTicketTitle { get; set; }

        [Display(Name = "Ticket description:")]
        [Required(ErrorMessage = "Submitted tickets must include a brief description")]
        public string RTicketDescription { get; set; }

        [Display(Name = "Ticket priority:")]
        [Required(ErrorMessage = "Submitted tickets must be designated a priority")]
        public string RTicketPriority { get; set; }

        [Display(Name = "Date closed:")]
        public string RTicketDate { get; set; }

        [Display(Name = "Closed by:")]
        public string RUsersName { get; set; }

        public ResolvedTicket()
        {
        }
    }
}
