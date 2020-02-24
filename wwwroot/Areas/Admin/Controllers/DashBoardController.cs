using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
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
using wwwrootBL.Entity;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
//using wwwroot.Hubs;
using System.Net;

namespace wwwroot.Areas.Admin.Controllers
{
    [InitializeSimpleMembershipAttribute]
    [Authorize(Roles = "Back Office Manager,Data Approver,Store Manager,Administrator,Owner,Employee")]
    public class DashBoardController : Controller
    {
        // GET: Admin/DashBoard
        protected static string Cloudurl;
        protected static string StatusMessage = "";
        protected static string ActivityLogMessage = "";
        protected static string DeleteMessage = "";
        private const int FirstPageIndex = 1;
        protected static int TotalDataCount;
        protected static int RtnDatalistcount;
        protected static Array Arr;
        protected static bool IsArray;
        protected static IEnumerable BindData;
        protected static bool IsEdit = false;
        // int userid = Convert.ToInt32(WebSecurity.CurrentUserId);
        // string username = WebSecurity.CurrentUserName;
        protected static string IsFilter = "0";
        protected static string paymethod = "";
        WestZoneEntities db = new WestZoneEntities();
        //protected static int PageSize;
        protected static int currentPageIndex;
        protected static string strdashbordsuccess;
        protected static string ExistCode = "";


        public ActionResult Index(string dashbordsuccess)
        {
            Cloudurl = ConfigurationManager.AppSettings["cloudurl"];
            ViewBag.CloudURL = Cloudurl;
            strdashbordsuccess = dashbordsuccess;
            dashbordsuccess = "";
            if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
            {

                string store_idval = Session["storeid"].ToString();
                ViewBag.Storeidvalue = store_idval;
            }

            return View();
        }


        [HttpPost]
        public ActionResult temp(string radio, string txtstartdate, string txtenddate, string DrpLstdept)
        {
            return View();
        }
        public ActionResult Grid(int IsBindData = 1, int currentPageIndex = 1, string orderby = "id", int IsAsc = 0, int PageSize = 20, int SearchRecords = 1, string Alpha = "", int deptname = 0, string startdate = "", string enddate = "", string payment = "", string Store_val = "", string searchdashbord = "", string AmtMaximum = "0", string AmtMinimum = "0")
        {

            if (!string.IsNullOrEmpty(Session["storeid"].ToString()))
            {

                string store_idval = Session["storeid"].ToString();
                ViewBag.Storeidvalue = store_idval;
            }

            int startcount = 0, endcount = 0;
            //if (sid == null)
            //{
            //    string names = Store_val;

            //    int ids = db.tbl_Store.Where(x => x.Name == names).Select(x => x.Id).FirstOrDefault();
            //    GlobalStore.GlobalStore_id = Store_val;
            //}
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
                        //if (a1.Split(':')[0].ToString() == "SearchTitle")
                        //{
                        //    SearchTitle = Convert.ToString(a1.Split(':')[1].ToString());
                        //}
                        if (a1.Split(':')[0].ToString() == "deptname")
                        {
                            deptname = Convert.ToInt32(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "startdate")
                        {
                            startdate = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "enddate")
                        {
                            enddate = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "payment")
                        {
                            payment = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "Store_val")
                        {
                            Store_val = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "searchdashbord")
                        {
                            searchdashbord = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "AmtMinimum")
                        {
                            AmtMinimum = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "AmtMaximum")
                        {
                            AmtMaximum = Convert.ToString(a1.Split(':')[1].ToString());
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
              //  ,"SearchTitle:" + SearchTitle
               ,"deptname:" + deptname
               ,"startdate:"+startdate
                ,"enddate:"+enddate
                ,"payment:"+payment
                ,"Store_val:"+Store_val
               ,"searchdashbord:"+searchdashbord
               ,"AmtMaximum:"+AmtMaximum
                ,"AmtMinimum:"+AmtMinimum
            };
            #endregion

            #region MyRegion_BindData
            int startIndex = ((currentPageIndex - 1) * PageSize) + 1;
            int endIndex = startIndex + PageSize - 1;

            if (IsBindData == 1 || IsEdit == true)
            {
                BindData = GetData(SearchRecords, deptname, startdate, enddate, payment, Store_val, Convert.ToString(searchdashbord).TrimEnd(), AmtMaximum, AmtMinimum).OfType<Invoice_Dashbord_Select>().ToList();
                TotalDataCount = BindData.OfType<Invoice_Dashbord_Select>().ToList().Count();
                RtnDatalistcount = BindData.OfType<Invoice_Dashbord_Select>().Take(20).Count();
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
            ViewBag.AmtMaximum = AmtMaximum;
            ViewBag.AmtMinimum = AmtMinimum;
            //ViewBag.SearchTitle = SearchTitle;
            //if (strdashbordsuccess != null)
            //{
            //    ViewBag.StatusMessage = strdashbordsuccess;
            //}
            //else
            //{
            //    ViewBag.StatusMessage = StatusMessage;
            //}
            if (strdashbordsuccess == "Success1" || strdashbordsuccess == "Success")
            {
                ViewBag.StatusMessage = strdashbordsuccess;
                strdashbordsuccess = "";
            }
            else
            {
                ViewBag.StatusMessage = StatusMessage;
            }
            ViewBag.startindex = startIndex;
            ViewBag.deptname = deptname;
            ViewBag.startdate = startdate;
            ViewBag.enddate = enddate;
            ViewBag.payment = payment;
            ViewBag.Store_val = Store_val;
            ViewBag.searchdashbord = searchdashbord;
            if (IsFilter == "1")
            {
                ViewBag.IsFilter = "1";
            }

            if (TotalDataCount < endIndex)
            {
                ViewBag.endIndex = TotalDataCount;
            }
            else
            {
                ViewBag.endIndex = endIndex;
            }
            ViewBag.TotalDataCount = TotalDataCount;
            var ColumnName = typeof(Invoice_Dashbord_Select).GetProperties().Where(p => p.Name == orderby).FirstOrDefault();

            IEnumerable Data = null;
            //Response.Write(ColumnName);
            //Response.End();
            if (IsAsc == 1)
            {
                ViewBag.AscVal = 0;
                Data = BindData.OfType<Invoice_Dashbord_Select>().ToList().OrderBy(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            else
            {

                ViewBag.AscVal = 1;

                Data = BindData.OfType<Invoice_Dashbord_Select>().ToList().OrderByDescending(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            StatusMessage = "";
            //// ViewBag.Pagetext = "Showing " + iStartsRecods + " to " + iEndRecord + " of " + iTotalRecords + " entries";
            List<ddllist> Lstdept = new List<ddllist>();
            Lstdept = FillDrpLstDepartment();
            ViewBag.Datadept = Lstdept;

            ViewBag.Invoicecount = RtnDatalistcount;
            if (ViewBag.Invoicecount == 0)
            {
                //StatusMessage = "NoItem";
                //ViewBag.StatusMessage = StatusMessage;
            }
            #region productcount
            if (TotalDataCount > PageSize)
            {
                if (currentPageIndex > 1)
                {
                    startcount = ((Convert.ToInt32(currentPageIndex - 1) * Convert.ToInt32(PageSize)) + 1);
                    endcount = (Convert.ToInt32(PageSize) * Convert.ToInt32(currentPageIndex));

                    if (Convert.ToInt32(endcount) > TotalDataCount)
                    {
                        endcount = TotalDataCount;
                    }
                }
                else
                {
                    startcount = 1;
                    endcount = (PageSize);
                }
            }
            else
            {
                startcount = 1;
                endcount = TotalDataCount;
            }

            try
            { }
            catch { TotalDataCount = 0; }


            ViewBag.startcount = startcount;
            ViewBag.endcount = endcount;
            ViewBag.totalcount = TotalDataCount;

            ViewBag.PageSize = PageSize;
            ViewBag.CurrentPageIndex = currentPageIndex;
            ViewBag.LastPageIndex = this.getLastPageIndex(PageSize);
            //ViewBag.sortbuildingtype = sortvalue;
            #endregion




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
        private IEnumerable GetData(int SearchRecords = 0, int deptname = 0, string startdate = "", string enddate = "", string payment = "", string Store_val = "", string searchdashbord = "", string AmtMaximum = "0", string AmtMinimum = "0")
        {

            if (AmtMaximum == "" || AmtMaximum == " " || AmtMaximum == null)
            {
                AmtMaximum = "0";
            }
            if (AmtMinimum == "" || AmtMinimum == " " || AmtMinimum == null)
            {
                AmtMinimum = "0";
            }
            //string userid = WebSecurity.CurrentUserId.ToString();
            int userid = WebSecurity.GetUserId(WebSecurity.CurrentUserName);
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

            #region unuse code
            //int storeid;

            //if (Store_val == "")
            //{


            //    var Store = db.tbl_user_store_By_Reg_userid(@WebSecurity.CurrentUserId).Select(x => x.StoreName).FirstOrDefault();
            //    storeid = db.tbl_Store.Where(x => x.Name == Store).Select(x => x.Id).FirstOrDefault();


            //}
            //else
            //{
            //    storeid = db.tbl_Store.Where(x => x.Name == Store_val).Select(x => x.Id).FirstOrDefault();
            //}

            //string useridbyroles="";
            //if (Roles.IsUserInRole("Back Office Manager"))
            //{
            //    useridbyroles = userid;
            //}
            //else if (Roles.IsUserInRole("Data Approver"))
            //{
            //    useridbyroles = db.tbl_user_store.Where(x => x.Storeid == storeid).Where(x => x.RoleId == 2).Select(x => x.Reg_userid).FirstOrDefault().ToString();
            //}
            //else if (Roles.IsUserInRole("Store Manager"))
            //{
            //    useridbyroles = db.tbl_user_store.Where(x => x.Storeid == storeid).Where(x => x.RoleId == 3).Select(x => x.Reg_userid).FirstOrDefault().ToString();
            //}

            #endregion

            #region dashbord grid and search
            string storeid = "";
            if (!string.IsNullOrEmpty(Session["storeid"].ToString()))
            {
                storeid = Session["storeid"].ToString();
            }
            else
            {
                RedirectToAction("index", "login");
            }


            //if (Roles.IsUserInRole("Back Office Manager"))
            //{
            //    RtnData = (from data in db.tbl_Invoice_Dashbord_GridData(start_date, end_date, payment, deptname, Convert.ToInt32(storeid), searchdashbord, userid.ToString())

            //               select new Invoice_Dashbord_Select
            //               {
            //                   id = data.id,
            //                   Storename = data.Storename,
            //                   Payment_type = data.Payment_type,
            //                   Type = data.Typename,
            //                   Vendorname = data.vendorname,
            //                   Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
            //                   Invoice_Number = data.Invoice_Number,
            //                   Note = data.Note,
            //                   Type_id = data.Type_id.GetValueOrDefault(),
            //                   TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
            //                   Status = data.Statusname,
            //                   IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
            //                   ScanInvoice = data.ScanInvoice,
            //                   Amt = data.deptamt,
            //                   deptid = data.deptid.GetValueOrDefault(),
            //               }).Take(5).ToList();


            //}
            //else if (Roles.IsUserInRole("Data Approver"))
            //{
            //    RtnData = (from data in db.tbl_Invoice_Dashbord_GridData_DataApp(start_date, end_date, payment, deptname, Convert.ToInt32(storeid), searchdashbord)

            //               select new Invoice_Dashbord_Select
            //               {
            //                   id = data.id,
            //                   Storename = data.Storename,
            //                   Payment_type = data.Payment_type,
            //                   Type = data.Typename,
            //                   Vendorname = data.vendorname,
            //                   Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
            //                   Invoice_Number = data.Invoice_Number,
            //                   Note = data.Note,
            //                   Type_id = data.Type_id.GetValueOrDefault(),
            //                   TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
            //                   Status = data.Statusname,
            //                   IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
            //                   ScanInvoice = data.ScanInvoice,
            //                   Amt = data.deptamt,
            //                   deptid = data.deptid.GetValueOrDefault(),
            //               }).Take(5).ToList();


            //}
            //else if (Roles.IsUserInRole("Store Manager"))
            //{
            //    RtnData = (from data in db.tbl_Invoice_Dashbord_GridData_StoreManager(start_date, end_date, payment, deptname, Convert.ToInt32(storeid), searchdashbord)

            //               select new Invoice_Dashbord_Select
            //               {
            //                   id = data.id,
            //                   Storename = data.Storename,
            //                   Payment_type = data.Payment_type,
            //                   Type = data.Typename,
            //                   Vendorname = data.vendorname,
            //                   Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
            //                   Invoice_Number = data.Invoice_Number,
            //                   Note = data.Note,
            //                   Type_id = data.Type_id.GetValueOrDefault(),
            //                   TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
            //                   Status = data.Statusname,
            //                   IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
            //                   ScanInvoice = data.ScanInvoice,
            //                   Amt = data.deptamt,
            //                   deptid = data.deptid.GetValueOrDefault(),
            //               }).Take(5).ToList();


            //}
            //else if (Roles.IsUserInRole("Administrator"))
            //{
            RtnData = (from data in db.tbl_Invoice_Dashbord_GridData_Administrator(start_date, end_date, payment, deptname, Convert.ToInt32(storeid), Convert.ToString(searchdashbord).TrimEnd(), Convert.ToDecimal(AmtMaximum), Convert.ToDecimal(AmtMinimum))

                       select new Invoice_Dashbord_Select
                       {
                           id = data.id,
                           Storename = data.Storename,
                           Payment_type = data.Payment_type,
                           Type = data.Typename,
                           Vendorname = data.vendorname,
                           Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
                           Invoice_Number = data.Invoice_Number,
                           Note = data.Note,
                           Type_id = data.Type_id.GetValueOrDefault(),
                           TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
                           Status = data.Statusname,
                           IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
                           ScanInvoice = data.ScanInvoice,
                           Amt = data.deptamt,
                           deptid = deptname,
                           Tooltip = data.RoleId
                       }).Take(20).ToList();


            //}



            #endregion

            #region grid for isfilter

            //if(IsFilter == "1")
            //{
            //    RtnData = (from data in db.tbl_Invoice_GridData(start_date, end_date, payment, deptname, Convert.ToInt32(storeid), 0)

            //               select new Invoice_Select
            //               {
            //                   id = data.id,
            //                   Storename = data.Storename,
            //                   Payment_type = data.Payment_type,
            //                   Type = data.Typename,
            //                   Vendorname = data.vendorname,
            //                   Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
            //                   Invoice_Number = data.Invoice_Number,
            //                   Note = data.Note,
            //                   Type_id = data.Type_id.GetValueOrDefault(),
            //                   TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
            //                   Amt = data.deptamt,
            //                   deptid = data.deptid.GetValueOrDefault(),
            //                   Status = data.Statusname,
            //                   IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
            //               }).ToList<Invoice_Select>();


            //}
            #endregion
            return RtnData;
        }

        public ActionResult GetDatapagescroll(int PageSize, int currentPageIndex, string rdcash, string rdcheck, string datval, string datendval, int deptnm, string searchdashbord = "", string AmtMaximum = "0", string AmtMinimum = "0")
        {
            string chk = "";
            if (rdcash != "")
                chk = rdcash;
            if (rdcheck != "")
            {
                if (chk != "")
                    chk = "";
                else
                    chk = rdcheck;
            }
            if (AmtMaximum == "" || AmtMaximum == " " || AmtMaximum == null)
            {
                AmtMaximum = "0";
            }
            if (AmtMinimum == "" || AmtMinimum == " " || AmtMinimum == null)
            {
                AmtMinimum = "0";
            }

            DateTime? start_date = null;
            DateTime? end_date = null;
            try
            {
                start_date = Convert.ToDateTime(datval);
            }
            catch { }

            try
            {
                end_date = Convert.ToDateTime(datendval);
            }
            catch { }
            System.Threading.Thread.Sleep(1000);

            int startcount = 0, endcount = 0;
            int startIndex = ((currentPageIndex - 1) * PageSize) + 1;
            int endIndex = startIndex + PageSize - 1;
            IEnumerable RtnData = null;
            int RtnDatalistcount = 0;
            #region dashbord grid and search
            string storeid = "";
            if (!string.IsNullOrEmpty(Session["storeid"].ToString()))
            {
                storeid = Session["storeid"].ToString();
            }
            else
            {
                RedirectToAction("index", "login");
            }
            //string storeid = GlobalStore.GlobalStore_id;

            RtnData = (from data in db.tbl_Invoice_Dashbord_GridData_Administrator(start_date, end_date, chk, deptnm, Convert.ToInt32(storeid), Convert.ToString(searchdashbord).TrimEnd(), Convert.ToDecimal(AmtMaximum), Convert.ToDecimal(AmtMinimum))

                       select new Invoice_Dashbord_Select
                       {
                           id = data.id,
                           Storename = data.Storename,
                           Payment_type = data.Payment_type,
                           Type = data.Typename,
                           Vendorname = data.vendorname,//date.ToString("dd-MM-yyyy")
                           Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
                           Invoice_Number = data.Invoice_Number,
                           Note = data.Note,
                           Type_id = data.Type_id.GetValueOrDefault(),
                           TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
                           Status = data.Statusname,
                           IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
                           ScanInvoice = data.ScanInvoice,
                           Amt = data.deptamt,
                           deptid = deptnm,
                           StrInvoice_Date = @wwwroot.Class.AdminSiteConfiguration.GetDateformat(data.Invoice_Date.ToString()),
                           Tooltip = data.RoleId
                       }).Skip(currentPageIndex * PageSize).Take(PageSize).ToList();

            //if (Roles.IsUserInRole("Back Office Manager"))
            //{
            //    RtnData = (from data in db.tbl_Invoice_Dashbord_GridData(null, null, "", 0, Convert.ToInt32(storeid), "", userid.ToString())

            //               select new Invoice_Dashbord_Select
            //               {
            //                   id = data.id,
            //                   Storename = data.Storename,
            //                   Payment_type = data.Payment_type,
            //                   Type = data.Typename,
            //                   Vendorname = data.vendorname,
            //                   Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
            //                   Invoice_Number = data.Invoice_Number,
            //                   Note = data.Note,
            //                   Type_id = data.Type_id.GetValueOrDefault(),
            //                   TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
            //                   Status = data.Statusname,
            //                   IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
            //                   ScanInvoice = data.ScanInvoice,
            //                   Amt = data.deptamt,
            //                   deptid = data.deptid.GetValueOrDefault(),
            //               }).Skip(currentPageIndex * PageSize).Take(PageSize).ToList();

            //    TotalDataCount = (from data in db.tbl_Invoice_Dashbord_GridData(null, null, "", 0, Convert.ToInt32(storeid), "", userid.ToString())

            //                      select new Invoice_Dashbord_Select
            //                      {
            //                          id = data.id,
            //                          Storename = data.Storename,
            //                          Payment_type = data.Payment_type,
            //                          Type = data.Typename,
            //                          Vendorname = data.vendorname,
            //                          Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
            //                          Invoice_Number = data.Invoice_Number,
            //                          Note = data.Note,
            //                          Type_id = data.Type_id.GetValueOrDefault(),
            //                          TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
            //                          Status = data.Statusname,
            //                          IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
            //                          ScanInvoice = data.ScanInvoice,
            //                          Amt = data.deptamt,
            //                          deptid = data.deptid.GetValueOrDefault(),
            //                      }).Count();

            //    RtnDatalistcount = (from data in db.tbl_Invoice_Dashbord_GridData(null, null, "", 0, Convert.ToInt32(storeid), "", userid.ToString())

            //                        select new Invoice_Dashbord_Select
            //                        {
            //                            id = data.id,
            //                            Storename = data.Storename,
            //                            Payment_type = data.Payment_type,
            //                            Type = data.Typename,
            //                            Vendorname = data.vendorname,
            //                            Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
            //                            Invoice_Number = data.Invoice_Number,
            //                            Note = data.Note,
            //                            Type_id = data.Type_id.GetValueOrDefault(),
            //                            TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
            //                            Status = data.Statusname,
            //                            IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
            //                            ScanInvoice = data.ScanInvoice,
            //                            Amt = data.deptamt,
            //                            deptid = data.deptid.GetValueOrDefault(),
            //                        }).Skip(currentPageIndex * PageSize).Take(PageSize).Count();
            //}
            //else if (Roles.IsUserInRole("Data Approver"))
            //{
            //    RtnData = (from data in db.tbl_Invoice_Dashbord_GridData_DataApp(null, null, "", 0, Convert.ToInt32(storeid), "")

            //               select new Invoice_Dashbord_Select
            //               {
            //                   id = data.id,
            //                   Storename = data.Storename,
            //                   Payment_type = data.Payment_type,
            //                   Type = data.Typename,
            //                   Vendorname = data.vendorname,
            //                   Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
            //                   Invoice_Number = data.Invoice_Number,
            //                   Note = data.Note,
            //                   Type_id = data.Type_id.GetValueOrDefault(),
            //                   TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
            //                   Status = data.Statusname,
            //                   IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
            //                   ScanInvoice = data.ScanInvoice,
            //                   Amt = data.deptamt,
            //                   deptid = data.deptid.GetValueOrDefault(),
            //               }).Skip(currentPageIndex * PageSize).Take(PageSize).ToList();

            //    TotalDataCount = (from data in db.tbl_Invoice_Dashbord_GridData_DataApp(null, null, "", 0, Convert.ToInt32(storeid), "")

            //                      select new Invoice_Dashbord_Select
            //                      {
            //                          id = data.id,
            //                          Storename = data.Storename,
            //                          Payment_type = data.Payment_type,
            //                          Type = data.Typename,
            //                          Vendorname = data.vendorname,
            //                          Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
            //                          Invoice_Number = data.Invoice_Number,
            //                          Note = data.Note,
            //                          Type_id = data.Type_id.GetValueOrDefault(),
            //                          TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
            //                          Status = data.Statusname,
            //                          IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
            //                          ScanInvoice = data.ScanInvoice,
            //                          Amt = data.deptamt,
            //                          deptid = data.deptid.GetValueOrDefault(),
            //                      }).Count();
            //    RtnDatalistcount = (from data in db.tbl_Invoice_Dashbord_GridData_DataApp(null, null, "", 0, Convert.ToInt32(storeid), "")

            //                        select new Invoice_Dashbord_Select
            //                        {
            //                            id = data.id,
            //                            Storename = data.Storename,
            //                            Payment_type = data.Payment_type,
            //                            Type = data.Typename,
            //                            Vendorname = data.vendorname,
            //                            Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
            //                            Invoice_Number = data.Invoice_Number,
            //                            Note = data.Note,
            //                            Type_id = data.Type_id.GetValueOrDefault(),
            //                            TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
            //                            Status = data.Statusname,
            //                            IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
            //                            ScanInvoice = data.ScanInvoice,
            //                            Amt = data.deptamt,
            //                            deptid = data.deptid.GetValueOrDefault(),
            //                        }).Skip(currentPageIndex * PageSize).Take(PageSize).Count();
            //}
            //else if (Roles.IsUserInRole("Store Manager"))
            //{
            //    RtnData = (from data in db.tbl_Invoice_Dashbord_GridData_StoreManager(null, null, "", 0, Convert.ToInt32(storeid), "")

            //               select new Invoice_Dashbord_Select
            //               {
            //                   id = data.id,
            //                   Storename = data.Storename,
            //                   Payment_type = data.Payment_type,
            //                   Type = data.Typename,
            //                   Vendorname = data.vendorname,
            //                   Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
            //                   Invoice_Number = data.Invoice_Number,
            //                   Note = data.Note,
            //                   Type_id = data.Type_id.GetValueOrDefault(),
            //                   TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
            //                   Status = data.Statusname,
            //                   IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
            //                   ScanInvoice = data.ScanInvoice,
            //                   Amt = data.deptamt,
            //                   deptid = data.deptid.GetValueOrDefault(),
            //               }).Skip(currentPageIndex * PageSize).Take(PageSize).ToList();
            //    TotalDataCount = (from data in db.tbl_Invoice_Dashbord_GridData_StoreManager(null, null, "", 0, Convert.ToInt32(storeid), "")

            //                      select new Invoice_Dashbord_Select
            //                      {
            //                          id = data.id,
            //                          Storename = data.Storename,
            //                          Payment_type = data.Payment_type,
            //                          Type = data.Typename,
            //                          Vendorname = data.vendorname,
            //                          Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
            //                          Invoice_Number = data.Invoice_Number,
            //                          Note = data.Note,
            //                          Type_id = data.Type_id.GetValueOrDefault(),
            //                          TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
            //                          Status = data.Statusname,
            //                          IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
            //                          ScanInvoice = data.ScanInvoice,
            //                          Amt = data.deptamt,
            //                          deptid = data.deptid.GetValueOrDefault(),
            //                      }).Count();
            //    RtnDatalistcount = (from data in db.tbl_Invoice_Dashbord_GridData_StoreManager(null, null, "", 0, Convert.ToInt32(storeid), "")

            //                        select new Invoice_Dashbord_Select
            //                        {
            //                            id = data.id,
            //                            Storename = data.Storename,
            //                            Payment_type = data.Payment_type,
            //                            Type = data.Typename,
            //                            Vendorname = data.vendorname,
            //                            Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
            //                            Invoice_Number = data.Invoice_Number,
            //                            Note = data.Note,
            //                            Type_id = data.Type_id.GetValueOrDefault(),
            //                            TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
            //                            Status = data.Statusname,
            //                            IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
            //                            ScanInvoice = data.ScanInvoice,
            //                            Amt = data.deptamt,
            //                            deptid = data.deptid.GetValueOrDefault(),
            //                        }).Skip(currentPageIndex * PageSize).Take(PageSize).Count();
            //}
            //else if (Roles.IsUserInRole("Administrator"))
            //{


            TotalDataCount = (from data in db.tbl_Invoice_Dashbord_GridData_Administrator(start_date, end_date, chk, deptnm, Convert.ToInt32(storeid), "", Convert.ToDecimal(AmtMaximum), Convert.ToDecimal(AmtMinimum))

                              select new Invoice_Dashbord_Select
                              {
                                  id = data.id,
                                  Storename = data.Storename,
                                  Payment_type = data.Payment_type,
                                  Type = data.Typename,
                                  Vendorname = data.vendorname,
                                  Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
                                  Invoice_Number = data.Invoice_Number,
                                  Note = data.Note,
                                  Type_id = data.Type_id.GetValueOrDefault(),
                                  TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
                                  Status = data.Statusname,
                                  IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
                                  ScanInvoice = data.ScanInvoice,
                                  Amt = data.deptamt,
                                  deptid = deptnm,
                                  Tooltip = data.RoleId
                              }).Count();
            RtnDatalistcount = (from data in db.tbl_Invoice_Dashbord_GridData_Administrator(start_date, end_date, chk, deptnm, Convert.ToInt32(storeid), "", Convert.ToDecimal(AmtMaximum), Convert.ToDecimal(AmtMinimum))

                                select new Invoice_Dashbord_Select
                                {
                                    id = data.id,
                                    Storename = data.Storename,
                                    Payment_type = data.Payment_type,
                                    Type = data.Typename,
                                    Vendorname = data.vendorname,
                                    Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
                                    Invoice_Number = data.Invoice_Number,
                                    Note = data.Note,
                                    Type_id = data.Type_id.GetValueOrDefault(),
                                    TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
                                    Status = data.Statusname,
                                    IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
                                    ScanInvoice = data.ScanInvoice,
                                    Amt = data.deptamt,
                                    deptid = deptnm,
                                    Tooltip = data.RoleId
                                }).Skip(currentPageIndex * PageSize).Take(PageSize).Count();
            //}

            #endregion


            ViewBag.Invoicecount = RtnDatalistcount;
            if (ViewBag.Invoicecount == 0)
            {
                //StatusMessage = "NoItem";
                //ViewBag.StatusMessage = StatusMessage;
            }
            #region productcount
            if (TotalDataCount > PageSize)
            {
                if (currentPageIndex > 1)
                {
                    startcount = ((Convert.ToInt32(currentPageIndex - 1) * Convert.ToInt32(PageSize)) + 1);
                    endcount = (Convert.ToInt32(PageSize) * Convert.ToInt32(currentPageIndex));

                    if (Convert.ToInt32(endcount) > TotalDataCount)
                    {
                        endcount = TotalDataCount;
                    }
                }
                else
                {
                    startcount = 1;
                    endcount = (PageSize);
                }
            }
            else
            {
                startcount = 1;
                endcount = TotalDataCount;
            }

            try
            { }
            catch { TotalDataCount = 0; }


            ViewBag.startcount = startcount;
            ViewBag.endcount = endcount;
            ViewBag.totalcount = TotalDataCount;

            ViewBag.PageSize = PageSize;
            ViewBag.CurrentPageIndex = currentPageIndex;
            ViewBag.LastPageIndex = this.getLastPageIndex(PageSize);
            //ViewBag.sortbuildingtype = sortvalue;
            #endregion

            return Json(RtnData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Grid(string[] radio, string txtstartdate, string txtenddate, string DrpLstdept, string AmtMaximum = "0", string AmtMinimum = "0")
        {

            if (radio != null)
            {
                IsFilter = "1";
                if (radio.Count() > 1)
                {
                    paymethod = "";
                }
                else if (radio.Count() == 1)
                {
                    paymethod = radio[0];
                }
            }
            else
            {
                paymethod = "";
                IsFilter = "0";
            }
            return RedirectToAction("Index", "DashBoard", new { IsBindData = 1, currentPageIndex = 1, orderby = "id", IsAsc = 0, PageSize = 20, SearchRecords = 1, Alpha = "", deptname = DrpLstdept, startdate = txtstartdate, enddate = txtenddate, payment = paymethod, Store_val = "", searchdashbord = "", AmtMaximum = AmtMaximum, AmtMinimum = AmtMinimum });
            //IEnumerable RtnData = null;
            //string storeid = GlobalStore.GlobalStore_id;
            //RtnData = (from data in db.tbl_Invoice_GridData(txtstartdate, txtenddate, radio, DrpLstdept, Convert.ToInt32(storeid), Status)

            //           select new Invoice_Select
            //           {
            //               id = data.id,
            //               Storename = data.Storename,
            //               Payment_type = data.Payment_type,
            //               Type = data.Typename,
            //               Vendorname = data.vendorname,
            //               Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
            //               Invoice_Number = data.Invoice_Number,
            //               Note = data.Note,
            //               Type_id = data.Type_id.GetValueOrDefault(),
            //               TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
            //               Amt = data.deptamt,
            //               deptid = data.deptid.GetValueOrDefault(),
            //               Status = data.Statusname,
            //               IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
            //           }).ToList<Invoice_Select>();

            //return RtnData;

        }

        #region Fill DropdownList Department
        public List<ddllist> FillDrpLstDepartment()
        {
            List<ddllist> LstDepartment = new List<ddllist>();

            if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
            {
                string storeid = Convert.ToString(Session["storeid"]);
                LstDepartment = (from a in db.tbl_Department
                                 where a.StoreID.ToString() == storeid
                                 orderby a.Name ascending
                                 select new ddllist
                                 {
                                     Value = a.id.ToString(),
                                     Text = a.Name
                                 }).ToList();
            }
            return LstDepartment;
        }
        #endregion

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
            //if (Roles.IsUserInRole("Administrator"))
            //{

            //    LstVendor = (from a in db.tbl_Vendor
            //                 orderby a.Name ascending
            //                 select new ddllist
            //                 {
            //                     Value = a.id.ToString(),
            //                     Text = a.Name
            //                 }).ToList();
            //}
            //else
            //{
            if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
            {
                string storeid = Convert.ToString(Session["storeid"]);
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

            //}

            return LstVendor;
        }
        #endregion
        public ActionResult Edit(int Id = 0, string storenameval = "", int deptname = 0, string startdate = "", string enddate = "", string payment = "", string Store_val = "", string searchdashbord = "", string RedairectFrom = "", int VendorName = 0, string AmtMaximum = "0", string AmtMinimum = "0")
        {
            ViewBag.CurrentDate = DateTime.Today.Date;

            //StatusMessage = "";
            ViewBag.StatusMessage = StatusMessage;
            ViewBag.Detailstorenamevalue = storenameval;
            IsArray = true;
            tbl_Invoice Data = db.tbl_Invoice.Find(Id);
            if (!string.IsNullOrEmpty(ExistCode))
            {
                ViewBag.ExistCode = ExistCode;
            }
            ViewBag.IDOnDetailPage = Id;
            Session["storeid"] = Data.Store_id.ToString();
            // GlobalStore.GlobalStore_id = Data.Store_id.ToString();

            Invoice_Edit Invoice_Edit = new Invoice_Edit
            {
                IsSync = Data.IsSync.GetValueOrDefault(),
                BindPaymentTypeList = FillDrpLstPamentype(),
                BindTypeList = FillDrpLstType(),
                BindVendorList = FillDrpLstVendor(),
                BindDepartmentList = FillDrpLstDepartment(),
                Disc_BindDepartmentList = FillDrpLstDepartment(),
                Dept_id = Convert.ToInt32(db.tbl_Invoice_Department.Where(x => x.Invoice_id == Data.id).Select(x => x.Dept_id).FirstOrDefault()),
                Amt = Convert.ToInt32(db.tbl_Invoice_Department.Where(x => x.Invoice_id == Data.id).Select(x => x.Amount).FirstOrDefault()),
                id = Data.id,
                Payment_type = Data.Payment_type,
                Type_id = Data.Type_id.GetValueOrDefault(),
                //Type = db.tbl_Type.Where(x => x.id == Data.Type_id).Select(x => x.Name).FirstOrDefault();
                Vendorname = db.tbl_Vendor.Where(x => x.id == Data.Vendor_id).Select(x => x.Name).FirstOrDefault(),
                Vendor_id = Data.Vendor_id.GetValueOrDefault(),
                Address = db.tbl_Vendor.Where(x => x.id == Data.Vendor_id).Select(x => x.Address).FirstOrDefault(),
                PhoneNumber = db.tbl_Vendor.Where(x => x.id == Data.Vendor_id).Select(x => x.PhoneNumber).FirstOrDefault(),
                Invoice_Number = Data.Invoice_Number,
                Invoice_Date = wwwroot.Class.AdminSiteConfiguration.GetDate(Data.Invoice_Date.Value.ToString()),
                InvoiceDate = wwwroot.Class.AdminSiteConfiguration.GetDate(Data.Invoice_Date.Value.ToString()),
                //Convert.ToDateTime(@wwwroot.Class.AdminSiteConfiguration.GetDate(Data.Invoice_Date.ToString())),
                TotalAmtByDept = Data.TotalAmtByDept.GetValueOrDefault(),
                Note = Data.Note,
                CreatedBy = Data.CreatedBy,
                CreatedOn = Data.CreatedOn.GetValueOrDefault(),
                ModifiedOn = Data.ModifiedOn.GetValueOrDefault(),
                ModifiedBy = Data.ModifiedBy,
                ScanInvoice = Data.ScanInvoice,
                vendoraddress = db.tbl_Vendor.Where(x => x.id == Data.Vendor_id).Select(x => x.Address).FirstOrDefault(),
                IsStatus_id = Data.IsStatus_id.GetValueOrDefault(),
                ApproveRejectBy = Data.ApproveRejectBy,
                ApproveRejectDate = Data.ApproveRejectDate.GetValueOrDefault(),
                Storename = db.tbl_Store.Where(x => x.Id == Data.Store_id).Select(x => x.Name).FirstOrDefault(),

                deptname = deptname,
                startdate = startdate,
                enddate = enddate,
                payment = payment,
                Store_val = Store_val,
                searchdashbord = searchdashbord,
                RedairectFrom = RedairectFrom,
                SearchVendorName = VendorName,
                AmtMaximum = AmtMaximum,
                AmtMinimum = AmtMinimum,
                QBtransfer = Convert.ToString(Convert.ToBoolean(Data.QBtransfer.GetValueOrDefault())),
                Store_id = Data.Store_id.GetValueOrDefault(),
                Discount = Data.discount,
                Discountamount = Data.discountamount,
                Discounttype = Convert.ToInt32(Data.discounttype),
                RefInvoiceId = (from a in db.tbl_Invoice where a.Ref_invoiceid == Data.id select a.Invoice_Number).FirstOrDefault()
            };
            if (Invoice_Edit.Discounttype == 0 || Invoice_Edit.Discounttype == null)
            {
                Invoice_Edit.Discounttype = 1;
            }
            Invoice_Edit.drplst = (from a in db.tbl_Invoice_Department
                                   where a.Invoice_id == Data.id
                                   select new tbl_Drp
                                   {
                                       id = a.id,
                                       Deptid = a.Dept_id,
                                       Amt = a.Amount
                                   }).ToList<tbl_Drp>();
            Invoice_Edit.Discounttypelist = (from a in db.tbl_discounttype
                                             select new ddllist
                                             {
                                                 Value = a.id.ToString(),
                                                 Text = a.Name,
                                                 selected_value = a.Name.Contains("NA") ? true : false
                                             }).ToList();
            foreach (var panelmodel in Invoice_Edit.drplst)
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
            if (TempData["PostedData"] != null)
            {
                Invoice_Edit = (Invoice_Edit)TempData["PostedData"];
            }
            return View(Invoice_Edit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Invoice_Edit PostedData, int ID = 0, HttpPostedFileBase ScanInvoice = null, string[] Deptid = null, string[] Amt = null)
        {
            if (PostedData.Discounttype == 1 || PostedData.Discounttype == null)
            {
                ModelState.Remove("Disc_Dept_id");
            }
            else
            {

            }
            if (PostedData.QBtransfer == "1")
            {
                PostedData.QBtransfer = "true";
            }
            else
            {
                PostedData.QBtransfer = "false";
            }
            IsEdit = true;
            Invoice_Edit custdata = new Invoice_Edit();
            PostedData.BindTypeList = FillDrpLstType();
            PostedData.BindVendorList = FillDrpLstVendor();
            PostedData.BindDepartmentList = FillDrpLstDepartment();
            PostedData.Disc_BindDepartmentList = FillDrpLstDepartment();
            PostedData.BindPaymentTypeList = FillDrpLstPamentype();

            if (ModelState.IsValid)
            {

                tbl_Invoice Invoice_data = db.tbl_Invoice.Find(ID);
                if (PostedData.Payment_type == "Cash")
                {
                    PostedData.Type_id = 1;
                }
                //var exists = db.tbl_Invoice_exists_InNo_Edit(ID, PostedData.Invoice_Number, PostedData.TotalAmtByDept, Convert.ToDateTime(PostedData.Invoice_Date)).Select(x => x.Value).FirstOrDefault();
                var exists = db.tbl_Invoice_exists_InNo_Edit_New(ID, PostedData.Invoice_Number, Convert.ToDateTime(PostedData.Invoice_Date), Invoice_data.Store_id, PostedData.Type_id, PostedData.Vendor_id).Select(x => x.Value).FirstOrDefault();

                if (Convert.ToInt32(exists) == 0)
                {
                    #region AttachNote                    
                    var Sacn_Title = "";
                    //Invoice_data.ScanInvoice;
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
                                var Status2 = "";
                                if (PostedData.RedairectFrom != "Dashboard")
                                {
                                    Status2 = StatusMessage;
                                    StatusMessage = "";
                                    ViewBag.StatusMessage = "";
                                }

                                ViewBag.StatusMessage = "InvalidImage";
                                if (PostedData.RedairectFrom == "Dashboard")
                                {
                                    return View("Index", new { startdate = PostedData.startdate, enddate = PostedData.enddate, payment = PostedData.payment, Store_val = PostedData.Store_val, searchdashbord = PostedData.searchdashbord, VendorName = PostedData.SearchVendorName, AmtMaximum = PostedData.AmtMaximum, AmtMinimum = PostedData.AmtMinimum });
                                }
                                else
                                {
                                    return RedirectToAction("Index", "InvoiceReport", new { dashbordsuccess = Status2, startdate = PostedData.startdate, enddate = PostedData.enddate, payment = PostedData.payment, Store_val = PostedData.Store_val, searchdashbord = PostedData.searchdashbord, VendorName = PostedData.SearchVendorName, AmtMaximum = PostedData.AmtMaximum, AmtMinimum = PostedData.AmtMinimum });
                                }

                            }
                            else
                            {
                                Sacn_Title = AdminSiteConfiguration.GetRandomNo() + Path.GetFileName(ScanInvoice.FileName);
                                Sacn_Title = AdminSiteConfiguration.RemoveSpecialCharacter(Sacn_Title);


                                var path1 = Request.PhysicalApplicationPath + "userfiles\\scanimage" + "\\" + Sacn_Title;
                                ScanInvoice.SaveAs(path1);
                                Invoice_data.UploadInvoice = Sacn_Title;
                                Invoice_data.ScanInvoice = Sacn_Title;
                                //#region cloudURL

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
                                //    if (!string.IsNullOrEmpty(Invoice_data.ScanInvoice))
                                //    {
                                //        cloudFilesProvider.DeleteObject("wsmanagementsys", "scanimage/" + Invoice_data.ScanInvoice);
                                //    }
                                //    stream.Flush();
                                //    stream.Close();
                                //}
                                //Invoice_data.UploadInvoice = Sacn_Title;
                                //Invoice_data.ScanInvoice = Sacn_Title;

                                //#endregion
                                //string foldername = Path.Combine("scanimage");
                                //AdminSiteConfiguration.DeleteImage(Sacn_Title, foldername);
                            }
                        }

                    }
                    #endregion
                    int uid = WebSecurity.CurrentUserId;
                    string fullname = db.tbl_user.Where(x => x.Reg_userid == uid).Select(x => x.Name).FirstOrDefault();

                    string success = "";
                    try
                    {
                        success = db.tbl_Invoice_Update(ID, PostedData.Invoice_Number, Convert.ToDateTime(PostedData.Invoice_Date), PostedData.Store_id, PostedData.Type_id, PostedData.Vendor_id, PostedData.Payment_type, PostedData.Note, PostedData.IsStatus_id, fullname, DateTime.Now.AddHours(1), PostedData.TotalAmtByDept, PostedData.QBtransfer == "true" ? true : false).Select(x => x.ToString()).FirstOrDefault().ToString();
                    }
                    catch
                    {
                        var existsdatya = db.tbl_Invoice_exists_InNo_Edit_New(ID, PostedData.Invoice_Number, Convert.ToDateTime(PostedData.Invoice_Date), PostedData.Store_id, PostedData.Type_id, PostedData.Vendor_id).Select(x => x.Value).FirstOrDefault();
                        StatusMessage = "Exists";
                        ViewBag.StatusMessage = StatusMessage;
                        PostedData.ExistID = existsdatya.ToString();
                        PostedData.BindTypeList = FillDrpLstType();
                        PostedData.BindVendorList = FillDrpLstVendor();
                        PostedData.BindDepartmentList = FillDrpLstDepartment();
                        PostedData.Disc_BindDepartmentList = FillDrpLstDepartment();
                        int j = 0;
                        int dept1 = 0;
                        Decimal amt1 = 0;

                        if (Deptid != null)
                        {
                            List<tbl_Drp> dataDept = new List<tbl_Drp>();
                            foreach (var val_id in Deptid)
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
                        PostedData.Discounttypelist = (from a in db.tbl_discounttype
                                                       select new ddllist
                                                       {
                                                           Value = a.id.ToString(),
                                                           Text = a.Name,
                                                           selected_value = a.Name.Contains("NA") ? true : false
                                                       }).ToList();
                        TempData["PostedData"] = PostedData;
                        return RedirectToAction("Edit");
                    }
                    if (success != "0")
                    {
                        //Invoice_data.Store_id = Convert.ToInt32(GlobalStore.GlobalStore_id);
                        //Invoice_data.Type_id = PostedData.Type_id;
                        //Invoice_data.Payment_type = PostedData.Payment_type;
                        //Invoice_data.Vendor_id = PostedData.Vendor_id;
                        //Invoice_data.Invoice_Date = Convert.ToDateTime(PostedData.Invoice_Date);
                        //Invoice_data.Invoice_Number = PostedData.Invoice_Number;
                        //Invoice_data.Note = PostedData.Note;
                        //Invoice_data.IsStatus_id = PostedData.IsStatus_id;
                        //Invoice_data.ModifiedBy = fullname;
                        //Invoice_data.ModifiedOn = DateTime.Now.AddHours(1);
                        //Invoice_data.TotalAmtByDept = PostedData.TotalAmtByDept;
                        //Invoice_data.QBtransfer = PostedData.QBtransfer == "1" ? true : false;
                        ////Invoice_data.UploadInvoice = Sacn_Title;
                        ////Invoice_data.ScanInvoice = Sacn_Title;
                        //db.Entry(Invoice_data).State = System.Data.Entity.EntityState.Modified;
                        //db.SaveChanges();

                        int j = 0;
                        int dept1 = 0;
                        string amt1 = "";

                        List<int> drplst = (from a in db.tbl_Invoice_Department where a.Invoice_id == ID select a.id).ToList();

                        for (int i = 0; i < drplst.Count; i++)
                        {
                            tbl_Invoice_Department deptdata = db.tbl_Invoice_Department.Find(drplst[i]);
                            db.tbl_Invoice_Department.Remove(deptdata);
                            db.SaveChanges();
                        }
                        if (Deptid != null)
                        {
                            foreach (var val_id in Deptid)
                            {
                                tbl_Invoice_Department dataDept = new tbl_Invoice_Department();
                                try
                                {
                                    if (val_id != "")
                                    {
                                        dept1 = Convert.ToInt32(val_id);
                                        amt1 = Amt[j];
                                        var successDept = db.tbl_Invoice_Department_Insert(Convert.ToInt32(ID), dept1, Convert.ToDecimal(amt1), WebSecurity.CurrentUserName, Convert.ToDateTime(PostedData.Invoice_Date), PostedData.Invoice_Number, PostedData.TotalAmtByDept);
                                    }
                                    j++;
                                }
                                catch { }
                            }
                        }

                        //activity Log
                        ActivityLogMessage = "Invoice Note with this Invoice Number " + "<a href='/Admin/InvoiceReport/Detail/" + Invoice_data.id + "'>" + Invoice_data.Invoice_Number + "</a> Edited by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.AddHours(1).ToString());

                        var successActivity = db.tbl_Activity_log_Insert(WebSecurity.CurrentUserId, ActivityLogMessage, WebSecurity.CurrentUserName, 2);
                        #region creditmemo
                        if (PostedData.Discounttype != 1 && PostedData.Discounttype != null)
                        {
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
                                ////Credit_Invoiceno = Credit_Invoiceno + CRdiscount + "%";
                                //Credit_Invoiceno = Credit_Invoiceno + Convert.ToString(PostedData.Discountamount);
                            }
                            string sucess1 = "";
                            #region AttachNote
                            string DSacn_Title1 = "";
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
                            else
                            {

                                if (System.IO.File.Exists(Request.PhysicalApplicationPath + "userfiles\\scanimage\\" + Invoice_data.ScanInvoice))
                                {
                                    DSacn_Title = AdminSiteConfiguration.GetRandomNo() + Path.GetFileName(Invoice_data.ScanInvoice);
                                    DSacn_Title = AdminSiteConfiguration.RemoveSpecialCharacter(DSacn_Title);


                                    var path1 = Request.PhysicalApplicationPath + "userfiles\\scanimage" + "\\" + DSacn_Title1;

                                    string ExistingFile = Request.PhysicalApplicationPath + "userfiles\\scanimage\\" + Invoice_data.ScanInvoice;
                                    string NewCopy = Request.PhysicalApplicationPath + "userfiles\\scanimage" + "\\" + DSacn_Title;
                                    System.IO.File.Copy(ExistingFile, NewCopy);

                                    //#region cloudURL

                                    //GC.Collect();
                                    //string username = AdminSiteConfiguration.ClaudUsername();
                                    //string api_key = AdminSiteConfiguration.ClaudKey();
                                    //string chosenContainer = AdminSiteConfiguration.ClaudContainer();

                                    //var cloudIdentity = new CloudIdentity() { APIKey = api_key, Username = username };
                                    //var cloudFilesProvider = new CloudFilesProvider(cloudIdentity);
                                    //string uriPath = ConfigurationManager.AppSettings["cloudurl"] + "scanimage/" + Invoice_data.ScanInvoice;
                                    //string newfile = AdminSiteConfiguration.GetRandomNo() + Invoice_data.ScanInvoice;

                                    //DSacn_Title = newfile;
                                    //cloudFilesProvider.CopyObject(chosenContainer, "scanimage/" + Invoice_data.ScanInvoice, chosenContainer, "scanimage/" + DSacn_Title);

                                    //Invoice_data.UploadInvoice = AdminSiteConfiguration.GetRandomNo() + Invoice_data.ScanInvoice;
                                    //Invoice_data.ScanInvoice = AdminSiteConfiguration.GetRandomNo() + Invoice_data.ScanInvoice;
                                    //#endregion
                                }
                            }
                            string scandocument = DSacn_Title;
                            #endregion
                            int Storeidval = Invoice_data.Store_id.GetValueOrDefault();
                            int userid = Convert.ToInt32(WebSecurity.CurrentUserId);
                            string username1 = WebSecurity.CurrentUserName;
                            if ((Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Data Approver")))
                            {
                                sucess1 = db.tbl_Invoice_Insert_StoreManager_discount(Storeidval, 2, "Check/ACH", PostedData.Vendor_id, Convert.ToDateTime(PostedData.Invoice_Date), Credit_Invoiceno, PostedData.Note, "AttachNote_Title", scandocument, scandocument, 2, uid.ToString(), PostedData.Discountamount, username1, Convert.ToBoolean(PostedData.QBtransfer), PostedData.Discounttype, PostedData.Discount, PostedData.Discountamount, Convert.ToInt32(ID)).Select(x => x.ToString()).FirstOrDefault().ToString();
                            }
                            else
                            {
                                sucess1 = db.tbl_Invoice_Insert_discount(Storeidval, 2, "Check/ACH", PostedData.Vendor_id, Convert.ToDateTime(PostedData.Invoice_Date), Credit_Invoiceno, PostedData.Note, "AttachNote_Title", scandocument, scandocument, 1, uid.ToString(), PostedData.Discountamount, Convert.ToBoolean(PostedData.QBtransfer), PostedData.Discounttype, PostedData.Discount, PostedData.Discountamount, Convert.ToInt32(ID)).Select(x => x.ToString()).FirstOrDefault().ToString();
                            }
                            int invoiceid = Convert.ToInt32(ID);
                            WestZoneEntities db1 = new WestZoneEntities();
                            db1.tbl_invoice_updatediscountdata(invoiceid, PostedData.Discounttype, PostedData.Discount, PostedData.Discountamount);

                            if (!string.IsNullOrEmpty(sucess1))
                            {
                                var successDept = db.tbl_Invoice_Department_Insert(Convert.ToInt32(sucess1), PostedData.Disc_Dept_id, Convert.ToDecimal(PostedData.Discountamount), username1, Convert.ToDateTime(PostedData.Invoice_Date), PostedData.Invoice_Number, PostedData.TotalAmtByDept);
                                //activity log
                                string fullname1 = db.tbl_user.Where(x => x.Reg_userid == uid).Select(x => x.Name).FirstOrDefault();
                                ActivityLogMessage = "Invoice Number " + "<a href='/Admin/InvoiceReport/Detail/" + ID + "'>" + Credit_Invoiceno + "</a> created by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.AddHours(1).ToString());
                                //ActivityLogMessage = "Invoice Number " + PostedData.Invoice_Number + " created by " + fullname + " on " + DateTime.Today;
                                var successActivity1 = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, username1, 1);
                                // UserHub.BroadcastData();
                            }

                        }
                        #endregion
                        StatusMessage = "SuccessEdit";
                    }
                    else
                    {

                        //return RedirectToAction("Index");

                        var Status1 = "";
                        if (PostedData.RedairectFrom != "Dashboard")
                        {
                            Status1 = StatusMessage;
                            StatusMessage = "";
                            ViewBag.StatusMessage = "";
                        }

                        if (PostedData.RedairectFrom == "Dashboard")
                        {
                            return RedirectToAction("Index", new { dashbordsuccess = Status1, startdate = PostedData.startdate, enddate = PostedData.enddate, payment = PostedData.payment, Store_val = PostedData.Store_val, searchdashbord = PostedData.searchdashbord, VendorName = PostedData.SearchVendorName, AmtMaximum = PostedData.AmtMaximum, AmtMinimum = PostedData.AmtMinimum });
                        }
                        else
                        {
                            return RedirectToAction("Index", "InvoiceReport", new { dashbordsuccess = Status1, startdate = PostedData.startdate, enddate = PostedData.enddate, payment = PostedData.payment, Store_val = PostedData.Store_val, searchdashbord = PostedData.searchdashbord, VendorName = PostedData.SearchVendorName, AmtMaximum = PostedData.AmtMaximum, AmtMinimum = PostedData.AmtMinimum });
                        }
                    }
                }
                else
                {
                    StatusMessage = "Exists";
                    ViewBag.StatusMessage = StatusMessage;
                    PostedData.ExistID = exists.ToString();
                    PostedData.BindTypeList = FillDrpLstType();
                    PostedData.BindVendorList = FillDrpLstVendor();
                    PostedData.BindDepartmentList = FillDrpLstDepartment();
                    PostedData.Disc_BindDepartmentList = FillDrpLstDepartment();
                    int j = 0;
                    int dept1 = 0;
                    Decimal amt1 = 0;

                    if (Deptid != null)
                    {
                        List<tbl_Drp> dataDept = new List<tbl_Drp>();
                        foreach (var val_id in Deptid)
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
                    PostedData.Discounttypelist = (from a in db.tbl_discounttype
                                                   select new ddllist
                                                   {
                                                       Value = a.id.ToString(),
                                                       Text = a.Name,
                                                       selected_value = a.Name.Contains("NA") ? true : false
                                                   }).ToList();
                    TempData["PostedData"] = PostedData;
                    return RedirectToAction("Edit");

                    //var Status1 = "";
                    //if (PostedData.RedairectFrom != "Dashboard")
                    //{
                    //    Status1 = StatusMessage;
                    //    StatusMessage = "";
                    //    ViewBag.StatusMessage = "";
                    //}

                    //if (PostedData.RedairectFrom == "Dashboard")
                    //{
                    //    return RedirectToAction("Index", new { startdate = PostedData.startdate, enddate = PostedData.enddate, payment = PostedData.payment, Store_val = PostedData.Store_val, searchdashbord = PostedData.searchdashbord, VendorName = PostedData.SearchVendorName, AmtMaximum = PostedData.AmtMaximum, AmtMinimum = PostedData.AmtMinimum });
                    //}
                    //else
                    //{
                    //    return RedirectToAction("Index", "InvoiceReport", new { dashbordsuccess = Status1, startdate = PostedData.startdate, enddate = PostedData.enddate, payment = PostedData.payment, Store_val = PostedData.Store_val, searchdashbord = PostedData.searchdashbord, VendorName = PostedData.SearchVendorName, AmtMaximum = PostedData.AmtMaximum, AmtMinimum = PostedData.AmtMinimum });
                    //}
                }
                ViewBag.StatusMessage = StatusMessage;
                //return RedirectToAction("Index");
                var Status = "";
                if (PostedData.RedairectFrom != "Dashboard")
                {
                    Status = StatusMessage;
                    StatusMessage = "";
                    ViewBag.StatusMessage = "";
                }


                if (PostedData.RedairectFrom == "Dashboard")
                {
                    return RedirectToAction("Index", new { startdate = PostedData.startdate, enddate = PostedData.enddate, payment = PostedData.payment, Store_val = PostedData.Store_val, searchdashbord = PostedData.searchdashbord, VendorName = PostedData.SearchVendorName, AmtMaximum = PostedData.AmtMaximum, AmtMinimum = PostedData.AmtMinimum });
                }
                else
                {
                    return RedirectToAction("Index", "InvoiceReport", new { dashbordsuccess = Status, startdate = PostedData.startdate, enddate = PostedData.enddate, payment = PostedData.payment, Store_val = PostedData.Store_val, searchdashbord = PostedData.searchdashbord, VendorName = PostedData.SearchVendorName, AmtMaximum = PostedData.AmtMaximum, AmtMinimum = PostedData.AmtMinimum });
                }
            }
            else
            {
                StatusMessage = "Error";
            }

            ViewBag.StatusMessage = StatusMessage;
            return View(PostedData);
        }

        public ActionResult Delete(int Id = 0)
        {
            StatusMessage = "Error";

            tbl_Invoice Data = db.tbl_Invoice.Find(Id);
            Data.IsActive = false;
            db.Entry(Data).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            string DSacn_Title = Data.ScanInvoice;
            //#region cloudURL
            //try
            //{
            //    GC.Collect();
            //    //HRApplication\1\\BlueBrain.pdf
            //    string username = AdminSiteConfiguration.ClaudUsername();
            //    string api_key = AdminSiteConfiguration.ClaudKey();
            //    var cloudIdentity = new CloudIdentity() { APIKey = api_key, Username = username };
            //    string uriPath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\scanimage\\" + Data.ScanInvoice;
            //    var cloudFilesProvider = new CloudFilesProvider(cloudIdentity);
            //    //string folder11Container = Path.Combine("HRApplication", "1");
            //    cloudFilesProvider.DeleteObject("wsmanagementsys", "scanimage/" + Data.ScanInvoice);
            //}
            //catch (Exception e)
            //{
            //}
            // #endregion
            string foldername = Path.Combine("scanimage");
            AdminSiteConfiguration.DeleteImage(DSacn_Title, foldername);
            int uid = WebSecurity.CurrentUserId;
            string fullname = db.tbl_user.Where(x => x.Reg_userid == uid).Select(x => x.Name).FirstOrDefault();
            ActivityLogMessage = "Invoice Number " + Data.Invoice_Number + " deleted by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.ToString());
            var successActivity = db.tbl_Activity_log_Insert(WebSecurity.CurrentUserId, ActivityLogMessage, WebSecurity.CurrentUserName, 3);
            StatusMessage = "Delete";
            DeleteMessage = Data.Invoice_Number + " deleted successfully.";
            var sucessdb = db.tbl_Invoice_DeleteAndInsertintodeletehistory(Id, Data.Store_id, Data.Type_id, Data.Payment_type, Data.Vendor_id, Data.Invoice_Date, Data.Invoice_Number, Data.Note, Data.ScanInvoice, Data.AttachNote, Data.ScanInvoice, Data.IsStatus_id, Data.CreatedBy, Data.TotalAmtByDept, Data.ApproveRejectBy, Data.QBtransfer).FirstOrDefault().Value;
            ViewBag.Delete = DeleteMessage;
            return null;
        }
    }
}