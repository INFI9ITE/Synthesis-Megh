using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using wwwroot.Areas.Admin.Models;
using wwwroot.Class;
using wwwrootBL.Entity;
using System.Data.Common;

namespace wwwroot.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [InitializeSimpleMembershipAttribute]
    public class UserController : Controller
    {
        // GET: Admin/User
        protected static string StatusMessage = "";
        protected static string InsertMessage = "";
        protected static string LockMessage = "";
        protected static string UnLockMessage = "";
        protected static string Editmessage = "";
        protected static string ActivityLogMessage = "";
        private const int FirstPageIndex = 1;
        protected static int TotalDataCount;
        protected static Array Arr;
        protected static bool IsArray;
        protected static IEnumerable BindData;
        protected static bool IsEdit = false;
        protected static string EmployeeCode;
        int userid = Convert.ToInt32(WebSecurity.CurrentUserId);
        string loginusername = WebSecurity.CurrentUserName;
        WestZoneEntities db = new WestZoneEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grid(int IsBindData = 1, int currentPageIndex = 1, string orderby = "id", int IsAsc = 0, int PageSize = 10, int SearchRecords = 1, string Alpha = "", string SearchTitle = "")
        {
            #region MyRegion_Array
            try
            {

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
                        if (a1.Split(':')[0].ToString() == "SearchTitle")
                        {
                            SearchTitle = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        //if (a1.Split(':')[0].ToString() == "Department")
                        //{
                        //    SearchTitle = Convert.ToString(a1.Split(':')[1].ToString());
                        //}
                        //if (a1.Split(':')[0].ToString() == "Designation")
                        //{
                        //    SearchTitle = Convert.ToString(a1.Split(':')[1].ToString());
                        //}
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
                ,"SearchTitle:" + SearchTitle

            };
            #endregion

            #region MyRegion_BindData
            int startIndex = ((currentPageIndex - 1) * PageSize) + 1;
            int endIndex = startIndex + PageSize - 1;

            if (IsBindData == 1 || IsEdit == true)
            {
                BindData = GetData(SearchRecords, SearchTitle).OfType<User_Select>().ToList();
                TotalDataCount = BindData.OfType<User_Select>().ToList().Count();

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
            ViewBag.SearchTitle = SearchTitle;
            ViewBag.StatusMessage = StatusMessage;
            ViewBag.Insert = InsertMessage;
            ViewBag.Edit = Editmessage;
            ViewBag.Lock = LockMessage;
            ViewBag.UnLock = UnLockMessage;
            ViewBag.startindex = startIndex;

            if (TotalDataCount < endIndex)
            {
                ViewBag.endIndex = TotalDataCount;
            }
            else
            {
                ViewBag.endIndex = endIndex;
            }
            ViewBag.TotalDataCount = TotalDataCount;
            var ColumnName = typeof(User_Select).GetProperties().Where(p => p.Name == orderby).FirstOrDefault();

            IEnumerable Data = null;
            //Response.Write(ColumnName);
            //Response.End();
            if (IsAsc == 1)
            {
                ViewBag.AscVal = 0;
                Data = BindData.OfType<User_Select>().ToList().OrderBy(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            else
            {

                ViewBag.AscVal = 1;

                Data = BindData.OfType<User_Select>().ToList().OrderByDescending(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            StatusMessage = "";
            //// ViewBag.Pagetext = "Showing " + iStartsRecods + " to " + iEndRecord + " of " + iTotalRecords + " entries";
            //List<ddllist> LstDatadept = new List<ddllist>();
            //LstDatadept = FillDrpLstDepartment();
            //ViewBag.DataDept = LstDatadept;

            //List<ddllist> LstDatadesig = new List<ddllist>();
            //LstDatadesig = FillDrpLstDesignation();
            //ViewBag.Datadesig = LstDatadesig;
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

        private IEnumerable GetData(int SearchRecords = 0, string SearchTitle = "")
        {
            IEnumerable RtnData = null;
            RtnData = (from data in db.tbl_user_GridData(SearchTitle)

                       select new User_Select
                       {
                           id = data.id,
                           Name = data.Name,
                           userid = data.userid_val.GetValueOrDefault(),
                           UserName = data.Username,
                           Password = data.Password,
                           //Email = data.Email,
                           CreatedOn = data.CreatedOn,
                           rolename = data.RoleName,
                           Reg_userid = data.Reg_userid.GetValueOrDefault(),
                           IsLock = data.lockval.GetValueOrDefault(),
                           Rolename=data.RoleName
                           //BindStorename=(from a in db.tbl_user_store where a.Reg_userid==data.Reg_userid select a.StoreName).ToList()

                       }).ToList<User_Select>();

            return RtnData;
        }

        //#region Fill DropdownList Store
        //public List<ddllist> FillDrpLstStore()
        //{
        //    List<ddllist> LstStore = new List<ddllist>();
        //    LstStore = (from a in db.tbl_Store
        //                orderby a.Name ascending
        //                select new ddllist
        //                {
        //                    Value = a.Name.ToString(),
        //                    Text = a.Name
        //                }).ToList();

        //    return LstStore;
        //}
        //#endregion

        #region Fill DropdownList Role
        public List<ddllist> FillDrpLstRole()
        {
            List<ddllist> LstRole = new List<ddllist>();
            LstRole = (from a in db.GetRoleNameList()
                       orderby a.RoleName ascending

                       select new ddllist
                       {
                           Value = a.RoleName.ToString(),
                           Text = a.RoleName

                       }).ToList();

            return LstRole;
        }
        #endregion

        public ActionResult Create(int ID = 0)
        {
            //ViewBag.statusmessage = "t";
            ViewBag.StatusMessage = StatusMessage;
            ViewBag.Insert = InsertMessage;
            StatusMessage = "";
            IsArray = true;
            User_Create User_data = new User_Create
            {
                BindRoleList = FillDrpLstRole()
                // BindStoreList = FillDrpLstStore()
                //BindRoleList = (from a in db.GetRoleNameList()
                //                orderby a.RoleName ascending
                //                //where
                //                //!a.RoleName.Contains("Administrator")
                //                //!a.RoleName.Contains("User")
                //                // a.RoleName ascending
                //                select new ddllist
                //                {
                //                    Value = a.RoleName,
                //                    Text = a.RoleName
                //                    //== "POS" ? "Cafe" : a.RoleName
                //                }).ToList()
            };

            return View(User_data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User_Create PostedData, string[] Storename, string rolename)
        {
            string success_val = "false";

            PostedData.BindRoleList = FillDrpLstRole();
            //PostedData.BindStoreList = FillDrpLstStore();

            if (ModelState.IsValid)
            {
                try
                {
                    string username = PostedData.UserName;
                    WebSecurity.CreateUserAndAccount(username, PostedData.Password);

                    int user_id = Convert.ToInt32(WebSecurity.GetUserId(username));
                    Roles.AddUserToRole(username, rolename);
                    //var rid = db.webpages_Roles_byRolename(rolename).Select();
                    string rid = Convert.ToString((from Data in db.webpages_Roles_byRolename(rolename)
                                                   select Data.Value).FirstOrDefault());
                    var success = db.tbl_user_Insert(PostedData.Name, "", username, PostedData.Password, loginusername, userid, Convert.ToInt32(rid), user_id).Select(x => x.Value).FirstOrDefault();

                    if (success.ToString() != "")
                    {
                        #region add multiple Store to User
                        //foreach (var item in Storename)
                        //{
                        //    db.tbl_user_store_Insert(userid, item, user_id);

                        //} 
                        #endregion
                        int uid = WebSecurity.CurrentUserId;
                        string fullname = db.tbl_user.Where(x => x.userid == uid).Select(x => x.Name).FirstOrDefault();
                        ActivityLogMessage = "User " + "<a href='/admin/user/detail/" + success + "'>" + PostedData.UserName + "</a> created by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.AddHours(1).ToString());
                        //ActivityLogMessage = "User: " + PostedData.UserName + " is created by " + loginusername + " on this " + DateTime.Today;
                        var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, loginusername, 1);
                        IsArray = false;
                        InsertMessage = PostedData.UserName + " has been created successfully.";
                        StatusMessage = "Success";
                    }


                    return RedirectToAction("index");
                    ViewBag.Insert = InsertMessage;
                    ViewBag.StatusMessage = StatusMessage;
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                    StatusMessage = "t";
                    return RedirectToAction("create", "user");
                }
            }
            else
            {
                ViewBag.StatusMessage = "Error";
            }
            // PostedData.BindStoreList = FillDrpLstStore();
            return View(PostedData);

        }

        public ActionResult ChangeStatusUnLock(int id = 0, bool active = false)
        {
            db.Membership_EnableUser(id);


            //tbl_user Data = db.tbl_user.Find(id);
            int uid = WebSecurity.CurrentUserId;
            string username = Convert.ToString((from Data1 in db.tbl_user_byid(id)
                                                select Data1.UserName).FirstOrDefault());
            string fullname = db.tbl_user.Where(x => x.userid == uid).Select(x => x.Name).FirstOrDefault();
            ActivityLogMessage = "User " + username + " UnLocked by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.AddHours(1).ToString());
            var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, loginusername, 3);

            UnLockMessage = username + " has been Unlocked successfully.";
            ViewBag.UnLock = UnLockMessage;
            StatusMessage = "UnLock";

            ViewBag.StatusMessage = StatusMessage;
            return null;
        }
        public ActionResult ChangeStatusLock(int id = 0, bool active = true)
        {
            db.Membership_DisableUser(id);

            //tbl_user Data = db.tbl_user.Find(id);

            string username = Convert.ToString((from Data1 in db.tbl_user_byid(id)
                                                select Data1.UserName).FirstOrDefault());
            int uid = WebSecurity.CurrentUserId;
            string fullname = db.tbl_user.Where(x => x.userid == uid).Select(x => x.Name).FirstOrDefault();
            ActivityLogMessage = "User " + username + " Locked by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.AddHours(1).ToString());
            var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, loginusername, 3);
            LockMessage = username + " has been locked successfully.";
            ViewBag.Lock = LockMessage;
            StatusMessage = "Lock";
            ViewBag.StatusMessage = StatusMessage;
            return null;
        }


        public ActionResult UserStore(int Id = 0)
        {
            List<UserStore> data_list = new List<UserStore>();
            //IsArray = true;
            //ViewBag.StatusMessage = StatusMessage;
            //ViewBag.Edit = Editmessage;
            //tbl_user Empdata = new tbl_user();


            //tbl_user Data = db.tbl_user.Find(Id);

            //User_Store User_Edit = new User_Store();

            ////if(Data.Roleid == 3)
            ////{
            //var STRID = db.StoreIdListFromUserId(Id).ToList();

            //for (int i = 0; i < STRID.Count; i++)
            //{
            //    var STID = STRID[i];
            //    if (Data.Roleid == 3 || Data.Roleid == 7)
            //    {


            //        var data = db.CheckUserExistwhilelock(STID, Data.Roleid, Data.Reg_userid).ToList();
            //        if (data.Count == 0)
            //        {
            //            var storename = db.tbl_Store.Where(x => x.Id == STID).Select(x => x.Name).FirstOrDefault();
            //            data_list.Add(new UserStore { UserStores = storename });
            //        }
            //    }
            //    else
            //    {
            //        data_list = (from datastore in db.tbl_user_store
            //                               where datastore.Reg_userid == Data.Reg_userid
            //                               select new UserStore
            //                               {
            //                                   UserStores = datastore.StoreName
            //                               }).ToList();
            //        var storename = db.tbl_Store.Where(x => x.Id == STID).Select(x => x.Name).FirstOrDefault();
            //        //data_list.Add(new UserStore { UserStores = storename });
            //    }
            //}
            //User_Edit.UserStore = data_list;

            ////var storeid = db.tbl_user_store.Where(x => x.Reg_userid == Data.Reg_userid).Select(x => x.Storeid).FirstOrDefault();

            ////ViewBag.Fullname = Data.Name;

            ////var succBackoffice = db.Get_ReguserId_edit(storeid).FirstOrDefault();
            ////User_Edit.BindBack_Office = (from dataUser in db.tbl_user_backoffice_edit_new(succBackoffice.Reg_userid, Data.Roleid)
            ////                             select new ddllist
            ////                             {
            ////                                 Value = dataUser.Reg_userid.ToString(),
            ////                                 Text = dataUser.Name

            ////                             }).ToList();
            ////}
            ////else
            ////{

            ////User_Edit.UserStore = (from datastore in db.tbl_user_store
            ////                       where datastore.Reg_userid == Data.Reg_userid
            ////                       select new UserStore
            ////                       {
            ////                           UserStores = datastore.StoreName
            ////                       }).ToList();
            //var storeid = db.tbl_user_store.Where(x => x.Reg_userid == Data.Reg_userid).Select(x => x.Storeid).FirstOrDefault();

            //ViewBag.Fullname = Data.Name;


            //User_Edit.BindBack_Office = (from dataUser in db.tbl_userlist(Data.Reg_userid, Data.Roleid, storeid)
            //                             select new ddllist
            //                             {
            //                                 Value = dataUser.Reg_userid.ToString(),
            //                                 Text = dataUser.Name
            //                             }).ToList();
            ////}
            //IsArray = true;
            //ViewBag.StatusMessage = StatusMessage;
            //ViewBag.Edit = Editmessage;
            tbl_user Empdata = new tbl_user();


            tbl_user Data = db.tbl_user.Find(Id);

            User_Store User_Edit = new User_Store();

            if (Data.Roleid == 3 || Data.Roleid == 7)
            {
                var STRID = db.StoreIdListFromUserId(Id).ToList();
                for (int i = 0; i < STRID.Count; i++)
                {
                    var STID = STRID[i];
                    var data = db.CheckUserExistwhilelock(STID, Data.Roleid, Data.Reg_userid).ToList();
                    if (data.Count == 0)
                    {
                        var storename = db.tbl_Store.Where(x => x.Id == STID).Select(x => x.Name).FirstOrDefault();
                        data_list.Add(new UserStore { UserStores = storename });
                    }
                }
                User_Edit.UserStore = data_list;
                var storeid = db.tbl_user_store.Where(x => x.Reg_userid == Data.Reg_userid).Select(x => x.Storeid).FirstOrDefault();

                ViewBag.Fullname = Data.Name;

                var succBackoffice = db.Get_ReguserId_edit(storeid).FirstOrDefault();
                User_Edit.BindBack_Office = (from dataUser in db.tbl_user_backoffice_edit_new(succBackoffice.Reg_userid, Data.Roleid).Where(x=>x.Reg_userid!= Data.Reg_userid)
                                             select new ddllist
                                             {
                                                 Value = dataUser.Reg_userid.ToString(),
                                                 Text = dataUser.Name

                                             }).ToList();
            }
            else
            {
                User_Edit.UserStore = (from datastore in db.tbl_user_store
                                       where datastore.Reg_userid == Data.Reg_userid
                                       select new UserStore
                                       {
                                           UserStores = datastore.StoreName
                                       }).ToList();
                var storeid = db.tbl_user_store.Where(x => x.Reg_userid == Data.Reg_userid).Select(x => x.Storeid).FirstOrDefault();

                ViewBag.Fullname = Data.Name;

                var succBackoffice = db.Get_ReguserId_edit(storeid).FirstOrDefault();
                User_Edit.BindBack_Office = (from dataUser in db.tbl_user_backoffice_edit_new(succBackoffice.Reg_userid, Data.Roleid)
                                             select new ddllist
                                             {
                                                 Value = dataUser.Reg_userid.ToString(),
                                                 Text = dataUser.Name

                                             }).ToList();
            }
            return View(User_Edit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserStore(User_Store PostedData, int[] Back_Office_userid, string[] Storename)
        {
            int id = PostedData.id;
            tbl_user Data = db.tbl_user.Find(id);
            if (ModelState.IsValid)
            {

                int temp = Back_Office_userid.Count();

                for (int j = 0; j < temp; j++)
                {
                    int regid = Back_Office_userid[j];
                    string storename = Storename[j];

                    int storeidbystorename = db.tbl_Store.Where(x => x.Name == storename).Select(x => x.Id).FirstOrDefault();


                    var succ_Role = db.Get_roleid_rolename_byReg_userid(regid).FirstOrDefault();
                    var succ_Back_offic_man = db.tbl_user_store_Insert_BackOfficeMan(storeidbystorename, userid, regid, storename, succ_Role.RoleId, succ_Role.Rolename);
                }
                var storeid = db.tbl_user_store.Where(x => x.Reg_userid == Data.Reg_userid).Select(x => x.Storeid).FirstOrDefault();
                db.delete_multiple_userstores(Convert.ToInt32(Data.Reg_userid), storeid);
                db.Membership_DisableUser(Data.Reg_userid);

                string username = Convert.ToString((from Data1 in db.tbl_user_byid(Data.Reg_userid)
                                                    select Data1.UserName).FirstOrDefault());
                int uid = WebSecurity.CurrentUserId;
                string fullname = db.tbl_user.Where(x => x.userid == uid).Select(x => x.Name).FirstOrDefault();
                ActivityLogMessage = "User " + username + " Locked by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.AddHours(1).ToString());
                var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, loginusername, 3);

                //PostedData.UserStore = (from datastore in db.tbl_user_store
                //                            where datastore.Reg_userid == Data.Reg_userid
                //                        select new UserStore
                //                            {
                //                                UserStores = datastore.StoreName

                //                            }).ToList();


                //    var storeid = db.tbl_user_store.Where(x => x.Reg_userid == Data.Reg_userid).Select(x => x.Storeid).FirstOrDefault();
                //    if (Data.Roleid == 2)
                //    {


                //        var succBackofficecount = db.Get_ReguserId_edit(storeid).Count();
                //        if (succBackofficecount > 0)
                //        {
                //            var succBackoffice = db.Get_ReguserId_edit(storeid).FirstOrDefault();
                //            PostedData.BindBack_Office = (from dataUser in db.tbl_user_backoffice_edit(succBackoffice.Reg_userid)
                //                                          select new ddllist
                //                                          {
                //                                              Value = dataUser.Reg_userid.ToString(),
                //                                              Text = dataUser.Name

                //                                          }).ToList();
                //            PostedData.Back_Office_userid = new List<int>();
                //            for (int i = 0; i < PostedData.BindBack_Office.Count; i++)
                //            {
                //                PostedData.Back_Office_userid.Add(succBackoffice.Reg_userid.GetValueOrDefault());
                //            }

                //        }

                //    }
                //    else if (Data.Roleid == 4)
                //    {
                //        var succstoremancount = db.Get_ReguserId_edit_storeman(storeid).Count();
                //        if (succstoremancount > 0)
                //        {
                //            var succstoreman = db.Get_ReguserId_edit_storeman(storeid).FirstOrDefault();
                //            PostedData.BindBack_Office = (from dataUser in db.tbl_user_Storemanager_edit(succstoreman.Reg_userid)
                //                                          select new ddllist
                //                                          {
                //                                              Value = dataUser.Reg_userid.ToString(),
                //                                              Text = dataUser.Name

                //                                          }).ToList();
                //            PostedData.Back_Office_userid = new List<int>();
                //            for (int i = 0; i < PostedData.BindBack_Office.Count; i++)
                //            {
                //                PostedData.Back_Office_userid.Add(succstoreman.Reg_userid.GetValueOrDefault());
                //            }
                //        }
                //    }
                //    else if (Data.Roleid == 3)
                //    {
                //        var succdataappcount = db.Get_ReguserId_edit_dataapp(storeid).Count();
                //        if (succdataappcount > 0)
                //        {
                //            var succdataapp = db.Get_ReguserId_edit_dataapp(storeid).FirstOrDefault();
                //            PostedData.BindBack_Office = (from dataUser in db.tbl_user_DataApprover_edit(succdataapp.Reg_userid)
                //                                          select new ddllist
                //                                          {
                //                                              Value = dataUser.Reg_userid.ToString(),
                //                                              Text = dataUser.Name

                //                                          }).ToList();
                //            PostedData.Back_Office_userid = new List<int>();
                //            for (int i = 0; i < PostedData.BindBack_Office.Count; i++)
                //            {
                //                int reg = succdataapp.Reg_userid.GetValueOrDefault();
                //                PostedData.Back_Office_userid.Add(reg);
                //            }

                //        }
                //    }

                return RedirectToAction("Index");
            }
            PostedData.UserStore = (from datastore in db.tbl_user_store
                                    where datastore.Reg_userid == Data.Reg_userid
                                    select new UserStore
                                    {
                                        UserStores = datastore.StoreName

                                    }).ToList();
            var storeid1 = db.tbl_user_store.Where(x => x.Reg_userid == Data.Reg_userid).Select(x => x.Storeid).FirstOrDefault();

            ViewBag.Fullname = Data.Name;

            var succBackoffice = db.Get_ReguserId_edit(storeid1).FirstOrDefault();
            PostedData.BindBack_Office = (from dataUser in db.tbl_user_backoffice_edit_new(succBackoffice.Reg_userid, Data.Roleid)
                                          select new ddllist
                                          {
                                              Value = dataUser.Reg_userid.ToString(),
                                              Text = dataUser.Name

                                          }).ToList();
            return RedirectToAction("UserStore", PostedData);
        }


        public ActionResult Resetpassword(int Id = 0)
        {
            User_Resetpassword User_Resetpassword = new User_Resetpassword();
            User_Resetpassword.Reg_userid = Id;
            //User_Resetpassword.Password = "";
            //User_Resetpassword.ConfirmPassword = "";
            return View(User_Resetpassword);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Resetpassword(User_Resetpassword PostedData)
        {

            string username = Convert.ToString((from Data1 in db.tbl_user_byid(PostedData.Reg_userid)
                                                select Data1.UserName).FirstOrDefault());
            bool changePasswordSucceeded;
            var token = WebSecurity.GeneratePasswordResetToken(username);
            changePasswordSucceeded = WebSecurity.ResetPassword(token, PostedData.Password);
            var UpdateEmpPwd = db.Update_tbl_user_Password(User.Identity.Name, PostedData.Password);

            int uid = WebSecurity.CurrentUserId;
            string fullname = db.tbl_user.Where(x => x.userid == uid).Select(x => x.Name).FirstOrDefault();
            ActivityLogMessage = "User " + username + " Locked by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.AddHours(1).ToString());
            var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, loginusername, 3);


            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id = 0)
        {
            IsArray = true;
            ViewBag.StatusMessage = StatusMessage;
            ViewBag.Edit = Editmessage;
            tbl_user Empdata = new tbl_user();


            tbl_user Data = db.tbl_user.Find(Id);
            var rolename = db.webpages_Roles.Where(x => x.RoleId == Data.Roleid).Select(x => x.RoleName).FirstOrDefault();
            var storeid = db.tbl_user_store.Where(x => x.Reg_userid == Data.Reg_userid).Select(x => x.Storeid).FirstOrDefault();
            User_Edit User_Edit = new User_Edit
            {
                BindRoleList = FillDrpLstRole(),
                // BindStoreList = FillDrpLstStore(),
                Name = Data.Name,
                //Email = Data.Email,
                UserName = Data.UserName,
                rolename = rolename,
                CreatedOn = Convert.ToDateTime(DateTime.Now.AddHours(1).ToString()),
                flag = db.tbl_user_store.Where(x => x.Storeid == storeid).Count()
            };


            User_Edit.UserStore = (from datastore in db.tbl_user_store
                                   where datastore.Reg_userid == Data.Reg_userid
                                   select new UserStore
                                   {
                                       UserStores = datastore.StoreName

                                   }).ToList();



            return View(User_Edit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(User_Edit PostedData, string[] StoreName, string rolename, int Id = 0)
        {
            IsEdit = true;
            PostedData.BindRoleList = FillDrpLstRole();
            // PostedData.BindStoreList = FillDrpLstStore();
            tbl_user custdata = new tbl_user();
            PostedData.UserStore = (from datastore in db.tbl_user_store
                                    where datastore.Reg_userid == PostedData.Reg_userid
                                    select new UserStore
                                    {
                                        UserStores = datastore.StoreName

                                    }).ToList();



            if (ModelState.IsValid)
            {
                tbl_user customer_data = db.tbl_user.Find(Id);
                int user_id = Convert.ToInt32(WebSecurity.GetUserId(PostedData.UserName));
                //string exist = Convert.ToString((from Data in db.tbl_user
                //                                 where Data.id != Id
                //                                 select Data.userid).FirstOrDefault());

                //if (Convert.ToInt32(exist) == 0)
                //{
                string rid = Convert.ToString((from Data in db.webpages_Roles_byRolename(rolename)
                                               select Data.Value).FirstOrDefault());
                customer_data.id = PostedData.id;
                customer_data.Name = PostedData.Name;

                customer_data.userid = user_id;
                customer_data.UserName = PostedData.UserName;
                customer_data.Roleid = Convert.ToInt32(rid);
                // customer_data.Email = PostedData.Email;

                customer_data.CreatedOn = Convert.ToDateTime(DateTime.Now.AddHours(1).ToString());
                db.Entry(customer_data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();


                //db.delete_multiple_userstores(customer_data.Reg_userid);
                db.delete_multiple_userRole(customer_data.Reg_userid);
                try { Roles.AddUserToRole(PostedData.UserName, rolename); }
                catch { }

                //foreach (var item in StoreName)
                //{
                //    db.tbl_user_store_Insert(userid, item, user_id);

                //}
                int uid = WebSecurity.CurrentUserId;
                string fullname = db.tbl_user.Where(x => x.userid == uid).Select(x => x.Name).FirstOrDefault();
                //ActivityLogMessage = "User: " + PostedData.UserName + " is edited by " + loginusername + " on this " + DateTime.Today;
                ActivityLogMessage = "User " + "<a href='/admin/user/detail/" + PostedData.id + "'>" + PostedData.UserName + "</a> updated by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.AddHours(1).ToString());
                var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, loginusername, 2);

                StatusMessage = "Success";
                Editmessage = PostedData.UserName + " has been updated successfully.";
                ViewBag.Edit = Editmessage;
                return RedirectToAction("Index");
                //}
                //else
                //{
                //    StatusMessage = "Exists";
                //}

            }
            else
            {
                StatusMessage = "Error";
            }

            ViewBag.StatusMessage = StatusMessage;
            return View(PostedData);
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter different User Name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }


        public JsonResult DrpStore()
        {
            //List<SelectListItem> customers = new List<SelectListItem>();

            //for (int i = 0; i < 10; i++)
            //{
            //    customers.Add(new SelectListItem
            //    {
            //        Value = entities.Customers.ToList()[i].CustomerID,
            //        Text = entities.Customers.ToList()[i].ContactName
            //    });
            //}
            List<ddllist1> LstStore = new List<ddllist1>();
            LstStore = (from a in db.tbl_Store
                        orderby a.Name ascending
                        select new ddllist1
                        {
                            Value = a.Name.ToString(),
                            Text = a.Name,
                            selectedvalue = false,
                        }).ToList();

            //return LstStore;
            return Json(new SelectList(LstStore.ToArray(), "Value", "Text"), JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Delete(int Id = 0)
        //{
        //    StatusMessage = "Error";
        //    //tbl_Store tbl_Store = PostedData.name;
        //    //db.Entry(customer_data).State = System.Data.Entity.EntityState.Modified;
        //    //db.SaveChanges();
        //    tbl_user Data = db.tbl_user.Find(Id);
        //    Data.IsActive = false;
        //    db.Entry(Data).State = System.Data.Entity.EntityState.Modified;
        //    db.SaveChanges();
        //    string username = Convert.ToString((from Data1 in db.tbl_user_byid(Data.id)
        //                                        select Data1.UserName).FirstOrDefault());
        //    ActivityLogMessage = "User: " + username + " is deleted by " + loginusername + " on this " + DateTime.Today;
        //    var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, loginusername);
        //    StatusMessage = "Delete";
        //    return null;
        //}


        public ActionResult Detail(int Id = 0)
        {
            IsArray = true;


            tbl_user Data = db.tbl_user.Find(Id);
            var rolename = db.webpages_Roles.Where(x => x.RoleId == Data.Roleid).Select(x => x.RoleName).FirstOrDefault();
            User_Select User_Select = new User_Select
            {
                BindRoleList = FillDrpLstRole(),
                //  BindStoreList = FillDrpLstStore(),
                Name = Data.Name,
                // Email = Data.Email,
                UserName = Data.UserName,
                rolename = rolename,
                CreatedOn = Convert.ToDateTime(DateTime.Now.AddHours(1)),
            };


            User_Select.UserStore = (from datastore in db.tbl_user_store
                                     where datastore.Reg_userid == Data.Reg_userid
                                     select new UserStore
                                     {
                                         UserStores = datastore.StoreName

                                     }).ToList();
            //tbl_user Data = db.tbl_user.Find(Id);
            //ViewBag.IDOnDetailPage = Id;
            //User_Select customer_select = new User_Select();
            //var success = db.tbl_user_GridData_byid(Id).FirstOrDefault();
            //customer_select.id = Data.id;
            //customer_select.Name = Data.Name;
            //customer_select.Email = Data.Email;
            //customer_select.UserName = Data.UserName;
            //customer_select.Password = Data.Password;
            return View(User_Select);
        }
    }
}