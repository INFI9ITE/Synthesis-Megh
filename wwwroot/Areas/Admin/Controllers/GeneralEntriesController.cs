using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wwwroot.Areas.Admin.Models;
using wwwroot.Class;
using wwwrootBL.Entity;

namespace wwwroot.Areas.Admin.Controllers
{
    public class GeneralEntriesController : Controller
    {
        protected static string StatusMessage = "";
        private const int FirstPageIndex = 1;
        protected static Array Arr;
        protected static bool IsArray;
        protected static int TotalDataCount;
        protected static bool IsEdit = false;
        protected static IEnumerable BindData;
        WestZoneEntities db = new WestZoneEntities();
        // GET: Admin/GeneralEntries
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
                BindData = GetData(SearchRecords, SearchTitle).OfType<GeneralEntries>().ToList();
                TotalDataCount = BindData.OfType<GeneralEntries>().ToList().Count();

            }


            if (TotalDataCount == 0)
            {
                StatusMessage = "NoItem";
            }
            if (string.IsNullOrEmpty(SearchTitle.Trim()))
            {
                int storeid = 0;
                DateTime? salesdate = null;
                if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
                {
                    storeid = Convert.ToInt32(Session["storeid"]);
                    ViewBag.storeid = storeid;
                }
                var data = db.tbl_SalesGeneralEntries_select(storeid, null).OrderByDescending(x => x.salesdate).Select(x => x.salesdate).FirstOrDefault();
                if (data != null || (!string.IsNullOrEmpty(Convert.ToString(data))))
                {
                    SearchTitle = AdminSiteConfiguration.GetMonthDateFormat(Convert.ToString(data));
                }
                else
                {
                    SearchTitle = AdminSiteConfiguration.GetMonthDateFormat(Convert.ToString(DateTime.Now)); 
                }
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
            var ColumnName = typeof(GeneralEntries).GetProperties().Where(p => p.Name == orderby).FirstOrDefault();

            IEnumerable Data = null;
            if (IsAsc == 1)
            {
                ViewBag.AscVal = 0;
                Data = BindData.OfType<GeneralEntries>().ToList().OrderBy(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            else
            {

                ViewBag.AscVal = 1;

                Data = BindData.OfType<GeneralEntries>().ToList().OrderByDescending(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            StatusMessage = "";
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

            int storeid = 0;
            DateTime? salesdate = null;
            if (!string.IsNullOrEmpty(SearchTitle.Trim()))
            {
                try
                {
                    salesdate = Convert.ToDateTime(SearchTitle.Trim());
                }
                catch (Exception e) { }
            }
            else
            {
                if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
                {
                    storeid = Convert.ToInt32(Session["storeid"]);
                    ViewBag.storeid = storeid;
                }
                var data = db.tbl_SalesGeneralEntries_select(storeid, null).OrderByDescending(x => x.salesdate).Select(x => x.salesdate).FirstOrDefault();
                if (data != null || (!string.IsNullOrEmpty(Convert.ToString(data))))
                {
                    SearchTitle = Convert.ToString(data);
                    ViewBag.SearchTitle = SearchTitle;
                    salesdate = data;
                }
                else
                {
                    salesdate = DateTime.Today;
                }
            }

            if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
            {
                storeid = Convert.ToInt32(Session["storeid"]);
                ViewBag.storeid = storeid;
            }
            RtnData = (from data in db.tbl_SalesGeneralEntries_select(storeid, salesdate)
                       select new GeneralEntries
                       {
                           id = data.id,
                           CloseOutDate = data.salesdate,
                           CreatedDate = data.Createddate,
                           TotalAmount = data.totalamount,
                           UserId = data.userid,
                           UserName = data.Fullname,
                           Status = data.statusname,
                          Storename=data.storename,
                           noofpos = data.noofpos.GetValueOrDefault()
                       }).ToList<GeneralEntries>();
            return RtnData;
        }

        public ActionResult MarkAsApprove(int Id)
        {
            tbl_SalesGeneralEntries Data = db.tbl_SalesGeneralEntries.Find(Id);
            if (Data.status == null || Data.status == 0)
            {
                Data.status = 1;
            }
            else
            {
                Data.status = 3;
            }

            db.Entry(Data).State = EntityState.Modified;
            db.SaveChanges();

            return null;
        }

        public ActionResult Detail(int id)
        {
            GeneralEntriesDetail Detail = new GeneralEntriesDetail();
            Detail.GeneralEntries = (from dt in db.GeneralEntryDetail(id)
                                     select new GeneralEntries
                                     {
                                         CloseOutDate = dt.SalesDate,
                                         CreatedDate = dt.CreatedDate,
                                         id = id,
                                         Status = dt.statusname,
                                         GroupName = dt.Groupname,
                                         TotalAmount = dt.Amount,
                                         UserName = dt.Fullname,
                                         Typeid = dt.Typeid,
                                         Memo = dt.Memo,
                                         ChildSalesId = dt.id,
                                         CloseOutDateformat = wwwroot.Class.AdminSiteConfiguration.GetDateDisplay(Convert.ToString(dt.SalesDate)),
                                         DeptName = dt.DepartmentName == null ? "" : dt.DepartmentName.Replace("&amp;", "&"),

                                         validationflag = db.CheckConfigurationsales(dt.SalesDate, dt.storeid).Count()
                                     }).ToList<GeneralEntries>();
            return View(Detail);
        }

        [HttpPost]
        public ActionResult Detail(GeneralEntriesDetail posteddata)
        {
            if (ModelState.IsValid)
            {
                if (posteddata.GeneralEntries.Count > 0)
                {

                    for (int i = 0; i < posteddata.GeneralEntries.Count; i++)
                    {
                        tbl_ChildSalesEntries obj = db.tbl_ChildSalesEntries.Find(posteddata.GeneralEntries[i].ChildSalesId);
                        obj.Amount = posteddata.GeneralEntries[i].TotalAmount;
                        db.Entry(obj).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
            }
            GeneralEntriesDetail Detail = new GeneralEntriesDetail();
            Detail.GeneralEntries = (from dt in db.GeneralEntryDetail(posteddata.GeneralEntries[0].id)
                                     select new GeneralEntries
                                     {
                                         CloseOutDate = dt.SalesDate,
                                         CreatedDate = dt.CreatedDate,
                                         id = posteddata.GeneralEntries[0].id,
                                         Status = dt.statusname,
                                         GroupName = dt.Groupname,
                                         TotalAmount = dt.Amount,
                                         UserName = dt.Fullname,
                                         Typeid = dt.Typeid,
                                         Memo = dt.Memo,
                                         ChildSalesId = dt.id,
                                         DeptName = dt.DepartmentName == null ? "" : dt.DepartmentName.Replace("&amp;", "&"),

                                         validationflag = db.CheckConfigurationsales(dt.SalesDate, dt.storeid).Count()
                                     }).ToList<GeneralEntries>();
            return RedirectToAction("Detail", Detail);
        }
        public ActionResult Delete(int id = 0)
        {
            StatusMessage = "Error";
            if (id > 0)
            {
                db.tbl_SalesGeneralEntries_Delete(id);
                StatusMessage = "Delete";
            }
            return null;
        }

    }
}