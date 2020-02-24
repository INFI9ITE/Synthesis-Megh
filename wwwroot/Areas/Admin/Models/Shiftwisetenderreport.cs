using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wwwroot.Areas.Admin.Models
{
    public class Report_Filter
    {
        [Required(ErrorMessage = " ")]
        public DateTime? Start_Date { get; set; }
        [Required(ErrorMessage = " ")]
        public DateTime? End_Date { get; set; }
    }
    public class Shiftwisetenderreport_Select
    {
        public List<ShiftWiseTotal> ShiftWiseTotal { get; set; }
        public List<TitleWiseTotal> TitleWiseTotal { get; set; }
        public List<ShiftList> shiftname { get; set; }
        public List<OtherDepositeList> OtherDepositeList { get; set; }
        public string Total { get; set; }
        public Nullable<decimal> CashTotal { get; set; }
        public Nullable<decimal> OtherTotal { get; set; }
        public int? PaidOutCount { get; set; }
        public List<string> PaidDistinctList { get; set; }
    }

    public class OtherDepositeList
    {
        public string Date { get; set; }
        public string Description { get; set; }
        public string PaymentMethod { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string options { get; set; }
        public string Vendor { get; set; }
        public string Other { get; set; }
    }

    public class ShiftWiseTotal
    {
        public Nullable<decimal> TotleByShift { get; set; }
        public Nullable<decimal> TotalShiftWiseTax { get; set; }
    }

    public class TitleWiseTotal
    {
        public string Title { get; set; }
    }

    public class ShiftList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}