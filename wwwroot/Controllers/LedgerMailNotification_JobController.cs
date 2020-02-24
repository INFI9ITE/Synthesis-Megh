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
    public class LedgerMailNotification_JobController : Controller
    {
        // GET: LedgerMailNotification_Job
        wwwrootnewEntities db = new wwwrootnewEntities();
        protected static string StatusMessage = "";
        public ActionResult Index()
        {
            int Ledgerdatabyid=0;
            foreach (var data in db.Ledger_GetISmail_data())
            {
                Ledgerdatabyid = data.Id;

                Mail(Ledgerdatabyid);
                //db.Ledger_updateIsmail_flag(Ledgerdatabyid);
                //db.SaveChanges();
            }
            db.Ledger_updateIsmail_flag();
            return View();
          
        }

      
        private void Mail(int id)
        {
            #region
            string success_val = "false";
            Employee_ExcelUpload UserProfile = new Employee_ExcelUpload();
            Ledger ledger_data = db.Ledgers.Find(id);
            UserProfile.EmpCode = ledger_data.EmpCode;

            var email = db.Employee_Select_EmailByEmpcode(ledger_data.EmpCode).FirstOrDefault();

            UserProfile.Email = email.ToString();
            UserProfile.Name = ledger_data.EmpName;
            UserProfile.Advance = Convert.ToDecimal(ledger_data.Advance);
            UserProfile.ExpenseClaim = Convert.ToDecimal(ledger_data.ExpenseClaim);
            UserProfile.Net = Convert.ToDecimal(ledger_data.Net);
            UserProfile.EntryNo = ledger_data.EntryNo;
            UserProfile.EntryDate = Convert.ToDateTime(ledger_data.EntryDate);
            UserProfile.ClaimReport = ledger_data.ClaimReport;
            UserProfile.Period = Convert.ToInt32(ledger_data.Period);
            UserProfile.NhText = ledger_data.NhText;
            UserProfile.Crdesc = ledger_data.Crdesc;
            UserProfile.Subject = "User Register " + wwwroot.Class.AdminSiteConfiguration.SiteName;

            Utility getdata = new Utility();
            getdata = (from a in db.Utilities select a).FirstOrDefault();
            string from = getdata.from;
            var to = UserProfile.Email;
            string HTML = ViewRenderer.RenderPartialView("~/Views/MailTemplate/EmployeeMail.cshtml", UserProfile, ControllerContext);
            success_val = "true";
            AdminUtilities.SendMail(from, to, UserProfile.Subject, HTML.ToString());
            Response.Write(HTML.ToString());
           
            #endregion
        }

    }
}