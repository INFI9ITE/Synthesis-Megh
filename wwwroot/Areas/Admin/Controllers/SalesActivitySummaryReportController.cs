using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using wwwroot.Areas.Admin.Models;
using wwwroot.Class;
using wwwrootBL.Entity;

namespace wwwroot.Areas.Admin.Controllers
{
    public class SalesActivitySummaryReportController : Controller
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
        Microsoft.Office.Interop.Excel.Application excelApplication;
        Microsoft.Office.Interop.Excel.Workbook excelWorkBook;

        bool isexists = false;
        string EXCEL_PATH = "";
        // GET: Admin/SalesActivitySummaryReport
        public ActionResult Index()
        {
            IsFirst = false;
            int Storeid = 0;
            List<ddllist> Lststore = new List<ddllist>();
            Lststore = FillDrpStoresearch();
            ViewBag.DataStore = Lststore;
            if ((Convert.ToString(Session["storeid"])) != "0")
            {
                Storeid = Convert.ToInt32((Session["storeid"]));
                ViewBag.storeid = Convert.ToString(Session["storeid"]);
                ViewBag.TerminalList = null;
                ViewBag.TerminalList = (from data in db.tbl_Store_Terminal
                                        where data.Storeid == Storeid && data.IsActive == true
                                        orderby data.id ascending
                                        select new ddllist
                                        {
                                            Value = data.id.ToString(),
                                            Text = data.Terminal
                                        }).ToList();
                ViewBag.TerminalListcount = (from data in db.tbl_Store_Terminal
                                             where data.Storeid == Storeid && data.IsActive == true
                                             orderby data.id ascending
                                             select new ddllist
                                             {
                                                 Value = data.id.ToString(),
                                                 Text = data.Terminal
                                             }).ToList().Count;
            }
            else
            {
                ViewBag.TerminalList = (from data in db.tbl_Store_Terminal
                                        where data.IsActive == true
                                        orderby data.id ascending
                                        select new ddllist
                                        {
                                            Value = data.id.ToString(),
                                            Text = data.Terminal
                                        }).ToList();
                ViewBag.TerminalListcount = (from data in db.tbl_Store_Terminal
                                             where data.IsActive == true
                                             orderby data.id ascending
                                             select new ddllist
                                             {
                                                 Value = data.id.ToString(),
                                                 Text = data.Terminal
                                             }).ToList().Count;
            }
            return View();
        }

        public ActionResult Grid(int IsBindData = 1, int currentPageIndex = 1, string orderby = "Id", int IsAsc = 0, int PageSize = 50, int SearchRecords = 1, string Alpha = "", string startdate = "", string enddate = "", int Storeid = 0, int Terminalid = 0, bool IsFalse = false)
        {
            ViewBag.StatusMessage = StatusMessage;
         
            

            #region MyRegion_Array
            try
            {
                if (IsFirst == false)
                {
                    //DateTime today = DateTime.Today;
                    //DateTime Startofmonth = new DateTime(today.Year,
                    //                                      today.Month,
                    //                                     1);
                    //startdate = wwwroot.Class.AdminSiteConfiguration.GetDate1(Convert.ToString(Startofmonth));
                    ////ViewBag.Startdate = wwwroot.Class.AdminSiteConfiguration.GetDate1(Convert.ToString(startdate));

                    //DateTime endOfMonth = new DateTime(today.Year,
                    //                                   today.Month,
                    //                                   DateTime.DaysInMonth(today.Year,
                    //                                                        today.Month));

                    //enddate = wwwroot.Class.AdminSiteConfiguration.GetDate1(Convert.ToString(endOfMonth));
                    //ViewBag.enddate = wwwroot.Class.AdminSiteConfiguration.GetDate1(Convert.ToString(endOfMonth));
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
                        if (a1.Split(':')[0].ToString() == "Terminalid")
                        {
                            Terminalid = Convert.ToInt32(a1.Split(':')[1].ToString());
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
                ,"Terminalid:" + Terminalid
            };
            #endregion

            #region MyRegion_BindData
            int startIndex = ((currentPageIndex - 1) * PageSize) + 1;
            int endIndex = startIndex + PageSize - 1;
            if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
            {
                Storeid= Convert.ToInt32(Session["storeid"]);
                ViewBag.storeid = Convert.ToString(Session["storeid"]);
            }
            if (IsBindData == 1 || IsEdit == true)
            {
                BindData = GetData(SearchRecords, startdate, enddate, Storeid, Terminalid).OfType<SalesActivitySummaryreport>().ToList();
                TotalDataCount = BindData.OfType<SalesActivitySummaryreport>().ToList().Count();
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
            ViewBag.Terminalid = Terminalid;

            TempData["startdate"] = startdate;
            TempData["enddate"] = enddate;
            TempData["Storeid"] = Storeid;
            TempData["Terminalid"] = Terminalid;

            if (TotalDataCount < endIndex)
            {
                ViewBag.endIndex = TotalDataCount;
            }
            else
            {
                ViewBag.endIndex = endIndex;
            }
            ViewBag.TotalDataCount = TotalDataCount;
            var ColumnName = typeof(SalesActivitySummaryreport).GetProperties().Where(p => p.Name == orderby).FirstOrDefault();

            IEnumerable Data = null;
            //Response.Write(ColumnName);
            //Response.End();
            if (IsAsc == 1)
            {
                ViewBag.AscVal = 0;
                Data = BindData.OfType<SalesActivitySummaryreport>().ToList().OrderBy(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            else
            {

                ViewBag.AscVal = 1;

                Data = BindData.OfType<SalesActivitySummaryreport>().ToList().OrderByDescending(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            ViewBag.StatusMessage = StatusMessage;
            StatusMessage = "";
            // ViewBag.Pagetext = "Showing " + iStartsRecods + " to " + iEndRecord + " of " + iTotalRecords + " entries";
            
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

        private IEnumerable GetData(int SearchRecords = 0, string startdate = "", string enddate = "", int Storeid = 0, int Terminalid = 0)
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

            RtnData = (from data in db.tbl_SalesActivitySummary_Select(start_date, end_date, Storeid, Terminalid)
                       select new SalesActivitySummaryreport
                       {
                           Id = data.Id,
                           TransactionStartTime = data.TransactionStartTime,
                           TransactionEndTime = data.TransactionEndTime,
                           CustomerCount = Convert.ToInt32(data.CustomerCount),
                           NetSalesWithTax = data.NetSalesWithTax,
                           TotalTaxCollected = data.TotalTaxCollected,
                           AverageSale = data.AverageSale,
                           Terminal = data.Terminal,
                           Storename = data.storename,
                           Terminalid = data.Terminalid,
                           Storeid = data.Storeid,
                           StartDate = data.StartDate
                       }).ToList<SalesActivitySummaryreport>();

            return RtnData;
        }

        public ActionResult Detail(int id)
        {
            tbl_SalesActivitySummary Data = db.tbl_SalesActivitySummary.Find(id);
            Detail Storedetail = new Detail();
            Storedetail.Storename = (from data1 in db.tbl_Store
                                     where data1.Id == Data.Storeid
                                     select data1.Name).FirstOrDefault();
            Storedetail.Terminal = (from data1 in db.tbl_Store_Terminal
                                    where data1.id == Data.Terminalid
                                    select data1.Terminal).FirstOrDefault();
            Storedetail.StartDate = Data.StartDate;
            Storedetail.TransactionStartTime = Data.TransactionStartTime;
            Storedetail.TransactionEndTime = Data.TransactionEndTime;
            Storedetail.CustomerCount = Convert.ToInt32(Data.CustomerCount);
            Storedetail.NetSalesWithTax = Data.NetSalesWithTax;
            Storedetail.TotalTaxCollected = Data.TotalTaxCollected;
            Storedetail.AverageSale = Data.AverageSale;

            Storedetail.TenderList = (from a in db.tbl_TendersInDrawerbySalesActivityId(id) select new Tender { TendersTitle = a.Title, TendersAmount = Convert.ToDecimal(a.Amount) }).ToList<Tender>();
            ;
            //Storedetail.TenderList.TendersTitle = tender.Title;
            //Storedetail.TenderList.TendersAmount = tender.Amount;

            //Storedetail.DepartmentList = (from a in db.tbl_DepartmentNetSalesbySalesActivityId(id) select a).FirstOrDefault();
            Storedetail.DepartmentList = (from a in db.tbl_DepartmentNetSalesbySalesActivityId(id) select new Department { DeptNetSalesTitle = a.Title, DeptAmount = Convert.ToDecimal(a.Amount) }).ToList<Department>();

            //Storedetail.DeptNetSalesTitle = department.Title;
            //Storedetail.DeptAmount = department.Amount;

            Storedetail.Paidoutlist = (from a in db.tbl_PaidOutbySalesActivityId(id) select new paidout { PaidOutTitle = a.Title, PaidOutAmount = Convert.ToDecimal(a.Amount) }).ToList<paidout>();
            //Storedetail.PaidOutTitle = paidout.Title;
            //Storedetail.PaidOutAmount = paidout.Amount;

            return View(Storedetail);
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

        //public JsonResult bindDrpTerminalbyStoreid(int Id)
        //{

        //    var Terminaldrp = (from data in db.tbl_Store_Terminal
        //                  where data.id == Id
        //                  select new ddllist
        //                  {
        //                      Value = data.id.ToString(),
        //                      Text = data.Terminal
        //                  }).ToList();
        //    return Json(new SelectList(Terminaldrp.ToArray(), "Value", "Text"), JsonRequestBehavior.AllowGet);
        //}

        public JsonResult bindDrpTerminalbyStoreid(int id = 0)
        {
            List<ddllist> Terminal = new List<ddllist>();
            if (id == 0)
            {
                Terminal = (from data in db.tbl_Store_Terminal
                                where data.IsActive == true
                                orderby data.id ascending
                                select new ddllist
                                {
                                    Value = data.id.ToString(),
                                    Text = data.Terminal
                                }).ToList();
                ViewBag.Chaptercount = Terminal.Count();
            }
            else
            {
                Terminal = (from data in db.tbl_Store_Terminal
                                where data.Storeid == id && data.IsActive == true
                                orderby data.id ascending
                                select new ddllist
                                {
                                    Value = data.id.ToString(),
                                    Text = data.Terminal
                                }).ToList();
                ViewBag.Chaptercount = Terminal.Count();
            }            
            
            return Json(new SelectList(Terminal.ToArray(), "Value", "Text"), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int Id = 0)
        {
            tbl_SalesActivitySummary Data = db.tbl_SalesActivitySummary.Find(Id);
            db.DeleteFromtbl_Excelread_Errormsg(Data.Id);
            db.DeleteFromtbl_DepartmentNetSales(Data.Id);
            db.DeleteFromtbl_PaidOut(Data.Id);
            db.DeleteFromtbl_TendersInDrawer(Data.Id);
            db.DeleteFromtbl_Storewise_Excelupload(Data.FileName);
            db.tbl_SalesActivitySummary.Remove(Data);
            db.SaveChanges();
            StatusMessage = "Delete";
           
            return null;
        }

        public string SyncFilesdata(string date)
        {
            string suceesfalg = "";
            string store_idvalue = "";
            if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
            {
                store_idvalue = Convert.ToString(Session["storeid"]);
                ViewBag.storeid = store_idvalue;
            }
            #region download file from mail
            Chilkat.Imap imap = new Chilkat.Imap();

            // Connect to an IMAP server.
            // Use TLS
            imap.Ssl = true;
            imap.Port = 993;
            Chilkat.Global glob = new Chilkat.Global();
            // Connect to an IMAP server.
            // Use TLS
            imap.UnlockComponent("Anything for 30-day trial");
            //  glob.UnlockBundle("Start my 30-day Trial");
            imap.UnlockComponent("Hello World");
            bool success = imap.Connect("imap.gmail.com");
            if (success != true)
            {
                string kk = imap.LastErrorText;
                // return;
            }

            // Login
            var storelist = (from a in db.tbl_Store where a.EmailId != null select a).ToList();
            for (int B = 0; B <= storelist.Count - 1; B++)
            {
                string fromemail = storelist[B].EmailId;
                string emailpassword = storelist[B].Password;
                success = imap.Login(fromemail, emailpassword);

                if (success != true)
                {
                    string kk = imap.LastErrorText;
                    //return 1;
                }

                // Select an IMAP mailbox
                success = imap.SelectMailbox("Inbox");
                if (success != true)
                {
                    string kk = imap.LastErrorText;

                }
                int uid = 2014;
                bool isUid = true;
                bool fetchUids = true;

                Chilkat.MessageSet messageSet = null;
                messageSet = imap.Search("NOT SEEN", true);
                if (imap.LastMethodSuccess != true)
                {
                    string kk = imap.LastErrorText;
                }
                if (imap.LastMethodSuccess == true)
                {
                    Chilkat.EmailBundle bundle = null;
                    bundle = imap.FetchHeaders(messageSet);
                    if (bundle == null)
                    {
                        string kk = imap.LastErrorText;
                    }

                    //  Loop over the email objects...
                    int i;
                    for (i = 0; i <= bundle.MessageCount - 1; i++)
                    {
                        int mm = bundle.MessageCount;
                        Chilkat.Email email = null;

                        email = bundle.GetEmail(i);

                        //  The sender's email address and name are available
                        //  in the From, FromAddress, and FromName properties.
                        //  If the sender is "Chilkat Support <support@chilkatsoft.com",
                        //  then the From property will hold the entire string.
                        //  the FromName property contains"Chilkat Support",
                        //  and the FromAddress property contains "support@chilkatsoft.com";
                        if (email != null)
                        {
                            //Console.WriteLine(email.From);
                            //Console.WriteLine(email.FromAddress);
                            //Console.WriteLine(email.FromName);

                            //  Assume at this point your code checks to see if the sender
                            //  is one in your contacts database.  If so, this is
                            //  the code you would write to download the entire
                            //  email and save it to a file.

                            //  The ckx-imap-uid header field is added when
                            //  headers are downloaded.  This makes it possible
                            //  to get the UID from the email object.
                            string uidStr = email.GetHeaderField("ckx-imap-uid");
                            int uid1 = Convert.ToInt32(uidStr);

                            Chilkat.Email fullEmail = null;

                            fullEmail = imap.FetchSingle(uid1, true);
                            if (!(fullEmail == null))
                            {


                                string storeid = "";
                                int store_id = 0;


                                storeid = Convert.ToString(storelist[B].Id);

                                int m = fullEmail.NumAttachments;
                                if (m > 0)
                                {

                                    //insert store wise Excel in table 

                                    if (!string.IsNullOrEmpty(storeid))
                                    {
                                        store_id = Convert.ToInt32(storeid);

                                    }
                                    //For saving indiviual attachements
                                    for (int j = 0; j < m; j++)
                                    {
                                        var random = new Random();
                                        int randomnumber = random.Next();
                                        fullEmail.GetAttachmentFilename(j);

                                        var sucess = db.tbl_Storewise_Excelupload_insert(store_id, randomnumber + imap.GetMailAttachFilename(email, j));
                                        //if (System.IO.Directory.Exists(Server.MapPath("~\\Userfiles\\Pending\\" + DateTime.Now.ToString("ddMMyyyy"))))
                                        //{
                                        //    fullEmail.SaveAttachedFile(j, Server.MapPath("~\\Userfiles\\Pending\\"));
                                        //    System.IO.File.Move(Server.MapPath("~\\Userfiles\\Pending\\" + imap.GetMailAttachFilename(email, j)), Server.MapPath("~\\Userfiles\\Pending\\" + DateTime.Now.ToString("ddMMyyyy") + "\\" + DateTime.Now.ToString("ddMMyyyyhhmmss") + imap.GetMailAttachFilename(email, j)));
                                        //}
                                        //else
                                        // {
                                        // System.IO.Directory.CreateDirectory(Server.MapPath("~\\Userfiles\\Pending\\" + DateTime.Now.ToString("ddMMyyyy")));
                                        // fullEmail.SaveAttachedFile(j, Server.MapPath("~\\Userfiles\\Pending\\" + randomnumber + imap.GetMailAttachFilename(email, j)));
                                        fullEmail.SetAttachmentFilename(j, Server.MapPath("~\\Userfiles\\Pending\\" + randomnumber + imap.GetMailAttachFilename(email, j)));
                                        fullEmail.SaveAttachedFile(j, Server.MapPath("~\\Userfiles\\Pending\\"));
                                        //System.IO.File.Move(Server.MapPath("~\\Userfiles\\Pending\\" + imap.GetMailAttachFilename(email, j)), Server.MapPath("~\\Userfiles\\Pending\\" + DateTime.Now.ToString("ddMMyyyy") + "\\" + DateTime.Now.ToString("ddMMyyyyhhmmss") + imap.GetMailAttachFilename(email, j)));

                                        //success = fullEmail.SetAttachmentFilename(j, Server.MapPath("~\\files\\" + email.EmailDate.ToShortDateString()) + "\\" + imap.GetMailAttachFilename(email, j));
                                        // }
                                    }
                                }





                            }
                        }
                    }
                }

                // Disconnect from the IMAP server.
                success = imap.Disconnect();
            }
            #endregion
            #region syndata in database
            ReadExcelFile(store_idvalue);
            #endregion
            return suceesfalg;
        }

        private void ReadExcelFile(string storeidval)
        {
            tbl_ExcelRead tbl_ExcelRead = new tbl_ExcelRead();
            //string EXCEL_PATH = Request.PhysicalApplicationPath + "Userfiles/Data.xls";
            var Exceldata = (from a in db.tbl_Storewise_Excelupload where a.issync == 0 orderby a.id ascending select a).Take(20).ToList(); 
            string EXCEL_PATH1 = Request.PhysicalApplicationPath + "Userfiles\\Pending\\";
            foreach (var Filedata in Exceldata)
            {
                //FileInfo info = new FileInfo(files);
                //var fileName = Path.GetFileName(info.FullName);
                var fileName = Filedata.filename;
                EXCEL_PATH = Request.PhysicalApplicationPath + "Userfiles\\Pending\\" + fileName;
                int store_idval = 0;
                store_idval = Convert.ToInt32(Filedata.Storeid);
                if (!EXCEL_PATH.EndsWith(".xls"))
                {

                    tbl_ExcelRead.Filename = Filedata.filename;


                    //store_idval = (from a in db.tbl_Storewise_Excelupload where a.filename == fileName select a.Storeid).FirstOrDefault().GetValueOrDefault();
                    tbl_ExcelRead.Excelreadate = DateTime.Now;
                    tbl_ExcelRead.CreatedDate = DateTime.Now;
                    tbl_ExcelRead.Type = 2;
                    db.tbl_ExcelRead.Add(tbl_ExcelRead);
                    db.SaveChanges();
                    tbl_Excelread_Errormsg tbl_Excelread_Errormsg = new tbl_Excelread_Errormsg();
                    tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                    tbl_Excelread_Errormsg.ErrorMessage = "Invalid File";
                    db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                    db.SaveChanges();
                    int idval = Filedata.id;
                    WestZoneEntities db1 = new WestZoneEntities();
                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                    break;
                }

                // System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
                excelApplication = new Application();
                //Opening/Loading the workBook in memory
                excelWorkBook = excelApplication.Workbooks.Open(EXCEL_PATH);

                //retrieving the worksheet counts inside the excel workbook
                int workSheetCounts = excelWorkBook.Worksheets.Count;
                int totalColumns = 0;
                Range objRange = null;
                var masterEntry = new Dictionary<string, string>();
                var TendersDrawer = new Dictionary<string, string>();
                var DepartmentSales = new Dictionary<string, string>();
                var Paidoutreports = new Dictionary<string, string>();
                string tablename = "";
                int rowcount = 0;
                int columncount = 0;
                int IsMain = 0;
                try
                {
                    for (int sheetCounter = 1; sheetCounter <= workSheetCounts; sheetCounter++)
                    {
                        Worksheet workSheet = excelWorkBook.Sheets[sheetCounter];
                        totalColumns = workSheet.UsedRange.Cells.Columns.Count + 1;
                        object[] data = null;

                        //Iterating from row 2 because first row contains HeaderNames
                        for (int row = 1; row < workSheet.UsedRange.Cells.Rows.Count; row++)
                        {
                            data = new object[totalColumns - 1];
                            int hasdata = 0;
                            for (int col = 1; col < totalColumns; col++)
                            {
                                objRange = workSheet.Cells[row, col];
                                rowcount = row;
                                columncount = col;
                                if (objRange.MergeCells)
                                {
                                    string columnValue = Convert.ToString(((Range)objRange.MergeArea[1, 1]).Text).Trim();
                                    if (columnValue == "Tenders In Drawer Report")
                                    {
                                        tablename = "TendersDrawer";
                                    }
                                    if (columnValue == "Tenders In DrawerTotals")
                                    {
                                        tablename = "";
                                    }
                                    if (columnValue == "Department Net Sales Report")
                                    {
                                        tablename = "DepartmentSales";
                                    }
                                    if (columnValue == "Net Sales for Departments Listed")
                                    {
                                        tablename = "";
                                    }
                                    if (columnValue == "Paid Out Report")
                                    {
                                        tablename = "Paidoutreports";
                                    }
                                    if (columnValue == "Paid Out Totals")
                                    {
                                        tablename = "";
                                    }
                                    if (!data.ToList().Contains(columnValue))
                                    {
                                        if (columnValue.Contains("Transaction End Time") && !masterEntry.Keys.Contains("Transaction End Time"))
                                        {
                                            int terminalindex = columnValue.IndexOf("Terminal:");
                                            masterEntry.Add("Transaction End Time", columnValue.Substring(0, 70).Replace("Transaction End Time:", "").Trim());
                                            masterEntry.Add("Terminal", columnValue.Substring(70).Replace("Terminal:", "").Trim());
                                            masterEntry.Add("ROWtransection time", rowcount.ToString());
                                            masterEntry.Add("Columntransection time", columncount.ToString());
                                        }
                                        hasdata++;
                                        data[hasdata - 1] = columnValue;
                                    }
                                }
                                else
                                {
                                    string columnValue = Convert.ToString(objRange.Text).Trim();
                                    //if (Convert.ToString(objRange.Text).Trim() != "")
                                    //{
                                    //    hasdata++;
                                    //    data[hasdata - 1] = Convert.ToString(objRange.Text).Trim();
                                    //}
                                    if (columnValue == "Tenders In Drawer Report")
                                    {
                                        tablename = "TendersDrawer";
                                    }
                                    if (columnValue == "Tenders In DrawerTotals")
                                    {
                                        tablename = "";
                                    }
                                    if (columnValue == "Department Net Sales Report")
                                    {
                                        tablename = "DepartmentSales";
                                    }
                                    if (columnValue == "Net Sales for Departments Listed")
                                    {
                                        tablename = "";
                                    }
                                    if (columnValue == "Paid Out Report")
                                    {
                                        tablename = "Paidoutreports";
                                    }
                                    if (columnValue == "Paid Out Totals")
                                    {
                                        tablename = "";
                                    }
                                    if (!data.ToList().Contains(columnValue))
                                    {
                                        if (columnValue.Contains("Transaction End Time") && !masterEntry.Keys.Contains("Transaction End Time"))
                                        {
                                            int terminalindex = columnValue.IndexOf("Terminal:");
                                            masterEntry.Add("Transaction End Time", columnValue.Substring(0, 70).Replace("Transaction End Time:", "").Trim());
                                            masterEntry.Add("Terminal", columnValue.Substring(70).Replace("Terminal:", "").Trim());
                                            masterEntry.Add("ROWtransection time", rowcount.ToString());
                                            masterEntry.Add("Columntransection time", columncount.ToString());
                                        }
                                        hasdata++;
                                        data[hasdata - 1] = columnValue;
                                    }
                                }
                            }
                            int elementcount = 0;

                            foreach (object element in data)
                            {
                                if (element != null) // Avoid NullReferenceException
                                {
                                    if (element.ToString().Contains("Customer Count") && !masterEntry.Keys.Contains("Customer Count"))
                                    {
                                        if (data[elementcount + 1] != null)
                                        {
                                            masterEntry.Add("Customer Count", data[elementcount + 1].ToString());
                                            masterEntry.Add("ROWCustomer Count", rowcount.ToString());
                                            masterEntry.Add("ColCustomer Count", columncount.ToString());
                                        }
                                    }
                                    if (element.ToString().Contains("Net Sales With Tax") && !masterEntry.Keys.Contains("Net Sales With Tax"))
                                    {
                                        if (data[elementcount + 1] != null)
                                        {
                                            masterEntry.Add("Net Sales With Tax", data[elementcount + 2].ToString());
                                            masterEntry.Add("Net Sales With Tax Row", rowcount.ToString());
                                            masterEntry.Add("Net Sales With Tax Col", columncount.ToString());
                                        }
                                    }
                                    if (element.ToString().Contains("Total Tax Collected") && !masterEntry.Keys.Contains("Total Tax Collected"))
                                    {
                                        if (data[elementcount + 1] != null)
                                        {
                                            masterEntry.Add("Total Tax Collected", data[elementcount + 2].ToString());
                                            masterEntry.Add("Total Tax Collected Row", rowcount.ToString());
                                            masterEntry.Add("Total Tax Collected Col", columncount.ToString());
                                        }
                                    }
                                    if (element.ToString().Contains("Average Sale") && !masterEntry.Keys.Contains("Average Sale"))
                                    {
                                        if (data[elementcount + 1] != null)
                                        {
                                            masterEntry.Add("Average Sale", data[elementcount + 1].ToString());
                                            masterEntry.Add("Average Sale Row", rowcount.ToString());
                                            masterEntry.Add("Average Sale Col", columncount.ToString());
                                        }
                                    }
                                    if (tablename == "TendersDrawer")
                                    {
                                        if (element.ToString() != "Tenders In Drawer Report")
                                        {
                                            if (!TendersDrawer.Keys.Contains(element.ToString()) && element.ToString() != "" && element.ToString() != "Quantity")
                                            {
                                                if (data[elementcount + 1] != null)
                                                {
                                                    TendersDrawer.Add(data[elementcount].ToString(), data[elementcount + 1].ToString());

                                                    break;
                                                }
                                                else
                                                {
                                                    if (IsMain != 1)
                                                    {
                                                        tbl_ExcelRead.Filename = fileName;
                                                        tbl_ExcelRead.Excelreadate = DateTime.Now;
                                                        tbl_ExcelRead.CreatedDate = DateTime.Now;
                                                        db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                                        db.SaveChanges();
                                                        IsMain = 1;
                                                    }
                                                    tbl_Excelread_Errormsg tbl_Excelread_Errormsg = new tbl_Excelread_Errormsg();
                                                    tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                    tbl_Excelread_Errormsg.RowNo = rowcount;
                                                    tbl_Excelread_Errormsg.ColumnNo = columncount;
                                                    tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + rowcount + ", Column No: " + columncount + ", " + "'" + data[elementcount].ToString() + "'" + " is Invalid.";
                                                    db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                    db.SaveChanges();
                                                    int idval = Filedata.id;
                                                    WestZoneEntities db1 = new WestZoneEntities();
                                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                                }
                                            }

                                        }
                                    }
                                    if (tablename == "DepartmentSales")
                                    {
                                        if (element.ToString() != "Department Net Sales Report")
                                        {
                                            if (!DepartmentSales.Keys.Contains(element.ToString()) && element.ToString() != "" && element.ToString() != "Department Name" && element.ToString() != "(Net Sales include Negative Total and Discount, without Tax)")
                                            {
                                                if (data[elementcount + 1] != null)
                                                {
                                                    DepartmentSales.Add(data[elementcount].ToString(), data[elementcount + 1].ToString());
                                                    break;
                                                }
                                                else
                                                {
                                                    if (data[elementcount].ToString() != "Net Sales")
                                                    {
                                                        if (IsMain != 1)
                                                        {
                                                            tbl_ExcelRead.Filename = fileName;
                                                            tbl_ExcelRead.Excelreadate = DateTime.Now;
                                                            tbl_ExcelRead.CreatedDate = DateTime.Now;
                                                            db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                                            db.SaveChanges();
                                                            IsMain = 1;
                                                        }
                                                        tbl_Excelread_Errormsg tbl_Excelread_Errormsg = new tbl_Excelread_Errormsg();
                                                        tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                        tbl_Excelread_Errormsg.RowNo = rowcount;
                                                        tbl_Excelread_Errormsg.ColumnNo = columncount;
                                                        tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + rowcount + ", Column No: " + columncount + ", " + "'" + data[elementcount].ToString() + "'" + " is Invalid.";
                                                        db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                        db.SaveChanges();
                                                        int idval = Filedata.id;
                                                        WestZoneEntities db1 = new WestZoneEntities();
                                                        var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (tablename == "Paidoutreports")
                                    {
                                        if (element.ToString() != "Paid Out Report")
                                        {
                                            if (!Paidoutreports.Keys.Contains(element.ToString()) && element.ToString() != "" && element.ToString() != "Quantity")
                                            {
                                                if (data[elementcount + 1] != null)
                                                {
                                                    Paidoutreports.Add(data[elementcount].ToString(), data[elementcount + 1].ToString());
                                                    break;
                                                }
                                                else
                                                {
                                                    if (IsMain != 1)
                                                    {
                                                        tbl_ExcelRead.Filename = fileName;
                                                        tbl_ExcelRead.Excelreadate = DateTime.Now;
                                                        tbl_ExcelRead.CreatedDate = DateTime.Now;
                                                        db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                                        db.SaveChanges();
                                                        IsMain = 1;
                                                    }
                                                    tbl_Excelread_Errormsg tbl_Excelread_Errormsg = new tbl_Excelread_Errormsg();
                                                    tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                    tbl_Excelread_Errormsg.RowNo = rowcount;
                                                    tbl_Excelread_Errormsg.ColumnNo = columncount;
                                                    tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + rowcount + ", Column No: " + columncount + ", " + "'" + data[elementcount].ToString() + "'" + " is Invalid.";
                                                    db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                    db.SaveChanges();
                                                    int idval = Filedata.id;
                                                    WestZoneEntities db1 = new WestZoneEntities();
                                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                                }
                                            }
                                        }
                                    }
                                    //Response.Write(element.ToString());
                                    //Response.Write("-------------------------------");
                                }
                                elementcount++;
                            }
                            //if (hasdata > 0)
                            //{
                            //    Response.Write("<br/>");
                            //}

                        }

                        string userid = "0";

                        int isflagtime = 0, timerowno = 0, timecolno = 0;
                        int isflagTerminal = 0, Terminalrowno = 0, Terminalcolno = 0;
                        int isflagColCount = 0, ColCountrowno = 0, ColCountcolno = 0;
                        int isflagColNetSales = 0, NetSalesrowno = 0, NetSalescolno = 0;
                        int isflagColTotTax = 0, TotTaxrowno = 0, TotTaxcolno = 0;
                        int isflagColAvgTax = 0, AvgTaxrowno = 0, AvgTaxcolno = 0;

                        //string TenderindrawkeyRow = "",TenderindrawkeyCol = "";
                        string[] specialCharacters = new string[] { "$", ",", "(", ")" };
                        tbl_SalesActivitySummary ObjSalesactivitysummary = new tbl_SalesActivitySummary();
                        foreach (var kvp in masterEntry)
                        {
                            if (kvp.Key == "Transaction End Time")
                            {
                                try
                                {
                                    string StartDate = kvp.Value.Substring(0, 19);
                                    string endDate = kvp.Value.Substring(kvp.Value.LastIndexOf("-") + 2, 19);

                                    DateTime Sdt = DateTime.ParseExact(StartDate, "MM/dd/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                                    DateTime Edt = DateTime.ParseExact(endDate, "MM/dd/yyyy hh:mm:ss", CultureInfo.InvariantCulture);

                                    string[] dtarray = StartDate.Split('/');
                                    string[] dtarray2 = endDate.Split('/');

                                    string SHours = dtarray[2].Substring(5, 2);
                                    string EHours = dtarray2[2].Substring(5, 2);

                                    DateTime? DateS = Convert.ToDateTime(wwwroot.Class.AdminSiteConfiguration.GetDate24HoursFormatMMMDD(Convert.ToString(Sdt)));
                                    DateTime? DateE = Convert.ToDateTime(wwwroot.Class.AdminSiteConfiguration.GetDate24HoursFormatMMMDD(Convert.ToString(Edt)));

                                    string STime = kvp.Value.Substring(20, 2);
                                    string ETime = kvp.Value.Substring(kvp.Value.LastIndexOf("-") + 22, 2);
                                    DateTime SD;
                                    DateTime ED;
                                    if (STime == "PM" || STime == "Pm" || STime == "pm")
                                    {
                                        SD = Convert.ToDateTime(DateS).AddHours(12);
                                    }
                                    //else if (STime == "AM" || STime == "Am" || STime == "am" && SHours == "12")
                                    //{
                                    //    SD = Convert.ToDateTime(DateS).AddHours(-12);
                                    //}
                                    else
                                    {
                                        SD = Convert.ToDateTime(DateS);
                                    }

                                    if (ETime == "PM" || ETime == "Pm" || ETime == "pm")
                                    {
                                        ED = Convert.ToDateTime(DateE).AddHours(12);
                                    }
                                    //else if (ETime == "AM" || ETime == "Am" || ETime == "am" && EHours == "12")
                                    //{
                                    //    ED = Convert.ToDateTime(DateE).AddHours(-12);
                                    //}
                                    else
                                    {
                                        ED = Convert.ToDateTime(DateE);
                                    }

                                    //Convert.ToString(DateTime.ParseExact(StartDate, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
                                    //string datechanged = dtarray[0] + "/" + dtarray[1] + "/" + dtarray[2];
                                    //string datechanged2 = dtarray2[0] + "/" + dtarray2[1] + "/" + dtarray2[2];

                                    string datechanged = wwwroot.Class.AdminSiteConfiguration.GetDate24HoursFormatMMMDD(Convert.ToString(SD));
                                    string datechanged2 = wwwroot.Class.AdminSiteConfiguration.GetDate24HoursFormatMMMDD(Convert.ToString(ED));
                                    try
                                    {
                                        if ((!string.IsNullOrEmpty(datechanged)) && (!string.IsNullOrEmpty(datechanged2)))
                                        {
                                            ObjSalesactivitysummary.StartDate = Convert.ToDateTime(datechanged);
                                            //ObjSalesactivitysummary.TransactionStartTime = Convert.ToDateTime(datechanged);
                                            ObjSalesactivitysummary.TransactionEndTime = Convert.ToDateTime(datechanged2);
                                            ObjSalesactivitysummary.shiftname = "Shift#";
                                            if (STime == "AM" && ETime == "AM")
                                            {
                                                ObjSalesactivitysummary.TransactionStartTime = Convert.ToDateTime(datechanged);
                                            }
                                            else if (STime == "PM" && ETime == "PM")
                                            {
                                                ObjSalesactivitysummary.TransactionStartTime = Convert.ToDateTime(datechanged2);
                                            }
                                            else if (STime == "AM" && ETime == "PM")
                                            {
                                                ObjSalesactivitysummary.TransactionStartTime = Convert.ToDateTime(datechanged);
                                            }
                                            else if (STime == "PM" && ETime == "AM")
                                            {
                                                ObjSalesactivitysummary.TransactionStartTime = Convert.ToDateTime(datechanged2);
                                            }
                                            else
                                            {
                                                ObjSalesactivitysummary.TransactionStartTime = Convert.ToDateTime(datechanged);
                                            }
                                        }
                                        else
                                        {
                                            isflagtime = 1;

                                        }
                                    }
                                    catch
                                    {
                                        isflagtime = 1;
                                        int idval = Filedata.id;
                                        WestZoneEntities db1 = new WestZoneEntities();
                                        var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                    }
                                }
                                catch
                                {
                                    isflagtime = 1;                                    int idval = Filedata.id;                                    WestZoneEntities db1 = new WestZoneEntities();
                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                }                            }
                            if (kvp.Key == "Terminal")
                            {
                                var storeid = store_idval;
                                var terminalid = (from a in db.tbl_Store_Terminal
                                                  where a.Terminal == kvp.Value && a.IsActive == true
                                                  select a.id).FirstOrDefault();
                                if (Convert.ToString(terminalid) == "0")
                                {
                                    var terminalsucess = db.tbl_Store_Terminal_Insert(storeid, kvp.Value, "").FirstOrDefault().Value;
                                    if (terminalsucess > 0)
                                    {
                                        terminalid = Convert.ToInt32(terminalsucess);
                                    }
                                }
                                try
                                {
                                    if ((!string.IsNullOrEmpty(terminalid.ToString())) && (!string.IsNullOrEmpty(storeid.ToString())))
                                    {
                                        ObjSalesactivitysummary.Terminalid = terminalid;
                                        ObjSalesactivitysummary.Storeid = storeid;
                                    }
                                    else
                                    {
                                        isflagTerminal = 1;
                                    }
                                }
                                catch
                                {
                                    isflagTerminal = 1;
                                    int idval = Filedata.id;
                                    WestZoneEntities db1 = new WestZoneEntities();
                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                }
                                var exist = db.tbl_SalesActivitySummary_Excelread_exists(ObjSalesactivitysummary.StartDate, ObjSalesactivitysummary.Terminalid, ObjSalesactivitysummary.Storeid).Select(x => x.Id).FirstOrDefault();
                                if (exist == 0)
                                {
                                    isexists = true;
                                }
                                else
                                {
                                    isexists = false;
                                }
                            }
                            if (kvp.Key == "Customer Count")
                            {
                                string Customercount = kvp.Value;
                                for (int i = 0; i < specialCharacters.Length; i++)
                                {
                                    if (kvp.Value.Contains(specialCharacters[i]))
                                    {
                                        Customercount = Customercount.Replace(specialCharacters[i], "");
                                    }
                                }
                                try
                                {
                                    if (!string.IsNullOrEmpty(Customercount))
                                    {
                                        ObjSalesactivitysummary.CustomerCount = Convert.ToDecimal(Customercount);

                                    }
                                    else
                                    {
                                        isflagColCount = 1;
                                    }
                                }
                                catch
                                {
                                    isflagColCount = 1;
                                    int idval = Filedata.id;
                                    WestZoneEntities db1 = new WestZoneEntities();
                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                }
                            }
                            if (kvp.Key == "Net Sales With Tax")
                            {
                                string NetSalesWithTax = kvp.Value;
                                for (int i = 0; i < specialCharacters.Length; i++)
                                {
                                    if (kvp.Value.Contains(specialCharacters[i]))
                                    {
                                        NetSalesWithTax = NetSalesWithTax.Replace(specialCharacters[i], "");
                                    }
                                }
                                try
                                {
                                    if (!string.IsNullOrEmpty(NetSalesWithTax))
                                    {
                                        ObjSalesactivitysummary.NetSalesWithTax = Convert.ToDecimal(NetSalesWithTax);

                                    }
                                    else
                                    {
                                        isflagColNetSales = 1;
                                    }
                                }
                                catch
                                {
                                    isflagColNetSales = 1;
                                    int idval = Filedata.id;
                                    WestZoneEntities db1 = new WestZoneEntities();
                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                }
                            }
                            if (kvp.Key == "Total Tax Collected")
                            {
                                string TotalTaxCollected = kvp.Value;
                                for (int i = 0; i < specialCharacters.Length; i++)
                                {
                                    if (kvp.Value.Contains(specialCharacters[i]))
                                    {
                                        TotalTaxCollected = TotalTaxCollected.Replace(specialCharacters[i], "");
                                    }
                                }
                                try
                                {
                                    if (!string.IsNullOrEmpty(TotalTaxCollected))
                                    {
                                        ObjSalesactivitysummary.TotalTaxCollected = Convert.ToDecimal(TotalTaxCollected);
                                        //isflagColTotTax = 1;
                                    }
                                    else
                                    {
                                        isflagColTotTax = 1;
                                    }
                                }
                                catch
                                {
                                    isflagColTotTax = 1;
                                    int idval = Filedata.id;
                                    WestZoneEntities db1 = new WestZoneEntities();
                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                }
                            }

                            if (kvp.Key == "Average Sale")
                            {
                                string AverageSale = kvp.Value;
                                for (int i = 0; i < specialCharacters.Length; i++)
                                {
                                    if (kvp.Value.Contains(specialCharacters[i]))
                                    {
                                        AverageSale = AverageSale.Replace(specialCharacters[i], "");
                                    }
                                }
                                try
                                {
                                    if (!string.IsNullOrEmpty(AverageSale))
                                    {
                                        ObjSalesactivitysummary.AverageSale = Convert.ToDecimal(AverageSale);
                                    }
                                    else
                                    {
                                        isflagColAvgTax = 1;
                                    }
                                }
                                catch
                                {
                                    isflagColAvgTax = 1;
                                    int idval = Filedata.id;
                                    WestZoneEntities db1 = new WestZoneEntities();
                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                }
                            }
                            //else
                            //{
                            //    ObjSalesactivitysummary.AverageSale = Convert.ToDecimal("0.00");
                            //}

                            if (isflagtime == 1)
                            {
                                if (kvp.Key == "ROWtransection time")
                                {
                                    timerowno = Convert.ToInt32(kvp.Value);
                                }
                                if (kvp.Key == "Columntransection time")
                                {
                                    timecolno = Convert.ToInt32(kvp.Value);
                                }
                                if (timerowno != 0 && timecolno != 0)
                                {
                                    if (IsMain != 1)
                                    {
                                        tbl_ExcelRead.Filename = fileName;
                                        tbl_ExcelRead.Excelreadate = DateTime.Now;
                                        tbl_ExcelRead.CreatedDate = DateTime.Now;
                                        db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                        db.SaveChanges();
                                        IsMain = 1;
                                    }
                                    tbl_Excelread_Errormsg tbl_Excelread_Errormsg = new tbl_Excelread_Errormsg();
                                    tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                    tbl_Excelread_Errormsg.RowNo = timerowno;
                                    tbl_Excelread_Errormsg.ColumnNo = timecolno;
                                    tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + timerowno + ", Column No: " + timecolno + ", " + "'" + " Transaction end time" + "'" + " is Invalid.";
                                    db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                    db.SaveChanges();
                                    int idval = Filedata.id;
                                    WestZoneEntities db1 = new WestZoneEntities();
                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                    timerowno = 0;
                                    timecolno = 0;

                                }
                            }

                            if (isflagTerminal == 1)
                            {
                                if (kvp.Key == "ROWtransection time")
                                {
                                    Terminalrowno = Convert.ToInt32(kvp.Value);
                                }
                                if (kvp.Key == "Columntransection time")
                                {
                                    Terminalcolno = Convert.ToInt32(kvp.Value);
                                }
                                if (Terminalrowno != 0 && Terminalcolno != 0)
                                {
                                    if (IsMain != 1)
                                    {
                                        tbl_ExcelRead.Filename = fileName;
                                        tbl_ExcelRead.Excelreadate = DateTime.Now;
                                        tbl_ExcelRead.CreatedDate = DateTime.Now;
                                        db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                        db.SaveChanges();
                                        IsMain = 1;
                                    }
                                    tbl_Excelread_Errormsg tbl_Excelread_Errormsg = new tbl_Excelread_Errormsg();
                                    tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                    tbl_Excelread_Errormsg.RowNo = Terminalrowno;
                                    tbl_Excelread_Errormsg.ColumnNo = Terminalcolno;
                                    tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + Terminalrowno + ", Column No: " + Terminalcolno + ", " + "'" + " Terminal" + "'" + " is Invalid.";
                                    db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                    db.SaveChanges();
                                    int idval = Filedata.id;
                                    WestZoneEntities db1 = new WestZoneEntities();
                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                    Terminalrowno = 0;
                                    Terminalcolno = 0;

                                }
                            }

                            if (isflagColCount == 1)
                            {
                                if (kvp.Key == "ROWCustomer Count")
                                {
                                    ColCountrowno = Convert.ToInt32(kvp.Value);
                                }
                                if (kvp.Key == "ColCustomer Count")
                                {
                                    ColCountcolno = Convert.ToInt32(kvp.Value);
                                }
                                if (ColCountrowno != 0 && ColCountcolno != 0)
                                {
                                    if (IsMain != 1)
                                    {
                                        tbl_ExcelRead.Filename = fileName;
                                        tbl_ExcelRead.Excelreadate = DateTime.Now;
                                        tbl_ExcelRead.CreatedDate = DateTime.Now;
                                        db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                        db.SaveChanges();
                                        IsMain = 1;
                                    }
                                    tbl_Excelread_Errormsg tbl_Excelread_Errormsg = new tbl_Excelread_Errormsg();
                                    tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                    tbl_Excelread_Errormsg.RowNo = ColCountrowno;
                                    tbl_Excelread_Errormsg.ColumnNo = ColCountcolno;
                                    tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + ColCountrowno + ", Column No: " + ColCountcolno + ", " + "'" + " Customer Count" + "'" + " is Invalid.";
                                    db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                    db.SaveChanges();
                                    int idval = Filedata.id;
                                    WestZoneEntities db1 = new WestZoneEntities();
                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                    ColCountrowno = 0;
                                    ColCountcolno = 0;

                                }
                            }

                            if (isflagColNetSales == 1)
                            {
                                if (kvp.Key == "Net Sales With Tax Row")
                                {
                                    NetSalesrowno = Convert.ToInt32(kvp.Value);
                                }
                                if (kvp.Key == "Net Sales With Tax Col")
                                {
                                    NetSalescolno = Convert.ToInt32(kvp.Value);
                                }
                                if (NetSalesrowno != 0 && NetSalescolno != 0)
                                {
                                    if (IsMain != 1)
                                    {
                                        tbl_ExcelRead.Filename = fileName;
                                        tbl_ExcelRead.Excelreadate = DateTime.Now;
                                        tbl_ExcelRead.CreatedDate = DateTime.Now;
                                        db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                        db.SaveChanges();
                                        IsMain = 1;
                                    }
                                    tbl_Excelread_Errormsg tbl_Excelread_Errormsg = new tbl_Excelread_Errormsg();
                                    tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                    tbl_Excelread_Errormsg.RowNo = NetSalesrowno;
                                    tbl_Excelread_Errormsg.ColumnNo = NetSalescolno;
                                    tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + NetSalesrowno + ", Column No: " + NetSalescolno + ", " + "'" + " Net Sales With Tax" + "'" + " is Invalid.";
                                    db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                    db.SaveChanges();
                                    int idval = Filedata.id;
                                    WestZoneEntities db1 = new WestZoneEntities();
                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                    NetSalesrowno = 0;
                                    NetSalescolno = 0;

                                }
                            }

                            if (isflagColTotTax == 1)
                            {
                                if (kvp.Key == "Total Tax Collected Row")
                                {
                                    TotTaxrowno = Convert.ToInt32(kvp.Value);
                                }
                                if (kvp.Key == "Total Tax Collected Col")
                                {
                                    TotTaxcolno = Convert.ToInt32(kvp.Value);
                                }
                                if (TotTaxrowno != 0 && TotTaxcolno != 0)
                                {
                                    if (IsMain != 1)
                                    {
                                        tbl_ExcelRead.Filename = fileName;
                                        tbl_ExcelRead.Excelreadate = DateTime.Now;
                                        tbl_ExcelRead.CreatedDate = DateTime.Now;
                                        db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                        db.SaveChanges();
                                        IsMain = 1;
                                    }
                                    tbl_Excelread_Errormsg tbl_Excelread_Errormsg = new tbl_Excelread_Errormsg();
                                    tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                    tbl_Excelread_Errormsg.RowNo = TotTaxrowno;
                                    tbl_Excelread_Errormsg.ColumnNo = TotTaxcolno;
                                    tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + TotTaxrowno + ", Column No: " + TotTaxcolno + ", " + "'" + " Total Tax Collected" + "'" + " is Invalid.";
                                    db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                    db.SaveChanges();
                                    int idval = Filedata.id;
                                    WestZoneEntities db1 = new WestZoneEntities();
                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                    TotTaxrowno = 0;
                                    TotTaxcolno = 0;

                                }
                            }

                            if (isflagColAvgTax == 1)
                            {
                                if (kvp.Key == "Average Sale Row")
                                {
                                    AvgTaxrowno = Convert.ToInt32(kvp.Value);
                                }
                                if (kvp.Key == "Average Sale Col")
                                {
                                    AvgTaxcolno = Convert.ToInt32(kvp.Value);
                                }
                                if (AvgTaxrowno != 0 && AvgTaxcolno != 0)
                                {
                                    if (IsMain != 1)
                                    {
                                        tbl_ExcelRead.Filename = fileName;
                                        tbl_ExcelRead.Excelreadate = DateTime.Now;
                                        tbl_ExcelRead.CreatedDate = DateTime.Now;
                                        db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                        db.SaveChanges();
                                        IsMain = 1;
                                    }
                                    tbl_Excelread_Errormsg tbl_Excelread_Errormsg = new tbl_Excelread_Errormsg();
                                    tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                    tbl_Excelread_Errormsg.RowNo = AvgTaxrowno;
                                    tbl_Excelread_Errormsg.ColumnNo = AvgTaxcolno;
                                    tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + AvgTaxrowno + ", Column No: " + AvgTaxcolno + ", " + "'" + " Average Sale" + "'" + " is Invalid.";
                                    db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                    db.SaveChanges();
                                    int idval = Filedata.id;
                                    WestZoneEntities db1 = new WestZoneEntities();
                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                    AvgTaxrowno = 0;
                                    AvgTaxcolno = 0;

                                }
                            }
                            //Response.Write(kvp.Key + "==>" + kvp.Value);
                            //Response.Write("<br/>");
                        }
                        if (IsMain != 1)
                        {
                            if (isexists == true)
                            {
                                ObjSalesactivitysummary.FileName = fileName;
                                ObjSalesactivitysummary.CreatedDate = DateTime.Now;
                                ObjSalesactivitysummary.CeatedBy = userid;
                                ObjSalesactivitysummary.IsActive = true;
                                WestZoneEntities db2 = new WestZoneEntities();
                                db2.tbl_SalesActivitySummary.Add(ObjSalesactivitysummary);
                                db2.SaveChanges();
                            }
                            if (isexists == true)
                            {
                                tbl_TendersInDrawer objtbl_TendersInDrawer = new tbl_TendersInDrawer();
                                foreach (var kvp in TendersDrawer)
                                {
                                    objtbl_TendersInDrawer.ActivitySalesSummuryId = ObjSalesactivitysummary.Id;
                                    objtbl_TendersInDrawer.Title = kvp.Key;


                                    string tenderamount = kvp.Value;
                                    for (int i = 0; i < specialCharacters.Length; i++)
                                    {
                                        if (kvp.Value.Contains(specialCharacters[i]))
                                        {
                                            tenderamount = tenderamount.Replace(specialCharacters[i], "");
                                        }
                                    }
                                    try
                                    {
                                        if (!string.IsNullOrEmpty(tenderamount))
                                        {
                                            objtbl_TendersInDrawer.Amount = Convert.ToDecimal(tenderamount);
                                        }
                                    }
                                    catch
                                    {
                                        if (IsMain != 1)
                                        {
                                            tbl_ExcelRead.Filename = fileName;
                                            tbl_ExcelRead.Excelreadate = DateTime.Now;
                                            tbl_ExcelRead.CreatedDate = DateTime.Now;
                                            db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                            db.SaveChanges();
                                            IsMain = 1;
                                        }
                                        tbl_Excelread_Errormsg tbl_Excelread_Errormsg = new tbl_Excelread_Errormsg();
                                        tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                        tbl_Excelread_Errormsg.RowNo = rowcount;
                                        tbl_Excelread_Errormsg.ColumnNo = columncount;
                                        tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + rowcount + ", Column No: " + columncount + ", " + "'" + kvp.Value + "'" + " is Invalid.";
                                        db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                        db.SaveChanges();
                                        int idval = Filedata.id;
                                        WestZoneEntities db_1 = new WestZoneEntities();
                                        var updatissynflag = db_1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                    }
                                    objtbl_TendersInDrawer.CreatedDate = DateTime.Now;
                                    objtbl_TendersInDrawer.CeatedBy = userid;
                                    objtbl_TendersInDrawer.IsActive = true;
                                    WestZoneEntities db3 = new WestZoneEntities();
                                    db3.tbl_TendersInDrawer.Add(objtbl_TendersInDrawer);
                                    db3.SaveChanges();
                                    //Response.Write(kvp.Key + "==>" + kvp.Value);
                                    //Response.Write("<br/>");
                                }

                                tbl_DepartmentNetSales objtbl_DepartmentNetSales = new tbl_DepartmentNetSales();
                                foreach (var kvp in DepartmentSales)
                                {
                                    objtbl_DepartmentNetSales.ActivitySalesSummuryId = ObjSalesactivitysummary.Id;
                                    objtbl_DepartmentNetSales.Title = kvp.Key;


                                    string departmentamount = kvp.Value;
                                    for (int i = 0; i < specialCharacters.Length; i++)
                                    {
                                        if (kvp.Value.Contains(specialCharacters[i]))
                                        {
                                            departmentamount = departmentamount.Replace(specialCharacters[i], "");
                                        }
                                    }
                                    try
                                    {
                                        if (!string.IsNullOrEmpty(departmentamount))
                                        {
                                            objtbl_DepartmentNetSales.Amount = Convert.ToDecimal(departmentamount);
                                        }
                                    }
                                    catch
                                    {
                                        if (IsMain != 1)
                                        {
                                            tbl_ExcelRead.Filename = fileName;
                                            tbl_ExcelRead.Excelreadate = DateTime.Now;
                                            tbl_ExcelRead.CreatedDate = DateTime.Now;
                                            db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                            db.SaveChanges();
                                            IsMain = 1;
                                        }
                                        tbl_Excelread_Errormsg tbl_Excelread_Errormsg = new tbl_Excelread_Errormsg();
                                        tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                        tbl_Excelread_Errormsg.RowNo = rowcount;
                                        tbl_Excelread_Errormsg.ColumnNo = columncount;
                                        tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + rowcount + ", Column No: " + columncount + ", " + "'" + kvp.Value + "'" + " is Invalid.";
                                        db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                        db.SaveChanges();
                                        int idval = Filedata.id;
                                        WestZoneEntities db1 = new WestZoneEntities();
                                        var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                    }
                                    objtbl_DepartmentNetSales.CreatedDate = DateTime.Now;
                                    objtbl_DepartmentNetSales.CeatedBy = userid;
                                    objtbl_DepartmentNetSales.IsActive = true;

                                    db.tbl_DepartmentNetSales.Add(objtbl_DepartmentNetSales);
                                    db.SaveChanges();
                                    //Response.Write(kvp.Key + "==>" + kvp.Value);
                                    //Response.Write("<br/>");
                                }

                                tbl_PaidOut objtbl_PaidOut = new tbl_PaidOut();
                                foreach (var kvp in Paidoutreports)
                                {
                                    objtbl_PaidOut.ActivitySalesSummuryId = ObjSalesactivitysummary.Id;
                                    objtbl_PaidOut.Title = kvp.Key;


                                    string Paidoutamount = kvp.Value;
                                    for (int i = 0; i < specialCharacters.Length; i++)
                                    {
                                        if (kvp.Value.Contains(specialCharacters[i]))
                                        {
                                            Paidoutamount = Paidoutamount.Replace(specialCharacters[i], "");
                                        }
                                    }
                                    try
                                    {
                                        if (!string.IsNullOrEmpty(Paidoutamount))
                                        {
                                            objtbl_PaidOut.Amount = Convert.ToDecimal(Paidoutamount);
                                        }
                                    }
                                    catch
                                    {
                                        if (IsMain != 1)
                                        {
                                            tbl_ExcelRead.Filename = fileName;
                                            tbl_ExcelRead.Excelreadate = DateTime.Now;
                                            tbl_ExcelRead.CreatedDate = DateTime.Now;
                                            db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                            db.SaveChanges();
                                            IsMain = 1;
                                        }
                                        tbl_Excelread_Errormsg tbl_Excelread_Errormsg = new tbl_Excelread_Errormsg();
                                        tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                        tbl_Excelread_Errormsg.RowNo = rowcount;
                                        tbl_Excelread_Errormsg.ColumnNo = columncount;
                                        tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + rowcount + ", Column No: " + columncount + ", " + "'" + kvp.Value + "'" + " is Invalid.";
                                        db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                        db.SaveChanges();
                                        int idval = Filedata.id;
                                        WestZoneEntities db1 = new WestZoneEntities();
                                        var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                    }


                                    objtbl_PaidOut.CreatedDate = DateTime.Now;
                                    objtbl_PaidOut.CeatedBy = userid;
                                    objtbl_PaidOut.IsActive = true;

                                    db.tbl_PaidOut.Add(objtbl_PaidOut);
                                    db.SaveChanges();
                                    //Response.Write(kvp.Key + "==>" + kvp.Value);
                                    //Response.Write("<br/>");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message + Convert.ToString(Filedata.id));
                    int idval = Filedata.id;
                    WestZoneEntities db1 = new WestZoneEntities();
                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                }
                finally
                {
                    //Release the Excel objects   
                    excelWorkBook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                    excelApplication.Workbooks.Close();
                    excelApplication.Quit();
                    excelApplication = null;
                    excelWorkBook = null;

                    GC.GetTotalMemory(false);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.GetTotalMemory(true);

                    if (IsMain != 1)
                    {
                        //String path = @"D:\MyTestFile1.txt";
                        //string Path =@wwwroot.Class.AdminSiteConfiguration.GetURL() + "userfiles/Pending/" + fileName;
                        string repFilePath = Request.PhysicalApplicationPath + @"userfiles\Pending\" + fileName;
                        DirectoryInfo sourceDir = new DirectoryInfo(repFilePath);
                        //DirectoryInfo sourceDir = new DirectoryInfo(@Path);
                        string Path = Request.PhysicalApplicationPath + @"userfiles\Done\";
                        string destinationPath = "";
                        //sourceDir.MoveTo(destinationPath);


                        if (System.IO.Directory.Exists(Path))
                        {
                            destinationPath = Path + fileName;
                            sourceDir.MoveTo(destinationPath);
                            int idval = Filedata.id;
                            WestZoneEntities db1 = new WestZoneEntities();
                            var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 1);
                        }
                        else
                        {
                            System.IO.Directory.CreateDirectory(Path);

                            destinationPath = Path + fileName;
                            sourceDir.MoveTo(destinationPath);
                            int idval = Filedata.id;
                            WestZoneEntities db1 = new WestZoneEntities();
                            var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 1);
                        }

                    }
                    //DumbDataIntoSql();
                }
            }
        }

        public ActionResult ExportExcelData()
        {
            string startdate = Convert.ToString(TempData["startdate"]);
            string enddate = Convert.ToString(TempData["enddate"]);
            int Storeid = Convert.ToInt32(TempData["Storeid"]);
            int Terminalid = Convert.ToInt32(TempData["Terminalid"]);

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
            string storeid = "";
            if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
            {
                storeid = Convert.ToString(Session["storeid"]);
            }
            else
            {
                RedirectToAction("index", "login");
            }
            // string storeid = GlobalStore.GlobalStore_id;
            System.Data.DataTable dt1 = new System.Data.DataTable();
            var datareport = (from data in db.tbl_SalesActivitySummary_Select(start_date, end_date, Storeid, Terminalid)
                       select new SalesActivitySummaryreport
                       {
                           Id = data.Id,
                           TransactionStartTime = data.TransactionStartTime,
                           TransactionEndTime = data.TransactionEndTime,
                           CustomerCount = Convert.ToInt32(data.CustomerCount),
                           NetSalesWithTax = data.NetSalesWithTax,
                           TotalTaxCollected = data.TotalTaxCollected,
                           AverageSale = data.AverageSale,
                           Terminal = data.Terminal,
                           Storename = data.storename,
                           Terminalid = data.Terminalid,
                           Storeid = data.Storeid,
                           StartDate = data.StartDate
                       }).ToList<SalesActivitySummaryreport>();

            List<SalesActivitySummaryreport> LstInvoice_Select = new List<SalesActivitySummaryreport>();

            for (int i = 0; i < datareport.Count; i++)
            {
                SalesActivitySummaryreport obj = new SalesActivitySummaryreport();
                obj.CustomerCount = datareport[i].CustomerCount;
                obj.AverageSale = datareport[i].AverageSale;
                obj.NetSalesWithTax = datareport[i].NetSalesWithTax;
                obj.Terminal = datareport[i].Terminal;
                obj.TotalTaxCollected= datareport[i].TotalTaxCollected;
                obj.TransactionTime = wwwroot.Class.AdminSiteConfiguration.GetDatetimeformatwithAMPM(Convert.ToString(datareport[i].StartDate)) + " - " + wwwroot.Class.AdminSiteConfiguration.GetDatetimeformatwithAMPM(Convert.ToString(datareport[i].TransactionEndTime));
                LstInvoice_Select.Add(obj);
            }

            dt1 = LINQToDataTable(LstInvoice_Select);
            Export oExport = new Export();
            string FileName = "Report" + ".xls";

            //int[] ColList = { 22, 20, 6, 31, 27, 12, 3 };
            //int[] ColList = { 22, 20, 6, 31, 32, 27, 12, 3 };
            int[] ColList = { 4,7,8,9,10};
            string[] arrHeader = {
             //"Transaction Time",
             "Terminal",
             "Customer Count",
             "Net Sales With Tax",
             "Total Tax Collected",
             "Average Sale"
             };

            //only change file extension to .xls for excel file

            oExport.ExportDetails(dt1, ColList, arrHeader, Export.ExportFormat.Excel, FileName);

            return RedirectToAction("Index", "SalesActivitySummaryReport");

        }
        public System.Data.DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            System.Data.DataTable dtReturn = new System.Data.DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others 

                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }
    }
}