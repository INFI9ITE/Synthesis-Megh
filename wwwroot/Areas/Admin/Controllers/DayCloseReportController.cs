using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using wwwroot.Areas.Admin.Models;
using wwwroot.Class;
using wwwrootBL.Entity;

namespace wwwroot.Areas.Admin.Controllers
{
    public class DayCloseReportController : Controller
    {
        protected static string StatusMessage = "";
        protected static string InsertMessage = "";
        protected static string DeleteMessage = "";
        protected static string Editmessage = "";
        protected static string ActivityLogMessage = "";
        private const int FirstPageIndex = 1;
        protected static int TotalDataCount;
        protected static Array Arr;
        protected static bool IsArray;
        protected static IEnumerable BindData;
        protected static bool IsEdit = false;
        protected static bool IsFirst = false;
        int userid = Convert.ToInt32(WebSecurity.CurrentUserId);
        string username = WebSecurity.CurrentUserName;
        WestZoneEntities db = new WestZoneEntities();
        // GET: Admin/DayCloseReport
        public ActionResult Index()
        {
            IsFirst = false;
            return View();
        }
        public ActionResult Grid(int IsBindData = 1, int currentPageIndex = 1, string orderby = "Storename", int IsAsc = 0, int PageSize = 10, int SearchRecords = 1, string Alpha = "", string startdate = "", string enddate = "", int Storeid = 0)
        {
            #region MyRegion_Array
            try
            {
                if (IsFirst == false)
                {
                    startdate = wwwroot.Class.AdminSiteConfiguration.GetDatetimeformatwithAMPM(Convert.ToString(DateTime.Now));
                    ViewBag.Startdate = startdate;
                    enddate = wwwroot.Class.AdminSiteConfiguration.GetDatetimeformatwithAMPM(Convert.ToString(DateTime.Now));
                    ViewBag.enddate = enddate;
                    IsFirst = true;
                }
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
                        if (a1.Split(':')[0].ToString() == "startdate")
                        {
                            startdate = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "enddate")
                        {
                            enddate = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "Storeid")
                        {
                            Storeid = Convert.ToInt32(a1.Split(':')[1].ToString());
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
                 ,"startdate:"+startdate
                ,"enddate:"+enddate
                ,"Storeid:" + Storeid

            };
            #endregion

            #region MyRegion_BindData
            int startIndex = ((currentPageIndex - 1) * PageSize) + 1;
            int endIndex = startIndex + PageSize - 1;

            if (IsBindData == 1 || IsEdit == true)
            {
                BindData = GetData(SearchRecords, startdate, enddate, Storeid).OfType<Dayclosereport>().ToList();
                TotalDataCount = BindData.OfType<Dayclosereport>().ToList().Count();
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
            ViewBag.startdate = startdate;
            ViewBag.enddate = enddate;
            ViewBag.StatusMessage = StatusMessage;
            ViewBag.Insert = InsertMessage;
            ViewBag.Edit = Editmessage;
            ViewBag.Delete = DeleteMessage;
            ViewBag.startindex = startIndex;
            ViewBag.Storeid = Storeid;

            if (TotalDataCount < endIndex)
            {
                ViewBag.endIndex = TotalDataCount;
            }
            else
            {
                ViewBag.endIndex = endIndex;
            }
            ViewBag.TotalDataCount = TotalDataCount;
            var ColumnName = typeof(Dayclosereport).GetProperties().Where(p => p.Name == orderby).FirstOrDefault();

            IEnumerable Data = null;
            //Response.Write(ColumnName);
            //Response.End();
            if (IsAsc == 1)
            {
                ViewBag.AscVal = 0;
                Data = BindData.OfType<Dayclosereport>().ToList().OrderBy(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            else
            {

                ViewBag.AscVal = 1;

                Data = BindData.OfType<Dayclosereport>().ToList().OrderByDescending(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            StatusMessage = "";

            ViewBag.TotalTaxAmt = BindData.OfType<Dayclosereport>().ToList().Skip(startIndex - 1).Take(PageSize).Select(x => x.TotTaxAmt).Sum();
            ViewBag.TotalNetAmt = BindData.OfType<Dayclosereport>().ToList().Skip(startIndex - 1).Take(PageSize).Select(x => x.TotNetAmt).Sum();
            // ViewBag.Pagetext = "Showing " + iStartsRecods + " to " + iEndRecord + " of " + iTotalRecords + " entries";
            List<ddllist> Lststore = new List<ddllist>();
            Lststore = FillDrpStoresearch();
            ViewBag.DataStore = Lststore;
            return View(Data);
            #endregion

        }
        #region Fill DropdownList Store
        public List<ddllist> FillDrpStoresearch()
        {
            List<ddllist> LstStore = new List<ddllist>();
            LstStore = (from a in db.tbl_user_Selectstore()
                        orderby a.Name ascending
                        select new ddllist
                        {
                            Value = a.Id.ToString(),
                            Text = a.Name
                        }).ToList();

            return LstStore;


        }
        #endregion
        private int getLastPageIndex(int PageSize)
        {
            int lastPageIndex = Convert.ToInt32(TotalDataCount) / PageSize;
            if (TotalDataCount % PageSize > 0)
                lastPageIndex += 1;
            return lastPageIndex;
        }

        private IEnumerable GetData(int SearchRecords = 0, string startdate = "", string enddate = "", int Storeid = 0)
        {
            DateTime? start_date = null;
            DateTime? end_date = null;
            try
            {
                start_date = Convert.ToDateTime(startdate).Date;
            }
            catch { }

            try
            {
                end_date = Convert.ToDateTime(enddate).Date;
            }
            catch { }
            IEnumerable RtnData = null;

            RtnData = (from data in db.tbl_DayClosereportGrid(start_date, end_date, Storeid)
                       select new Dayclosereport
                       {
                           TotNetAmt = data.NetAmount.GetValueOrDefault(),
                           TotTaxAmt = data.TaxAmount.GetValueOrDefault(),
                           Storename = data.storename,
                           Storeid = data.storeid,
                           listofterminal = (from a in db.tbl_SalesActivitySummary_Terminallist(data.storeid, start_date, end_date)
                                             select new listterminal
                                             {
                                                 Terminal = a.terminal,
                                                 TaxAmt = a.TotalTaxCollected.GetValueOrDefault(),
                                                 NetAmt = a.NetSalesWithTax.GetValueOrDefault(),

                                             }).ToList<listterminal>(),
                       }).ToList<Dayclosereport>();

            return RtnData;
        }
    }
}