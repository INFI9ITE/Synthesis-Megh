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
    
    public partial class tbl_Invoice_Dashbord_GridData_StoreManager_Result
    {
        public int id { get; set; }
        public Nullable<int> Store_id { get; set; }
        public Nullable<int> Type_id { get; set; }
        public string Payment_type { get; set; }
        public Nullable<int> Vendor_id { get; set; }
        public Nullable<System.DateTime> Invoice_Date { get; set; }
        public string Invoice_Number { get; set; }
        public string Note { get; set; }
        public string AttachNote { get; set; }
        public string UploadInvoice { get; set; }
        public string ScanInvoice { get; set; }
        public Nullable<decimal> TotalAmtByDept { get; set; }
        public Nullable<int> IsStatus_id { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ApproveRejectBy { get; set; }
        public Nullable<System.DateTime> ApproveRejectDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string TxnID { get; set; }
        public Nullable<int> IsSync { get; set; }
        public Nullable<bool> NotificationColor { get; set; }
        public string Storename { get; set; }
        public string Typename { get; set; }
        public string vendorname { get; set; }
        public string Statusname { get; set; }
        public Nullable<decimal> deptamt { get; set; }
        public Nullable<int> deptid { get; set; }
    }
}
