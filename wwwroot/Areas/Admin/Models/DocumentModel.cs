using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wwwroot.Areas.Admin.Models
{
    public class DocumentModel
    {
        public string CategoryName { get; set; }
        public List<ddllist> BindCategoryList { get; set; }
    }
}