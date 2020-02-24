using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using wwwroot.Areas.Admin.Models;

using wwwroot.Class;
using wwwrootBL.Entity;

namespace wwwroot.Controllers
{

    [InitializeSimpleMembershipAttribute]
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/
        protected static string StatusMessage = "";
        WestZoneEntities db = new WestZoneEntities();
        public ActionResult Index()
        {
            ViewBag.statusmessage = StatusMessage;

            if (!string.IsNullOrEmpty(StatusMessage))
            {
                if (StatusMessage == "t")
                {
                    ViewBag.ErrorMessage = "Invalid username or password.";
                }
                if (StatusMessage == "t1")
                {
                    ViewBag.ErrorMessage = "Login failed. Please contact System Administrator.";
                }
            }
            StatusMessage = "";

            if (Request.Cookies["AdminLoginCoockie"] != null)
            {
                try
                {
                    ViewBag.ReturnUrl = Request.QueryString["ReturnUrl"].ToString();
                }
                catch { }

                try
                {
                    HttpCookie AdminLoginCoockie = Request.Cookies.Get("AdminLoginCoockie");

                    string AdminUsername = AdminLoginCoockie.Values["AdminUsername"].ToString();
                    string AdminPassword = AdminLoginCoockie.Values["AdminPassword"].ToString();
                    string AdminRememberme = AdminLoginCoockie.Values["AdminRememberme"].ToString();

                    if (AdminRememberme == true.ToString())
                    {
                        ViewBag.AdminUsername = AdminUsername;
                        ViewBag.AdminPassword = AdminPassword;
                        ViewBag.AdminRememberme = AdminRememberme;

                    }
                }
                catch { }
            }

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Admin_Login model, string ReturnUrl = "")
        {
            int reg_userid = db.tbl_user.Where(x => x.UserName == model.UserName).Select(x => x.Reg_userid).FirstOrDefault().GetValueOrDefault();
            var storeid = db.tbl_user_store.Where(x => x.Reg_userid == reg_userid).Select(x => x.Storeid).FirstOrDefault();
            var storecount = db.tbl_user_store.Where(x => x.Storeid == storeid).Select(x => x.id).Count();
            //if (storecount > 0 || model.UserName == "admin")
            //{

            //}
            //StatusMessage = "t1";
            //return RedirectToAction("index", "login");
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                if (model.RememberMe == true)
                {
                    HttpCookie AdminLoginCoockie = new HttpCookie("AdminLoginCoockie");
                    Response.Cookies.Remove("AdminLoginCoockie");
                    Response.Cookies.Add(AdminLoginCoockie);
                    AdminLoginCoockie.Values.Add("AdminUsername", model.UserName.ToString());
                    AdminLoginCoockie.Values.Add("AdminPassword", model.Password.ToString());
                    AdminLoginCoockie.Values.Add("AdminRememberme", model.RememberMe.ToString());

                    DateTime dtExpiry = DateTime.Now.AddDays(100);
                    Response.Cookies["AdminLoginCoockie"].Expires = dtExpiry;
                }
                else
                {
                    HttpCookie myCookie = new HttpCookie("AdminLoginCoockie");

                    Response.Cookies.Remove("AdminLoginCoockie");
                    DateTime dtExpiry = DateTime.Now.AddDays(-10);
                    Response.Cookies["AdminLoginCoockie"].Expires = dtExpiry;
                }

                int stid;
                int userid = WebSecurity.GetUserId(model.UserName);
                var Store = db.tbl_user_store_By_Reg_userid(Convert.ToInt32(userid)).Select(x => x.StoreName).FirstOrDefault();
                stid = db.tbl_Store.Where(x => x.Name == Store).Select(x => x.Id).FirstOrDefault();
               // GlobalStore.GlobalStore_id = stid.ToString();
                Session["storeid"] = stid.ToString();
                if (Roles.IsUserInRole(model.UserName, "Administrator"))
                {

                    return RedirectToAction("index", "dashboard", new { area = "Admin" });
                }
                else if (Roles.IsUserInRole(model.UserName, "Back Office Manager"))
                {

                    return RedirectToAction("index", "dashboard", new { area = "Admin" });
                }
                else if (Roles.IsUserInRole(model.UserName, "Data Approver"))
                {

                    return RedirectToAction("index", "dashboard", new { area = "Admin" });
                }
                else if (Roles.IsUserInRole(model.UserName, "Store Manager"))
                {

                    return RedirectToAction("index", "dashboard", new { area = "Admin" });
                }
                else if (Roles.IsUserInRole(model.UserName, "Owner"))
                {

                    return RedirectToAction("index", "dashboard", new { area = "Admin" });
                }
                else if (Roles.IsUserInRole(model.UserName, "Employee"))
                {

                    return RedirectToAction("index", "dashboard", new { area = "Admin" });
                }
                //else if (Roles.IsUserInRole(model.UserName, "GrnDetails"))
                //{
                //    return RedirectToAction("index", "dashboard", new { area = "Admin" });
                //}
                //else if (Roles.IsUserInRole(model.UserName, "Order"))
                //{
                //    return RedirectToAction("index", "dashboard", new { area = "Admin" });
                //}
                //else if (Roles.IsUserInRole(model.UserName, "PoDetail"))
                //{
                //    return RedirectToAction("index", "dashboard", new { area = "Admin" });
                //}
                //else if (Roles.IsUserInRole(model.UserName, "ProjectExpenses"))
                //{
                //    return RedirectToAction("index", "dashboard", new { area = "Admin" });
                //}
                //else if (Roles.IsUserInRole(model.UserName, "SalesBilling"))
                //{
                //    return RedirectToAction("index", "dashboard", new { area = "Admin" });
                //}
                StatusMessage = " ";

                return RedirectToAction("index", "login");
            }

            //StatusMessage = " ";
            StatusMessage = "t";
            return RedirectToAction("index", "login");
        }


        public ActionResult LogOut()
        {

            WebSecurity.Logout();

            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }


        public ActionResult ChangePassword(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
              message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
              : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
              : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
              : "";

            ViewBag.StatusMessageError = message == ManageMessageId.ChangePasswordError ? "The current password is incorrect or the new password is invalid." : "";

            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("ChangePassword");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(AdminChangePasswordModel model)
        {
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
                        changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                    }
                    catch (Exception ex)
                    {
                        Error = ex.Message;
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("ChangePassword", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        return RedirectToAction("ChangePassword", new { Message = ManageMessageId.ChangePasswordError });
                    }
                }
            }
            return View(model);
        }


        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            ChangePasswordError,
        }

    }
}
