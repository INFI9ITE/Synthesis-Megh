//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wwwrootBL.Entity
{
    using System;
    
    public partial class tbl_SalesActivitySummary_Excelread_exists_Result
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
        public string CeatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}