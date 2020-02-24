using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wwwroot.Areas.Admin.Models
{
    public class Shiftwisereport_Select
    {
        public List<ddlList> TerminalList { get; set; }
        public List<ddlShiftList> ShiftList { get; set; }
        public List<BindTerminaldata> TerminalData { get; set; }
        public List<BindShiftdata> ShiftData { get; set; }
        public List<Bindshiftwisetenderlist> ShiftWisetenderData { get; set; }
        public List<Bindotherdepositdata> Otherdepositlist { get; set; }
        public decimal? totalsalesamount { get; set; }
        public int? Coustomercount { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string terminal_id { get; set; }
        public string Shift_id { get; set; }
        //[Required(ErrorMessage = "Amount for AMEX is Required ")]
        public Nullable<decimal> AMEX { get; set; }
        //[Required(ErrorMessage = "Amount for Discover is Required ")]
        public Nullable<decimal> Discover { get; set; }
        //[Required(ErrorMessage = "Amount for Master is Required ")]
        public Nullable<decimal> Master { get; set; }
        //[Required(ErrorMessage = "Amount for Visa is Required ")]
        public Nullable<decimal> Visa { get; set; }   
        public string DepositeCount { get; set; }
        public int? Optionid { get; set; }
        public List<ddllist> SelectOptionList { get; set; }
        public int? Payid { get; set; }
        public List<ddllist> payMehoed { get; set; }
        public int? vendorid { get; set; }
        public List<ddllist> SelectVendorList { get; set; }
    }

    public class ddlList
    {
        public int TerminalId { get; set; }
        public string TerminalName { get; set; }
        public decimal? SalesAmount { get; set; }
        public decimal? TotalTaxAmount { get; set; }
        public int? CustomerCount { get; set; }
        public List<ddlShiftList> ShiftList { get; set; }
        
    }
    public class Bindotherdepositdata
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string payment { get; set; }
        public decimal? amount { get; set; }
        public DateTime? date { get; set; }
        public int? storeid { get; set; }
        public string options { get; set; }
        public string Vendor { get; set; }
        public string Other { get; set; }
    }
    public class BindTerminaldata
    {
        public int TerminalId { get; set; }
        public string TerminalName { get; set; }
    }
    public class BindShiftdata
    {
        public decimal? SalesAmount { get; set; }
        public int? terminalid { get; set; }
        public int? CustomerCount { get; set; }
        public List<ddlShiftList> ShiftdataList { get; set; }
    }
    public class Bindshiftwisetenderlist
    {
        public int Id { get; set; }
        public string Terminalname { get; set; }
        public string Terminalid { get; set; }
        public string ShiftName { get; set; }
        public decimal? SalesAmount { get; set; }
        public decimal? TotalTaxAmount { get; set; }
        public decimal? CustomerCount { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public List<ShiftNameList> ShiftNameList { get; set; }
        public List<TenderList> TenderList { get; set; }
        public List<PaidoutList> paidoutLists { get; set; }
        //[Required(ErrorMessage = "Cashier Name is Required ")]
        public string CashierName { get; set; }
        public decimal? Paidoutamount { get; set; }
    }
    public class ddlShiftList
    {
        public int Id { get; set; }
        public string ShiftName { get; set; }
        public decimal? SalesAmount { get; set; }
        public decimal? TotalTaxAmount { get; set; }
        public decimal? CustomerCount { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public List<ShiftNameList> ShiftNameList { get; set; }
        public List<TenderList> TenderList { get; set; }
        public string CashierName { get; set; }
    }

    public class ShiftNameList
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public class TenderList
    {
        public string Name { get; set; }
        [Required(ErrorMessage = "Amount is Required ")]
        public decimal? Amount { get; set; }
        public int? Id { get; set; }
        public string ListName { get; set; }
    }

    public class PaidoutList
    {
        public string Title { get; set; }
        [Required(ErrorMessage = "Amount is Required ")]
        public decimal? Amount { get; set; }
        public int? Id { get; set; }
        public string ListName { get; set; }
    }

}