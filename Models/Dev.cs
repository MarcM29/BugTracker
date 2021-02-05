using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Dev
    {
        public int DevId { get; set; }
        [Display(Name = "Assigned developer")]
        [Required(ErrorMessage = "Must include a developers name in order to assign the ticket")]
        public string DevName { get; set; }

        [Display(Name = "Assigned ticket ID")]
        public int AssignedTicketId { get; set; }
        public Dev()
        {

        }
    }
}
