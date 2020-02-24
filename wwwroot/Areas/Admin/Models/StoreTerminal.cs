using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace wwwroot.Areas.Admin.Models
{
    public class Storeterminal_Create
    {
        public int id { get; set; }
        [Required(ErrorMessage = " ")] 
        public string Terminal { get; set; }
        [Required(ErrorMessage = " ")]
        public Nullable<int> Storeid { get; set; }
        
        public string Storename { get; set; }
        public List<ddllist> BindStoreidList { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }

    }
    public class Storeterminal_Select
    {
        public int id { get; set; }
    
        public string Terminal { get; set; }
        public Nullable<int> Storeid { get; set; }
     
        public string Storename { get; set; }
        public List<ddllist> BindStoreidList { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }

    }
    public class Storeterminal_Sdit
    {
        public int id { get; set; }
        [Required(ErrorMessage = " ")]
        public string Terminal { get; set; }
        [Required(ErrorMessage = " ")]
        public Nullable<int> Storeid { get; set; }

        public string Storename { get; set; }
        public List<ddllist> BindStoreidList { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }

    }
}