using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using wwwrootBL.Entity;
using wwwroot.Models;
using wwwroot.Areas.Admin.Models;
using wwwroot.Class;
using System.IO;
using System.Web.Security;
using System.Configuration;

namespace wwwroot.Areas.Admin.Controllers
{
    public class DocumentController : Controller
    {
        #region vari
        protected static string Cloudurl;
        protected static string StatusMessage = "";
        protected static string ActivityLogMessage = "";
        protected static string DeleteMessage = "";
        private const int FirstPageIndex = 1;
        protected static int TotalDataCount;
        protected static int RtnDatalistcount;
        protected static Array Arr;
        protected static bool IsArray;
        protected static IEnumerable BindData;
        protected static bool IsEdit = false;
        // int userid = Convert.ToInt32(WebSecurity.CurrentUserId);
        // string username = WebSecurity.CurrentUserName;
        protected static string IsFilter = "0";
        protected static string paymethod = "";
        WestZoneEntities db = new WestZoneEntities();
        //protected static int PageSize;
        protected static int currentPageIndex;
        protected static string strdashbordsuccess;
        protected static string ExistCode = "";
        #endregion

        // GET: Admin/Document
        public ActionResult Index(string dashbordsuccess)
        {
            if (TempData["msg"] != null)
            {
                ViewBag.StatusMessage = TempData["msg"].ToString();
                strdashbordsuccess = TempData["msg"].ToString();
            }

            //Cloudurl = ConfigurationManager.AppSettings["cloudurl"];
            ViewBag.CloudURL = Cloudurl;
            // strdashbordsuccess = dashbordsuccess;
            //  ViewBag.StatusMessage = strdashbordsuccess;
            dashbordsuccess = "";
            if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
            {

                string store_idval = Session["storeid"].ToString();
                ViewBag.Storeidvalue = store_idval;
            }

            return View();
        }

        public ActionResult Grid(int IsBindData = 1, int currentPageIndex = 1, string orderby = "Id", int IsAsc = 0, int PageSize = 20, int SearchRecords = 1, string Alpha = "", string SearchTitle = "", int CategoryId = 0, string startdate = "", string enddate = "", bool chkImages = false, bool chkEmail = false, bool chkDoc = false, bool chkSheet = false, bool chkOther = false, bool IsPrivate = false, bool IsFavorite = false, int tabListing = 0)
        {
            DateTime d = DateTime.Now;

            DateTime? stDate = null;
            DateTime? enDate = null;

            try
            {
                stDate = Convert.ToDateTime(startdate);
                enDate = Convert.ToDateTime(enddate);
            }
            catch (Exception ex)
            {
            }


            #region QueryText

            string strFileType = ",.pdf,.txt,.doc,.docx,.jpg,.jpeg,.gif,.png,.xls,.xlsx,.eml,.msg,.rtf,.csv";
            if (chkDoc == true || chkImages == true || chkSheet == true || chkEmail == true || chkOther == true)
            {
                strFileType = "";

                if (chkDoc == true)
                {
                    strFileType += ",.doc,.docx,.pdf";
                }
                if (chkImages == true)
                {
                    strFileType += ",.jpg,.jpeg,.gif,.png";
                }
                if (chkSheet == true)
                {
                    strFileType += ",.xls,.xlsx,.csv";
                }
                if (chkEmail == true)
                {
                    strFileType += ",.eml,.msg";
                }
                if (chkOther == true)
                {
                    strFileType += ",.txt,.rtf";
                }

            }


            if (strFileType.Length > 0)
            {
                strFileType.Remove(0, 1);
            }

            //            string strQry = @" 
            //select 
            //id,
            //ROW_NUMBER() OVER(ORDER BY id desc) as RowNumber
            //,isprivate as Private
            //,Title as DocumentTitle
            //,AttachExtention
            //,(select Name from tbl_Store where id=t.Storeid) as StoreName  
            //,(select Name from tbl_DocumentCategory where id=t.CategoryId) as Category
            //,createdDate
            //,Notes
            //,[Description] as 'Description'
            //,isDelete

            // from tbl_DocumentGallary t where 1=1 ";


            //            if (CategoryId > 0)
            //            {
            //                strQry += " and t.CategoryId = " + CategoryId + " ";
            //            }
            //            if (stDate != null)
            //            {
            //                strQry += " and convert(varchar(10), CreatedDate,101) >= convert(varchar(10)," + stDate + ",101) ";
            //            }
            //            if (enDate != null)
            //            {
            //                strQry += " and convert(varchar(10), CreatedDate,101) >= convert(varchar(10)," + enDate + ",101) ";
            //            }

            //            strQry += " and (  ( t.AttachFile  like '%" + SearchTitle + "%') or (t.id in (select docid from tbl_Document_keyword where docid =t.id and title like '%" + SearchTitle + "%'))  " + ") ";
            //            //if(IsPrivate == true)
            //            //{
            //            //    strQry += " and t.isprivate = 1 ";
            //            //}
            //            //if(IsFavorite == true)
            //            //{
            //            //    strQry += " and t.id in (select docid from tbl_DocumentFavorites where DocId=t.Id and IsFavorite=1) ";
            //            //}

            //            strQry += strFileType;
            #endregion

            List<DocumentGrid> docGridList = new List<DocumentGrid>();
            try
            {
                int CurrentUserId = WebSecurity.CurrentUserId;
                bool isAdmin = false;
                bool isDataApprover = false;
                bool isStoreManager = false;
                int StoreId = 0;

                isAdmin = Roles.IsUserInRole("Administrator") ? true : false;
                isDataApprover = Roles.IsUserInRole("Data Approver") ? true : false;
                isStoreManager = Roles.IsUserInRole("Store Manager") ? true : false;

                if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
                {
                    StoreId = Convert.ToInt16(Session["storeid"]);
                }
                int startIndex = ((currentPageIndex - 1) * PageSize) + 1;
                int endIndex = startIndex + PageSize - 1;
                docGridList = (from data in db.tbl_Document_Grid_DataNew(CategoryId, stDate, enDate, SearchTitle, 0, 0, CurrentUserId, chkImages, chkEmail, chkDoc, chkSheet, chkOther, isAdmin, isDataApprover, isStoreManager, StoreId, strFileType)
                               select new DocumentGrid
                               {

                                   Id = data.id,
                                   Type = "doc",
                                   isprivate = data.isprivate ?? false,
                                   DocTitle = data.Title,
                                   AttachPath = data.FilePath,
                                   AttachFile = data.AttachFile + data.AttachExtention,
                                   AttachLink = wwwroot.Class.AdminSiteConfiguration.GetURL() + "\\userfiles\\docfile\\" + data.FilePath + "\\" + data.AttachFile + data.AttachExtention,
                                   storeName = data.StoreName,
                                   categoryName = data.Category,
                                   CreatedDate = data.createdDate,
                                   CreatedDateFormated = AdminSiteConfiguration.GetDateformat(Convert.ToString(data.createdDate)),
                                   Notes = data.Notes,
                                   Description = data.Description,
                                   isFavorite = (data.favId != null && data.favId.Value > 0) ? true : false,
                                   IsDelete = data.isDelete ?? false,
                                   AttachExtention = data.AttachExtention ?? "",
                                   IsStatus_id = data.createdby.GetValueOrDefault(),
                                   FavId = data.favId ?? 0
                               }).ToList();
                ViewBag.TotalDoc = docGridList.Count();
                ViewBag.TotalPrivate = docGridList.Where(x => x.isprivate == true).Count();
                ViewBag.TotalFav = docGridList.Where(x => x.FavId > 0).Count();

                ViewBag.totalcount = docGridList.Count();
                if (tabListing == 1)
                {
                    docGridList = docGridList.Where(x => x.isFavorite == true).ToList();
                    ViewBag.totalcount = docGridList.Count();
                }
                else if (tabListing == 2)
                {
                    docGridList = docGridList.Where(x => x.isprivate == true).ToList();
                    ViewBag.totalcount = docGridList.Count();
                }
                var ColumnName = typeof(DocumentGrid).GetProperties().Where(p => p.Name == orderby).FirstOrDefault();

                IEnumerable Data = null;
                //Response.Write(ColumnName);
                //Response.End();
                if (IsAsc == 1)
                {
                    ViewBag.IsAscVal = 0;
                    docGridList = docGridList.OfType<DocumentGrid>().ToList().OrderBy(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize).ToList();
                }
                else
                {

                    ViewBag.IsAscVal = 1;

                    docGridList = docGridList.OfType<DocumentGrid>().ToList().OrderByDescending(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize).ToList();
                }
                StatusMessage = docGridList.Count() == 0 ? "NoItem" : "";


            }
            catch (Exception ex)
            {
            }
            //  List<DocumentGrid> docgridList = GetData(SearchRecords, CategoryId, SearchTitle, startdate, enddate, 1); //.OfType<DocumentGrid>().ToList();
            // TotalDataCount = docGrid.Count();
            ViewBag.CategoryList = FillCategoryList();

            ViewBag.CategoryId = CategoryId;
            ViewBag.tabListing = tabListing;
            ViewBag.IsBindData = IsBindData;
            ViewBag.CurrentPageIndex = currentPageIndex;
            // ViewBag.LastPageIndex = this.getLastPageIndex(PageSize);
            ViewBag.OrderByVal = orderby;
            //ViewBag.IsAscVal = IsAsc;
            ViewBag.PageSize = PageSize;
            ViewBag.Alpha = Alpha;
            ViewBag.chkImages = chkImages;
            ViewBag.chkEmail = chkEmail;
            ViewBag.chkDoc = chkDoc;
            ViewBag.chkSheet = chkSheet;
            ViewBag.chkOther = chkOther;
            ViewBag.SearchTitle = SearchTitle;

            ViewBag.startindex = 1;
            ViewBag.startdate = startdate;
            ViewBag.enddate = enddate;
            //ViewBag.Store_val = Store_val;
            //ViewBag.TotalDoc = db.tbl_DocumentGallary.Where(x => x.IsDelete ?? false == false).Count();
            //ViewBag.TotalPrivate = db.tbl_DocumentGallary.Where(x => x.IsDelete ?? false == false && x.IsPrivate == true).Count();



            //if (strdashbordsuccess == "success" || strdashbordsuccess == "SuccessEdit" || strdashbordsuccess == "Exists" || strdashbordsuccess == "InvalidImage" || strdashbordsuccess == "Delete" || strdashbordsuccess == "Document added successfully." || strdashbordsuccess == "Document edited successfully.")
            if (strdashbordsuccess != null && strdashbordsuccess.Length > 25)
            {
                ViewBag.StatusMessage = strdashbordsuccess;
                strdashbordsuccess = "";
            }
            else
            {
                ViewBag.StatusMessage = StatusMessage;
            }

            if (TempData["msg"] != null && TempData["msg"].ToString().Length > 25)
            {
                ViewBag.StatusMessage = TempData["msg"].ToString();
            }

            for (int i = 0; i < docGridList.Count; i++)
            {
                var FileExt = docGridList[i].AttachExtention.ToLower();

                if (FileExt.Contains("pdf"))
                {
                    docGridList[i].FileTypeImage = "icon-pdf.svg";
                }
                else if (FileExt.Contains("jpg") || FileExt.Contains("jpeg"))
                {
                    docGridList[i].FileTypeImage = "icon-jpg.svg";
                }
                else if (FileExt.Contains("gif"))
                {
                    docGridList[i].FileTypeImage = "icon-gif.svg";
                }
                else if (FileExt.Contains("png"))
                {
                    docGridList[i].FileTypeImage = "icon-png.svg";
                }
                else if (FileExt.Contains("doc") || FileExt.Contains("docx"))
                {
                    docGridList[i].FileTypeImage = "icon-doc.svg";
                }
                else if (FileExt.Contains("xls") || FileExt.Contains("xlsx") || FileExt.Contains("csv"))
                {
                    docGridList[i].FileTypeImage = "icon-xls.svg";
                }
                else if (FileExt.Contains("txt") || FileExt.Contains("rtf"))
                {
                    docGridList[i].FileTypeImage = "icon-txt.svg";
                }
                else if (FileExt.Contains("eml") || FileExt.Contains("msg"))
                {
                    docGridList[i].FileTypeImage = "icon-eml.svg";
                }

            }

            docGridList = docGridList.Take(20).ToList();
            return View(docGridList);
        }

        public ActionResult GridScroll(int IsBindData = 1, int currentPageIndex = 1, string orderby = "id", int IsAsc = 0, int PageSize = 20, int SearchRecords = 1, string Alpha = "", string SearchTitle = "", int CategoryId = 0, string startdate = "", string enddate = "", bool chkImages = false, bool chkEmail = false, bool chkDoc = false, bool chkSheet = false, bool chkOther = false, bool IsPrivate = false, bool IsFavorite = false, int tabListing = 0)
        {
            strdashbordsuccess = "";
            DateTime d = DateTime.Now;

            DateTime? stDate = null;
            DateTime? enDate = null;

            try
            {
                stDate = Convert.ToDateTime(startdate);
                enDate = Convert.ToDateTime(enddate);
            }
            catch (Exception ex)
            {
            }


            #region QueryText

            string strFileType = ",.pdf,.txt,.doc,.docx,.jpg,.jpeg,.gif,.png,.xls,.xlsx,.eml,.msg,.rtf,.csv";
            if (chkDoc == true || chkImages == true || chkSheet == true || chkEmail == true || chkOther == true)
            {
                strFileType = "";

                if (chkDoc == true)
                {
                    strFileType += ",.doc,.docx,.pdf";
                }
                if (chkImages == true)
                {
                    strFileType += ",.jpg,.jpeg,.gif,.png";
                }
                if (chkSheet == true)
                {
                    strFileType += ",.xls,.xlsx,.csv";
                }
                if (chkEmail == true)
                {
                    strFileType += ",.eml,.msg";
                }
                if (chkOther == true)
                {
                    strFileType += ",.txt,.rtf";
                }

            }


            if (strFileType.Length > 0)
            {
                strFileType.Remove(0, 1);
            }

            //            string strQry = @" 
            //select 
            //id,
            //ROW_NUMBER() OVER(ORDER BY id desc) as RowNumber
            //,isprivate as Private
            //,Title as DocumentTitle
            //,AttachExtention
            //,(select Name from tbl_Store where id=t.Storeid) as StoreName  
            //,(select Name from tbl_DocumentCategory where id=t.CategoryId) as Category
            //,createdDate
            //,Notes
            //,[Description] as 'Description'
            //,isDelete

            // from tbl_DocumentGallary t where 1=1 ";


            //            if (CategoryId > 0)
            //            {
            //                strQry += " and t.CategoryId = " + CategoryId + " ";
            //            }
            //            if (stDate != null)
            //            {
            //                strQry += " and convert(varchar(10), CreatedDate,101) >= convert(varchar(10)," + stDate + ",101) ";
            //            }
            //            if (enDate != null)
            //            {
            //                strQry += " and convert(varchar(10), CreatedDate,101) >= convert(varchar(10)," + enDate + ",101) ";
            //            }

            //            strQry += " and (  ( t.AttachFile  like '%" + SearchTitle + "%') or (t.id in (select docid from tbl_Document_keyword where docid =t.id and title like '%" + SearchTitle + "%'))  " + ") ";
            //            //if(IsPrivate == true)
            //            //{
            //            //    strQry += " and t.isprivate = 1 ";
            //            //}
            //            //if(IsFavorite == true)
            //            //{
            //            //    strQry += " and t.id in (select docid from tbl_DocumentFavorites where DocId=t.Id and IsFavorite=1) ";
            //            //}

            //            strQry += strFileType;
            #endregion

            List<DocumentGrid> docGridList = new List<DocumentGrid>();
            try
            {
                int CurrentUserId = WebSecurity.CurrentUserId;
                bool isAdmin = false;
                bool isDataApprover = false;
                bool isStoreManager = false;
                int StoreId = 0;

                isAdmin = Roles.IsUserInRole("Administrator") ? true : false;
                isDataApprover = Roles.IsUserInRole("Data Approver") ? true : false;
                isStoreManager = Roles.IsUserInRole("Store Manager") ? true : false;

                if (!string.IsNullOrEmpty(Convert.ToString(Session["storeid"])))
                {
                    StoreId = Convert.ToInt16(Session["storeid"]);
                }

                int startIndex = ((currentPageIndex) * PageSize) + 1;
                int endIndex = startIndex + PageSize - 1;
                if (tabListing == 0)
                    docGridList = (from data in db.tbl_Document_Grid_DataNew(CategoryId, stDate, enDate, SearchTitle, 0, 0, CurrentUserId, chkImages, chkEmail, chkDoc, chkSheet, chkOther, isAdmin, isDataApprover, isStoreManager, StoreId, strFileType)
                                   select new DocumentGrid
                                   {

                                       Id = data.id,
                                       Type = "doc",
                                       isprivate = data.isprivate ?? false,
                                       DocTitle = data.Title,
                                       AttachPath = data.FilePath,
                                       AttachFile = data.AttachFile + data.AttachExtention,
                                       AttachLink = wwwroot.Class.AdminSiteConfiguration.GetURL() + "\\userfiles\\docfile\\" + data.FilePath + "\\" + data.AttachFile + data.AttachExtention,
                                       storeName = data.StoreName,
                                       categoryName = data.Category,
                                       CreatedDate = data.createdDate,
                                       CreatedDateFormated = AdminSiteConfiguration.GetDateformat(Convert.ToString(data.createdDate)),
                                       Notes = data.Notes,
                                       Description = data.Description,
                                       isFavorite = (data.favId != null && data.favId.Value > 0) ? true : false,
                                       IsDelete = data.isDelete ?? false,
                                       AttachExtention = data.AttachExtention ?? "",
                                       IsStatus_id = data.createdby.GetValueOrDefault(),
                                       FavId = data.favId ?? 0
                                   }).ToList();//.Skip(currentPageIndex * PageSize).Take(PageSize)
                else if (tabListing == 1)
                {
                    docGridList = (from data in db.tbl_Document_Grid_DataNew(CategoryId, stDate, enDate, SearchTitle, 0, 0, CurrentUserId, chkImages, chkEmail, chkDoc, chkSheet, chkOther, isAdmin, isDataApprover, isStoreManager, StoreId, strFileType)
                                   select new DocumentGrid
                                   {

                                       Id = data.id,
                                       Type = "doc",
                                       isprivate = data.isprivate ?? false,
                                       DocTitle = data.Title,
                                       AttachPath = data.FilePath,
                                       AttachFile = data.AttachFile + data.AttachExtention,
                                       AttachLink = wwwroot.Class.AdminSiteConfiguration.GetURL() + "\\userfiles\\docfile\\" + data.FilePath + "\\" + data.AttachFile + data.AttachExtention,
                                       storeName = data.StoreName,
                                       categoryName = data.Category,
                                       CreatedDate = data.createdDate,
                                       CreatedDateFormated = AdminSiteConfiguration.GetDateformat(Convert.ToString(data.createdDate)),
                                       Notes = data.Notes,
                                       Description = data.Description,
                                       isFavorite = (data.favId != null && data.favId.Value > 0) ? true : false,
                                       IsDelete = data.isDelete ?? false,
                                       AttachExtention = data.AttachExtention ?? "",
                                       IsStatus_id = data.createdby.GetValueOrDefault(),
                                       FavId = data.favId ?? 0
                                   }).Where(x => x.isFavorite == true).ToList();//.Skip(currentPageIndex * PageSize).Take(PageSize)

                }
                else if (tabListing == 2)
                {
                    docGridList = (from data in db.tbl_Document_Grid_DataNew(CategoryId, stDate, enDate, SearchTitle, 0, 0, CurrentUserId, chkImages, chkEmail, chkDoc, chkSheet, chkOther, isAdmin, isDataApprover, isStoreManager, StoreId, strFileType)
                                   select new DocumentGrid
                                   {

                                       Id = data.id,
                                       Type = "doc",
                                       isprivate = data.isprivate ?? false,
                                       DocTitle = data.Title,
                                       AttachPath = data.FilePath,
                                       AttachFile = data.AttachFile + data.AttachExtention,
                                       AttachLink = wwwroot.Class.AdminSiteConfiguration.GetURL() + "\\userfiles\\docfile\\" + data.FilePath + "\\" + data.AttachFile + data.AttachExtention,
                                       storeName = data.StoreName,
                                       categoryName = data.Category,
                                       CreatedDate = data.createdDate,
                                       CreatedDateFormated = AdminSiteConfiguration.GetDateformat(Convert.ToString(data.createdDate)),
                                       Notes = data.Notes,
                                       Description = data.Description,
                                       isFavorite = (data.favId != null && data.favId.Value > 0) ? true : false,
                                       IsDelete = data.isDelete ?? false,
                                       AttachExtention = data.AttachExtention ?? "",
                                       IsStatus_id = data.createdby.GetValueOrDefault(),
                                       FavId = data.favId ?? 0
                                   }).Where(x => x.isprivate == true).ToList();//.Skip(currentPageIndex * PageSize).Take(PageSize)

                }

                ViewBag.TotalDoc = docGridList.Count();
                ViewBag.TotalPrivate = docGridList.Where(x => x.isprivate == true).Count();
                ViewBag.TotalFav = docGridList.Where(x => x.FavId > 0).Count();

                ViewBag.totalcount = docGridList.Count();
                if (tabListing == 1)
                {
                    docGridList = docGridList.Where(x => x.isFavorite == true).ToList();
                    ViewBag.totalcount = docGridList.Count();
                }
                else if (tabListing == 2)
                {
                    docGridList = docGridList.Where(x => x.isprivate == true).ToList();
                    ViewBag.totalcount = docGridList.Count();
                }
                var ColumnName = typeof(DocumentGrid).GetProperties().Where(p => p.Name == orderby).FirstOrDefault();

                IEnumerable Data = null;
                //Response.Write(ColumnName);
                //Response.End();
                if (IsAsc == 0)
                {
                    ViewBag.IsAscVal = 0;
                    docGridList = docGridList.OfType<DocumentGrid>().ToList().OrderBy(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize).ToList();
                }
                else
                {

                    ViewBag.IsAscVal = 1;

                    docGridList = docGridList.OfType<DocumentGrid>().ToList().OrderByDescending(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize).ToList();
                }
                StatusMessage = docGridList.Count() == 0 ? "NoItem" : "";


            }
            catch (Exception ex)
            {
            }
            //  List<DocumentGrid> docgridList = GetData(SearchRecords, CategoryId, SearchTitle, startdate, enddate, 1); //.OfType<DocumentGrid>().ToList();
            // TotalDataCount = docGrid.Count();
            ViewBag.CategoryList = FillCategoryList();

            ViewBag.CategoryId = CategoryId;
            ViewBag.tabListing = tabListing;
            ViewBag.IsBindData = IsBindData;
            ViewBag.CurrentPageIndex = currentPageIndex;
            // ViewBag.LastPageIndex = this.getLastPageIndex(PageSize);
            ViewBag.OrderByVal = orderby;
            ViewBag.IsAscVal = IsAsc;
            ViewBag.PageSize = PageSize;
            ViewBag.Alpha = Alpha;
            ViewBag.chkImages = chkImages;
            ViewBag.chkEmail = chkEmail;
            ViewBag.chkDoc = chkDoc;
            ViewBag.chkSheet = chkSheet;
            ViewBag.chkOther = chkOther;
            ViewBag.SearchTitle = SearchTitle;
            ViewBag.startindex = 1;
            ViewBag.startdate = startdate;
            ViewBag.enddate = enddate;
            //ViewBag.Store_val = Store_val;
            //ViewBag.TotalDoc = db.tbl_DocumentGallary.Where(x => x.IsDelete ?? false == false).Count();
            //ViewBag.TotalPrivate = db.tbl_DocumentGallary.Where(x => x.IsDelete ?? false == false && x.IsPrivate == true).Count();



            if (strdashbordsuccess == "success" || strdashbordsuccess == "SuccessEdit" || strdashbordsuccess == "Exists" || strdashbordsuccess == "InvalidImage" || strdashbordsuccess == "Delete")
            {
                ViewBag.StatusMessage = strdashbordsuccess;
                strdashbordsuccess = "";
            }
            else
            {
                ViewBag.StatusMessage = StatusMessage;
            }

            for (int i = 0; i < docGridList.Count; i++)
            {
                var FileExt = docGridList[i].AttachExtention.ToLower();

                if (FileExt.Contains("pdf"))
                {
                    docGridList[i].FileTypeImage = "icon-pdf.svg";
                }
                else if (FileExt.Contains("jpg") || FileExt.Contains("jpeg"))
                {
                    docGridList[i].FileTypeImage = "icon-jpg.svg";
                }
                else if (FileExt.Contains("gif"))
                {
                    docGridList[i].FileTypeImage = "icon-gif.svg";
                }
                else if (FileExt.Contains("png"))
                {
                    docGridList[i].FileTypeImage = "icon-png.svg";
                }
                else if (FileExt.Contains("doc") || FileExt.Contains("docx"))
                {
                    docGridList[i].FileTypeImage = "icon-doc.svg";
                }
                else if (FileExt.Contains("xls") || FileExt.Contains("xlsx") || FileExt.Contains("csv"))
                {
                    docGridList[i].FileTypeImage = "icon-xls.svg";
                }
                else if (FileExt.Contains("txt") || FileExt.Contains("rtf"))
                {
                    docGridList[i].FileTypeImage = "icon-txt.svg";
                }
                else if (FileExt.Contains("eml") || FileExt.Contains("msg"))
                {
                    docGridList[i].FileTypeImage = "icon-eml.svg";
                }
            }

            return Json(docGridList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddDocument()
        {
            DocumentCreate documentCreate = new Models.DocumentCreate();
            if (TempData["PostedData"] != null)
            {
                documentCreate = (DocumentCreate)TempData["PostedData"];
                TempData["PostedData"] = null;
            }

            ViewBag.StoreId = Session["storeid"].ToString();

            documentCreate.CategoryList = FillCategoryList();
            documentCreate.StoreList = FillStoreList();


            return View(documentCreate);
        }

        [HttpPost]
        public ActionResult AddDocument(DocumentCreate PostedData, HttpPostedFileBase AttachFile, string btnsubmit = "")
        {
            PostedData.CategoryList = FillCategoryList();
            PostedData.StoreList = FillStoreList();

            string strFilePrefix = DateTime.Now.ToString("ddMMyyyy") + "_";
            if (ModelState.IsValid)
            {
                #region file
                try
                {
                    PostedData.StoreList = FillStoreList();

                    var storeList = PostedData.StoreList.Where(x => x.Value == PostedData.StoreId.ToString()).FirstOrDefault();
                    var StoreName = "";
                    if (storeList != null)
                    {
                        StoreName = storeList.Text;
                    }

                    if (AttachFile != null)
                    {
                        if (AttachFile.ContentLength > 0)
                        {
                            string Sacn_Title;
                            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".eml", ".msg", ".txt", ".csv", ".rtf", ".msg" };
                            PostedData.AttachFile = AttachFile.FileName;
                            PostedData.AttachExtention = Path.GetExtension(AttachFile.FileName);

                            if (!allowedExtensions.Contains(PostedData.AttachExtention.ToLower()))
                            {
                                ViewBag.StatusMessage = "Invalid File";
                                PostedData.strErrMessage = "Invalid File";
                                TempData["PostedData"] = PostedData;
                                return RedirectToAction("AddDocument", "Document");
                            }
                            else
                            {
                                if (AttachFile.ContentLength > 20971520)
                                {
                                    ViewBag.StatusMessage = "InvalidPDFSize";
                                    PostedData.strErrMessage = "InvalidPDFSize";
                                    TempData["PostedData"] = PostedData;
                                    return RedirectToAction("AddDocument", "Document");
                                }
                                else
                                {
                                    Sacn_Title = Path.GetFileName(PostedData.Title);
                                    Sacn_Title = AdminSiteConfiguration.RemoveSpecialCharacter(Sacn_Title);
                                    StoreName = AdminSiteConfiguration.RemoveSpecialCharacter(StoreName);

                                    DateTime curDate = DateTime.Now;
                                    string BasePath = "~\\userfiles\\docfile";
                                    string ExtPath = "\\" + StoreName;
                                    ExtPath = ExtPath + "\\" + curDate.Year.ToString();
                                    ExtPath = ExtPath + "\\" + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(curDate.Month); ;

                                    PostedData.FilePath = ExtPath;
                                    if (!Directory.Exists(Server.MapPath(BasePath + ExtPath)))
                                        Directory.CreateDirectory(Server.MapPath(BasePath + ExtPath));


                                    ////Request.PhysicalApplicationPath +



                                    int DocId = 0;
                                    PostedData.CreatedBy = WebSecurity.CurrentUserId;
                                    PostedData.CreatedDate = DateTime.Now;

                                    PostedData.IsPrivate = PostedData.chkPrivate == "1" ? true : false;
                                    PostedData.IsFavorite = PostedData.chkFav == "1" ? true : false;
                                    PostedData.AttachFile = strFilePrefix + (Sacn_Title.Replace(PostedData.AttachExtention, ""));
                                    PostedData.AttachExtention = PostedData.AttachExtention.ToLower();
                                    DocId = Convert.ToInt16(db.tbl_DocumentGallery_Insert(PostedData.Title, PostedData.CategoryId, PostedData.StoreId, PostedData.Notes, PostedData.Description, PostedData.FilePath, PostedData.AttachFile, PostedData.AttachExtention, PostedData.CreatedBy, PostedData.CreatedDate, PostedData.ModifiedBy, PostedData.ModifiedDate, PostedData.IsPrivate).Select(x => x.ToString()).FirstOrDefault());

                                    var path1 = Server.MapPath(BasePath + ExtPath + "\\") + PostedData.AttachFile + "_" + DocId.ToString() + PostedData.AttachExtention;

                                    AttachFile.SaveAs(path1);


                                    if (PostedData.KeyWords != null)
                                    {
                                        var KeywordList = PostedData.KeyWords.Split(',');
                                        foreach (string keyword in KeywordList)
                                        {
                                            db.tbl_Document_keyword_Insert(DocId, keyword, true);
                                        }
                                    }
                                    db.tbl_DocumentFavorites_Insert(DocId, PostedData.CreatedBy, DateTime.Now, PostedData.IsFavorite);

                                    string message = "";
                                    ViewBag.StatusMessage = "Document added successfully.";

                                    TempData["msg"] = "Document added successfully.";
                                    if (btnsubmit == "Save & New")
                                    {
                                        return RedirectToAction("AddDocument", "Document", new { @dashbordsuccess = message });
                                    }
                                    else
                                    {
                                        return RedirectToAction("index", "Document", new { @dashbordsuccess = message });
                                    }


                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    return RedirectToAction("index", "Document", new { @dashbordsuccess = "" });
                }
                #endregion

                return RedirectToAction("index", "Document", new { @dashbordsuccess = "" });
            }
            else
            {

                return RedirectToAction("addDocument", "Document", new { @dashbordsuccess = "" });
            }
            // return RedirectToAction("index", "Document", new { @dashbordsuccess = "" });
        }

        [HttpGet]
        public ActionResult EditDocument(int id = 0, string RedairectFrom = "")
        {
            int CurrentUserId = Convert.ToInt32(WebSecurity.CurrentUserId);
            DocumentCreate documentCreate = new Models.DocumentCreate();
            documentCreate.CategoryList = FillCategoryList();
            documentCreate.StoreList = FillStoreList();

            try
            {
                var data = db.tbl_DocumentGallary.Where(x => x.Id == id).FirstOrDefault();
                var dataKeyword = db.tbl_Document_keyword.Where(x => x.DocID == id).ToList();
                var dataFav = db.tbl_DocumentFavorites.Where(x => x.DocId == id && x.UserId == CurrentUserId).FirstOrDefault();
                var FullPath = data.FilePath + "\\" + data.AttachFile + data.AttachExtention;

                foreach (var dk in dataKeyword)
                {
                    documentCreate.KeyWords += dk.Title + ",";
                }
                if (documentCreate.KeyWords != null && documentCreate.KeyWords.Contains(","))
                {
                    documentCreate.KeyWords = documentCreate.KeyWords.Remove(documentCreate.KeyWords.LastIndexOf(","));
                }
                #region

                ddllist StoreNameList = documentCreate.StoreList.Where(x => x.Value == data.StoreId.ToString()).FirstOrDefault();

                documentCreate.Title = data.Title;
                documentCreate.CategoryId = data.CategoryId;
                documentCreate.StoreId = data.StoreId;
                documentCreate.StoreName = StoreNameList != null ? StoreNameList.Text : "";
                documentCreate.Notes = data.Notes;
                documentCreate.Description = data.Description;
                //documentCreate.KeyWords = data.KeyWords;
                documentCreate.FullPath = FullPath;
                documentCreate.AttachFile = data.AttachFile;
                documentCreate.AttachExtention = data.AttachExtention;
                documentCreate.CreatedBy = data.CreatedBy;
                documentCreate.CreatedDate = data.CreatedDate;
                documentCreate.ModifiedBy = data.ModifiedBy;
                documentCreate.ModifiedDate = data.ModifiedDate;
                documentCreate.IsPrivate = data.IsPrivate;
                documentCreate.IsDelete = data.IsDelete;
                //documentCreate.IsFavorite = data.IsFavorite;
                documentCreate.chkPrivate = data.IsPrivate == true ? "1" : "0";
                if (dataFav != null && dataFav.IsFavorite == true)
                {
                    documentCreate.chkFav = "1";
                }
                else
                {
                    documentCreate.chkFav = "0";
                }
                #endregion

                if (TempData["PostedData"] != null)
                {
                    DocumentCreate tempData = (DocumentCreate)TempData["PostedData"];
                    documentCreate.FullPath = FullPath;
                    documentCreate.AttachFile = tempData.AttachFile;
                    documentCreate.AttachExtention = tempData.AttachExtention;
                    TempData["PostedData"] = null;
                }
            }
            catch (Exception ex)
            {
            }
            return View(documentCreate);
        }

        [HttpPost]
        public ActionResult EditDocument(DocumentCreate PostedData, HttpPostedFileBase AttachFile, string btnsubmit = "")
        {
            string strOldFile = "";
            string strNewFile = "";

            PostedData.CategoryList = FillCategoryList();
            PostedData.StoreList = FillStoreList();

            string strFilePrefix = DateTime.Now.ToString("ddMMyyyy") + "_";
            if (ModelState.IsValid)
            {
            }

            #region file
            try
            {
                PostedData.StoreList = FillStoreList();
                var storeList = PostedData.StoreList.Where(x => x.Value == PostedData.StoreId.ToString()).FirstOrDefault();
                var StoreName = "";
                if (storeList != null)
                {
                    StoreName = storeList.Text;
                }

                if (AttachFile != null)
                {
                    if (AttachFile.ContentLength > 0)
                    {
                        string Sacn_Title;
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".eml", ".msg", ".txt", ".csv", ".rtf", ".msg" };

                        PostedData.AttachFile = AttachFile.FileName;
                        PostedData.AttachExtention = Path.GetExtension(AttachFile.FileName);

                        if (!allowedExtensions.Contains(PostedData.AttachExtention.ToLower()))
                        {
                            ViewBag.StatusMessage = "Invalid File";
                            // return View(PostedData);
                            PostedData.strErrMessage = "Invalid File";
                            TempData["PostedData"] = PostedData;
                            return RedirectToAction("EditDocument", "Document", new { id = PostedData.Id });
                        }
                        else
                        {
                            if (AttachFile.ContentLength > 20971520)
                            {
                                ViewBag.StatusMessage = "InvalidPDFSize";
                                PostedData.strErrMessage = "InvalidPDFSize";
                                TempData["PostedData"] = PostedData;
                                return RedirectToAction("EditDocument", "Document", new { id = PostedData.Id });
                            }
                            else
                            {
                                Sacn_Title = Path.GetFileName(PostedData.Title);
                                Sacn_Title = AdminSiteConfiguration.RemoveSpecialCharacter(Sacn_Title);
                                StoreName = AdminSiteConfiguration.RemoveSpecialCharacter(StoreName);

                                DateTime curDate = DateTime.Now;
                                string BasePath = "~\\userfiles\\docfile";
                                string ExtPath = "\\" + StoreName;
                                ExtPath = ExtPath + "\\" + curDate.Year.ToString();
                                ExtPath = ExtPath + "\\" + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(curDate.Month); ;

                                PostedData.FilePath = ExtPath;
                                if (!Directory.Exists(Server.MapPath(BasePath + ExtPath)))
                                    Directory.CreateDirectory(Server.MapPath(BasePath + ExtPath));

                                Sacn_Title = (Sacn_Title.Replace(PostedData.AttachExtention, "")) + "_" + PostedData.Id.ToString();

                                var path1 = Server.MapPath(BasePath + ExtPath + "\\") + strFilePrefix + Sacn_Title + PostedData.AttachExtention;
                                strNewFile = Server.MapPath(BasePath + ExtPath + "\\");
                                ////Request.PhysicalApplicationPath +
                                if (PostedData.Id > 0)
                                {
                                    var dataDoc1 = db.tbl_DocumentGallary.Where(x => x.Id == PostedData.Id).FirstOrDefault();
                                    strNewFile += dataDoc1.AttachFile + dataDoc1.AttachExtention;
                                    if (System.IO.File.Exists(strNewFile))
                                    {
                                        System.IO.File.Delete(strNewFile);
                                    }
                                }

                                AttachFile.SaveAs(path1);
                                PostedData.AttachFile = (Sacn_Title.Replace(PostedData.AttachExtention, ""));
                            }
                        }
                    }
                    else
                    {
                        ViewBag.StatusMessage = "InvalidPDFSize";
                        //return RedirectToAction("EditDocument", "Document", new { id = PostedData.Id });
                    }
                }
                else
                {
                    ViewBag.StatusMessage = "InvalidPDFSize";
                    //return RedirectToAction("EditDocument", "Document", new { id = PostedData.Id });
                }

            }
            catch (Exception ex)
            {
            }
            #endregion

            try
            {
                int DocId = 0;
                PostedData.ModifiedBy = WebSecurity.CurrentUserId;
                PostedData.ModifiedDate = DateTime.Now;

                PostedData.IsPrivate = PostedData.chkPrivate == "1" ? true : false;
                PostedData.IsFavorite = PostedData.chkFav == "1" ? true : false;

                tbl_DocumentGallary dataDoc;
                if (PostedData.Id > 0)
                {
                    dataDoc = db.tbl_DocumentGallary.Where(x => x.Id == PostedData.Id).FirstOrDefault();
                    dataDoc.ModifiedBy = PostedData.ModifiedBy;
                    dataDoc.ModifiedDate = PostedData.ModifiedDate;
                    dataDoc.IsPrivate = PostedData.IsPrivate;
                    dataDoc.IsDelete = PostedData.IsDelete;

                    dataDoc.Title = PostedData.Title;
                    dataDoc.CategoryId = PostedData.CategoryId;
                    dataDoc.StoreId = PostedData.StoreId;
                    dataDoc.Notes = PostedData.Notes;
                    dataDoc.Description = PostedData.Description;

                    if (AttachFile != null)
                    {
                        if (AttachFile.ContentLength > 0)
                        {
                            dataDoc.FilePath = PostedData.FilePath;
                            dataDoc.AttachFile = strFilePrefix + AdminSiteConfiguration.RemoveSpecialCharacter(PostedData.AttachFile);

                            dataDoc.AttachExtention = PostedData.AttachExtention.ToLower();
                        }
                    }
                    dataDoc.ModifiedDate = DateTime.Now;

                    db.SaveChanges();


                    db.tbl_DocumentKeywords_deleteByDocId(PostedData.Id);
                    if (PostedData.KeyWords != null)
                    {
                        var KeywordList = PostedData.KeyWords.Split(',');
                        foreach (string keyword in KeywordList)
                        {
                            db.tbl_Document_keyword_Insert(PostedData.Id, keyword, true);
                        }
                    }
                    tbl_DocumentFavorites docFav = db.tbl_DocumentFavorites.Where(x => x.DocId == PostedData.Id).FirstOrDefault();
                    docFav.IsFavorite = PostedData.IsFavorite;
                    db.SaveChanges();
                }

                string message = "";

                TempData["msg"] = "Document edited successfully.";

                if (btnsubmit == "Save & New")
                {
                    return RedirectToAction("AddDocument", "Document", new { @dashbordsuccess = message });
                }
                else
                {
                    return RedirectToAction("index", "Document", new { @dashbordsuccess = message });
                }
            }

            catch (Exception ex)
            {
                return RedirectToAction("index", "Document", new { @dashbordsuccess = "" });
            }
        }

        [HttpGet]
        public ActionResult DetailDocument(int id = 0, string RedairectFrom = "")
        {
            int CurrentUserId = Convert.ToInt32(WebSecurity.CurrentUserId);

            ViewBag.id = id;
            DocumentCreate documentCreate = new Models.DocumentCreate();
            documentCreate.CategoryList = FillCategoryList();
            documentCreate.StoreList = FillStoreList();

            try
            {
                var data = db.tbl_Document_Get_Detail(id).FirstOrDefault();
                // var data1 = db.tbl_DocumentGallary.Where(x => x.Id == id).FirstOrDefault();
                var dataKeyword = db.tbl_Document_keyword.Where(x => x.DocID == id).ToList();
                var dataFav = db.tbl_DocumentFavorites.Where(x => x.DocId == id && x.UserId == CurrentUserId).FirstOrDefault();
                // var dataCreateBy = db.tbl_user.Where(x => x.Reg_userid == data.CreatedBy).FirstOrDefault();
                //  var dataModifyBy = db.tbl_user.Where(x => x.Reg_userid == data.ModifiedBy).FirstOrDefault();

                var FullPath = data.FilePath + "\\" + data.AttachFile + data.AttachExtention;

                // <span class="keywordsbox">Bank Account Information</span>
                foreach (var dk in dataKeyword)
                {
                    documentCreate.KeyWords += "<span class='keywordsbox'>" + dk.Title + "</span>";
                }

                #region
                ddllist StoreNameList = documentCreate.StoreList.Where(x => x.Value == data.StoreId.ToString()).FirstOrDefault();
                ddllist CategoryNameList = documentCreate.CategoryList.Where(x => x.Value == data.CategoryId.ToString()).FirstOrDefault();

                documentCreate.Id = data.Id;
                documentCreate.Title = data.Title;
                documentCreate.CategoryId = data.CategoryId;
                documentCreate.StoreId = data.StoreId;
                documentCreate.StoreName = StoreNameList != null ? StoreNameList.Text : "";
                documentCreate.CategoryName = StoreNameList != null ? CategoryNameList.Text : "";
                documentCreate.Notes = data.Notes;
                //documentCreate.Description = data.Description;
                //documentCreate.KeyWords = data.KeyWords;
                documentCreate.FullPath = FullPath;
                documentCreate.AttachFile = data.AttachFile;
                documentCreate.AttachExtention = data.AttachExtention;
                documentCreate.CreatedBy = data.CreatedBy;
                documentCreate.CreatedDateFormated = AdminSiteConfiguration.GetDateformat(Convert.ToString(data.CreatedDate));
                documentCreate.ModifiedBy = data.ModifiedBy;
                documentCreate.ModifiedDate = data.ModifiedDate;
                documentCreate.IsPrivate = data.IsPrivate;
                documentCreate.IsDelete = data.IsDelete;
                //documentCreate.IsFavorite = data.IsFavorite;
                documentCreate.chkPrivate = data.IsPrivate == true ? "1" : "0";

                documentCreate.CreatedByName = data.CreatedByName;
                documentCreate.ModifyByName = data.ModifiedByName;

                if (dataFav != null && dataFav.IsFavorite == true)
                {
                    documentCreate.chkFav = "1";
                }
                else
                {
                    documentCreate.chkFav = "0";
                }


                var FileExt = documentCreate.AttachExtention.ToLower();

                if (FileExt.Contains("pdf"))
                {
                    documentCreate.FileTypeImage = "icon-pdf.svg";
                }
                else if (FileExt.Contains("jpg") || FileExt.Contains("jpeg"))
                {
                    documentCreate.FileTypeImage = "icon-jpg.svg";
                }
                else if (FileExt.Contains("gif"))
                {
                    documentCreate.FileTypeImage = "icon-gif.svg";
                }
                else if (FileExt.Contains("png"))
                {
                    documentCreate.FileTypeImage = "icon-png.svg";
                }
                else if (FileExt.Contains("doc") || FileExt.Contains("docx"))
                {
                    documentCreate.FileTypeImage = "icon-doc.svg";
                }
                else if (FileExt.Contains("xls") || FileExt.Contains("xlsx") || FileExt.Contains("csv"))
                {
                    documentCreate.FileTypeImage = "icon-xls.svg";
                }
                else if (FileExt.Contains("txt") || FileExt.Contains("rtf"))
                {
                    documentCreate.FileTypeImage = "icon-txt.svg";
                }
                else if (FileExt.Contains("eml") || FileExt.Contains("msg"))
                {
                    documentCreate.FileTypeImage = "icon-eml.svg";
                }

                #endregion
            }
            catch (Exception ex)
            {
            }
            return View(documentCreate);
        }

        [HttpPost]
        public ActionResult DetailDocument(int Id = 0)
        {
            var data = db.tbl_DocumentGallary.Where(x => x.Id == Id).FirstOrDefault();
            if (data != null)
            {
                data.IsDelete = true;
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("index", "Document", new { @dashbordsuccess = "Delete" });
            }
            return RedirectToAction("index", "Document", new { @dashbordsuccess = "Delete" });
        }

        public ActionResult Delete(int Id = 0)
        {

            try
            {
                var data = db.tbl_DocumentGallary.Where(x => x.Id == Id).FirstOrDefault();
                data.IsDelete = true;
                db.SaveChanges();
                TempData["msg"] = "Document deleted successfully.";
                return Json(new { sucess = 1 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { sucess = 0 }, JsonRequestBehavior.AllowGet);
            }

            // return RedirectToAction("index", "Document", new { @dashbordsuccess = "Delete" });
        }

        public ActionResult AddToFavorite(int DocId = 0)
        {
            try
            {
                tbl_DocumentFavorites data = db.tbl_DocumentFavorites.Where(x => x.DocId == DocId && x.UserId == WebSecurity.CurrentUserId).FirstOrDefault();
                if (data != null)
                {
                    data.IsFavorite = data.IsFavorite == true ? false : true; //reverse favorite flag
                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else if (DocId > 0)
                {
                    var insert = db.tbl_DocumentFavorites_Insert(DocId, WebSecurity.CurrentUserId, DateTime.Now, true);
                    data = db.tbl_DocumentFavorites.Where(x => x.DocId == DocId && x.UserId == WebSecurity.CurrentUserId).FirstOrDefault();
                }


                string message = data.IsFavorite == true ? "Document added to favorite." : "Document added to Unfavorite.";

                return Json(new { sucess = 1, msg = message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { sucess = 0, msg = "" }, JsonRequestBehavior.AllowGet);
            }
            //return RedirectToAction("index", "Document", new { @dashbordsuccess = "Added to favorite successfully." });
        }

        public List<ddllist> FillStoreList()
        {
            //List<ddllist> StoreList = (from dataUser in db.tbl_user_Selectstore()

            //                           select new ddllist
            //                           {
            //                               Value = dataUser.Id.ToString(),
            //                               Text = dataUser.Name
            //                           }).ToList();


            //if (Roles.IsUserInRole("Back Office Manager") || Roles.IsUserInRole("Data Approver") || Roles.IsUserInRole("Store Manager"))
            //{
            //    var Storenamelist1 = db.tbl_user_store_By_Reg_userid(@WebSecurity.CurrentUserId).Select(x => x.Storeid).ToList();
            //    StoreList = StoreList.Where(x => Storenamelist1.Contains(Convert.ToInt32(x.Value))).ToList();
            //    //StoreList = StoreList.Where(x => x.Text == Storenamelist1.ToString()).ToList();
            //}

            List<ddllist> StoreList = new List<ddllist>();
            //ddllist obj = new ddllist();
            //obj.Text = "All Store";
            //obj.Value = "0";
            //StoreList.Add(obj);

            if ((!Roles.IsUserInRole("Administrator")) && (!Roles.IsUserInRole("Store Manager")))
            {
                StoreList = (from dataUser in db.tbl_user_store_By_Reg_userid(@WebSecurity.CurrentUserId)
                             select new ddllist
                             {
                                 Value = dataUser.Storeid.ToString(),
                                 Text = dataUser.StoreName

                             }).ToList();
            }
            else
            {
                StoreList = ((from dataUser in db.tbl_user_Selectstore()
                              select new ddllist
                              {
                                  Value = dataUser.Id.ToString(),
                                  Text = dataUser.Name

                              }).ToList());
            }
            return StoreList;
        }

        public List<ddllist> FillCategoryList()
        {
            List<ddllist> CategoryList = (from dataUser in db.tbl_DocumentCategory_GetAll()
                                          select new ddllist
                                          {
                                              Value = dataUser.Id.ToString(),
                                              Text = dataUser.Name
                                          }).ToList();

            return CategoryList;
        }

    }
}