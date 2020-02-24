using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using wwwroot.Class;
using wwwrootBL.Entity;
namespace wwwroot.Controllers
{
    //[Authorize(Roles="No Role")]
    [InitializeSimpleMembershipAttribute]
    public class RoleController : Controller
    {
        //
        // GET: /Role/


        public ActionResult Index()
        {
            return View();
        }

        #region Admin Create

        public ActionResult AdminCreate()
        {
            try
            {
                WebSecurity.CreateUserAndAccount("Admin", "Camlin@357");

                Roles.CreateRole("Administrator");
                Roles.AddUserToRole("Admin", "Administrator");
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index", "Role");
        }

        #endregion



        #region Role

        public ActionResult ManageRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleCreate(string RoleName)
        {

            try
            {
                Roles.CreateRole(RoleName);

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message + "<== Error");


            }
            return RedirectToAction("Index", "Role");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleDelete(string RoleName)
        {

            try
            {
                Roles.DeleteRole(RoleName);

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);

            }
            return RedirectToAction("Index", "Role");

        }
        #endregion



        #region User

        public ActionResult ManageUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUserWithRoleName(string UserName, string Password, string RoleName)
        {
            try
            {
                WebSecurity.CreateUserAndAccount(UserName, Password);



            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }


            try
            {
                Roles.CreateRole(RoleName);
            }
            catch { }

            try
            {

                Roles.AddUserToRole(UserName, RoleName);
            }
            catch { }

            return RedirectToAction("Index", "Role");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUser(string UserName)
        {
            WestZoneEntities db = new WestZoneEntities();

            var courseList = db.getusernames().ToList<getusernames_Result>();


            foreach (getusernames_Result cs in courseList)
            {
                try
                {
                    if (Roles.GetRolesForUser(cs.UserName).Count() > 0)
                    {
                        Roles.RemoveUserFromRoles(cs.UserName, Roles.GetRolesForUser(cs.UserName));
                    }
                }
                catch { }


                try
                {
                    ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(cs.UserName);

                }
                catch { }


                try
                {

                    ((SimpleMembershipProvider)Membership.Provider).DeleteUser(cs.UserName, true);
                }
                catch { }
            }



            try
            {
                //DataBaseEntities db = new DataBaseEntities();
                var UserNames = db.getusernames();
                foreach (var item in UserNames)
                {
                    if (WebMatrix.WebData.WebSecurity.UserExists(item.UserName))
                    {
                        var userRoles = Roles.GetRolesForUser(item.UserName);
                        if (userRoles.Count() > 0)
                        {
                            Roles.RemoveUserFromRoles(item.UserName, userRoles);
                            ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(item.UserName);
                        }
                        else
                        {
                            ((SimpleMembershipProvider)Membership.Provider).DeleteUser(item.UserName, true);
                        }
                        // deletes record from webpages_Membership table 

                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            return RedirectToAction("Index", "Role");
        }


        #endregion

    }
}
