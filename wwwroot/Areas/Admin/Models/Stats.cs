using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wwwroot.Areas.Admin.Models
{
    public class Stats
    {
        public List<Stats_List> stats_Lists { get; set; }
        public List<SyncData> syncdata { get; set; }
    }

    public class Stats_List
    {
        public int Id { get; set; }
        public Nullable<int> Storeid { get; set; }
        public Nullable<int> Terminalid { get; set; }
        public Nullable<System.DateTime> TransactionStartTime { get; set; }
        public Nullable<System.DateTime> TransactionEndTime { get; set; }
        public Nullable<decimal> CustomerCount { get; set; }
        public Nullable<decimal> NetSalesWithTax { get; set; }
        public Nullable<decimal> TotalTaxCollected { get; set; }
        public Nullable<decimal> AverageSale { get; set; }
        public string FileName { get; set; }
        public string CeatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string shiftname { get; set; }
        public string cashiername { get; set; }
        public string StoreName { get; set; }
        public string TerminalName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
    }

    public class SyncData
    {
        public int id { get; set; }
        public Nullable<int> Storeid { get; set; }
        public Nullable<System.DateTime> Createdate { get; set; }
        public Nullable<int> issync { get; set; }
        public string filename { get; set; }
        public string ErrorMessage { get; set; }
        public string StoreName { get; set; }
    }
}