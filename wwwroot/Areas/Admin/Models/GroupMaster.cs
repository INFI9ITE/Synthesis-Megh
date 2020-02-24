using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace wwwroot.Areas.Admin.Models
{
    public class GroupMaster_Create
    {
        public int id { get; set; }
        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^([a-zA-Z ]{3,})*$", ErrorMessage = "Minimum 3 letters,No Number or special character")]
        public string Name { get; set; }
     

    }
   
    public class GroupMaster_Select
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int? Exist { get; set; }
        public string QbAccount { get; set; }
        public int? QbAccountid { get; set; }
        public string typicalname { get; set; }
        public int? typicalid { get; set; }
        public string memo { get; set; }
       // public List<SelectListItem> typicalnamelist { get;set;}
        public List<ddllist> typicalnameliststore { get; set; }
    }
    
    public class GroupMaster_Edit
    {
        public int id { get; set; }
        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^([a-zA-Z ]{3,})*$", ErrorMessage = "Minimum 3 letters,No Number or special character")]
        public string Name { get; set; }
        
    }   
}