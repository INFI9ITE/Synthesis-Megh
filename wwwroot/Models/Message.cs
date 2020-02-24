using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace wwwroot.Models
{
    public class Message_Create
    {
        public Guid PvId { get; set; }
        [Required(ErrorMessage = " ")]
        public string Message { get; set; }
        public string PostedBy { get; set; }
        public DateTime PostedDate { get; set; }
    }

    public class Message_Select
    {
        public Guid PvId { get; set; }
        public string Message { get; set; }
        public string PostedBy { get; set; }
        public DateTime PostedDate { get; set; }
    }

    public class Message_Mail
    {
        public string Message { get; set; }
        public string PostedBy { get; set; }
        public string PostedTo { get; set; }
        public string Subject { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string FormId { get; set; }
        public DateTime InstallationDate { get; set; }

    }
}