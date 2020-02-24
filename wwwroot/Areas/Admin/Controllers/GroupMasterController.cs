using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    public class GroupMasterController : Controller
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

        public ActionResult Grid(int IsBindData = 1, int currentPageIndex = 1, string orderby = "id", int IsAsc = 0, int PageSize = 50, int SearchRecords = 1, string Alpha = "", string SearchTitle = "")
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
                BindData = GetData(SearchRecords, SearchTitle).OfType<GroupMaster_Select>().ToList();
                TotalDataCount = BindData.OfType<GroupMaster_Select>().ToList().Count();

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
            var ColumnName = typeof(GroupMaster_Select).GetProperties().Where(p => p.Name == orderby).FirstOrDefault();

            IEnumerable Data = null;
            //Response.Write(ColumnName);
            //Response.End();
            if (IsAsc == 1)
            {
                ViewBag.AscVal = 0;
                Data = BindData.OfType<GroupMaster_Select>().ToList().OrderBy(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            else
            {

                ViewBag.AscVal = 1;

                Data = BindData.OfType<GroupMaster_Select>().ToList().OrderBy(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            StatusMessage = "";
            //// ViewBag.Pagetext = "Showing " + iStartsRecods + " to " + iEndRecord + " of " + iTotalRecords + " entries";
            //List<ddllist> LstDatadept = new List<ddllist>();
            //LstDatadept = FillDrpLstDepartment();
            //ViewBag.DataDept = LstDatadept;

            //List<ddllist> LstDatadesig = new List<ddllist>();
            //LstDatadesig = FillDrpLstDesignation();
            //ViewBag.Datadesig = LstDatadesig;

            ViewBag.QBAccount = (from dataUser in db.tbl_Department

                                 select new ddllist
                                 {
                                     Value = dataUser.id.ToString(),
                                     Text = dataUser.Name,
                                     selectedvalue = dataUser.id
                                 }).ToList();



            ViewBag.typicalnamelst = (from dataUser in db.tbl_TypicalBalance_master

                                      select new SelectListItem
                                      {
                                          Value = dataUser.id.ToString(),
                                          Text = dataUser.Name
                                      }).ToList();


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
            try
            {
                RtnData = (from data in db.tbl_Groupname_Search(SearchTitle)
                           select new GroupMaster_Select
                           {
                               id = data.id,
                               Name = data.name,
                               QbAccount = data.QbAccount,
                               QbAccountid = data.QbAccountid.Value,
                               typicalname = data.typicalname,
                               typicalid = data.typicalid.Value,
                               memo = data.memo,
                               Exist = db.CheckUseOfGroupId(data.id).FirstOrDefault()
                           }).ToList<GroupMaster_Select>();
            }
            catch (Exception e) { }
            return RtnData;
        }

        public ActionResult Create()
        {
            //ViewBag.statusmessage = "t";
            ViewBag.StatusMessage = StatusMessage;
            ViewBag.Insert = InsertMessage;
            StatusMessage = "";
            IsArray = true;


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GroupMaster_Create PostedData)
        {
            string exist = Convert.ToString((from Data in db.tbl_GroupName
                                             where Data.name == PostedData.Name
                                             select Data.id).FirstOrDefault());
            if (Convert.ToInt32(exist) == 0)
            {
                if (ModelState.IsValid)
                {
                    tbl_GroupName Data_Insert = new tbl_GroupName();

                    Data_Insert.name = PostedData.Name;
                    db.tbl_GroupName.Add(Data_Insert);
                    db.SaveChanges();

                    Tbl_Configuration tbl_Configuration = new Tbl_Configuration();
                    tbl_Configuration.Dept_id = 0;
                    tbl_Configuration.GroupId = Data_Insert.id;
                    tbl_Configuration.StoreId = 0;
                    db.Tbl_Configuration.Add(tbl_Configuration);
                    db.SaveChanges();

                    IsArray = false;
                    StatusMessage = "Success";
                    return RedirectToAction("index");
                }
                else
                {
                    ViewBag.StatusMessage = "Error";
                }
            }
            else
            {
                StatusMessage = "Exists";
                ViewBag.StatusMessage = "Exists";
            }
            return RedirectToAction("index", "GroupMaster");
        }

        public ActionResult Edit(int Id = 0)
        {
            IsArray = true;
            ViewBag.StatusMessage = StatusMessage;
            StatusMessage = "";
            tbl_GroupName Data = db.tbl_GroupName.Find(Id);
            if (Data == null)
            {
                return HttpNotFound();
            }
            GroupMaster_Edit Groupname_Edit = new GroupMaster_Edit();
            Groupname_Edit.Name = Data.name;
            return View(Groupname_Edit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(GroupMaster_Edit PostedData, int id = 0)
        {
            IsEdit = true;
            string exist = Convert.ToString((from Data in db.tbl_GroupName
                                             where Data.name == PostedData.Name && Data.id != id
                                             select Data.id).FirstOrDefault());
            if (Convert.ToInt32(exist) == 0)
            {
                if (ModelState.IsValid)
                {
                    tbl_GroupName Groupname_data = db.tbl_GroupName.Find(id);

                    Groupname_data.name = PostedData.Name;
                    db.Entry(Groupname_data).State = EntityState.Modified;
                    db.SaveChanges();
                    StatusMessage = "Edit";
                    return RedirectToAction("Index");
                }
                else
                {
                    StatusMessage = "Error";
                }
            }
            else
            {
                StatusMessage = "Exists";
            }
            ViewBag.StatusMessage = StatusMessage;
            return RedirectToAction("Edit", "GroupMaster", PostedData);
        }



        public ActionResult Delete(int Id = 0)
        {
            StatusMessage = "Error";
            tbl_GroupName Data = db.tbl_GroupName.Find(Id);
            db.tbl_GroupName.Remove(Data);
            db.SaveChanges();
            StatusMessage = "Delete";
            ViewBag.StatusMessage = "Delete";
            return null;
        }

        public JsonResult GetQBAccount()
        {
            List<ddllist> LstQBAccount = new List<ddllist>();
            try
            {
                LstQBAccount = (from a in db.tbl_Department
                                select new ddllist
                                {
                                    Value = a.id.ToString(),
                                    Text = a.Name
                                }).ToList();
            }
            catch (Exception e) { };
            return Json(new SelectList(LstQBAccount.ToArray(), "Value", "Text"), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetQBAccountId(string QBId)
        {
            int QBIdval = Convert.ToInt32(QBId);
            int Id = (from a in db.tbl_Department
                      where a.id == QBIdval
                      select a.id).FirstOrDefault();
            return Json(Id, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTypicalBalance()
        {
            List<ddllist> LstTypicalBalance = new List<ddllist>();
            try
            {
                LstTypicalBalance = (from a in db.tbl_TypicalBalance_master
                                     select new ddllist
                                     {
                                         Value = a.id.ToString(),
                                         Text = a.Name
                                     }).ToList();
            }
            catch (Exception e) { };
            return Json(new SelectList(LstTypicalBalance.ToArray(), "Value", "Text"), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTypicalBalanceId(string Typicalbalidval)
        {
            int Typicalbalid = Convert.ToInt32(Typicalbalidval);
            int Id = (from a in db.tbl_TypicalBalance_master
                      where a.id == Typicalbalid
                      select a.id).FirstOrDefault();
            return Json(Id, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveGroupMaster(string Name, string QBAccountid, string Typicalbalid, string memo)
        {
            string message = "";
            string exist = Convert.ToString((from Data in db.tbl_GroupName
                                             where Data.name == Name
                                             select Data.id).FirstOrDefault());
            if (Convert.ToInt32(exist) == 0)
            {
                tbl_GroupName Data_Insert = new tbl_GroupName();

                Data_Insert.name = Name;
                Data_Insert.deptid = Convert.ToInt32(QBAccountid);
                Data_Insert.Typicalbalanceid = Convert.ToInt32(Typicalbalid);
                Data_Insert.memo = memo;
                db.tbl_GroupName.Add(Data_Insert);
                db.SaveChanges();
                message = "sucess";
            }
            else
            {
                message = "Exists";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateGroupMaster(int ID, string Name, string QBAccountid, string Typicalbalid, string memo)
        {
            string message = "";
            string exist = Convert.ToString((from Data in db.tbl_GroupName
                                             where Data.name == Name && Data.id != ID
                                             select Data.id).FirstOrDefault());
            if (Convert.ToInt32(exist) == 0)
            {
                tbl_GroupName Groupname_data = db.tbl_GroupName.Find(ID);

                Groupname_data.name = Name;
                Groupname_data.deptid = Convert.ToInt32(QBAccountid);
                Groupname_data.Typicalbalanceid = Convert.ToInt32(Typicalbalid);
                Groupname_data.memo = memo;
                db.Entry(Groupname_data).State = EntityState.Modified;
                db.SaveChanges();
                message = "Edit";
            }
            else
            {
                message = "Exists";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}