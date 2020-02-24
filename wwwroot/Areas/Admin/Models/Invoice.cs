using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace wwwroot.Areas.Admin.Models
{
    public class Invoice_Create
    {
        public int id { get; set; }
        //[Required(ErrorMessage = " ")]
        public int Store_id { get; set; }
        [Required(ErrorMessage = " ")]
        public int Type_id { get; set; }

        public int Type { get; set; }
        [Required(ErrorMessage = " ")]
        public string Payment_type { get; set; }
        [Required(ErrorMessage = " ")]
        public int Vendor_id { get; set; }
        [Required(ErrorMessage = " ")]
        
        public DateTime? Invoice_Date { get; set; }
        public string InvoiceDate { get; set; }
        [Required(ErrorMessage = " ")]
        public string Invoice_Number { get; set; }
        public string Note { get; set; }
        public string AttachNote { get; set; }
        public string UploadInvoice { get; set; }
        [Required(ErrorMessage = " ")]
        public string ScanInvoice { get; set; }
        public int IsStatus_id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public string Storename { get; set; }
        public List<ddllist> BindStoreList { get; set; }
        public List<ddllist> BindPaymentTypeList { get; set; }
        public List<ddllist> BindTypeList { get; set; }
        public string Vendorname { get; set; }
        public string Existcode { get; set; }
        public List<ddllist> BindVendorList { get; set; }
        public string Departmentname { get; set; }
      //  [Required(ErrorMessage = " ")]
        public int Dept_id { get; set; }
     
        public int Disc_Dept_id { get; set; }        
        public List<ddllist> BindDepartmentList { get; set; }
        public List<ddllist> Disc_BindDepartmentList { get; set; }
       
        public Nullable<decimal> Amt { get; set; }
        public decimal TotalAmtByDept { get; set; }
        public string vendoraddress { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> flagaddnew { get; set; }
        [Required(ErrorMessage = " ")]
        public int storeid { get; set; }
        public List<ddllist> AdminStorenamelist { get; set; }

        public string QuickInvoice { get; set; }
        public string QBtransfer { get; set; }
        public int Discounttype { get; set; }
        public List<ddllist> Discounttypelist { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Discountamount { get; set; }
        public List<tbl_Drp> drplst { get; set; }
    }
    public class Invoice_Select
    {
        public int id { get; set; }
        public int Store_id { get; set; }
        public int Type_id { get; set; }
        public string Payment_type { get; set; }
        public int Vendor_id { get; set; }
        public DateTime Invoice_Date { get; set; }
        public string Invoice_Number { get; set; }
        public string Note { get; set; }
        public string AttachNote { get; set; }
        public string UploadInvoice { get; set; }
        public string ScanInvoice { get; set; }
        public int IsStatus_id { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public string Storename { get; set; }
        public List<ddllist> BindStoreList { get; set; }
        public string Type { get; set; }
        public List<ddllist> BindTypeList { get; set; }
        public string Vendorname { get; set; }
        public List<ddllist> BindVendorList { get; set; }
        public string Departmentname { get; set; }
        public List<ddllist> BindDepartmentList { get; set; }
        public Nullable<decimal> Amt { get; set; }
        public decimal TotalAmtByDept { get; set; }
        public string address { get; set; }
        public string ApproveRejectBy { get; set; }
        public DateTime ApproveRejectDate { get; set; }
        public string Createdon_Date_string { get; set; }
        public string Invoice_Date_string { get; set; }
        public int deptid { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> Refinvoiceno { get; set; }
        public decimal Discountper { get; set; }
        public decimal discountamt { get; set; }
        public string RefInvoiceId { get; set; }
        public Nullable<decimal> Refdiscountamt { get; set; }

        public Nullable<int> deptname { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string payment { get; set; }
        public string Store_val { get; set; }
        public string searchdashbord { get; set; }
        public string RedairectFrom { get; set; }
        public Nullable<int> SearchVendorName { get; set; }
        public string AmtMaximum { get; set; }
        public string AmtMinimum { get; set; }
        public string Tooltip { get; set; }
     
    }
    public class Invoice_Edit
    {
        public int id { get; set; }
        //[Required(ErrorMessage = " ")]
        public int Store_id { get; set; }
        //[Required(ErrorMessage = " ")]
        public int Type_id { get; set; }

        public int Type { get; set; }
     //   [Required(ErrorMessage = " ")]
        public string Payment_type { get; set; }
        [Required(ErrorMessage = " ")]
        public int Vendor_id { get; set; }
        public string InvoiceDate { get; set; }
        [Required(ErrorMessage = " ")]
        public string Invoice_Date { get; set; }
        //public string Invoice_Datestr { get; set; }
        [Required(ErrorMessage = " ")]
        public string Invoice_Number { get; set; }
        public string Note { get; set; }
        public string AttachNote { get; set; }
        public string UploadInvoice { get; set; }
        //[Required(ErrorMessage = " ")]
        public string ScanInvoice { get; set; }
        public int IsStatus_id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public string Storename { get; set; }
        public List<ddllist> BindStoreList { get; set; }
        public List<ddllist> BindPaymentTypeList { get; set; }
        public List<ddllist> BindTypeList { get; set; }
        public string Vendorname { get; set; }
        public List<ddllist> BindVendorList { get; set; }
        public string Departmentname { get; set; }
        //[Required(ErrorMessage = " ")]
        public int Dept_id { get; set; }
        public List<ddllist> BindDepartmentList { get; set; }
        [Required(ErrorMessage = " ")]
        public Nullable<int> Disc_Dept_id { get; set; }
        public List<ddllist> Disc_BindDepartmentList { get; set; }
        public Nullable<decimal> Amt { get; set; }
        public decimal TotalAmtByDept { get; set; }
        public string vendoraddress { get; set; }

        public string ApproveRejectBy { get; set; }
        public DateTime ApproveRejectDate { get; set; }
        public List<tbl_Drp> drplst { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Nullable<int> IsSync { get; set; }
        //[Required(ErrorMessage = " ")]
        //public int storeid { get; set; }
        //public List<ddllist> AdminStorenamelist { get; set; }

        public Nullable<int> deptname { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string payment { get; set; }
        public string Store_val { get; set; }
        public string searchdashbord { get; set; }
        public string RedairectFrom { get; set; }
        public Nullable<int> SearchVendorName { get; set; }
        public string AmtMaximum { get; set; }
        public string AmtMinimum { get; set; }
        public string QBtransfer { get; set; }
        public string ExistID { get; set; }

        public Nullable<int> Discounttype { get; set; }
        public List<ddllist> Discounttypelist { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Discountamount { get; set; }
        public string RefInvoiceId { get; set; }
    }
    public class tbl_Drp
    {
        public Nullable<int> id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Deptid { get; set; }
        public List<ddllist> drpname { get; set; }
        public Nullable<decimal> Amt { get; set; }

    }
    public class Invoice_Notification
    {
        public int id { get; set; }
        public int Store_id { get; set; }
        public DateTime Invoice_Date { get; set; }
        public string Invoice_Number { get; set; }
        public string Storename { get; set; }
        public string username { get; set; }
        public Boolean NotificationColor { get; set; }

    }
    public class Invoice_Notification_Showall
    {
        public int id { get; set; }
        public int Store_id { get; set; }
        public DateTime Invoice_Date { get; set; }
        public string Invoice_Number { get; set; }
        public string Storename { get; set; }
        public string username { get; set; }

    }
    public class Invoice_Dashbord_Select
    {
        public int id { get; set; }
        public int Store_id { get; set; }
        public int Type_id { get; set; }
        public string Payment_type { get; set; }
        public int Vendor_id { get; set; }

        //[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Invoice_Date { get; set; }
        public string Invoice_Date_str { get; set; }
        public string Invoice_Number { get; set; }
        public string Note { get; set; }
        public string AttachNote { get; set; }
        public string UploadInvoice { get; set; }
        public string ScanInvoice { get; set; }
        public int IsStatus_id { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public string Storename { get; set; }
        public List<ddllist> BindStoreList { get; set; }
        public string Type { get; set; }
        public List<ddllist> BindTypeList { get; set; }
        public string Vendorname { get; set; }
        public List<ddllist> BindVendorList { get; set; }
        public string Departmentname { get; set; }
        public List<ddllist> BindDepartmentList { get; set; }
        public Nullable<decimal> Amt { get; set; }
        public decimal TotalAmtByDept { get; set; }
        public string address { get; set; }
        public string ApproveRejectBy { get; set; }
        public DateTime ApproveRejectDate { get; set; }
        public int deptid { get; set; }
        public string StrInvoice_Date { get; set; }

        public string Tooltip { get; set; }
    }
   

    public class Invoice_Select_ForPdf
    {
        public string Vendorname { get; set; }
        public string Type { get; set; }
        public string Invoice_Number { get; set; }
        public string CreatedOn { get; set; }
        public string Invoice_Date { get; set; }
        public decimal TotalAmtByDept { get; set; }
        public string Status { get; set; }
        public string Payment_type { get; set; }

    }

}