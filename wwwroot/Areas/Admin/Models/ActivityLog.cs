using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wwwroot.Areas.Admin.Models
{
    public class ActivityLog_Select
    {
        public int id { get; set; }
        public int userid { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public int Action { get; set; }
    }
}