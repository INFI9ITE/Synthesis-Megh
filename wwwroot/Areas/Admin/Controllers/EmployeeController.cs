using Cloudutility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using wwwroot.Areas.Admin.Models;
using wwwroot.Class;
using wwwroot.Hubs;
using wwwrootBL.Entity;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
namespace wwwroot.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [InitializeSimpleMembershipAttribute]
    public class EmployeeController : Controller
    {
        // GET: Admin/Employee

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
                BindData = GetData(SearchRecords, SearchTitle).OfType<Employee_Select>().ToList();
                TotalDataCount = BindData.OfType<Employee_Select>().ToList().Count();

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
            var ColumnName = typeof(Employee_Select).GetProperties().Where(p => p.Name == orderby).FirstOrDefault();

            IEnumerable Data = null;
            //Response.Write(ColumnName);
            //Response.End();
            if (IsAsc == 1)
            {
                ViewBag.AscVal = 0;
                Data = BindData.OfType<Employee_Select>().ToList().OrderBy(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            else
            {

                ViewBag.AscVal = 1;

                Data = BindData.OfType<Employee_Select>().ToList().OrderByDescending(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
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
            RtnData = (from data in db.tbl_Employee_GridData(SearchTitle)

                       select new Employee_Select
                       {
                           id = data.id,
                           Name = data.Name,
                           userid = data.userid_val.GetValueOrDefault(),
                           Employeeid = data.Username,
                           Password = data.Password,
                           Email = data.Email,
                           CreatedOn = data.CreatedOn,
                           rolename = data.RoleName,
                           Reg_userid = data.Reg_userid.GetValueOrDefault(),
                           IsLock = data.lockval.GetValueOrDefault(),
                           HireDate=data.HireDate,
                           //BindStorename=(from a in db.tbl_user_store where a.Reg_userid==data.Reg_userid select a.StoreName).ToList()

                       }).ToList<Employee_Select>();

            return RtnData;
        }

        #region bind all dropdown

        #region Fill DropdownList Gender
        public List<ddllist> FillDrpLstGender()
        {
            List<ddllist> LstGender = new List<ddllist>();
            LstGender = (from a in db.tbl_Gender
                         orderby a.Gender ascending

                         select new ddllist
                         {
                             Value = a.id.ToString(),
                             Text = a.Gender

                         }).ToList();

            return LstGender;
        }
        #endregion

        #region Fill DropdownList Marital Status
        public List<ddllist> FillDrpLstMaritalStatus()
        {
            List<ddllist> LstMaritalStatus = new List<ddllist>();
            LstMaritalStatus = (from a in db.tbl_MaritalStatus
                                orderby a.MaritalStatus ascending

                                select new ddllist
                                {
                                    Value = a.id.ToString(),
                                    Text = a.MaritalStatus

                                }).ToList();

            return LstMaritalStatus;
        }
        #endregion

        #region Fill DropdownList Store
        public List<ddllist> FillDrpLstStore()
        {
            List<ddllist> LstStore = new List<ddllist>();
            LstStore = (from dataUser in db.tbl_user_Selectstore()

                        select new ddllist
                        {
                            Value = dataUser.Id.ToString(),
                            Text = dataUser.Name
                        }).ToList();

            return LstStore;

        }
        #endregion

        #region Fill DropdownList Department
        public List<ddllist> FillDrpLstDepartment()
        {
            List<ddllist> LstDepartment = new List<ddllist>();
            LstDepartment = (from a in db.tbl_Department
                             orderby a.Name ascending

                             select new ddllist
                             {
                                 Value = a.id.ToString(),
                                 Text = a.Name

                             }).ToList();

            return LstDepartment;
        }
        #endregion

        #region Fill DropdownList Employment Type
        public List<ddllist> FillDrpLstEmpType()
        {
            List<ddllist> LstEmpType = new List<ddllist>();
            LstEmpType = (from a in db.tbl_EmploymentType
                          orderby a.EmployeeType ascending

                          select new ddllist
                          {
                              Value = a.id.ToString(),
                              Text = a.EmployeeType

                          }).ToList();

            return LstEmpType;
        }
        #endregion

        #region Fill DropdownList Employment Status
        public List<ddllist> FillDrpLstEmpstatus()
        {
            List<ddllist> LstEmpstatus = new List<ddllist>();
            LstEmpstatus = (from a in db.tbl_EmploymentStatus
                            orderby a.EmpStatus ascending

                            select new ddllist
                            {
                                Value = a.id.ToString(),
                                Text = a.EmpStatus

                            }).ToList();

            return LstEmpstatus;
        }
        #endregion

        #endregion

        public ActionResult Create(int ID = 0)
        {
            //ViewBag.statusmessage = "t";
            ViewBag.StatusMessage = StatusMessage;
            ViewBag.Insert = InsertMessage;
            StatusMessage = "";
            IsArray = true;
            Employee_Create User_data = new Employee_Create
            {
                BindGender = FillDrpLstGender(),
                BindMaritalStatus = FillDrpLstMaritalStatus(),
                BindStore = FillDrpLstStore(),
                BindDepartment = FillDrpLstDepartment(),
                BindEmploymentType = FillDrpLstEmpType(),
                BindEmploymentStatus = FillDrpLstEmpstatus()
            };

            return View(User_data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee_Create PostedData, HttpPostedFileBase Photo, HttpPostedFileBase EmpDoc)
        {
            string success_val = "false";
            string Rolename = "Employee";
            PostedData.BindGender = FillDrpLstGender();
            PostedData.BindMaritalStatus = FillDrpLstMaritalStatus();
            PostedData.BindStore = FillDrpLstStore();
            PostedData.BindDepartment = FillDrpLstDepartment();
            PostedData.BindEmploymentType = FillDrpLstEmpType();
            PostedData.BindEmploymentStatus = FillDrpLstEmpstatus();


            if (ModelState.IsValid)
            {
                try
                {
                    string username = PostedData.Employeeid;
                    WebSecurity.CreateUserAndAccount(username, PostedData.Password);

                    int user_id = Convert.ToInt32(WebSecurity.GetUserId(username));
                    Roles.AddUserToRole(username, Rolename);
                    //var rid = db.webpages_Roles_byRolename(rolename).Select();
                    string rid = Convert.ToString((from Data in db.webpages_Roles_byRolename(Rolename)
                                                   select Data.Value).FirstOrDefault());

                    #region Attach Photo

                    var Photo_Title = "";
                    if (Photo != null)
                    {

                        if (Photo.ContentLength > 0)
                        {

                            var allowedExtensions = new[] { ".jpeg",".jpg",".png" };
                            var extension = Path.GetExtension(Photo.FileName);

                            if (!allowedExtensions.Contains(extension))
                            {
                                ViewBag.StatusMessage = "InvalidImage";
                                return View("Index");
                            }
                            else
                            {

                                Photo_Title = AdminSiteConfiguration.GetRandomNo() + Path.GetFileName(Photo.FileName);
                                Photo_Title = AdminSiteConfiguration.RemoveSpecialCharacter(Photo_Title);

                                var path1 = Request.PhysicalApplicationPath + "userfiles\\photoimage" + "\\" + Photo_Title;
                                Photo.SaveAs(path1);

                                #region cloudURL
                                try
                                {
                                    GC.Collect();
                                    string cloudusername = AdminSiteConfiguration.ClaudUsername();
                                    string api_key = AdminSiteConfiguration.ClaudKey();
                                    string chosenContainer = AdminSiteConfiguration.ClaudContainer();

                                    var cloudIdentity = new CloudIdentity() { APIKey = api_key, Username = cloudusername };
                                    var cloudFilesProvider = new CloudFilesProvider(cloudIdentity);
                                    string uriPath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\photoimage\\" + Photo_Title;

                                    using (System.IO.FileStream stream = System.IO.File.OpenRead(uriPath))
                                    {

                                        cloudFilesProvider.CreateObject(chosenContainer, stream, "photoimage/" + Photo_Title);
                                        stream.Flush();
                                        stream.Close();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                                //Clouduploader.UploadDocument("scanimage", Sacn_Title, "wsmanagementsys", Request.PhysicalApplicationPath + "userfiles\\scanimage\\" + Sacn_Title);

                                #endregion
                                string foldername = Path.Combine("photoimage");
                                AdminSiteConfiguration.DeleteImage(Photo_Title, foldername);

                            }
                        }

                    }
                    #endregion

                    #region Attach Document

                    var Doc_Title = "";
                    if (EmpDoc != null)
                    {

                        if (EmpDoc.ContentLength > 0)
                        {

                            var allowedExtensions = new[] { ".txt",".docx",".doc",".pdf" };
                            var extension = Path.GetExtension(EmpDoc.FileName);

                            if (!allowedExtensions.Contains(extension))
                            {
                                ViewBag.StatusMessage = "InvalidImage";
                                return View("Index");
                            }
                            else
                            {

                                Doc_Title = AdminSiteConfiguration.GetRandomNo() + Path.GetFileName(Photo.FileName);
                                Doc_Title = AdminSiteConfiguration.RemoveSpecialCharacter(Photo_Title);

                                var path1 = Request.PhysicalApplicationPath + "userfiles\\docfile" + "\\" + Doc_Title;
                                EmpDoc.SaveAs(path1);

                                #region cloudURL
                                try
                                {
                                    GC.Collect();
                                    string cloudusername = AdminSiteConfiguration.ClaudUsername();
                                    string api_key = AdminSiteConfiguration.ClaudKey();
                                    string chosenContainer = AdminSiteConfiguration.ClaudContainer();

                                    var cloudIdentity = new CloudIdentity() { APIKey = api_key, Username = cloudusername };
                                    var cloudFilesProvider = new CloudFilesProvider(cloudIdentity);
                                    string uriPath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\docfile\\" + Doc_Title;

                                    using (System.IO.FileStream stream = System.IO.File.OpenRead(uriPath))
                                    {

                                        cloudFilesProvider.CreateObject(chosenContainer, stream, "docfile/" + Doc_Title);
                                        stream.Flush();
                                        stream.Close();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                                //Clouduploader.UploadDocument("scanimage", Sacn_Title, "wsmanagementsys", Request.PhysicalApplicationPath + "userfiles\\scanimage\\" + Sacn_Title);

                                #endregion
                                string foldername = Path.Combine("docfile");
                                AdminSiteConfiguration.DeleteImage(Doc_Title, foldername);

                            }
                        }

                    }
                    #endregion

                    string Name = PostedData.FirstName+" " +PostedData.LastName;
                    var success= db.tbl_Employee_Insert(PostedData.FirstName, PostedData.LastName, PostedData.SecondName, Name, PostedData.Birthday, PostedData.SocSecurityNo, PostedData.Genderid, PostedData.MaritalStatusid, Photo_Title, Doc_Title, PostedData.EmpNote, PostedData.HomePhone, PostedData.MobilePhone, PostedData.Street, PostedData.AptSuiteBuilding, PostedData.City, PostedData.State, PostedData.ZipCode, PostedData.HireDate, PostedData.TerminationDate, PostedData.Storeid, PostedData.Deptid, PostedData.EmpTypeid, PostedData.EmpStatusId, PostedData.Email, PostedData.Employeeid, PostedData.Password, userid.ToString(), userid, Convert.ToInt32(rid), user_id).Select(x => x.Value).FirstOrDefault();

                    var storename =Convert.ToString((from Data in db.tbl_Store.Where(x=>x.Id==PostedData.Storeid)select Data.Name).FirstOrDefault());

                    var succ_Store = db.tbl_Employee_store_Insert(PostedData.Storeid, userid, user_id, storename, Convert.ToInt32(rid), Rolename);

                    if (success.ToString() != "")
                    {
                        IsArray = false;
                        InsertMessage = PostedData.Employeeid + " has been created successfully.";
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

        public ActionResult Edit(int Id = 0)
        {
            IsArray = true;
            ViewBag.StatusMessage = StatusMessage;
            ViewBag.Edit = Editmessage;
            tbl_user Empdata = new tbl_user();


            tbl_user Data = db.tbl_user.Find(Id);
            var rolename = db.webpages_Roles.Where(x => x.RoleId == Data.Roleid).Select(x => x.RoleName).FirstOrDefault();
            var storeid = db.tbl_user_store.Where(x => x.Reg_userid == Data.Reg_userid).Select(x => x.Storeid).FirstOrDefault();
            Employee_Edit Employee_Edit = new Employee_Edit
            {
                BindGender = FillDrpLstGender(),
                BindMaritalStatus = FillDrpLstMaritalStatus(),
                BindStore = FillDrpLstStore(),
                BindDepartment=FillDrpLstDepartment(),
                BindEmploymentType=FillDrpLstEmpType(),
                BindEmploymentStatus=FillDrpLstEmpstatus(),

                LastName=Data.LastName,
                FirstName=Data.FirstName,
                SecondName=Data.SecondName,
                Birthday=Data.Birthday,
                SocSecurityNo=Data.SocSecurityNo,
                Genderid = Data.Genderid,
                MaritalStatusid = Data.MaritalStatusid,
                EmpNote=Data.EmpNote,
                Email = Data.Email,
                Name = Data.Name,
                HomePhone=Data.HomePhone,
                MobilePhone=Data.MobilePhone,
                Street=Data.Street,
                ZipCode=Data.ZipCode,
                Employeeid = Data.UserName,
                HireDate=Data.HireDate,
                TerminationDate=Data.TerminationDate,
                Storeid=Data.Storeid,
                Department=Data.Deptid.ToString(),
                EmpTypeid=Data.EmpTypeid,
                EmpStatusId=Data.EmpStatusId,
                Photo=Data.Photo,
                EmpDoc=Data.EmpDoc,
                CreatedOn = Convert.ToDateTime(DateTime.Now.AddHours(1).ToString()),
               // flag = db.tbl_user_store.Where(x => x.Storeid == storeid).Count()
            };


            //Employee_Edit.UserStore = (from datastore in db.tbl_user_store
            //                       where datastore.Reg_userid == Data.Reg_userid
            //                       select new UserStore
            //                       {
            //                           UserStores = datastore.StoreName

            //                       }).ToList();



            return View(Employee_Edit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(User_Edit PostedData, string[] StoreName, string rolename, int Id = 0)
        {
            IsEdit = true;
            //PostedData.BindRoleList = FillDrpLstRole();
            //// PostedData.BindStoreList = FillDrpLstStore();
            //tbl_user custdata = new tbl_user();
            //PostedData.UserStore = (from datastore in db.tbl_user_store
            //                        where datastore.Reg_userid == PostedData.Reg_userid
            //                        select new UserStore
            //                        {
            //                            UserStores = datastore.StoreName

            //                        }).ToList();



            //if (ModelState.IsValid)
            //{
            //    tbl_user customer_data = db.tbl_user.Find(Id);
            //    int user_id = Convert.ToInt32(WebSecurity.GetUserId(PostedData.UserName));
            //    //string exist = Convert.ToString((from Data in db.tbl_user
            //    //                                 where Data.id != Id
            //    //                                 select Data.userid).FirstOrDefault());

            //    //if (Convert.ToInt32(exist) == 0)
            //    //{
            //    string rid = Convert.ToString((from Data in db.webpages_Roles_byRolename(rolename)
            //                                   select Data.Value).FirstOrDefault());
            //    customer_data.id = PostedData.id;
            //    customer_data.Name = PostedData.Name;

            //    customer_data.userid = user_id;
            //    customer_data.UserName = PostedData.UserName;
            //    customer_data.Roleid = Convert.ToInt32(rid);
            //    // customer_data.Email = PostedData.Email;

            //    customer_data.CreatedOn = Convert.ToDateTime(DateTime.Now.AddHours(1).ToString());
            //    db.Entry(customer_data).State = System.Data.Entity.EntityState.Modified;
            //    db.SaveChanges();


            //    //db.delete_multiple_userstores(customer_data.Reg_userid);
            //    db.delete_multiple_userRole(customer_data.Reg_userid);
            //    try { Roles.AddUserToRole(PostedData.UserName, rolename); }
            //    catch { }

            //    //foreach (var item in StoreName)
            //    //{
            //    //    db.tbl_user_store_Insert(userid, item, user_id);

            //    //}
            //    int uid = WebSecurity.CurrentUserId;
            //    string fullname = db.tbl_user.Where(x => x.userid == uid).Select(x => x.Name).FirstOrDefault();
            //    //ActivityLogMessage = "User: " + PostedData.UserName + " is edited by " + loginusername + " on this " + DateTime.Today;
            //    ActivityLogMessage = "User " + "<a href='/admin/user/detail/" + PostedData.id + "'>" + PostedData.UserName + "</a> updated by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.AddHours(1).ToString());
            //    var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, loginusername, 2);

            //    StatusMessage = "Success";
            //    Editmessage = PostedData.UserName + " has been updated successfully.";
            //    ViewBag.Edit = Editmessage;
            //    return RedirectToAction("Index");
            //    //}
            //    //else
            //    //{
            //    //    StatusMessage = "Exists";
            //    //}

            //}
            //else
            //{
            //    StatusMessage = "Error";
            //}

            //ViewBag.StatusMessage = StatusMessage;
            return View(PostedData);
        }
    }
}