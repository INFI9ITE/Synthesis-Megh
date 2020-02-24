using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wwwroot.Areas.Admin.Models;
using wwwroot.Models;
using wwwroot.Class;
using WebMatrix.WebData;
using Microsoft.Web.WebPages.OAuth;
using wwwrootBL.Entity;
namespace wwwroot.Areas.Admin.Controllers
{
    public class ChangePasswordController : Controller
    {
        protected static string StatusMessage = "";
        // GET: Admin/ChangePassword
        public ActionResult Index()
        {
            ViewBag.StatusMessage = StatusMessage;
            // ViewBag.Sucessmessage = savedmessage;
            StatusMessage = "";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AdminChangePasswordModel postdata)
        {
            WestZoneEntities db = new WestZoneEntities();
            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("ChangePassword");
            if (hasLocalAccount)
            {
                if (ModelState.IsValid)
                {
                    string Error = "";
                    bool changePasswordSucceeded;
                    try
                    {
                        changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, postdata.OldPassword, postdata.NewPassword);
                        var UpdateEmpPwd = db.Update_tbl_user_Password(User.Identity.Name, postdata.NewPassword);

                    }
                    catch (Exception ex)
                    {
                        Error = ex.Message;
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        StatusMessage = "SuccessChangePassword";
                        ViewBag.Sucessmessage = StatusMessage;
                        TempData["message"] = "Changepasswordsucess";
                    }
                    else
                    {
                        StatusMessage = "Chnagepassworderror";
                        ViewBag.StatusMessage = StatusMessage;
                        TempData["message"] = "Chnagepassworderror";
                    }
                }
                else
                {
                    StatusMessage = "Error";
                    ViewBag.StatusMessage = StatusMessage;
                    TempData["message"] = "Chnagepassworderror";
                    return View(postdata);
                }
            }
            //StatusMessage = "SuccessChangePassword";
            //ViewBag.Sucessmessage = StatusMessage;
            //Response.Write(ViewBag.Sucessmessage);
            //Response.Write(StatusMessage);
            //Response.End();
            return RedirectToAction("index");
        }


        public ActionResult validatepassword(string Password)
        {
            bool isvaliduser = false;
            string UserName = WebSecurity.CurrentUserName;
            isvaliduser = WebSecurity.Login(UserName, Password);
            return Json(new { IsValid = isvaliduser }, JsonRequestBehavior.AllowGet);
        }
    }
}