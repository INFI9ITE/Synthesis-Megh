using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using wwwroot.Areas.Admin.Models;
using wwwroot.Class;
//using wwwroot.Hubs;
using wwwrootBL.Entity;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
using System.Configuration;

namespace wwwroot.Areas.Admin.Controllers
{
    [InitializeSimpleMembershipAttribute]
    [Authorize(Roles = "Back Office Manager,Data Approver,Administrator,Owner")]
    public class InvoiceController : Controller
    {
        // GET: Admin/Invoice
        protected static string StatusMessage = "";
        protected static string ExistCode = "";
        protected static string ActivityLogMessage = "";
        private const int FirstPageIndex = 1;
        protected static int TotalDataCount;
        protected static Array Arr;
        protected static bool IsArray;
        protected static IEnumerable BindData;
        protected static bool IsEdit = false;
        protected static int Quickvalue;
        int userid = Convert.ToInt32(WebSecurity.CurrentUserId);
        string username = WebSecurity.CurrentUserName;
        WestZoneEntities db = new WestZoneEntities();
        public ActionResult Index()
        {
            Invoice_Create Invoice_Create = new Invoice_Create();
            Invoice_Create.Invoice_Date = DateTime.Today.Date;
            if (StatusMessage == "Success1" || StatusMessage == "Success")
            {
                ViewBag.StatusMessage = StatusMessage;
                StatusMessage = "";
            }
            else
            {
                ViewBag.StatusMessage = "";
            }
            return View();
        }
        public ActionResult Grid(int IsBindData = 1, int currentPageIndex = 1, string orderby = "id", int IsAsc = 0, int PageSize = 10, int SearchRecords = 1, string Alpha = "", string SearchTitle = "", int Vendorname = 0, string startdate = "", string enddate = "")
        {
            #region MyRegion_Array
            try
            {

                if (IsArray == true)
                {
                    foreach (string a1 in Arr)
                    {
                        if (a1.Split(':')[0].ToString() == "IsBindData")
                        {
                            IsBindData = Convert.ToInt32(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "currentPageIndex")
                        {
                            currentPageIndex = Convert.ToInt32(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "orderby")
                        {
                            orderby = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "IsAsc")
                        {
                            IsAsc = Convert.ToInt32(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "PageSize")
                        {
                            PageSize = Convert.ToInt32(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "SearchRecords")
                        {
                            SearchRecords = Convert.ToInt32(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "Alpha")
                        {
                            Alpha = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "SearchTitle")
                        {
                            SearchTitle = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "Vendorname")
                        {
                            Vendorname = Convert.ToInt32(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "startdate")
                        {
                            startdate = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "enddate")
                        {
                            enddate = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                    }
                }
            }
            catch { }

            IsArray = false;
            Arr = new string[]
            {  "IsBindData:" + IsBindData
                ,"currentPageIndex:" + currentPageIndex
                ,"orderby:" + orderby
                ,"IsAsc:" + IsAsc
                ,"PageSize:" + PageSize
                ,"SearchRecords:" + SearchRecords
                ,"Alpha:" + Alpha
                ,"SearchTitle:" + SearchTitle
               ,"Vendorname:" + Vendorname
               ,"startdate:"+startdate
                ,"enddate:"+enddate
            };
            #endregion

            #region MyRegion_BindData
            int startIndex = ((currentPageIndex - 1) * PageSize) + 1;
            int endIndex = startIndex + PageSize - 1;

            if (IsBindData == 1 || IsEdit == true)
            {
                BindData = GetData(SearchRecords, SearchTitle, Vendorname, startdate, enddate).OfType<Invoice_Select>().ToList();
                TotalDataCount = BindData.OfType<Invoice_Select>().ToList().Count();

            }


            if (TotalDataCount == 0)
            {
                StatusMessage = "NoItem";
            }

            ViewBag.IsBindData = IsBindData;
            ViewBag.CurrentPageIndex = currentPageIndex;
            ViewBag.LastPageIndex = this.getLastPageIndex(PageSize);
            ViewBag.OrderByVal = orderby;
            ViewBag.IsAscVal = IsAsc;
            ViewBag.PageSize = PageSize;
            ViewBag.Alpha = Alpha;
            ViewBag.SearchRecords = SearchRecords;
            ViewBag.SearchTitle = SearchTitle;
            ViewBag.StatusMessage = StatusMessage;
            ViewBag.startindex = startIndex;
            ViewBag.Vendorname = Vendorname;
            ViewBag.startdate = startdate;
            ViewBag.enddate = enddate;

            if (TotalDataCount < endIndex)
            {
                ViewBag.endIndex = TotalDataCount;
            }
            else
            {
                ViewBag.endIndex = endIndex;
            }
            ViewBag.TotalDataCount = TotalDataCount;
            var ColumnName = typeof(Invoice_Select).GetProperties().Where(p => p.Name == orderby).FirstOrDefault();

            IEnumerable Data = null;
            //Response.Write(ColumnName);
            //Response.End();
            if (IsAsc == 1)
            {
                ViewBag.AscVal = 0;
                Data = BindData.OfType<Invoice_Select>().ToList().OrderBy(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            else
            {

                ViewBag.AscVal = 1;

                Data = BindData.OfType<Invoice_Select>().ToList().OrderByDescending(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            StatusMessage = "";
            //// ViewBag.Pagetext = "Showing " + iStartsRecods + " to " + iEndRecord + " of " + iTotalRecords + " entries";
            //List<ddllist> LstDatadept = new List<ddllist>();
            //LstDatadept = FillDrpLstDepartment();
            //ViewBag.DataDept = LstDatadept;

            List<ddllist> Lstvendor = new List<ddllist>();
            Lstvendor = FillDrpLstVendor();
            ViewBag.Datavendor = Lstvendor;
            return View(Data);
            #endregion
        }

        private int getLastPageIndex(int PageSize)
        {
            int lastPageIndex = Convert.ToInt32(TotalDataCount) / PageSize;
            if (TotalDataCount % PageSize > 0)
                lastPageIndex += 1;
            return lastPageIndex;
        }
        private IEnumerable GetData(int SearchRecords = 0, string SearchTitle = "", int Vendorname = 0, string startdate = "", string enddate = "")
        {
            DateTime? start_date = null;
            DateTime? end_date = null;
            try
            {
                start_date = Convert.ToDateTime(startdate);
            }
            catch { }

            try
            {
                end_date = Convert.ToDateTime(enddate);
            }
            catch { }
            IEnumerable RtnData = null;
            RtnData = null;

            return RtnData;
        }


        #region Fill DropdownList pamenttype
        public List<ddllist> FillDrpLstPamentype()
        {
            List<ddllist> LstPamentype = new List<ddllist>();
            LstPamentype = (from a in db.tbl_Pamentype
                            orderby a.Name ascending
                            select new ddllist
                            {
                                Value = a.Name.ToString(),
                                Text = a.Name
                            }).ToList();

            return LstPamentype;
        }
        #endregion

        #region Fill DropdownList Store
        public List<ddllist> FillDrpLstStore()
        {
            List<ddllist> LstStore = new List<ddllist>();
            LstStore = (from a in db.tbl_Store
                        orderby a.Name ascending
                        select new ddllist
                        {
                            Value = a.Id.ToString(),
                            Text = a.Name
                        }).ToList();

            return LstStore;
        }
        #endregion

        #region Fill DropdownList Type
        public List<ddllist> FillDrpLstType()
        {
            List<ddllist> LstType = new List<ddllist>();
            LstType = (from a in db.tbl_Type
                       orderby a.Name ascending
                       select new ddllist
                       {
                           Value = a.id.ToString(),
                           Text = a.Name
                       }).ToList();

            return LstType;
        }
        #endregion

        #region Fill DropdownList Vendor
        public List<ddllist> FillDrpLstVendor()
        {
            List<ddllist> LstVendor = new List<ddllist>();

            if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
            {
                string storeid = Session["storeid"].ToString();
                LstVendor = (from a in db.tbl_Vendor
                             where a.StoreId.ToString() == storeid && a.IsActive == true
                             orderby a.Name ascending
                             select new ddllist
                             {
                                 Value = a.id.ToString(),
                                 Text = a.Name
                             }).ToList();
            }
            else
            {
                RedirectToAction("index", "login");
            }



            return LstVendor;
        }
        #endregion

        #region Fill DropdownList Department
        public List<ddllist> FillDrpLstDepartment()
        {
            List<ddllist> LstDepartment = new List<ddllist>();
            //Session["storeid"].ToString()
            if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
            {
                string storeid = Session["storeid"].ToString();
                LstDepartment = (from a in db.tbl_Department
                                 where a.StoreID.ToString() == storeid
                                 orderby a.Name ascending
                                 select new ddllist
                                 {
                                     Value = a.id.ToString(),
                                     Text = a.Name
                                 }).ToList();
            }
            else
            {
                RedirectToAction("index", "login");
            }
            return LstDepartment;
        }
        #endregion

        //vendor drp
        public JsonResult BindVendorlist(int Store_idval = 0)
        {
            //GlobalStore.GlobalStore_id = Store_idval.ToString();
            var LstVendor = (from a in db.tbl_Vendor
                             where a.StoreId == Store_idval && a.IsActive == true
                             orderby a.Name ascending
                             select new ddllist
                             {
                                 Value = a.id.ToString(),
                                 Text = a.Name
                             }).ToList();
            return Json(new SelectList(LstVendor, "Value", "Text"), JsonRequestBehavior.AllowGet);
        }
        //end
        public JsonResult BindDepartmentlist(int Store_idval = 0)
        {
            //GlobalStore.GlobalStore_id = Store_idval.ToString();
            var LstDepartment = (from a in db.tbl_Department
                                 where a.StoreID == Store_idval
                                 orderby a.Name ascending
                                 select new ddllist
                                 {
                                     Value = a.id.ToString(),
                                     Text = a.Name
                                 }).ToList();
            return Json(new SelectList(LstDepartment, "Value", "Text"), JsonRequestBehavior.AllowGet);
        }
        //public JsonResult SetGlobalStoreidByStoreSelection(int id = 0)
        //{  Invoice_Create User_data = new Invoice_Create();
        //    string data = "false";

        //    GlobalStore.GlobalStore_id = id.ToString();
        //    var alldata = Convert.ToInt32(GlobalStore.GlobalStore_id);
        //    User_data.BindVendorList = FillDrpLstVendor();
        //    User_data.BindDepartmentList = FillDrpLstDepartment();
        //    if (alldata > 0)
        //    {
        //        data = "false";

        //    }
        //    else
        //    {
        //        data = "true";
        //    }

        //    return Json(User_data);
        //}

        [HttpGet]
        public ActionResult Create(int ID = 0/*, int quick = 0*/)
        {
            ViewBag.CurrentDate = DateTime.Today.Date;
            if (StatusMessage == "Success1" || StatusMessage == "Success" || StatusMessage == "Exists")
            {
                ViewBag.StatusMessage = StatusMessage;
                StatusMessage = "";
            }
            else
            {
                ViewBag.StatusMessage = "";
            }
            if (!string.IsNullOrEmpty(ExistCode))
            {
                ViewBag.ExistCode = ExistCode;
            }

            StatusMessage = "";
            IsArray = true;
            //Quickvalue = quick;
            Invoice_Create User_data = new Invoice_Create();
            if (TempData["PostedData"] != null)
            {
                User_data = (Invoice_Create)TempData["PostedData"];
            }
            if (User_data.Discounttype > 1)
            {
            }
            else
            {
                User_data.Discounttype = 1;
            }
            User_data.AdminStorenamelist = (from dataUser in db.tbl_user_Selectstore()

                                            select new ddllist
                                            {
                                                Value = dataUser.Id.ToString(),
                                                Text = dataUser.Name
                                            }).ToList();
            User_data.Discounttypelist = (from a in db.tbl_discounttype
                                          select new ddllist
                                          {
                                              Value = a.id.ToString(),
                                              Text = a.Name,
                                              selected_value = a.Name.Contains("NA") ? true : false
                                          }).ToList();
            //User_data.Discounttype = 1;
            if (Convert.ToString(Session["storeid"]) != "0")
            {
                User_data.BindDepartmentList = FillDrpLstDepartment();
                User_data.Disc_BindDepartmentList = FillDrpLstDepartment();
                if (User_data.storeid != null && User_data.storeid != 0)
                    User_data.storeid = Convert.ToInt32(Session["storeid"]);
                string storeid = Session["storeid"].ToString();
                User_data.BindVendorList = (from a in db.tbl_Vendor
                                            where a.StoreId.ToString() == storeid && a.IsActive == true
                                            orderby a.Name ascending
                                            select new ddllist
                                            {
                                                Value = a.id.ToString(),
                                                Text = a.Name
                                            }).ToList();

                User_data.BindDepartmentList = (from a in db.tbl_Department
                                                where a.StoreID.ToString() == storeid
                                                orderby a.Name ascending
                                                select new ddllist
                                                {
                                                    Value = a.id.ToString(),
                                                    Text = a.Name
                                                }).ToList();
            }
            else
            {
                User_data.BindVendorList = FillDrpLstVendor();
                if (User_data.BindVendorList.Count == 0)
                {
                    string STOREVAL = Convert.ToString(User_data.Store_id);
                    User_data.BindVendorList = (from a in db.tbl_Vendor
                                                where a.StoreId.ToString() == STOREVAL && a.IsActive == true
                                                orderby a.Name ascending
                                                select new ddllist
                                                {
                                                    Value = a.id.ToString(),
                                                    Text = a.Name
                                                }).ToList();
                    User_data.BindDepartmentList = (from a in db.tbl_Department
                                                    where a.StoreID.ToString() == STOREVAL
                                                    orderby a.Name ascending
                                                    select new ddllist
                                                    {
                                                        Value = a.id.ToString(),
                                                        Text = a.Name
                                                    }).ToList();
                    User_data.Disc_BindDepartmentList = (from a in db.tbl_Department
                                                         where a.StoreID.ToString() == STOREVAL
                                                         orderby a.Name ascending
                                                         select new ddllist
                                                         {
                                                             Value = a.id.ToString(),
                                                             Text = a.Name
                                                         }).ToList();
                }
            }

            User_data.BindPaymentTypeList = FillDrpLstPamentype();
            User_data.BindTypeList = FillDrpLstType();
            //User_data.BindVendorList = FillDrpLstVendor();
            //if(User_data.BindVendorList==null)
            //{
            //    string storeid = User_data.storeid.ToString();
            //    User_data.BindVendorList=(from a in db.tbl_Vendor
            //     where a.StoreId.ToString() == storeid && a.IsActive == true
            //     orderby a.Name ascending
            //     select new ddllist
            //     {
            //         Value = a.id.ToString(),
            //         Text = a.Name
            //     }).ToList();
            //}


            //List<ddllist> lst = new List<ddllist>();
            //ddllist obj = new ddllist();
            //obj.Text = "All Store";
            //obj.Value = "0";
            //lst.Add(obj);
            //User_data.AdminStorenamelist = lst;
            //User_data.AdminStorenamelist.AddRange((from dataUser in db.tbl_user_Selectstore()
            //                                        select new ddllist
            //                                        {
            //                                            Value = dataUser.Id.ToString(),
            //                                            Text = dataUser.Name

            //                                        }).ToList());

            return View(User_data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Invoice_Create PostedData, HttpPostedFileBase ScanInvoice, string[] Dept_id, string[] Amt, string addnew = "", string btnsubmit = "")
        {
            int Storeidval = 0;
            if (PostedData.Discounttype == 1)
            {
                ModelState.Remove("Disc_Dept_id");
            }
            else
            {

            }
            if (ModelState.IsValid)
            {

                if (PostedData.InvoiceDate != null)
                {
                    PostedData.Invoice_Date = Convert.ToDateTime(PostedData.InvoiceDate);
                }
                Invoice_Create Data_Insert = new Invoice_Create();
                if (Roles.IsUserInRole("Administrator"))
                {
                    Storeidval = PostedData.storeid;
                    // GlobalStore.GlobalStore_id = Storeidval.ToString();
                }
                else
                {
                    if (!string.IsNullOrEmpty(Session["storeid"].ToString()))
                    {
                        Storeidval = Convert.ToInt32(Session["storeid"].ToString());

                    }
                    else
                    {
                        RedirectToAction("index", "login");
                    }
                }
                //var exists = db.tbl_Invoice_exists_InNo(PostedData.Invoice_Number, PostedData.TotalAmtByDept, PostedData.Invoice_Date).Select(x => x.Value).FirstOrDefault();
                var exists = db.tbl_Invoice_exists_InNo_New(PostedData.Invoice_Number, PostedData.Invoice_Date, Storeidval, PostedData.Type, PostedData.Vendor_id).Select(x => x.Value).FirstOrDefault();
                if (exists == 0)
                {
                    try
                    {
                        #region AttachNote

                        var Sacn_Title = "";
                        if (ScanInvoice != null)
                        {

                            if (ScanInvoice.ContentLength > 0)
                            {

                                var allowedExtensions = new[] { ".pdf" };
                                var extension = Path.GetExtension(ScanInvoice.FileName);
                                var Ext = Convert.ToString(extension).ToLower();
                                if (!allowedExtensions.Contains(Ext))
                                {
                                    ViewBag.StatusMessage = "InvalidImage";
                                    return View(PostedData);
                                }
                                else
                                {
                                    if (ScanInvoice.ContentLength > 20971520)
                                    {
                                        ViewBag.StatusMessage = "InvalidPDFSize";
                                        return View(PostedData);
                                    }
                                    else
                                    {
                                        Sacn_Title = AdminSiteConfiguration.GetRandomNo() + Path.GetFileName(ScanInvoice.FileName);
                                        Sacn_Title = AdminSiteConfiguration.RemoveSpecialCharacter(Sacn_Title);

                                        var path1 = Request.PhysicalApplicationPath + "userfiles\\scanimage" + "\\" + Sacn_Title;
                                        ScanInvoice.SaveAs(path1);

                                        //#region cloudURL
                                        ////try
                                        ////{
                                        //GC.Collect();
                                        //string username = AdminSiteConfiguration.ClaudUsername();
                                        //string api_key = AdminSiteConfiguration.ClaudKey();
                                        //string chosenContainer = AdminSiteConfiguration.ClaudContainer();

                                        //var cloudIdentity = new CloudIdentity() { APIKey = api_key, Username = username };
                                        //var cloudFilesProvider = new CloudFilesProvider(cloudIdentity);
                                        //string uriPath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\scanimage\\" + Sacn_Title;

                                        //using (System.IO.FileStream stream = System.IO.File.OpenRead(uriPath))
                                        //{

                                        //    cloudFilesProvider.CreateObject(chosenContainer, stream, "scanimage/" + Sacn_Title);
                                        //    stream.Flush();
                                        //    stream.Close();
                                        //}
                                        ////}
                                        ////catch (Exception ex)
                                        ////{
                                        ////    throw ex;
                                        ////}
                                        ////Clouduploader.UploadDocument("scanimage", Sacn_Title, "wsmanagementsys", Request.PhysicalApplicationPath + "userfiles\\scanimage\\" + Sacn_Title);

                                        //#endregion
                                        //string foldername = Path.Combine("scanimage");
                                        //AdminSiteConfiguration.DeleteImage(Sacn_Title, foldername);
                                    }
                                }
                            }

                        }
                        #endregion
                        #region Insert
                        int uid = WebSecurity.CurrentUserId;


                        string success = "";
                        //var storeid = db.tbl_Store.Where(x => x.Name == PostedData.Storename).Select(x => x.Id).FirstOrDefault();

                        //Response.Write(Storeidval);
                        //Response.End();
                        string userfullname = db.tbl_user.Where(x => x.Reg_userid == uid).Select(x => x.Name).FirstOrDefault();
                        bool qbtransfer = false;
                        if (PostedData.QBtransfer == "1")
                        {
                            qbtransfer = true;
                        }
                        else
                        {
                            qbtransfer = false;
                        }
                        if (PostedData.QuickInvoice == "1" && (Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Data Approver")))
                        {
                            success = db.tbl_Invoice_Insert_StoreManager(Storeidval, PostedData.Type, PostedData.Payment_type, PostedData.Vendor_id, Convert.ToDateTime(PostedData.Invoice_Date), PostedData.Invoice_Number, PostedData.Note, "AttachNote_Title", Sacn_Title, Sacn_Title, 2, uid.ToString(), PostedData.TotalAmtByDept, userfullname, qbtransfer).Select(x => x.ToString()).FirstOrDefault().ToString();
                        }
                        else
                        {
                            success = db.tbl_Invoice_Insert(Storeidval, PostedData.Type, PostedData.Payment_type, PostedData.Vendor_id, Convert.ToDateTime(PostedData.Invoice_Date), PostedData.Invoice_Number, PostedData.Note, "AttachNote_Title", Sacn_Title, Sacn_Title, 1, uid.ToString(), PostedData.TotalAmtByDept, qbtransfer).Select(x => x.ToString()).FirstOrDefault().ToString();
                        }
                        try
                        {
                            if (Convert.ToInt32(success) > 0)
                            {
                                int j = 0;
                                int dept1 = 0;
                                string amt1 = "";

                                if (Dept_id != null)
                                {
                                    foreach (var val_id in Dept_id)
                                    {
                                        tbl_Invoice_Department dataDept = new tbl_Invoice_Department();

                                        dept1 = Convert.ToInt32(val_id);
                                        amt1 = Amt[j];

                                        var successDept = db.tbl_Invoice_Department_Insert(Convert.ToInt32(success), dept1, Convert.ToDecimal(amt1), username, PostedData.Invoice_Date, PostedData.Invoice_Number, PostedData.TotalAmtByDept);
                                        j++;
                                    }
                                }
                                //activity log
                                string fullname = db.tbl_user.Where(x => x.Reg_userid == uid).Select(x => x.Name).FirstOrDefault();
                                if (PostedData.QuickInvoice == "1")
                                {
                                    ActivityLogMessage = "Quick Invoice Number " + "<a href='/Admin/InvoiceReport/Detail/" + success + "'>" + PostedData.Invoice_Number + "</a> created by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.ToString());
                                }
                                else
                                {
                                    ActivityLogMessage = "Invoice Number " + "<a href='/Admin/InvoiceReport/Detail/" + success + "'>" + PostedData.Invoice_Number + "</a> created by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.ToString());
                                }
                                //ActivityLogMessage = "Invoice Number " + PostedData.Invoice_Number + " created by " + fullname + " on " + DateTime.Today;
                                var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, username, 1);
                                //UserHub.BroadcastData();
                                IsArray = false;
                                if (PostedData.QuickInvoice == "1")
                                {
                                    StatusMessage = "Success1";
                                    ViewBag.StatusMessage = StatusMessage;
                                }
                                else
                                {
                                    StatusMessage = "Success";
                                    ViewBag.StatusMessage = StatusMessage;
                                }
                                if (PostedData.Discounttype != 1)
                                {
                                    int invoiceid = Convert.ToInt32(success);
                                    WestZoneEntities db1 = new WestZoneEntities();
                                    db1.tbl_invoice_updatediscountdata(invoiceid, PostedData.Discounttype, PostedData.Discount, PostedData.Discountamount);
                                    string sucess1 = "";
                                    #region AttachNote

                                    var DSacn_Title = "";
                                    if (ScanInvoice != null)
                                    {

                                        if (ScanInvoice.ContentLength > 0)
                                        {

                                            var allowedExtensions = new[] { ".pdf" };
                                            var extension = Path.GetExtension(ScanInvoice.FileName);
                                            var Ext = Convert.ToString(extension).ToLower();
                                            if (!allowedExtensions.Contains(Ext))
                                            //if (!allowedExtensions.Contains(extension))
                                            {
                                                ViewBag.StatusMessage = "InvalidImage";
                                                return View("Index");
                                            }
                                            else
                                            {

                                                DSacn_Title = AdminSiteConfiguration.GetRandomNo() + Path.GetFileName(ScanInvoice.FileName);
                                                DSacn_Title = AdminSiteConfiguration.RemoveSpecialCharacter(DSacn_Title);

                                                var path1 = Request.PhysicalApplicationPath + "userfiles\\scanimage" + "\\" + DSacn_Title;
                                                ScanInvoice.SaveAs(path1);

                                                //#region cloudURL
                                                //try
                                                //{
                                                //    GC.Collect();
                                                //    string username = AdminSiteConfiguration.ClaudUsername();
                                                //    string api_key = AdminSiteConfiguration.ClaudKey();
                                                //    string chosenContainer = AdminSiteConfiguration.ClaudContainer();

                                                //    var cloudIdentity = new CloudIdentity() { APIKey = api_key, Username = username };
                                                //    var cloudFilesProvider = new CloudFilesProvider(cloudIdentity);
                                                //    string uriPath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\scanimage\\" + DSacn_Title;

                                                //    using (System.IO.FileStream stream = System.IO.File.OpenRead(uriPath))
                                                //    {

                                                //        cloudFilesProvider.CreateObject(chosenContainer, stream, "scanimage/" + DSacn_Title);
                                                //        stream.Flush();
                                                //        stream.Close();
                                                //    }
                                                //}
                                                //catch (Exception ex)
                                                //{
                                                //    throw ex;
                                                //}
                                                ////Clouduploader.UploadDocument("scanimage", Sacn_Title, "wsmanagementsys", Request.PhysicalApplicationPath + "userfiles\\scanimage\\" + Sacn_Title);

                                                //#endregion
                                                //string foldername = Path.Combine("scanimage");
                                                //AdminSiteConfiguration.DeleteImage(DSacn_Title, foldername);

                                            }
                                        }
                                    }
                                    #endregion
                                    string CRdiscount = "";
                                    string Credit_Invoiceno = PostedData.Invoice_Number + "_cr";
                                    if (PostedData.Discounttype == 2)
                                    {
                                        CRdiscount = PostedData.Discount.ToString();
                                        Credit_Invoiceno = Credit_Invoiceno + CRdiscount + "%";
                                    }
                                    else
                                    {
                                        //decimal percentageval = Convert.ToDecimal((PostedData.Discountamount * 100) / PostedData.TotalAmtByDept);
                                        //CRdiscount = Convert.ToString(Math.Round(percentageval, 2));
                                        //// Credit_Invoiceno = Credit_Invoiceno + CRdiscount + "%";
                                        //Credit_Invoiceno = Credit_Invoiceno + Convert.ToString(PostedData.Discountamount);
                                    }

                                    if (PostedData.QuickInvoice == "1" && (Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Data Approver")))
                                    {
                                        sucess1 = db.tbl_Invoice_Insert_StoreManager_discount(Storeidval, 2, "Check/ACH", PostedData.Vendor_id, Convert.ToDateTime(PostedData.Invoice_Date), Credit_Invoiceno, PostedData.Note, "AttachNote_Title", DSacn_Title, DSacn_Title, 2, uid.ToString(), PostedData.Discountamount, userfullname, qbtransfer, 1, 0, 0, invoiceid).Select(x => x.ToString()).FirstOrDefault().ToString();
                                    }
                                    else
                                    {
                                        sucess1 = db.tbl_Invoice_Insert_discount(Storeidval, 2, "Check/ACH", PostedData.Vendor_id, Convert.ToDateTime(PostedData.Invoice_Date), Credit_Invoiceno, PostedData.Note, "AttachNote_Title", DSacn_Title, DSacn_Title, 1, uid.ToString(), PostedData.Discountamount, qbtransfer, 1, 0, 0, invoiceid).Select(x => x.ToString()).FirstOrDefault().ToString();
                                    }
                                    if (!string.IsNullOrEmpty(sucess1))
                                    {
                                        var successDept = db.tbl_Invoice_Department_Insert(Convert.ToInt32(sucess1), PostedData.Disc_Dept_id, Convert.ToDecimal(PostedData.Discountamount), username, PostedData.Invoice_Date, PostedData.Invoice_Number, PostedData.TotalAmtByDept);
                                        //activity log
                                        string fullname1 = db.tbl_user.Where(x => x.Reg_userid == uid).Select(x => x.Name).FirstOrDefault();
                                        if (PostedData.QuickInvoice == "1")
                                        {

                                            ActivityLogMessage = "Quick Invoice Number " + "<a href='/Admin/InvoiceReport/Detail/" + success + "'>" + Credit_Invoiceno + "</a> created by " + fullname1 + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.ToString());
                                        }
                                        else
                                        {
                                            ActivityLogMessage = "Invoice Number " + "<a href='/Admin/InvoiceReport/Detail/" + success + "'>" + Credit_Invoiceno + "</a> created by " + fullname1 + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.ToString());
                                        }
                                        //ActivityLogMessage = "Invoice Number " + PostedData.Invoice_Number + " created by " + fullname + " on " + DateTime.Today;
                                        var successActivity1 = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, username, 1);
                                        //UserHub.BroadcastData();
                                    }
                                }
                                if (btnsubmit == "Save & New")
                                {
                                    string storename = Convert.ToString(db.tbl_user_store_select_StorebyUser(userid).FirstOrDefault());
                                    PostedData.BindPaymentTypeList = FillDrpLstPamentype();
                                    PostedData.BindTypeList = FillDrpLstType();
                                    if (storename != null)
                                    {
                                        PostedData.Storename = storename.ToString();
                                    }
                                    else
                                    {
                                        PostedData.Storename = "All Store";
                                    }
                                    PostedData.BindVendorList = FillDrpLstVendor();
                                    PostedData.BindDepartmentList = FillDrpLstDepartment();
                                    PostedData.Disc_BindDepartmentList = FillDrpLstDepartment();
                                    if (PostedData.QuickInvoice == "1")
                                    {
                                        StatusMessage = "Success1";
                                        ViewBag.StatusMessage = StatusMessage;
                                    }
                                    else
                                    {
                                        StatusMessage = "Success";
                                        ViewBag.StatusMessage = StatusMessage;
                                    }
                                    return RedirectToAction("Create");

                                }
                                else
                                {
                                    if (PostedData.QuickInvoice == "1")
                                    {
                                        StatusMessage = "Success1";
                                        ViewBag.StatusMessage = StatusMessage;
                                    }
                                    else
                                    {
                                        StatusMessage = "Success";
                                        ViewBag.StatusMessage = StatusMessage;
                                    }
                                    string message = StatusMessage;
                                    StatusMessage = "";

                                    return RedirectToAction("index", "DashBoard", new { @dashbordsuccess = message });
                                }

                            }
                            else
                            {
                                return RedirectToAction("index", "login");
                            }
                        }
                        catch
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        string storename = Convert.ToString(db.tbl_user_store_select_StorebyUser(userid).FirstOrDefault());
                        PostedData.BindPaymentTypeList = FillDrpLstPamentype();
                        PostedData.BindTypeList = FillDrpLstType();
                        if (storename != null)
                        { PostedData.Storename = storename.ToString(); }
                        PostedData.BindVendorList = FillDrpLstVendor();
                        PostedData.BindDepartmentList = FillDrpLstDepartment();
                        PostedData.Disc_BindDepartmentList = FillDrpLstDepartment();
                        StatusMessage = "Exists";
                        ViewBag.StatusMessage = StatusMessage;

                        return RedirectToAction("Create");
                    }
                }
                else
                {

                    string storename = Convert.ToString(db.tbl_user_store_select_StorebyUser(userid).FirstOrDefault());
                    PostedData.BindPaymentTypeList = FillDrpLstPamentype();
                    PostedData.BindTypeList = FillDrpLstType();
                    if (storename != null)
                    { PostedData.Storename = storename.ToString(); }
                    PostedData.BindVendorList = FillDrpLstVendor();
                    PostedData.BindDepartmentList = FillDrpLstDepartment();
                    PostedData.Disc_BindDepartmentList = FillDrpLstDepartment();
                    PostedData.AdminStorenamelist = (from dataUser in db.tbl_user_Selectstore()

                                                     select new ddllist
                                                     {
                                                         Value = dataUser.Id.ToString(),
                                                         Text = dataUser.Name
                                                     }).ToList();
                    PostedData.Discounttypelist = (from a in db.tbl_discounttype
                                                   select new ddllist
                                                   {
                                                       Value = a.id.ToString(),
                                                       Text = a.Name,
                                                       selected_value = a.Name.Contains("NA") ? true : false
                                                   }).ToList();

                    StatusMessage = "Exists";
                    PostedData.Existcode = exists.ToString();
                    PostedData.Store_id = PostedData.storeid;
                    PostedData.Invoice_Date = PostedData.Invoice_Date;
                    PostedData.Payment_type = PostedData.Payment_type;
                    PostedData.Type_id = PostedData.Type;
                    PostedData.InvoiceDate = wwwroot.Class.AdminSiteConfiguration.GetDate(PostedData.Invoice_Date.Value.ToString());
                    int j = 0;
                    int dept1 = 0;
                    Decimal amt1 = 0;

                    if (Dept_id != null)
                    {
                        List<tbl_Drp> dataDept = new List<tbl_Drp>();
                        foreach (var val_id in Dept_id)
                        {
                            dept1 = Convert.ToInt32(val_id);
                            amt1 = Convert.ToDecimal(Amt[j]);
                            dataDept.Add(new tbl_Drp { Amt = amt1, Deptid = dept1 });
                            j++;
                        }
                        PostedData.drplst = dataDept;
                    }
                    foreach (var panelmodel in PostedData.drplst)
                    {
                        //var panelmodellist = (from a in db.tbl_CECApprovedPV where a.CEC_ID == panelmodel.PanelSelectId select a.LicenceOrCertiHolder).FirstOrDefault();

                        panelmodel.drpname = (from s in db.tbl_Department
                                              where s.id == panelmodel.Deptid
                                              select new ddllist
                                              {
                                                  Value = s.id.ToString(),
                                                  Text = s.Name
                                              }).ToList();
                    }
                    TempData["PostedData"] = PostedData;


                    ViewBag.ExistCode = exists;
                    ViewBag.StatusMessage = StatusMessage;
                    return RedirectToAction("Create");

                }
                // ViewBag.StatusMessage = StatusMessage;
            }
            else
            {
                ViewBag.StatusMessage = "Error";
            }
            if (PostedData.flagaddnew == 1)
            {
                string storename = Convert.ToString(db.tbl_user_store_select_StorebyUser(userid).FirstOrDefault());
                PostedData.BindPaymentTypeList = FillDrpLstPamentype();
                PostedData.BindTypeList = FillDrpLstType();
                if (storename != null)
                { PostedData.Storename = storename.ToString(); }
                PostedData.BindVendorList = FillDrpLstVendor();
                PostedData.BindDepartmentList = FillDrpLstDepartment();
                PostedData.Disc_BindDepartmentList = FillDrpLstDepartment();
                StatusMessage = "Success";
                ViewBag.StatusMessage = StatusMessage;

                return RedirectToAction("Create");

            }
            else
            {

                return RedirectToAction("index");
            }

            return RedirectToAction("Create");

            #endregion

        }


        public string BindVendoraddress(int vid = 0)
        {
            string data = "";

            int vid1 = 0;
            if (vid > 0)
            {
                vid1 = Convert.ToInt32(vid);

                var dataval = db.tbl_Vendor.Where(x => x.id == vid1).Select(x => x.Address).FirstOrDefault();
                if (dataval == "" || dataval == null)
                {
                    dataval = "Not Available";
                }
                data = dataval;
            }
            return data;
        }
        public string BindVendorphone(int vid = 0)
        {
            string data = "";

            int vid1 = 0;
            if (vid > 0)
            {
                vid1 = Convert.ToInt32(vid);

                var dataval = db.tbl_Vendor.Where(x => x.id == vid1).Select(x => x.PhoneNumber).FirstOrDefault();

                if (dataval == "" || dataval == null)
                {
                    dataval = "Not Available";
                }
                data = dataval;
            }
            return data;
        }
    }
}