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
    public class StoreTerminalController : Controller
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
        // GET: Admin/StoreTerminal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grid(int IsBindData = 1, int currentPageIndex = 1, string orderby = "id", int IsAsc = 0, int PageSize = 10, int SearchRecords = 1, string Alpha = "", string SearchTitle = "",int Storename=0)
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
                        if (a1.Split(':')[0].ToString() == "Storeename")
                        {
                            Storename = Convert.ToInt32(a1.Split(':')[1].ToString());
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
                ,"Storeename:" + Storename
            };
            #endregion

            #region MyRegion_BindData
            int startIndex = ((currentPageIndex - 1) * PageSize) + 1;
            int endIndex = startIndex + PageSize - 1;

            if (IsBindData == 1 || IsEdit == true)
            {
                BindData = GetData(SearchRecords, SearchTitle, Storename).OfType<Storeterminal_Create>().ToList();
                TotalDataCount = BindData.OfType<Storeterminal_Create>().ToList().Count();
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
            ViewBag.Storename = Storename;
            if (TotalDataCount < endIndex)
            {
                ViewBag.endIndex = TotalDataCount;
            }
            else
            {
                ViewBag.endIndex = endIndex;
            }
            ViewBag.TotalDataCount = TotalDataCount;
            var ColumnName = typeof(Storeterminal_Create).GetProperties().Where(p => p.Name == orderby).FirstOrDefault();

            IEnumerable Data = null;
            //Response.Write(ColumnName);
            //Response.End();
            if (IsAsc == 1)
            {
                ViewBag.AscVal = 0;
                Data = BindData.OfType<Storeterminal_Create>().ToList().OrderBy(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            else
            {

                ViewBag.AscVal = 1;

                Data = BindData.OfType<Storeterminal_Create>().ToList().OrderByDescending(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            StatusMessage = "";
            // ViewBag.Pagetext = "Showing " + iStartsRecods + " to " + iEndRecord + " of " + iTotalRecords + " entries";
            List<ddllist> Lststore = new List<ddllist>();
            Lststore = FillDrpStoresearch();
            ViewBag.DataStore = Lststore;
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

        private IEnumerable GetData(int SearchRecords = 0, string SearchTitle = "",int Storename=0)
        {
            IEnumerable RtnData = null;

            RtnData = (from data in db.tbl_Store_Terminal_Select(Storename, SearchTitle)
                       select new Storeterminal_Create
                       {
                           id = data.id,
                           Terminal = data.Terminal,
                           Storename = data.storename


                       }).ToList<Storeterminal_Create>();

            return RtnData;
        }

        #region Fill DropdownList Store
        public List<ddllist> FillDrpStoresearch()
        {
            List<ddllist> LstStore = new List<ddllist>();
            LstStore = (from a in db.tbl_user_Selectstore()
                        orderby a.Name ascending
                        select new ddllist
                        {
                            Value = a.Id.ToString(),
                            Text = a.Name
                        }).ToList();

            return LstStore;


        }
        #endregion

        #region Fill DropdownList Store
        public List<ddllist> FillDrpStore()
        {
            List<ddllist> LstStore = new List<ddllist>();
            LstStore = (from a in db.tbl_user_Selectstore()
                        orderby a.Name ascending
                        select new ddllist
                        {
                            Value = a.Id.ToString(),
                            Text = a.Name
                        }).ToList();

            return LstStore;


        }
        #endregion
        public ActionResult Create(int ID = 0)
        {

            ViewBag.StatusMessage = StatusMessage;
            ViewBag.Insert = InsertMessage;
            StatusMessage = "";
            IsArray = true;
            Storeterminal_Create Store_data = new Storeterminal_Create
            {
                BindStoreidList = FillDrpStore(),

            };
            Store_data.Storeid = ID;
            return View(Store_data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Storeterminal_Create PostedData, string[] Storename_Data_app, string[] Storename_Owner, string[] Storename_Backoffice)
        {

            if (ModelState.IsValid)
            {
                tbl_Store Data_Insert = new tbl_Store();
                //int exist = (from a in db.tbl_Store where a.Name.Contains(PostedData.Name) select a.Id).FirstOrDefault();
                var exist = db.tbl_tbl_Store_Terminal_exists(PostedData.Terminal, PostedData.Storeid).Select(x => x.id).FirstOrDefault();

                if (exist == 0)
                {
                    string uid = WebSecurity.CurrentUserId.ToString();
                    var success = db.tbl_Store_Terminal_Insert(PostedData.Storeid, PostedData.Terminal, uid);

                    StatusMessage = "Success";
                    InsertMessage = PostedData.Terminal + " created successfully.";
                    ViewBag.Insert = InsertMessage;
                    return RedirectToAction("index");
                }
                else
                {
                    StatusMessage = "Exists";
                    InsertMessage = PostedData.Terminal + " is already exists.";
                    ViewBag.Insert = InsertMessage;
                }

                ViewBag.Insert = InsertMessage;
                ViewBag.StatusMessage = StatusMessage;
            }
            else
            {
                ViewBag.StatusMessage = "Error";
            }
            return RedirectToAction("index", "StoreTerminal");
        }

        public ActionResult Edit(int Id = 0)
        {
            IsArray = true;
            ViewBag.StatusMessage = StatusMessage;
            ViewBag.Edit = Editmessage;
            tbl_Store_Terminal Empdata = new tbl_Store_Terminal();


            tbl_Store_Terminal Data = db.tbl_Store_Terminal.Find(Id);

            Storeterminal_Sdit Storeterminal_Sdit = new Storeterminal_Sdit();
            Storeterminal_Sdit.Terminal = Data.Terminal;

            Storeterminal_Sdit.BindStoreidList = (from a in db.tbl_user_Selectstore()
                                                  orderby a.Name ascending
                                                  select new ddllist
                                                  {
                                                      Value = a.Id.ToString(),
                                                      Text = a.Name
                                                  }).ToList();

            Storeterminal_Sdit.Storeid = Data.Storeid.GetValueOrDefault();


            //Store_Edit.UserBackoffice= Data.ba
            return View(Storeterminal_Sdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Edit(Storeterminal_Sdit PostedData,int ID = 0)
        {
            IsEdit = true;
            PostedData.BindStoreidList = FillDrpStore();
            if (ModelState.IsValid)
            {
               
                   tbl_Store_Terminal editterminal = db.tbl_Store_Terminal.Find(ID);
                var exist = db.tbl_tbl_Store_Terminal_existsbyid(ID, PostedData.Terminal, PostedData.Storeid).Select(x => x.id).FirstOrDefault();



                if (Convert.ToInt32(exist) == 0)
                {
                    editterminal.Terminal = PostedData.Terminal;
                    editterminal.Storeid = PostedData.Storeid;
                    db.Entry(editterminal).State = System.Data.Entity.EntityState.Modified; 
             
                    db.SaveChanges();

                    StatusMessage = "Edit";
                    Editmessage = PostedData.Terminal + " updated successfully.";
                    ViewBag.Edit = Editmessage;
                    return RedirectToAction("Index");
                }
                else
                {
                    
                    StatusMessage = "Exists";
                    InsertMessage = PostedData.Terminal + " is already exists.";
                    ViewBag.Insert = InsertMessage;
                    return RedirectToAction("Edit");
                }
            }
            else
            {
                StatusMessage = "Error";
                return RedirectToAction("Index", "StoreTerminal");
            }

            ViewBag.StatusMessage = StatusMessage;
            return View(PostedData);
        }

        public ActionResult Delete(int Id = 0)
        {
            StatusMessage = "Error";

            tbl_Store_Terminal Data = db.tbl_Store_Terminal.Find(Id);
            Data.IsActive = false;
            db.Entry(Data).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            StatusMessage = "Delete";
            DeleteMessage = Data.Terminal + " deleted successfully.";
            ViewBag.Delete = DeleteMessage;
            return null;
        }
    }
}