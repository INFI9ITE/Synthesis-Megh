using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using wwwroot.Areas.Admin.Models;
using wwwroot.Class;
using wwwrootBL.Entity;
using static wwwrootBL.Entity.Utility;

namespace wwwroot.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator,Back Office Manager,Data Approver,Store Manager,Owner,Employee")]
    [InitializeSimpleMembershipAttribute]

    public class AdminIncludeController : Controller
    {
        WestZoneEntities db = new WestZoneEntities();
        public ActionResult AdminLoginHeader()
        {

            return View();
        }


        public ActionResult Footer()
        {

            return View();
        }


        public ActionResult Header()
        {
            Store_header Store_headerobj = new Store_header();
            if ((!Roles.IsUserInRole("Administrator")) && (!Roles.IsUserInRole("Store Manager")))
            {
                Store_headerobj.Storenamelist = (from dataUser in db.tbl_user_store_By_Reg_userid(@WebSecurity.CurrentUserId)
                                                 select new ddllist
                                                 {
                                                     Value = dataUser.Storeid.ToString(),
                                                     Text = dataUser.StoreName

                                                 }).ToList();
                if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
                {
                    Store_headerobj.storeid = Convert.ToInt32(Session["storeid"]);
                }
                else
                {
                    return RedirectToAction("index", "login");
                }
            }
            else
            {
                List<ddllist> lst = new List<ddllist>();
                ddllist obj = new ddllist();
                obj.Text = "All Store";
                obj.Value = "0";
                lst.Add(obj);
                Store_headerobj.Storenamelist = lst;
                Store_headerobj.Storenamelist.AddRange((from dataUser in db.tbl_user_Selectstore()
                                                        select new ddllist
                                                        {
                                                            Value = dataUser.Id.ToString(),
                                                            Text = dataUser.Name

                                                        }).ToList());
                //Store_headerobj.storeid = Convert.ToInt32(GlobalStore.GlobalStore_id);
                if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
                {
                    Store_headerobj.storeid = Convert.ToInt32(Session["storeid"]);
                }
                else
                {
                    return RedirectToAction("index", "login");
                }
            }
            return View(Store_headerobj);
        }

        //public ActionResult getStore()
        //{

        //    return View();
        //}


        [HttpPost]
        public ActionResult Header(Store_header PostedData, string stid, string name)
        {
            string Currentpagename = HttpContext.Request.RequestContext.RouteData.Values["controller"].ToString();
            //PostedData.storeid = succstoreman.Reg_userid.GetValueOrDefault();


            // string storename= PostedData.hdstore;
            // int id = db.tbl_Store.Where(x => x.Name == storename).Select(x => x.Id).FirstOrDefault();
            Session["storeid"] = PostedData.storeid.ToString();
            //GlobalStore.GlobalStore_id = PostedData.storeid.ToString();

            //  GlobalStore.GlobalStore_name = storename;
            //return Redirect("/Dashboard");
            if (name == "shiftwisereport")
            {
                return RedirectToAction("index", "shiftwisereport");
            }
            if (name == "shiftwisetenderreport")
            {
                return RedirectToAction("index", "shiftwisetenderreport");
            }
            if (name == "stats")
            {
                return RedirectToAction("index", "stats");
            }
            return RedirectToAction("index", "dashboard");

            //return View();
        }

        public ActionResult Menu()
        {

            return View();
        }
        public ActionResult SideMenu()
        {
            ViewBag.Flag = "True";
            return View();
        }
        public ActionResult signout()
        {
            FormsAuthentication.SignOut();
            WebSecurity.Logout();
            Session.Abandon(); // it will clear the session at the end of request
            return Redirect("/Login");

        }
        [HttpGet]
        public ActionResult GetAllData()
        {
            // string Store_val = ""  // pass it on parameter
            WestZoneEntities db = new WestZoneEntities();
            string username = User.Identity.Name;
            int Count = 10; IEnumerable<object> Result = null;

            object[] parameters = { Count };
            int userid = Convert.ToInt32(WebSecurity.CurrentUserId);


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
            //   var data1 = db.Get_InvoiceNotification(userid).ToList();

            string storeid = "";
            if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
            {
                storeid = Convert.ToString((Session["storeid"]));
            }
            else
            {
                RedirectToAction("index", "login");
            }
            // int storeid = Convert.ToInt32(GlobalStore.GlobalStore_id);

            Result = (from data in db.Get_InvoiceNotification(userid, Convert.ToInt32(storeid))

                      select new Invoice_Notification
                      {
                          id = data.id,
                          Storename = data.storename,
                          Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
                          Invoice_Number = data.Invoice_Number,
                          Store_id = data.Store_id.GetValueOrDefault(),
                          username = data.fullname,
                          NotificationColor = data.NotificationColor.GetValueOrDefault(),
                      }).ToList<Invoice_Notification>();

            var modalcountval = db.Get_InvoiceNotification_Grid(userid, Convert.ToInt32(storeid)).Count();


            ViewBag.Modalcount = modalcountval;

            return PartialView("~/Areas/Admin/Views/AdminInclude/_InvoiceNotification.cshtml", Result);
        }

        [HttpGet]
        public ActionResult GetUserWiseStickyNote()
        {
            var getdata = (from dr in db.tbl_UserWiseStickyNotes where dr.UserId == WebSecurity.CurrentUserId select dr.Notes).FirstOrDefault();
            return Json(new { notes = getdata == null ? "" : getdata }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SetUserWiseStickyNote(string notes)
        {
            try
            {
                tbl_UserWiseStickyNotes getdata = (from dr in db.tbl_UserWiseStickyNotes where dr.UserId == WebSecurity.CurrentUserId select dr).FirstOrDefault();
                if (getdata != null)
                {
                    getdata.Notes = notes;
                    db.Entry(getdata).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { notes = getdata.Notes, msg = "Note updated successfully.", msgstatus = 1, excepetion = "" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    getdata = new tbl_UserWiseStickyNotes();
                    getdata.Notes = notes;
                    getdata.UserId = WebSecurity.CurrentUserId;
                    db.tbl_UserWiseStickyNotes.Add(getdata);
                    db.SaveChanges();
                    return Json(new { notes = getdata.Notes, msg = "Note added successfully.", msgstatus = 1, excepetion = "" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { notes = "", msg = "An error while updating entry.", msgstatus = 0, excepetion = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
