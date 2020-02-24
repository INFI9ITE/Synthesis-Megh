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

namespace wwwroot.Areas.Admin.Controllers
{
    [InitializeSimpleMembershipAttribute]
    [Authorize(Roles = "Administrator")]
    public class StoreController : Controller
    {
        // GET: Admin/Store
        protected static string StatusMessage = "";
        protected static string InsertMessage = "";
        protected static string DeleteMessage = "";
        protected static string Editmessage = "";
        protected static string ActivityLogMessage = "";
        private const int FirstPageIndex = 1;
        protected static int TotalDataCount;
        protected static Array Arr;
        protected static bool IsArray;
        protected static IEnumerable BindData;
        protected static bool IsEdit = false;
        int userid = Convert.ToInt32(WebSecurity.CurrentUserId);
        string username = WebSecurity.CurrentUserName;
        WestZoneEntities db = new WestZoneEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grid(int IsBindData = 1, int currentPageIndex = 1, string orderby = "Id", int IsAsc = 0, int PageSize = 10, int SearchRecords = 1, string Alpha = "", string SearchTitle = "")
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
                BindData = GetData(SearchRecords, SearchTitle).OfType<Store_Create>().ToList();
                TotalDataCount = BindData.OfType<Store_Create>().ToList().Count();
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
            ViewBag.Delete = DeleteMessage;
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
            var ColumnName = typeof(Store_Create).GetProperties().Where(p => p.Name == orderby).FirstOrDefault();

            IEnumerable Data = null;
            //Response.Write(ColumnName);
            //Response.End();
            if (IsAsc == 1)
            {
                ViewBag.AscVal = 0;
                Data = BindData.OfType<Store_Create>().ToList().OrderBy(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            else
            {

                ViewBag.AscVal = 1;

                Data = BindData.OfType<Store_Create>().ToList().OrderByDescending(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            StatusMessage = "";
            // ViewBag.Pagetext = "Showing " + iStartsRecods + " to " + iEndRecord + " of " + iTotalRecords + " entries";

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

            RtnData = (from data in db.tbl_Store_GridData(SearchTitle)
                       select new Store_Create
                       {
                           Id = data.Id,
                           Name = data.Name,
                           Address = data.Address,
                           Address2 = data.Address2,
                           StoreNo = data.StoreNo,
                           FaxNo = data.FaxNo,
                           rolefalg = db.tbl_user_store.Where(x => x.Storeid == data.Id).Count()
                       }).ToList<Store_Create>();

            return RtnData;
        }

        #region Fill DropdownList Back Office Manager
        public List<ddllist> FillDrpLstBackoffice()
        {
            List<ddllist> LstBackoffice = new List<ddllist>();
            LstBackoffice = (from a in db.tbl_user_backoffice()
                             orderby a.Name ascending
                             select new ddllist
                             {
                                 Value = a.Reg_userid.ToString(),
                                 Text = a.Name
                             }).ToList();

            return LstBackoffice;
        }
        #endregion

        #region Fill DropdownList Store Manager
        public List<ddllist> FillDrpLstStoreManager()
        {
            List<ddllist> LstStoreManager = new List<ddllist>();
            LstStoreManager = (from a in db.tbl_user_Storemanager()
                               orderby a.Name ascending
                               select new ddllist
                               {
                                   Value = a.Reg_userid.ToString(),
                                   Text = a.Name
                               }).ToList();

            return LstStoreManager;
        }
        #endregion

        #region Fill DropdownList Data Approver
        public List<ddllist> FillDrpLstDataApprover()
        {
            List<ddllist> LstDataApprover = new List<ddllist>();
            LstDataApprover = (from a in db.tbl_user_DataApprover()
                               orderby a.Name ascending
                               select new ddllist
                               {
                                   Value = a.Reg_userid.ToString(),
                                   Text = a.Name
                               }).ToList();

            return LstDataApprover;
        }
        #endregion
        #region Fill DropdownList Owner
        public List<ddllist> FillDrpLstOwner()
        {
            List<ddllist> LstDataOwner = new List<ddllist>();
            LstDataOwner = (from a in db.tbl_user_Owner()
                            orderby a.Name ascending
                            select new ddllist
                            {
                                Value = a.Reg_userid.ToString(),
                                Text = a.Name
                            }).ToList();

            return LstDataOwner;
        }
        #endregion
        public ActionResult Create(int ID = 0)
        {

            ViewBag.StatusMessage = StatusMessage;
            ViewBag.Insert = InsertMessage;
            StatusMessage = "";
            IsArray = true;
            Store_Create Store_data = new Store_Create
            {
                BindBack_Office = FillDrpLstBackoffice(),
                BindStore_manager = FillDrpLstStoreManager(),
                BindData_app = FillDrpLstDataApprover(),
                BindData_Owner = FillDrpLstOwner()
            };
            return View(Store_data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Store_Create PostedData, string[] Storename_Data_app, string[] Storename_Owner, string[] Storename_Backoffice)
        {

            if (ModelState.IsValid)
            {
                tbl_Store Data_Insert = new tbl_Store();
                //int exist = (from a in db.tbl_Store where a.Name.Contains(PostedData.Name) select a.Id).FirstOrDefault();
                var exist = db.tbl_Store_exists(PostedData.Name).Select(x => x.Id).FirstOrDefault();

                if (exist == 0)
                {
                    var EmailExist = db.tbl_Store_Emailexists(PostedData.EmailId).Select(x => x.Id).FirstOrDefault();

                    if (EmailExist == 0)
                    {
                        var success = db.tbl_Store_Create(PostedData.Name, PostedData.Address, PostedData.StoreNo, PostedData.FaxNo, username, PostedData.Address2, PostedData.EmailId, PostedData.Password).Select(x => x.Value).FirstOrDefault();

                        if (success.ToString() != "")
                        {
                            #region Single Backoffice manager (Not in use)
                            //*****************
                            var succ_Role_backoffice = db.Get_roleid_rolename_byReg_userid(PostedData.Back_Office_userid).FirstOrDefault();
                            var succ_Back_offic_man = db.tbl_user_store_Insert_BackOfficeMan(Convert.ToInt32(success), userid, PostedData.Back_Office_userid, PostedData.Name, succ_Role_backoffice.RoleId, succ_Role_backoffice.Rolename);
                            //******************
                            #endregion

                            #region Asign Single Store to Store manager User
                            var succ_Role_Store_man = db.Get_roleid_rolename_byReg_userid(PostedData.Store_Man_userid).FirstOrDefault();
                            var succ_Store_man = db.tbl_user_store_Insert_StoreMan(Convert.ToInt32(success), userid, PostedData.Store_Man_userid, PostedData.Name, succ_Role_Store_man.RoleId, succ_Role_Store_man.Rolename);
                            #endregion

                            #region Asign multiple Store to Back office manager User
                            //foreach (var item in Storename_Backoffice)
                            //{
                            //    var succ_Role_backoffice = db.Get_roleid_rolename_byReg_userid(Convert.ToInt32(item)).FirstOrDefault();
                            //    var succ_Back_offic_man = db.tbl_user_store_Insert_BackOfficeMan(Convert.ToInt32(success), userid, Convert.ToInt32(item), PostedData.Name, succ_Role_backoffice.RoleId, succ_Role_backoffice.Rolename);
                            //}
                            #endregion

                            #region Asign multiple Store to Data app User
                            foreach (var item in Storename_Data_app)
                            {
                                //db.tbl_user_store_Insert(userid, item, user_id);
                                // var regid = db.tbl_user.Where(x => x.Name == item).Select(x => x.Reg_userid).FirstOrDefault();
                                var succ_Role_Data_App = db.Get_roleid_rolename_byReg_userid(Convert.ToInt32(item)).FirstOrDefault();
                                var succ_Data_App = db.tbl_user_store_Insert_DataApp(Convert.ToInt32(success), userid, Convert.ToInt32(item), PostedData.Name, succ_Role_Data_App.RoleId, succ_Role_Data_App.Rolename);
                            }
                            #endregion

                            #region Asign multiple Store to Owner User
                            foreach (var item in Storename_Owner)
                            {
                                //db.tbl_user_store_Insert(userid, item, user_id);
                                // var regid = db.tbl_user.Where(x => x.Name == item).Select(x => x.Reg_userid).FirstOrDefault();
                                var succ_Role_Owner = db.Get_roleid_rolename_byReg_userid(Convert.ToInt32(item)).FirstOrDefault();
                                var succ_Data_App = db.tbl_user_store_Insert_Owner(Convert.ToInt32(success), userid, Convert.ToInt32(item), PostedData.Name, succ_Role_Owner.RoleId, succ_Role_Owner.Rolename);
                            }
                            #endregion


                            int uid = WebSecurity.CurrentUserId;
                            // ActivityLogMessage = username + " created " + PostedData.Name + " on this " + DateTime.Today;
                            string fullname = db.tbl_user.Where(x => x.userid == uid).Select(x => x.Name).FirstOrDefault();
                            ActivityLogMessage = "Store " + "<a href='/admin/store/detail/" + success + "'>" + PostedData.Name + "</a> created by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.AddHours(1).ToString());
                            var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, username, 1);
                            IsArray = false;
                            StatusMessage = "Success";
                            InsertMessage = PostedData.Name + " created successfully.";
                            ViewBag.Insert = InsertMessage;
                        }

                        return RedirectToAction("index");
                    }
                    else
                    {
                        StatusMessage = "EmailExists";
                        InsertMessage = PostedData.EmailId + " is already exists.";
                        ViewBag.Insert = InsertMessage;
                    }

                }
                else
                {
                    StatusMessage = "Exists";
                    InsertMessage = PostedData.Name + " is already exists.";
                    ViewBag.Insert = InsertMessage;
                }

                ViewBag.Insert = InsertMessage;
                ViewBag.StatusMessage = StatusMessage;
            }
            else
            {
                ViewBag.StatusMessage = "Error";
            }
            return RedirectToAction("index", "Store");
        }

        public ActionResult Edit(int Id = 0)
        {
            IsArray = true;
            ViewBag.StatusMessage = StatusMessage;
            ViewBag.Edit = Editmessage;
            tbl_Store Empdata = new tbl_Store();


            tbl_Store Data = db.tbl_Store.Find(Id);

            Store_Edit Store_Edit = new Store_Edit();
            Store_Edit.Name = Data.Name;
            Store_Edit.Address = Data.Address;
            Store_Edit.StoreNo = Data.StoreNo;
            Store_Edit.FaxNo = Data.FaxNo;
            Store_Edit.Address2 = Data.Address2;
            Store_Edit.EmailId = Data.EmailId;
            Store_Edit.Password = Data.Password;
            Store_Edit.storeflag = db.tbl_user_store.Where(x => x.Storeid == Id).Count();
            var succBackoffice = db.Get_ReguserId_edit(Id).FirstOrDefault();
            if (succBackoffice != null)
            {
                Store_Edit.BindBack_Office = (from dataUser in db.tbl_user_backoffice_edit(succBackoffice.Reg_userid.GetValueOrDefault())
                                              select new ddllist
                                              {
                                                  Value = dataUser.Reg_userid.ToString(),
                                                  Text = dataUser.Name

                                              }).ToList();

                Store_Edit.Back_Office_userid = succBackoffice.Reg_userid.GetValueOrDefault();
            }
            #region store manager
            var succstoreman = db.Get_ReguserId_edit_storeman(Id).FirstOrDefault();
            if (succstoreman != null)
            {
                Store_Edit.BindStore_manager = (from dataUser in db.tbl_user_Storemanager_edit(succstoreman.Reg_userid)
                                                select new ddllist
                                                {
                                                    Value = dataUser.Reg_userid.ToString(),
                                                    Text = dataUser.Name

                                                }).ToList();
                Store_Edit.Store_Man_userid = succstoreman.Reg_userid.GetValueOrDefault();
            }
            #endregion
            var succdataapp1 = db.Get_ReguserId_edit_dataapp(Id).ToList();

            if (succdataapp1.Count > 0)
            {
                var succdataapp = (from a in db.Get_ReguserId_edit_dataapp(Id)
                                   select new UserDataAppmulti
                                   {
                                       UserDataAppmultis = a.Reg_userid.ToString()
                                   }).ToList();
                Store_Edit.BindData_app = (from dataUser in db.tbl_user_DataApprover_edit(0)
                                           select new ddllist
                                           {
                                               Value = dataUser.Reg_userid.ToString(),
                                               Text = dataUser.Name

                                           }).ToList();
                Store_Edit.Storename_Data_app_list = succdataapp;
            }
            var succOwner1 = db.Get_ReguserId_edit_Owner(Id).ToList();

            //if (succOwner1.Count > 0)
            //{
            var succOwner = (from a in db.Get_ReguserId_edit_Owner(Id)
                             select new UserOwnermulti
                             {
                                 UserOwnermultis = a.Reg_userid.ToString()
                             }).ToList();
            Store_Edit.BindData_Owner = (from dataUser in db.tbl_user_Owner_edit(0)
                                         select new ddllist
                                         {
                                             Value = dataUser.Reg_userid.ToString(),
                                             Text = dataUser.Name

                                         }).ToList();
            Store_Edit.Storename_Owner_list = succOwner;
            //}
            //Store_Edit.UserBackoffice= Data.ba
            return View(Store_Edit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Store_Edit PostedData, string[] Storename_Data_app, string[] Storename_Owner, int ID = 0)
        {
            IsEdit = true;

            if (Storename_Owner == null)
            {
                ModelState.Remove("Storename_Owner");
            }

            tbl_Store custdata = new tbl_Store();
            if (ModelState.IsValid)
            {
                tbl_Store Store_data = db.tbl_Store.Find(ID);

                var succBackoffice = db.Get_ReguserId_edit(Store_data.Id).FirstOrDefault();

                //PostedData.BindBack_Office = (from dataUser in db.tbl_user_backoffice_edit(succBackoffice.Reg_userid)
                //                              select new ddllist
                //                              {
                //                                  Value = dataUser.Reg_userid.ToString(),
                //                                  Text = dataUser.Name


                //                              }).ToList();
                var succstoreman = db.Get_ReguserId_edit_storeman(Store_data.Id).FirstOrDefault();
                //PostedData.BindStore_manager = (from dataUser in db.tbl_user_Storemanager_edit(succstoreman.Reg_userid)
                //                                select new ddllist
                //                                {
                //                                    Value = dataUser.Reg_userid.ToString(),
                //                                    Text = dataUser.Name

                //                                }).ToList();
                var succdataapp = db.Get_ReguserId_edit_dataapp(Store_data.Id).ToList();
                //PostedData.BindData_app = (from dataUser in db.tbl_user_DataApprover_edit(succdataapp.Reg_userid)
                //                           select new ddllist
                //                           {
                //                               Value = dataUser.Reg_userid.ToString(),
                //                               Text = dataUser.Name

                //                           }).ToList();
                var succOwner = db.Get_ReguserId_edit_Owner(Store_data.Id).ToList();



                string exist = Convert.ToString((from Data in db.tbl_Store
                                                 where Data.Name == PostedData.Name
                                                  && Data.Id != PostedData.Id && Data.IsActive == true
                                                 select Data.Id).FirstOrDefault());
                if (Convert.ToInt32(exist) == 0)
                {
                    var success = db.tbl_Store_Update(PostedData.Id, PostedData.Name, PostedData.Address, PostedData.StoreNo, PostedData.FaxNo, userid.ToString(), PostedData.Address2, PostedData.EmailId, PostedData.Password);
                    if (success.ToString() != "")
                    {


                        // delete User store
                        db.delete_multiple_userstores(Convert.ToInt32(succBackoffice.Reg_userid), ID);
                        db.delete_multiple_userstores(Convert.ToInt32(succstoreman.Reg_userid), ID);
                        foreach (var item in succdataapp)
                        {
                            db.delete_multiple_userstores(Convert.ToInt32(item.Reg_userid), ID);
                        }
                        foreach (var item in succOwner)
                        {
                            db.delete_multiple_userstores(Convert.ToInt32(item.Reg_userid), ID);
                        }
                        //close user store


                        //add User Store
                        var succ_Role_backoffice = db.Get_roleid_rolename_byReg_userid(PostedData.Back_Office_userid).FirstOrDefault();
                        var succ_Back_offic_man = db.tbl_user_store_Insert_BackOfficeMan(Convert.ToInt32(ID), userid, PostedData.Back_Office_userid, PostedData.Name, succ_Role_backoffice.RoleId, succ_Role_backoffice.Rolename);
                        var succ_Role_Store_man = db.Get_roleid_rolename_byReg_userid(PostedData.Store_Man_userid).FirstOrDefault();
                        var succ_Store_man = db.tbl_user_store_Insert_StoreMan(Convert.ToInt32(ID), userid, PostedData.Store_Man_userid, PostedData.Name, succ_Role_Store_man.RoleId, succ_Role_Store_man.Rolename);

                        //close user store




                        #region add multiple Store to User
                        if (Storename_Data_app != null)
                        {
                            foreach (var item in Storename_Data_app)
                            {
                                //db.tbl_user_store_Insert(userid, item, user_id);
                                // var regid = db.tbl_user.Where(x => x.Name == item).Select(x => x.Reg_userid).FirstOrDefault();
                                var succ_Role_Data_App = db.Get_roleid_rolename_byReg_userid(Convert.ToInt32(item)).FirstOrDefault();
                                var succ_Data_App = db.tbl_user_store_Insert_DataApp(Convert.ToInt32(ID), userid, Convert.ToInt32(item), PostedData.Name, succ_Role_Data_App.RoleId, succ_Role_Data_App.Rolename);
                            }
                        }
                        #endregion
                        #region add multiple Store to User
                        if (Storename_Owner != null)
                        {
                            foreach (var item in Storename_Owner)
                            {
                                //db.tbl_user_store_Insert(userid, item, user_id);
                                // var regid = db.tbl_user.Where(x => x.Name == item).Select(x => x.Reg_userid).FirstOrDefault();
                                var succ_Role_Owner = db.Get_roleid_rolename_byReg_userid(Convert.ToInt32(item)).FirstOrDefault();
                                var succ_Data_App = db.tbl_user_store_Insert_Owner(Convert.ToInt32(ID), userid, Convert.ToInt32(item), PostedData.Name, succ_Role_Owner.RoleId, succ_Role_Owner.Rolename);
                            }
                        }
                        #endregion




                        int uid = WebSecurity.CurrentUserId;
                        string fullname = db.tbl_user.Where(x => x.userid == uid).Select(x => x.Name).FirstOrDefault();
                        //ActivityLogMessage = username + " Edited " + PostedData.Name + " on this " + DateTime.Today;
                        ActivityLogMessage = "Store " + "<a href='/admin/store/detail/" + PostedData.Id + "'>" + PostedData.Name + "</a> edited by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.AddHours(1).ToString());
                        var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, username, 2);
                        StatusMessage = "Edit";
                        Editmessage = PostedData.Name + " updated successfully.";
                        ViewBag.Edit = Editmessage;
                        return RedirectToAction("Index");

                    }


                }
                else
                {
                    StatusMessage = "Exists";
                    InsertMessage = PostedData.Name + " strore name is already exists.";
                    ViewBag.Insert = InsertMessage;
                }
            }
            else
            {
                StatusMessage = "Error";
                return RedirectToAction("Index", "Store");
            }

            ViewBag.StatusMessage = StatusMessage;
            return View(PostedData);
        }
        public ActionResult Detail(int Id = 0)
        {
            IsArray = true;
            tbl_Store Data = db.tbl_Store.Find(Id);

            var role = (from data in db.tbl_user_store
                        where data.Storeid == Id
                        select data.RoleName).Distinct().ToList();

            List<string> lstrole = new List<string>();
            for (int i = 0; i < role.Count; i++)
            {
                lstrole.Add(role[i]);

            }

            var struserid = (from data in db.tbl_user_store
                             where data.Storeid == Id
                             select data.Reg_userid).ToList();

            List<string> lstusername = new List<string>();

            for (int i = 0; i < struserid.Count; i++)
            {
                int reg_id = Convert.ToInt32(struserid[i]);
                var usernm = (from data1 in db.UserProfiles
                              where data1.UserId == reg_id
                              select data1.UserName).ToList();
                string unm = Convert.ToString(usernm[0]);
                lstusername.Add(unm);

            }

            string roleString = String.Join(",", lstrole);
            string userstring = String.Join(",", lstusername);
            ViewBag.IDOnDetailPage = Id;
            Store_Select customer_select = new Store_Select();
            customer_select.Id = Data.Id;
            customer_select.StoreNo = Data.StoreNo;
            customer_select.Name = Data.Name;
            customer_select.FaxNo = Data.FaxNo;
            customer_select.Address = Data.Address;
            customer_select.Address2 = Data.Address2;
            customer_select.rolename = roleString;
            customer_select.username = userstring;
            customer_select.EmailId = Data.EmailId;
            return View(customer_select);
        }
        public ActionResult Delete(int Id = 0)
        {
            StatusMessage = "Error";

            tbl_Store Data = db.tbl_Store.Find(Id);
            Data.IsActive = false;
            db.Entry(Data).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            var succ = db.tbl_user_store_delete(Id);

            string name = Convert.ToString((from Data1 in db.tbl_store_byid(Data.Id)
                                            select Data1.Name).FirstOrDefault());
            int uid = WebSecurity.CurrentUserId;
            string fullname = db.tbl_user.Where(x => x.userid == uid).Select(x => x.Name).FirstOrDefault();
            ActivityLogMessage = "Store " + name + " deleted by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.AddHours(1).ToString());
            var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, username, 3);
            StatusMessage = "Delete";
            DeleteMessage = name + " deleted successfully.";
            ViewBag.Delete = DeleteMessage;
            return null;
        }
    }
}