using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wwwroot.Areas.Admin.Models;
using wwwrootBL.Entity;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.Entity;
using WebMatrix.WebData;
using System.Globalization;

namespace wwwroot.Areas.Admin.Controllers
{
    public class ShiftwisereportController : Controller
    {

        protected static string Terminalid_val = "";
        protected static string Shiftid_val = "";
        protected static string Tid_val = "";
        protected static string Sid_val = "";
        protected static string startdate = "";
        protected static string ErrorMessage = "";
        protected bool IsFirst = false;
        WestZoneEntities db = new WestZoneEntities();
        // GET: Admin/Shiftwisereport
        public ActionResult Index(int StoreId = 0, string TerminalId = "", string StartDate = "")
        {
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string storeid = "";
            Shiftwisereport_Select shiftwisereport_Select = new Shiftwisereport_Select();
            if (StoreId == 0 || StartDate == "" || TerminalId == "")
            {
                ViewBag.Startdate = startdate;
                ViewBag.terminalidval = Terminalid_val;
                ViewBag.Shiftdataid = Shiftid_val;
                Terminalid_val = "";
                Shiftid_val = "";

                if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
                {
                    storeid = Convert.ToString(Session["storeid"]);
                    ViewBag.storeid = storeid;
                    int sid = Convert.ToInt32(storeid);
                    if ((string.IsNullOrEmpty(startdate)) && (storeid != "0"))
                    {
                        try
                        {

                            startdate = wwwroot.Class.AdminSiteConfiguration.GetDateformat(Convert.ToString((from data in db.GetLatestAvailableDate() select data.LatestAvailableDate).FirstOrDefault()));
                        }
                        catch (Exception e) { }
                        ViewBag.Startdate = startdate;
                    }
                    if (!string.IsNullOrEmpty(startdate))
                    {
                        shiftwisereport_Select.Otherdepositlist = (from a in db.tbl_otherdeposit_selectbystoreid(startdate, sid)
                                                                   select new Bindotherdepositdata
                                                                   {
                                                                       name = a.name,
                                                                       amount = a.amount,
                                                                       payment = a.paymentmethod,
                                                                       storeid = a.storeid,
                                                                       date = a.createdate,
                                                                       options = a.options,
                                                                       Vendor = a.Vendor,
                                                                       Other = a.Other,

                                                                   }).ToList();
                    }
                }
            }
            else
            {

                ViewBag.Startdate = StartDate;
                Terminalid_val = "";
                Shiftid_val = "";

                //string storeid = "";

                if (StoreId != 0)
                {
                    ViewBag.Startdate = StartDate;
                    storeid = Convert.ToString(StoreId);
                    ViewBag.storeid = storeid;
                    int sid = Convert.ToInt32(storeid);
                    Session["storeid"] = sid;
                    ViewBag.terminalid_val = TerminalId;
                    Terminalid_val = TerminalId;
                    if (!string.IsNullOrEmpty(StartDate))
                    {
                        var CustomerCount = (from a in db.GetCustomercount_byterminal(StartDate, sid)
                                             select a.customercount).FirstOrDefault();
                        decimal SalesTotal = Convert.ToDecimal((from a in db.GetSalesAmountTotal(sid, StartDate)
                                                                select a.TotalByTitle).FirstOrDefault());
                        decimal PaidOutTotal = Convert.ToDecimal((from a in db.GetPaidOutTotal_Shiftwisereport(sid, StartDate)
                                                                  select a.TotalByTitlePO).FirstOrDefault());
                        shiftwisereport_Select.totalsalesamount = SalesTotal + PaidOutTotal;
                        shiftwisereport_Select.Coustomercount = CustomerCount;

                        shiftwisereport_Select.Otherdepositlist = (from a in db.tbl_otherdeposit_selectbystoreid(StartDate, sid)
                                                                   select new Bindotherdepositdata
                                                                   {
                                                                       name = a.name,
                                                                       amount = a.amount,
                                                                       payment = a.paymentmethod,
                                                                       storeid = a.storeid,
                                                                       date = a.createdate,
                                                                       options = a.options,
                                                                       Vendor = a.Vendor,
                                                                       Other = a.Other
                                                                   }).ToList();
                    }


                }
            }

            shiftwisereport_Select.SelectOptionList = (from a in db.tbl_Option_select()
                                                       select new ddllist
                                                       {
                                                           Value = a.SelectOption,
                                                           Text = a.SelectOption
                                                       }).ToList();

            string storeidval = Session["storeid"].ToString();
            shiftwisereport_Select.SelectVendorList = (from a in db.tbl_Vendor
                                                       where a.StoreId.ToString() == storeidval && a.IsActive == true
                                                       orderby a.Name ascending
                                                       select new ddllist
                                                       {
                                                           Value = a.Name,
                                                           Text = a.Name
                                                       }).ToList();



            return View(shiftwisereport_Select);
        }
        public ActionResult TerminalGrid(string date = "")
        {
            ViewBag.terminalid_val = Terminalid_val;
            int storeid = 0;
            Shiftwisereport_Select shiftwisereport_Select = new Shiftwisereport_Select();

            if (Convert.ToInt32(Session["storeid"]) != 0)
            {
                storeid = Convert.ToInt32(Session["storeid"]);
            }
            if ((string.IsNullOrEmpty(date)) && (storeid != 0))
            {
                date = wwwroot.Class.AdminSiteConfiguration.GetDateformat(Convert.ToString((from data in db.GetLatestAvailableDate() select data.LatestAvailableDate).FirstOrDefault()));
            }
            //var Count = (from data in db.Get_Count_tbl_otherdeposit(Convert.ToInt32(storeid), startdate) select data.DepositeCount).FirstOrDefault();
            var countval = db.tbl_otherdeposit_selectbystoreid(date, Convert.ToInt32(storeid)).ToList().Count();
            ViewBag.DepositeCount = countval;
            DateTime? Currentdate = null;
            try
            {
                string dateval = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(date));
                startdate = dateval;
                Currentdate = Convert.ToDateTime(dateval);
            }
            catch { }

            shiftwisereport_Select.TerminalData = (from data in db.tbl_SalesActivitySummary_Terminalwiselist(storeid, date)
                                                   select new BindTerminaldata
                                                   {
                                                       TerminalId = data.Terminalid.GetValueOrDefault(),
                                                       TerminalName = data.terminal,
                                                   }).ToList();
            if (shiftwisereport_Select.TerminalData.Count > 0)
            {

                ViewBag.Terminalidvalue = shiftwisereport_Select.TerminalData[0].TerminalId;
                ViewBag.terminalidval = shiftwisereport_Select.TerminalData[0].TerminalId;
                Terminalid_val = Convert.ToString(shiftwisereport_Select.TerminalData[0].TerminalId);
                ViewBag.Shiftdataid = "";
            }
            if (shiftwisereport_Select.TerminalData.Count == 0)
            {
                ErrorMessage = "NoItemFound";
                ViewBag.ErrorMessage = ErrorMessage;
                ErrorMessage = "";
            }
            shiftwisereport_Select.SelectOptionList = (from a in db.tbl_Option_select()

                                                           // orderby a.SelectOption ascending
                                                       select new ddllist
                                                       {
                                                           Value = a.SelectOption,
                                                           Text = a.SelectOption
                                                       }).ToList();

            string storeidval = Session["storeid"].ToString();
            shiftwisereport_Select.SelectVendorList = (from a in db.tbl_Vendor
                                                       where a.StoreId.ToString() == storeidval && a.IsActive == true
                                                       orderby a.Name ascending
                                                       select new ddllist
                                                       {
                                                           Value = a.Name,
                                                           Text = a.Name
                                                       }).ToList();
            //string[] dtarray = date.Split('-');
            //var dt = Convert.ToDateTime(dtarray[1] + "-" + dtarray[0] + "-" + dtarray[2]);
            ViewBag.TotalCount = (from data in db.GetUnassignShiftName(date, Convert.ToInt32(storeidval)) select data.TotalCount).FirstOrDefault();
            return PartialView(shiftwisereport_Select);

        }
        public ActionResult ShiftDataGrid(string date = "", string terminalid = "")
        {
            int storeid = 0;
            ViewBag.terminalidval = "";
            ViewBag.Shiftdataid = "";
            Shiftwisereport_Select shiftwisereport_Select = new Shiftwisereport_Select();

            if (Convert.ToInt32(Session["storeid"]) != 0)
            {
                storeid = Convert.ToInt32(Session["storeid"]);
            }
            if ((string.IsNullOrEmpty(date)) && (storeid != 0))
            {
                date = wwwroot.Class.AdminSiteConfiguration.GetDateformat(Convert.ToString((from data in db.GetLatestAvailableDate() select data.LatestAvailableDate).FirstOrDefault()));
            }
            //if (Convert.ToInt32(Session["storeid"]) != 0)
            //{
            //    storeid = Convert.ToInt32(Session["storeid"]);
            //}
            DateTime? Currentdate = null;
            try
            {
                string dateval = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(date));
                Currentdate = Convert.ToDateTime(dateval);
            }
            catch { }
            startdate = date;

            if (!string.IsNullOrEmpty(terminalid))
            {
                int terminalidval = Convert.ToInt32(terminalid);
                //Terminalid_val = Convert.ToString(terminalid);
                // Shiftid_val = "";
                //  ViewBag.terminalidval = terminalid;
                //  ViewBag.Shiftdataid = "";
                var SalesTotal = Convert.ToDecimal((from a in db.GetSalesAmountTotalbyTerminalID(storeid, date, terminalidval)
                                                        select a.TotalByTitle).FirstOrDefault());
                decimal PaidOutTotal = Convert.ToDecimal((from a in db.GetPaidOutTotal_Shiftwisereportbyterminalid(storeid, date, terminalidval)
                                                          select a.TotalByTitlePO).FirstOrDefault());
                shiftwisereport_Select.ShiftData = (from data in db.tbl_SalesActivitySummary_Terminalwiselistbytid(storeid, date, terminalidval)
                                                    select new BindShiftdata
                                                    {
                                                        terminalid = terminalidval,

                                                        SalesAmount = SalesTotal + PaidOutTotal,
                                                        CustomerCount = (from a in db.GetTotalCustomercount_byterminalid(date, storeid, data.Terminalid)
                                                                         select a.customercount).FirstOrDefault(),
                                                        ShiftdataList = (from a1 in db.tbl_SalesActivitySummary_shiftlist(storeid, date, data.Terminalid)
                                                                         select new ddlShiftList
                                                                         {
                                                                             Id = a1.Id,
                                                                             ShiftName = a1.shiftname,
                                                                         }).ToList<ddlShiftList>(),

                                                    }).ToList();
                //if (shiftwisereport_Select.ShiftData.Count > 0)
                //{

                //}
            }
            shiftwisereport_Select.SelectOptionList = (from a in db.tbl_Option_select()

                                                           // orderby a.SelectOption ascending
                                                       select new ddllist
                                                       {
                                                           Value = a.SelectOption,
                                                           Text = a.SelectOption
                                                       }).ToList();
            string storeidval = Session["storeid"].ToString();
            shiftwisereport_Select.SelectVendorList = (from a in db.tbl_Vendor
                                                       where a.StoreId.ToString() == storeidval && a.IsActive == true
                                                       orderby a.Name ascending
                                                       select new ddllist
                                                       {
                                                           Value = a.Name,
                                                           Text = a.Name
                                                       }).ToList();
            return PartialView(shiftwisereport_Select);
        }
        public ActionResult ShiftWisetenderGrid(string date = "", string terminalid = "", string shiftid = "")
        {
            ViewBag.ErrorMessage = ErrorMessage;
            ErrorMessage = "";
            int storeid = 0;

            Shiftwisereport_Select shiftwisereport_Select = new Shiftwisereport_Select();
            if (Convert.ToInt32(Session["storeid"]) != 0)
            {
                storeid = Convert.ToInt32(Session["storeid"]);
            }
            if ((string.IsNullOrEmpty(date)) && (storeid != 0))
            {
                date = wwwroot.Class.AdminSiteConfiguration.GetDateformat(Convert.ToString((from data in db.GetLatestAvailableDate() select data.LatestAvailableDate).FirstOrDefault()));
            }
            DateTime? Currentdate = null;
            try
            {
                string dateval = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(date));
                Currentdate = Convert.ToDateTime(dateval);
                startdate = date;
            }
            catch { }
            Terminalid_val = Convert.ToString(terminalid);
            Shiftid_val = Convert.ToString(shiftid);
            ViewBag.terminalidval = "";
            ViewBag.Shiftdataid = "";
            if (!string.IsNullOrEmpty(terminalid) && !string.IsNullOrEmpty(shiftid))
            {
                int shiftidval = Convert.ToInt32(shiftid);
                int terminalidval = Convert.ToInt32(terminalid);

                Terminalid_val = terminalid;
                shiftwisereport_Select.terminal_id = terminalid;
                shiftwisereport_Select.ShiftWisetenderData = (from a1 in db.tbl_SalesActivitySummary_shiftlist_byid(storeid, date, terminalidval, shiftidval)
                                                              select new Bindshiftwisetenderlist
                                                              {
                                                                  Id = a1.Id,
                                                                  CustomerCount = a1.CustomerCount,
                                                                  Terminalname = a1.terminal,
                                                                  StartTime = a1.starttime,
                                                                  EndTime = a1.Endtime,
                                                                  SalesAmount = a1.NetSalesWithTax,
                                                                  TotalTaxAmount = a1.TotalTaxCollected,
                                                                  ShiftName = a1.shiftname,
                                                                  CashierName = a1.cashiername,
                                                                  Paidoutamount = a1.Paidoutamount,
                                                                  ShiftNameList = (from data1 in db.tbl_shift
                                                                                   where data1.name != null || data1.name != ""
                                                                                   select new ShiftNameList
                                                                                   {
                                                                                       Text = data1.name,
                                                                                       Value = data1.name
                                                                                   }).ToList<ShiftNameList>(),
                                                                  TenderList = (from a2 in db.tbl_tenderinDraw_byid(a1.Id)
                                                                                select new TenderList
                                                                                {
                                                                                    Amount = a2.Amount,
                                                                                    Id = a2.Id,
                                                                                    Name = a2.Title,
                                                                                    ListName = "Activity"
                                                                                }).ToList<TenderList>(),
                                                                  paidoutLists = (from dt in db.tbl_PaidOut_byid(a1.Id)
                                                                                  select new PaidoutList
                                                                                  {
                                                                                      Amount = dt.Amount,
                                                                                      Title = dt.Title,
                                                                                      Id = dt.Id,
                                                                                      ListName = "PaidOut"
                                                                                  }).ToList<PaidoutList>()
                                                              }).ToList<Bindshiftwisetenderlist>();
                var CardDetailList = (from data in db.GetCreditCardDetails(storeid, Convert.ToInt32(Shiftid_val), date) select data).FirstOrDefault();
                if (CardDetailList != null)
                {
                    if (Convert.ToString(CardDetailList.Amount_AMEX) != null)
                    {
                        shiftwisereport_Select.AMEX = CardDetailList.Amount_AMEX;
                    }
                    if (Convert.ToString(CardDetailList.Amount_Discover) != null)
                    {
                        shiftwisereport_Select.Discover = CardDetailList.Amount_Discover;
                    }
                    if (Convert.ToString(CardDetailList.Amount_Visa) != null)
                    {
                        shiftwisereport_Select.Visa = CardDetailList.Amount_Visa;
                    }
                    if (Convert.ToString(CardDetailList.Amount_Master) != null)
                    {
                        shiftwisereport_Select.Master = CardDetailList.Amount_Master;
                    }
                }
            }
            else
            {
                ErrorMessage = "NoItemFound";
                ViewBag.ErrorMessage = ErrorMessage;
                ErrorMessage = "";
            }
            shiftwisereport_Select.SelectOptionList = (from a in db.tbl_Option_select()

                                                           //  orderby a.SelectOption ascending
                                                       select new ddllist
                                                       {
                                                           Value = a.SelectOption,
                                                           Text = a.SelectOption
                                                       }).ToList();
            string storeidval = Session["storeid"].ToString();
            shiftwisereport_Select.SelectVendorList = (from a in db.tbl_Vendor
                                                       where a.StoreId.ToString() == storeidval && a.IsActive == true
                                                       orderby a.Name ascending
                                                       select new ddllist
                                                       {
                                                           Value = a.Name,
                                                           Text = a.Name
                                                       }).ToList();
            return PartialView(shiftwisereport_Select);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShiftWisetenderGrid(Shiftwisereport_Select Posteddata, string[] Title, string[] Amount)
        {
            if (ModelState.IsValid)
            {
                Shiftwisereport_Select shiftwisereport_Select = new Shiftwisereport_Select();
                if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
                {
                    int storeid = 0;
                    storeid = Convert.ToInt32(Session["storeid"]);

                    int SummeryId = Posteddata.ShiftWisetenderData[0].Id;
                    string date = Convert.ToString((from a in db.tbl_SalesActivitySummary where a.Id == SummeryId select a.TransactionStartTime).FirstOrDefault());
                    string SelectShift = Posteddata.ShiftWisetenderData[0].ShiftName;
                    string CashierName = Posteddata.ShiftWisetenderData[0].CashierName;
                    int tid = Convert.ToInt32(Posteddata.terminal_id);
                    Tid_val = Convert.ToString(tid);
                    Sid_val = Convert.ToString(SummeryId);
                    Terminalid_val = Convert.ToString(tid);
                    Shiftid_val = Convert.ToString(SummeryId);
                    var exist = db.CheckExistence_byshiftwise(storeid, date, tid, SummeryId, SelectShift).Select(x => x.Value).FirstOrDefault();
                    if (exist == 0)
                    {
                        if (SelectShift == null || SelectShift == "")
                        {
                            SelectShift = "Shift#";
                        }
                        var Sucess = db.tbl_SalesActivitySummary_updatecashiername(SummeryId, SelectShift, CashierName);
                        if (Posteddata.ShiftWisetenderData[0].TenderList.Count > 0)
                        {
                            for (int i = 0; i < Posteddata.ShiftWisetenderData[0].TenderList.Count; i++)
                            {
                                decimal amountval = Convert.ToDecimal(Posteddata.ShiftWisetenderData[0].TenderList[i].Amount);
                                int id = Convert.ToInt32(Posteddata.ShiftWisetenderData[0].TenderList[i].Id);
                                var Sucesstenderamt = db.tbl_TendersInDrawer_updateAmount(id, amountval);
                            }
                        }

                        int j = 0;
                        int tenderlist = 0;
                        string amt = "";
                        string nameval = "";
                        if (Title != null)
                        {
                            WestZoneEntities db1 = new WestZoneEntities();
                            foreach (var val_id in Title)
                            {
                                tbl_TendersInDrawer dataDept = new tbl_TendersInDrawer();
                                if (val_id != string.Empty)
                                {
                                    nameval = val_id;
                                }
                                else
                                {
                                    nameval = "Shift #";
                                }
                                amt = Amount[j];
                                decimal amotval = Convert.ToDecimal(amt);

                                var successDept = db1.Insert_tbl_TendersInDrawer(nameval, amotval, SummeryId);
                                j++;
                            }
                        }
                        string Result = "";
                        if (Posteddata.AMEX != null || Posteddata.Discover != null || Posteddata.Master != null || Posteddata.Visa != null)
                        {
                            var Exist = (from data in db.tbl_Creditcard_details_exists(storeid, Convert.ToInt32(Sid_val), date, SelectShift) select data).FirstOrDefault();
                            if (Exist == 0)
                            {
                                Result = (db.tbl_Creditcard_details_Insert(Convert.ToInt32(Sid_val), storeid, date, Posteddata.AMEX, Posteddata.Discover, Posteddata.Master, Posteddata.Visa, SelectShift, tid)).FirstOrDefault().ToString();
                                //tbl_Creditcard_details tbl_Creditcard_Details = new tbl_Creditcard_details();
                                //tbl_Creditcard_Details.ShiftId = Convert.ToInt32(Sid_val);
                                //tbl_Creditcard_Details.StoreId = storeid;
                                //tbl_Creditcard_Details.Date = Convert.ToDateTime(date);
                                //tbl_Creditcard_Details.Amount_AMEX = Posteddata.AMEX;
                                //tbl_Creditcard_Details.Amount_Discover = Posteddata.Discover;
                                //tbl_Creditcard_Details.Amount_Master = Posteddata.Master;
                                //tbl_Creditcard_Details.Amount_Visa = Posteddata.Visa;
                                //tbl_Creditcard_Details.ShiftName = SelectShift;
                                //tbl_Creditcard_Details.TerminalId = tid;
                                //db.tbl_Creditcard_details.Add(tbl_Creditcard_Details);
                                //db.SaveChanges();
                            }
                            else
                            {
                                var UpdateResult = (db.tbl_Creditcard_details_Update(Exist, Convert.ToInt32(Sid_val), storeid, date, Posteddata.AMEX, Posteddata.Discover, Posteddata.Master, Posteddata.Visa, SelectShift, tid));
                                //tbl_Creditcard_details tbl_Creditcard_Details = db.tbl_Creditcard_details.Find(Exist);
                                //tbl_Creditcard_Details.ShiftId = Convert.ToInt32(Sid_val);
                                //tbl_Creditcard_Details.StoreId = storeid;
                                //tbl_Creditcard_Details.Date = Convert.ToDateTime(date);
                                //tbl_Creditcard_Details.Amount_AMEX = Posteddata.AMEX;
                                //tbl_Creditcard_Details.Amount_Discover = Posteddata.Discover;
                                //tbl_Creditcard_Details.Amount_Master = Posteddata.Master;
                                //tbl_Creditcard_Details.Amount_Visa = Posteddata.Visa;
                                //tbl_Creditcard_Details.ShiftName = SelectShift;
                                //db.Entry(tbl_Creditcard_Details).State = EntityState.Modified;
                                //db.SaveChanges();
                            }
                        }
                        if (Posteddata.ShiftWisetenderData[0].paidoutLists != null)
                        {
                            if (Posteddata.ShiftWisetenderData[0].paidoutLists.Count > 0)
                            {
                                for (int i = 0; i < Posteddata.ShiftWisetenderData[0].paidoutLists.Count; i++)
                                {
                                    int? Id = Posteddata.ShiftWisetenderData[0].paidoutLists[i].Id;
                                    int UserID = WebSecurity.CurrentUserId;
                                    decimal? AMT = Posteddata.ShiftWisetenderData[0].paidoutLists[i].Amount;
                                    db.tbl_PaidOut_Update_byid(Id, UserID, AMT);
                                }
                            }
                        }
                        ViewBag.Startdate = startdate;
                        ErrorMessage = "Sucess";
                    }
                    else
                    {
                        ErrorMessage = "ExistShift";
                    }
                }
                return RedirectToAction("Index", shiftwisereport_Select);
            }
            return RedirectToAction("Index", Posteddata);
        }

        public JsonResult Saveotherdepositdata(int sid, string date, string payment, string amount, string options, string vendor, string Other = "", string name = "")
        {
            string message = "";
            if ((!string.IsNullOrEmpty(date)) /*&& (!string.IsNullOrEmpty(amount))*/)
            {
                decimal amountval = 0;
                if (amount != "")
                {
                    amountval = Convert.ToDecimal(amount);
                }


                var Sucess = db.tbl_otherdeposit_insert(name, payment, amountval, date, sid, options, vendor, Other).Select(x => x.Value).FirstOrDefault();
                if (Sucess > 0)
                {
                    message = "sucess";
                }
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OtherDepositGrid(string date = "")
        {
            string storeid = "";
            Shiftwisereport_Select shiftwisereport_Select = new Shiftwisereport_Select();
            if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
            {

                storeid = Convert.ToString(Session["storeid"]);
                ViewBag.storeid = storeid;
                int sid = Convert.ToInt32(storeid);
                if (!string.IsNullOrEmpty(date))
                {
                    var countval = db.tbl_otherdeposit_selectbystoreid(date, Convert.ToInt32(storeid)).ToList().Count();
                    ViewBag.DepositeCount = countval;
                    shiftwisereport_Select.Otherdepositlist = (from a in db.tbl_otherdeposit_selectbystoreid(date, sid)
                                                               select new Bindotherdepositdata
                                                               {
                                                                   Id = a.id,
                                                                   name = a.name,
                                                                   amount = a.amount,
                                                                   payment = a.paymentmethod,
                                                                   storeid = a.storeid,
                                                                   date = a.createdate,
                                                                   options = a.options,
                                                                   Vendor = a.Vendor,
                                                                   Other = a.Other
                                                               }).ToList();


                }
            }
            shiftwisereport_Select.SelectOptionList = (from a in db.tbl_Option_select()

                                                           //orderby a.SelectOption ascending
                                                       select new ddllist
                                                       {
                                                           Value = a.SelectOption,
                                                           Text = a.SelectOption
                                                       }).ToList();
            string storeidval = Session["storeid"].ToString();
            shiftwisereport_Select.SelectVendorList = (from a in db.tbl_Vendor
                                                       where a.StoreId.ToString() == storeidval && a.IsActive == true
                                                       orderby a.Name ascending
                                                       select new ddllist
                                                       {
                                                           Value = a.Name,
                                                           Text = a.Name
                                                       }).ToList();

            return View(shiftwisereport_Select);
        }
        public JsonResult GetPaymethodlist(string Id)
        {

            var paymethodlist = (from data in db.tbl_Payment_Method_Byoption(Id)
                                 select new ddllist
                                 {
                                     Value = data.payMehoed,
                                     Text = data.payMehoed
                                 }).ToList();



            return Json(new SelectList(paymethodlist.ToArray(), "Value", "Text"), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Deleteotherdepositdata(int Id)
        {
            string message = "";
            if (Id != 0)
            {
                var Sucess = db.tbl_otherdeposit_Delete(Id);
                message = "sucess";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Daycloseout(string date_val = "")
        {
            string Message = "";
            //string[] dtarray = dateval.Split('-');
            //string date = dtarray[1] + "-" + dtarray[0] + "-" + dtarray[2];
            string date = date_val;
            if (!string.IsNullOrEmpty(Convert.ToString(date)))
            {
                int storeid = 0;
                int userid = Convert.ToInt32(WebSecurity.CurrentUserId);
                if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
                {
                    storeid = Convert.ToInt32(Session["storeid"]);
                }
                decimal TotalSalesamount = 0;
                var totalamunt = db.GettotalAmount(date, storeid).ToList();
                if (totalamunt.Count > 0)
                {
                    TotalSalesamount = Convert.ToDecimal(totalamunt.FirstOrDefault());
                }
                var Saleslist = db.GetTilteWiseSaleslist(date, storeid).ToList();
                if (Saleslist.Count > 0)
                {
                    var configcount = Saleslist.Where(c => c.groupid == null).Where(x => x.refid.ToString() != "4").ToList();

                    if (configcount.Count == 0)
                    {
                        var sucess = db.Insert_SalesGeneralEntries(storeid, userid, date, TotalSalesamount).Select(x => x.Value).FirstOrDefault();

                        if (sucess > 0)
                        {
                            var poscount = db.tbl_SalesActivitySummary_Terminalwiselist(storeid, date).Count();
                            var update_pos = db.tbl_SalesGeneralEntries_updateposno(Convert.ToInt32(sucess), poscount);
                            int j = 0;
                            decimal SalesTotal = Convert.ToDecimal((from a in db.GetSalesAmountTotal(storeid, date)
                                                                    select a.TotalByTitle).FirstOrDefault());
                            decimal PaidOutTotal = Convert.ToDecimal((from a in db.GetPaidOutTotal_Shiftwisereport(storeid, date)
                                                                      select a.TotalByTitlePO).FirstOrDefault());
                            var GetAmountlist = db.GetTotalNetSalesTaxAmount(date, storeid).FirstOrDefault();
                            decimal totalNetSalesTaxamout = Convert.ToDecimal(GetAmountlist.totalnetsalesamountwithtax.GetValueOrDefault());
                            decimal totalTaxamout = Convert.ToDecimal(GetAmountlist.totaltaxamount.GetValueOrDefault());
                            decimal overshotval = totalNetSalesTaxamout - (SalesTotal + PaidOutTotal);
                            foreach (var item in Saleslist)
                            {
                                int groupid = item.groupid.GetValueOrDefault();
                                var groupname = (from a in db.tbl_GroupName where a.id == groupid select a.name).FirstOrDefault();
                                var deptid = item.deptid;
                                var memo = item.MEmo;
                                var typicalbalid = item.typicalbalid.GetValueOrDefault();
                                decimal sucesss = 0;
                                if (item.flag.ToString() == "1")
                                {
                                    if (item.refid == 1)
                                    {
                                        sucesss = db.Insert_tbl_ChildSalesEntries(Convert.ToInt32(sucess), storeid, groupname, groupid,
                                            totalNetSalesTaxamout, deptid).Select(x => x.Value).FirstOrDefault();
                                        if (sucesss > 0)
                                        {
                                            var updatdtae = db.tbl_ChildSalesEntries_updatedata(Convert.ToInt32(sucesss), memo, 1, item.title);
                                        }
                                    }
                                    if (item.refid == 2)
                                    {
                                        sucesss = db.Insert_tbl_ChildSalesEntries(Convert.ToInt32(sucess), storeid, groupname, groupid,
                                            totalTaxamout, deptid).Select(x => x.Value).FirstOrDefault();
                                        if (sucesss > 0)
                                        {
                                            var updatdtae = db.tbl_ChildSalesEntries_updatedata(Convert.ToInt32(sucesss), memo, 2, item.title);
                                        }
                                    }
                                    if (item.refid == 3)
                                    {
                                        sucesss = db.Insert_tbl_ChildSalesEntries(Convert.ToInt32(sucess), storeid, groupname, groupid,
                                            totalTaxamout, deptid).Select(x => x.Value).FirstOrDefault();
                                        if (sucesss > 0)
                                        {
                                            var updatdtae = db.tbl_ChildSalesEntries_updatedata(Convert.ToInt32(sucesss), memo, 1, item.title);
                                        }
                                    }
                                    if (item.refid == 4)
                                    {
                                        sucesss = db.Insert_tbl_ChildSalesEntries(Convert.ToInt32(sucess), storeid, groupname, groupid, (overshotval * (-1)), deptid).Select(x => x.Value).FirstOrDefault();
                                        if (overshotval < 0)
                                        {
                                            if (sucesss > 0)
                                            {
                                                var updatdtae = db.tbl_ChildSalesEntries_updatedata(Convert.ToInt32(sucesss), "Over/ Short", 2, item.title);
                                            }
                                        }
                                        else
                                        {
                                            if (sucesss > 0)
                                            {
                                                var updatdtae = db.tbl_ChildSalesEntries_updatedata(Convert.ToInt32(sucesss), "Over/ Short", 1, item.title);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    sucesss = db.Insert_tbl_ChildSalesEntries(Convert.ToInt32(sucess), storeid, groupname, groupid, item.totalamount, deptid).Select(x => x.Value).FirstOrDefault();
                                    if (sucesss > 0)
                                    {
                                        var updatdtae = db.tbl_ChildSalesEntries_updatedata(Convert.ToInt32(sucesss), memo, typicalbalid, item.title);
                                    }
                                }

                            }
                            Message = "Day Close Out Successful";
                        }
                    }
                    else
                    {
                        string ConfigMessage = "";
                        foreach (var dataconfi in configcount)
                        {

                            ConfigMessage += dataconfi.title + ", ";


                        }
                        Message = "Please Configure " + ConfigMessage + "Group Name";
                    }
                }
                else
                {
                    Message = "Group Name is not Configured.";
                }
            }
            else
            {
                Message = "Please Select Some Date==" + date + " sdsdsd " + date_val;
            }
            return Json(Message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStatus(string date = "")
        {
            string Message = Convert.ToString((from data in db.Get_statusCode(startdate) select data.status).FirstOrDefault());
            return Json(Message, JsonRequestBehavior.AllowGet);
        }
    }
}