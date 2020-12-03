using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PersonalSiteMVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "* Name is required")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "* Name is required")]
        public string lastName { get; set; }

        public string Company { get; set; }

        public string Position { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required(ErrorMessage = "* Message is required")]
        [UIHint("MultilineText")]//change frm a singel line textbox to multiline
        public string Message { get; set; }

    }
}