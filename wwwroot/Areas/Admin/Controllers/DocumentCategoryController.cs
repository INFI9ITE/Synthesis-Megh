using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using wwwroot.Areas.Admin.Models;
using wwwrootBL.Entity;

namespace wwwroot.Areas.Admin.Controllers
{
    public class DocumentCategoryController : Controller
    {
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
        // GET: Admin/DocumentCategory
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
                BindData = GetData(SearchRecords, SearchTitle).OfType<DocumentCategory>().ToList();
                TotalDataCount = BindData.OfType<DocumentCategory>().ToList().Count();
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
            var ColumnName = typeof(DocumentCategory).GetProperties().Where(p => p.Name == orderby).FirstOrDefault();

            IEnumerable Data = null;
            //Response.Write(ColumnName);
            //Response.End();
            if (IsAsc == 1)
            {
                ViewBag.AscVal = 0;
                Data = BindData.OfType<DocumentCategory>().ToList().OrderBy(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            else
            {

                ViewBag.AscVal = 1;

                Data = BindData.OfType<DocumentCategory>().ToList().OrderByDescending(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
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

            RtnData = (from data in db.tbl_DocumentCategory_GridData(SearchTitle)
                       select new DocumentCategory
                       {
                           Id = data.Id,
                           Name = data.Name
                       }).ToList<DocumentCategory>();

            return RtnData;
        }
        public ActionResult Create(int ID = 0)
        {

            ViewBag.StatusMessage = StatusMessage;
            ViewBag.Insert = InsertMessage;
            StatusMessage = "";
            IsArray = true;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DocumentCategory PostedData, string[] Storename_Data_app, string[] Storename_Owner, string[] Storename_Backoffice)
        {

            if (ModelState.IsValid)
            {
                tbl_DocumentCategory Data_Insert = new tbl_DocumentCategory();
                //int exist = (from a in db.tbl_Store where a.Name.Contains(PostedData.Name) select a.Id).FirstOrDefault();
                var exist = db.tbl_DocumentCategory_exists(PostedData.Name).Select(x => x.Id).FirstOrDefault();

                if (exist == 0)
                {

                        var success = db.tbl_DocumentCategory_Create(PostedData.Name).Select(x => x.Value).FirstOrDefault();

                        if (success.ToString() != "")
                        {
                            

                            int uid = WebSecurity.CurrentUserId;
                            // ActivityLogMessage = username + " created " + PostedData.Name + " on this " + DateTime.Today;
                            string fullname = db.tbl_user.Where(x => x.userid == uid).Select(x => x.Name).FirstOrDefault();
                            ActivityLogMessage = "Category " + "<a href='/admin/documentcategory/detail/" + success + "'>" + PostedData.Name + "</a> created by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.AddHours(1).ToString());
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
            return RedirectToAction("index", "DocumentCategory");
        }

        public ActionResult Edit(int Id = 0)
        {
            IsArray = true;
            ViewBag.StatusMessage = StatusMessage;
            ViewBag.Edit = Editmessage;
            tbl_DocumentCategory Data = db.tbl_DocumentCategory.Find(Id);
            DocumentCategory cat_Edit = new DocumentCategory();
            cat_Edit.Name = Data.Name;
            return View(cat_Edit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(DocumentCategory PostedData, string[] Storename_Data_app, string[] Storename_Owner, int ID = 0)
        {
            IsEdit = true;

            if (Storename_Owner == null)
            {
                ModelState.Remove("Storename_Owner");
            }

            tbl_DocumentCategory custdata = new tbl_DocumentCategory();
            if (ModelState.IsValid)
            {
                tbl_DocumentCategory Store_data = db.tbl_DocumentCategory.Find(ID);
                string exist = Convert.ToString((from Data in db.tbl_DocumentCategory
                                                 where Data.Name == PostedData.Name
                                                  && Data.Id != PostedData.Id
                                                 select Data.Id).FirstOrDefault());
                if (Convert.ToInt32(exist) == 0)
                {
                    var success = db.tbl_DocumentCategory_Update(PostedData.Id, PostedData.Name);
                    if (success.ToString() != "")
                    {

                        int uid = WebSecurity.CurrentUserId;
                        string fullname = db.tbl_user.Where(x => x.userid == uid).Select(x => x.Name).FirstOrDefault();
                        //ActivityLogMessage = username + " Edited " + PostedData.Name + " on this " + DateTime.Today;
                        ActivityLogMessage = "Category " + "<a href='/admin/documentcategory/detail/" + PostedData.Id + "'>" + PostedData.Name + "</a> edited by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.AddHours(1).ToString());
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
                    InsertMessage = PostedData.Name + " Category name is already exists.";
                    ViewBag.Insert = InsertMessage;
                }
            }
            else
            {
                StatusMessage = "Error";
                return RedirectToAction("Index", "DocumentCategory");
            }

            ViewBag.StatusMessage = StatusMessage;
            return View(PostedData);
        }
        public ActionResult Detail(int Id = 0)
        {
            tbl_DocumentCategory Data = db.tbl_DocumentCategory.Find(Id);
            DocumentCategory documentCategory = new DocumentCategory();
            documentCategory.Id = Data.Id;
            documentCategory.Name = Data.Name;
            return View(documentCategory);
        }
        public ActionResult Delete(int Id = 0)
        {
            StatusMessage = "Error";

            tbl_DocumentCategory Data = db.tbl_DocumentCategory.Find(Id);
            //db.Entry(Data).State = System.Data.Entity.EntityState.Modified;

            string name = Convert.ToString((from Data1 in db.tbl_DocumentCategory_byid(Data.Id)
                                            select Data1.Name).FirstOrDefault());
            var succ = db.tbl_DocumentCategory_delete(Id);
            db.SaveChanges();
            
            int uid = WebSecurity.CurrentUserId;
            string fullname = db.tbl_user.Where(x => x.userid == uid).Select(x => x.Name).FirstOrDefault();
            ActivityLogMessage = "Category " + name + " deleted by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.AddHours(1).ToString());
            var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, username, 3);
            StatusMessage = "Delete";
            DeleteMessage = name + " deleted successfully.";
            ViewBag.Delete = DeleteMessage;
            return null;
        }
    }
}