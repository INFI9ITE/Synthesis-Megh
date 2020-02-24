using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wwwroot.Areas.Admin.Models;
using wwwrootBL.Entity;

namespace wwwroot.Areas.Admin.Controllers
{
    public class ShiftwisetenderreportController : Controller
    {
        WestZoneEntities db = new WestZoneEntities();
        protected static string ErrorMessage = "";
        protected static bool IsFirst = true;
        // GET: Admin/Shiftwisetenderreport
        public ActionResult Index()
        {
            if (IsFirst == true)
            {

                IsFirst = false;
            }
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string storeid = "";
            if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
            {
                storeid = Convert.ToString(Session["storeid"]);
                ViewBag.storeid = storeid;
            }
            ViewBag.LatestDate = wwwroot.Class.AdminSiteConfiguration.GetDate1(Convert.ToString((from data in db.GetLatestAvailableDateForSalesSummery() select data.LatestAvailableDate).FirstOrDefault()));

            return View();
        }
        public ActionResult Grid(string date = "", string Edate = "")
        {
            int storeid = 0;
            Shiftwisetenderreport_Select shiftwisetenderreport_Select = new Shiftwisetenderreport_Select();
            if (Convert.ToInt32(Session["storeid"]) != 0)
            {
                storeid = Convert.ToInt32(Session["storeid"]);
            }
            DateTime? Sdate = null;
            DateTime? Enddate = null;
            if (!string.IsNullOrEmpty(date))
            {
                Sdate = Convert.ToDateTime(date);
            }
            else
            {
                try
                {
                    Sdate = Convert.ToDateTime(wwwroot.Class.AdminSiteConfiguration.GetDate1(Convert.ToString((from data in db.GetLatestAvailableDateForSalesSummery() select data.LatestAvailableDate).FirstOrDefault())));
                    date = wwwroot.Class.AdminSiteConfiguration.GetDate1(Convert.ToString((from data in db.GetLatestAvailableDateForSalesSummery() select data.LatestAvailableDate).FirstOrDefault()));
                }
                catch
                {
                    Sdate = DateTime.Now;
                    date = wwwroot.Class.AdminSiteConfiguration.GetDate1(DateTime.Now.ToShortDateString());
                }

            }
            if (!string.IsNullOrEmpty(Edate))
            {
                Enddate = Convert.ToDateTime(Edate);
            }
            else
            {
                try
                {
                    Enddate = Convert.ToDateTime(wwwroot.Class.AdminSiteConfiguration.GetDate1(Convert.ToString((from data in db.GetLatestAvailableDateForSalesSummery() select data.LatestAvailableDate).FirstOrDefault())));
                    Edate = wwwroot.Class.AdminSiteConfiguration.GetDate1(Convert.ToString((from data in db.GetLatestAvailableDateForSalesSummery() select data.LatestAvailableDate).FirstOrDefault()));
                }
                catch
                {
                    Enddate = DateTime.Now;
                    Edate = wwwroot.Class.AdminSiteConfiguration.GetDate1(DateTime.Now.ToShortDateString());
                }
            }
            ViewBag.storeid = storeid;
            ViewBag.StartDate = date;
            ViewBag.EndDate = Edate;
            shiftwisetenderreport_Select.shiftname = (from data in db.tbl_shift
                                                      select new ShiftList
                                                      {
                                                          Id = data.id,
                                                          Name = data.name
                                                      }).ToList();
            shiftwisetenderreport_Select.PaidOutCount = (from dt in db.GetPaidOutCount(date, Edate) select dt.PaidOutCount).FirstOrDefault();
            shiftwisetenderreport_Select.PaidDistinctList = (from dt in db.GetPaidOutTitleList(date, Edate) select dt.PaidOutTitle).ToList();
            shiftwisetenderreport_Select.TitleWiseTotal = (from data1 in db.GetTitleList(storeid, date, Edate)
                                                           select new TitleWiseTotal
                                                           {
                                                               Title = data1.Title
                                                           }).ToList<TitleWiseTotal>();
            ViewBag.TitleCount = shiftwisetenderreport_Select.TitleWiseTotal.Count;
            if (shiftwisetenderreport_Select.TitleWiseTotal.Count == 0)
            {
                ErrorMessage = "NoItemFound";
                ViewBag.ErrorMessage = ErrorMessage;
                ErrorMessage = "";
            }
            shiftwisetenderreport_Select.CashTotal = (from data in db.GetCashTotal(storeid, date, Edate) select data.TotalByTitle).FirstOrDefault();
            shiftwisetenderreport_Select.OtherTotal = (from data in db.GetOtherTotal(storeid, date, Edate) select data.TotalByTitle).FirstOrDefault() + (from data in db.GetPaidOutTotal(storeid, date, Edate) select data.PaidOutTotal).FirstOrDefault();
            shiftwisetenderreport_Select.OtherDepositeList = (from data in db.Getotherdeposit(storeid, date, Edate)
                                                              select new OtherDepositeList
                                                              {
                                                                  Amount = data.amount,
                                                                  Date = data.createdate.ToString(),
                                                                  Description = data.name,
                                                                  PaymentMethod = data.paymentmethod,
                                                                  options = data.options,
                                                                  Vendor = data.Vendor,
                                                                  Other = data.Other
                                                              }).ToList<OtherDepositeList>();
            ViewBag.DepositeCount = shiftwisetenderreport_Select.OtherDepositeList.Count;
            return View(shiftwisetenderreport_Select);
        }
    }
}