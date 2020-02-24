using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wwwroot.Areas.Admin.Models
{
    public class Configuration
    {
        public List<Configurationlist> Configrationlist { get; set; }
        
    }

    public class DrpList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Configurationlist
    {
        public int? groupid { get; set; }
        public string Groupname { get; set; }
        public int? Deptid { get; set; }
        public int Storeid { get; set; }
        public int? typicalbalid { get; set; }
        public string memo { get; set; }
        public string typicalbalance { get; set; }
        public string Deptname { get; set; }
        public string tendername { get; set; }
        public int flag { get; set; }
        public List<DrpList> GroupList { get; set; }
    }
}