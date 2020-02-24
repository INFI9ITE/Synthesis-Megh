using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wwwroot.Areas.Admin.Models
{
    public class Store_header
    {
        public string ControllerName { get; set; }
        public int storeid { get; set; }
        public List<ddllist> Storenamelist { get; set; }

    }
}