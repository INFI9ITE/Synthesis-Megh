using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wwwroot.Areas.Admin.Models
{
    public class GeneralEntries
    {
        public int id { get; set; }
        public DateTime? CloseOutDate { get; set; }        
        public decimal? TotalAmount { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? validationflag { get; set; }
        public string DeptName { get; set; }
        public string GroupName { get; set; }
        public int? noofpos { get; set; }
        public int? Typeid { get; set; }
        public string Memo { get; set; }
        public int? ChildSalesId { get; set; }
        public string CloseOutDateformat { get; set; }
        public string Storename { get; set; }
    }
    public class GeneralEntriesDetail
    {
        public decimal? EditTotalAmount { get; set; }
       
        public List<GeneralEntries> GeneralEntries { get; set; }
    }
}