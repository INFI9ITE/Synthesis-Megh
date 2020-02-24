using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wwwroot.Models
{

    public class JobSalesActivitySummary
    {

        #region Basic Detail
        public int Id { get; set; }
        public Nullable<int> Storeid { get; set; }
        public string Storename { get; set; }
        public Nullable<int> Terminalid { get; set; }
        public string Terminal { get; set; }
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
        #endregion

        #region Department
        public int DeptNetSalesId { get; set; }
        public Nullable<int> DeptActivitySalesSummuryId { get; set; }
        public string DeptNetSalesTitle { get; set; }
        public Nullable<decimal> DeptAmount { get; set; }
        public string DeptNetSalesCeatedBy { get; set; }
        public Nullable<System.DateTime> DeptCreatedDate { get; set; }
        public string DeptNetSalesUpdatedBy { get; set; }
        public Nullable<System.DateTime> DeptNetSalesUpdatedDate { get; set; }
        public Nullable<bool> DeptNetSalesIdIsActive { get; set; }
        #endregion

        #region Tender
        public int TendersInDrawerId { get; set; }
        public Nullable<int> TendersActivitySalesSummuryId { get; set; }
        public string TendersTitle { get; set; }
        public Nullable<decimal> TendersAmount { get; set; }
        public string TendersCeatedBy { get; set; }
        public Nullable<System.DateTime> TendersCreatedDate { get; set; }
        public string TendersUpdatedBy { get; set; }
        public Nullable<System.DateTime> TendersUpdatedDate { get; set; }
        public Nullable<bool> TendersIsActive { get; set; }
        #endregion

        # region PaidOut
        public int PaidOutOutId { get; set; }
        public Nullable<int> PaidOutActivitySalesSummuryId { get; set; }
        public string PaidOutTitle { get; set; }
        public Nullable<decimal> PaidOutAmount { get; set; }
        public string PaidOutCeatedBy { get; set; }
        public Nullable<System.DateTime> PaidOutCreatedDate { get; set; }
        public string PaidOutUpdatedBy { get; set; }
        public Nullable<System.DateTime> PaidOutUpdatedDate { get; set; }
        public Nullable<bool> PaidOutIsActive { get; set; }
        #endregion
    }
}