using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wwwroot.Models
{
    public class QBHistoryModel
    {
        public int QBID { get; set; }
        public int StoreID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Operation { get; set; }
        public string Para { get; set; }
    }
}