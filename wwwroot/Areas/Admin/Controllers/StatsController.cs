using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wwwroot.Areas.Admin.Models;
using wwwrootBL.Entity;

namespace wwwroot.Areas.Admin.Controllers
{
    public class StatsController : Controller
    {
        WestZoneEntities db = new WestZoneEntities();
        protected static string StatusMessage = "";
        // GET: Admin/Stats
        public ActionResult Index()
        {
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string storeid = "";
            if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
            {
                storeid = Convert.ToString(Session["storeid"]);
                ViewBag.storeid = storeid;
            }
         
            return View();
        }

        public ActionResult Grid()
        {
            ViewBag.StatusMessage = StatusMessage;
            StatusMessage = "";
            int storeid = 0;
            if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
            {
                storeid = Convert.ToInt32(Session["storeid"]);
                ViewBag.storeid = storeid;
            }
            Stats stats = new Stats();

            stats.stats_Lists = (from data in db.GetUnassignedShiftnamelist(Convert.ToInt32(storeid))
                                 select new Stats_List
                                 {
                                     AverageSale = data.AverageSale,
                                     cashiername = data.cashiername,
                                     CeatedBy = data.CeatedBy,
                                     CreatedDate = data.CreatedDate,
                                     CustomerCount = data.CustomerCount,
                                     FileName = data.FileName,
                                     Id = data.Id,
                                     IsActive = data.IsActive,
                                     NetSalesWithTax = data.NetSalesWithTax,
                                     shiftname = data.shiftname,
                                     Storeid = data.Storeid,
                                     Terminalid = data.Terminalid,
                                     TotalTaxCollected = data.TotalTaxCollected,
                                     TransactionEndTime = data.TransactionEndTime,
                                     TransactionStartTime = data.TransactionStartTime,
                                     UpdatedBy = data.UpdatedBy,
                                     UpdatedDate = data.UpdatedDate,
                                     StoreName = data.StoreName,
                                     TerminalName = data.TerminalName,
                                     StartDate = data.StartDate
                                 }).ToList<Stats_List>();
            stats.syncdata = (from data in db.GetSyncwiselist(Convert.ToInt32(storeid))
                              select new SyncData
                              {
                                  Createdate = data.Createdate,
                                  filename = data.filename,
                                  id = data.id,
                                  issync = data.issync,
                                  Storeid = data.Storeid,
                                  StoreName = data.StoreName,
                                  ErrorMessage = data.ErrorMessage
                              }).ToList<SyncData>();
            return View(stats);
        }

        public ActionResult DownloadPhoto(string FileName = "")
        {
            string FileUrl = wwwroot.Class.AdminSiteConfiguration.GetURL() + "userfiles/Pending/" + FileName;
            var Ext = (System.IO.Path.GetExtension(FileUrl)).ToString().Substring(1);
            Response.ContentType = Ext + "/application";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.WriteFile("~\\userfiles\\Pending\\" + FileName);
            Response.End();
            //return null;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0)
        {
            StatusMessage = "";
            if (id > 0)
            {
                tbl_Storewise_Excelupload Data = db.tbl_Storewise_Excelupload.Find(id);
                Data.isActive = true;
                db.Entry(Data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                StatusMessage = "Delete";
                ViewBag.StatusMessage = StatusMessage;
                
            }
            return null;
        }
    }
}