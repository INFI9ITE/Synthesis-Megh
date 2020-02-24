using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using wwwroot.Areas.Admin.Models;
using wwwroot.Class;
using wwwroot.Models;
using wwwrootBL.Entity;
namespace wwwroot.Controllers
{
    [InitializeSimpleMembershipAttribute]
    public class ForgotPasswordController : Controller
    {
        WestZoneEntities db = new WestZoneEntities();
        protected static string StatusMessage = "";
        // GET: ForgotPassword
        public ActionResult Index()
        {
            ViewBag.StatusMessage = StatusMessage;
            StatusMessage = "";

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ForgetPassword pwd)
        {

            string success_val = "false";

            //  string abc = ((SimpleMembershipProvider)Membership.Provider).GetPassword(id, true.ToString());
            if (ModelState.IsValid)
            {
                string existUser = Convert.ToString((from Data in db.getusernames()
                                                     where Data.UserName.Trim().ToLower() == pwd.Username.Trim().ToLower()
                                                     select Data.UserId).FirstOrDefault());

                if (Convert.ToInt32(existUser) != 0)
                {


                    pwd.Name = pwd.Username;

                    string Role = (from a in db.getrolebyusername(pwd.Username) select a).SingleOrDefault().ToString();

                    int UserId = Convert.ToInt32(existUser);
                    //if (Role == "Administrator")
                    //{

                    //    pwd.Email = "vibhusha@meghtechnologies.com";
                    //}
                    //else
                    //{
                        pwd.Email = (from a in db.GetEmailId(Role, UserId) select a).SingleOrDefault().ToString();
                    //}



                    var token = WebSecurity.GeneratePasswordResetToken(pwd.Username);

                    string resetLink = "<a href='" + wwwroot.Class.AdminSiteConfiguration.GetURL() + Url.Action("ResetPassword", "ForgotPassword", new { rt = token }) + "'>Click here</a>";
                    pwd.Password = resetLink;

                    pwd.Subject = "Forgot Password " + wwwroot.Class.AdminSiteConfiguration.SiteName;

                    Utility getdata = new Utility();
                    getdata = (from a in db.Utilities select a).FirstOrDefault();
                    string from = getdata.from;
                    var to = pwd.Email;

                    //Response.Write(getdata.from + "  " +pwd.Email);
                    //Response.End();

                    //Response.Write("Name:" + pwd.Name + ":Username:" + pwd.Username + ":Email:" + pwd.Email + ":pwd:" + pwd.Password + ":Sub:" + pwd.Subject);
                    //Response.End();
                    string HTML = ViewRenderer.RenderPartialView("~/Views/MailTemplate/ForgotPasswordMail.cshtml", pwd, ControllerContext);



                    success_val = "true";
                    //try
                    //{

                        AdminUtilities.SendMail(from, to, pwd.Subject, HTML.ToString());
                    //}
                    //catch(Exception e) { }

                    StatusMessage = "Success";
                    return RedirectToAction("index");
                }
                else
                {
                    ViewBag.StatusMessage = "Exists";
                    return View(pwd);
                }
            }
            else
            {
                ViewBag.StatusMessage = "Error";
                return View(pwd);
            }

            ViewBag.StatusMessage = StatusMessage;

            return View(pwd);
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(string rt)
        {
            ViewBag.StatusMessage = "";
            ResetPassword Rp = new ResetPassword();
            Rp.rt = rt;
            return View(Rp);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPassword model, string hftoken)
        {

            if (ModelState.IsValid)
            {

                bool resetResponse = WebSecurity.ResetPassword(hftoken, model.Password);
                //Response.Write(resetResponse);
                //Response.End();
                if (resetResponse)
                {
                    ViewBag.StatusMessage = "Success";
                }
                else
                {
                    ViewBag.StatusMessage = "Error";
                }
            }

            return View(model);
        }


        public string GetMailTemplate(Message_Mail MailData)
        {
            string HTML = "";
            HTML = ViewRenderer.RenderPartialView("~/Views/MailTemplate/MessageMail.cshtml", MailData, ControllerContext);
            return HTML;
        }
    }
}