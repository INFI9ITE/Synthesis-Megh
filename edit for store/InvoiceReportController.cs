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
using wwwrootBL.Entity;
using WebMatrix.WebData;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace wwwroot.Areas.Admin.Controllers
{
    [InitializeSimpleMembershipAttribute]
    [Authorize(Roles = "Back Office Manager,Data Approver,Store Manager,Administrator")]
    public class InvoiceReportController : Controller
    {
        // GET: Admin/InvoiceReport
        protected static string StatusMessage = "";
        protected static string ActivityLogMessage = "";
        protected static string DeleteMessage = "";
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

        public ActionResult Grid(int IsBindData = 1, int currentPageIndex = 1, string orderby = "id", int IsAsc = 0, int PageSize = 10, int SearchRecords = 1, string Alpha = "", int deptname = 0, string startdate = "", string enddate = "", string payment = "", string Store_val = "", int Status = 0)
        {




            //if (sid == null)
            //{
            //    string names = Store_val;

            //    int ids = db.tbl_Store.Where(x => x.Name == names).Select(x => x.Id).FirstOrDefault();
            //    GlobalStore.GlobalStore_id = Store_val;
            //}

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
                        //if (a1.Split(':')[0].ToString() == "SearchTitle")
                        //{
                        //    SearchTitle = Convert.ToString(a1.Split(':')[1].ToString());
                        //}
                        if (a1.Split(':')[0].ToString() == "deptname")
                        {
                            deptname = Convert.ToInt32(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "startdate")
                        {
                            startdate = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "enddate")
                        {
                            enddate = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "payment")
                        {
                            payment = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "Store_val")
                        {
                            Store_val = Convert.ToString(a1.Split(':')[1].ToString());
                        }
                        if (a1.Split(':')[0].ToString() == "Status")
                        {
                            Status = Convert.ToInt32(a1.Split(':')[1].ToString());
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
              //  ,"SearchTitle:" + SearchTitle
               ,"deptname:" + deptname
               ,"startdate:"+startdate
                ,"enddate:"+enddate
                ,"payment:"+payment
                ,"Store_val:"+Store_val
                ,"Status:"+Status
            };
            #endregion

            #region MyRegion_BindData
            int startIndex = ((currentPageIndex - 1) * PageSize) + 1;
            int endIndex = startIndex + PageSize - 1;

            if (IsBindData == 1 || IsEdit == true)
            {
                BindData = GetData(SearchRecords, deptname, startdate, enddate, payment, Store_val, Status).OfType<Invoice_Select>().ToList();
                TotalDataCount = BindData.OfType<Invoice_Select>().ToList().Count();

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
            //ViewBag.SearchTitle = SearchTitle;
            ViewBag.StatusMessage = StatusMessage;
            ViewBag.startindex = startIndex;
            ViewBag.deptname = deptname;
            ViewBag.startdate = startdate;
            ViewBag.enddate = enddate;
            ViewBag.payment = payment;
            ViewBag.Store_val = Store_val;
            ViewBag.Status = Status;

            if (TotalDataCount < endIndex)
            {
                ViewBag.endIndex = TotalDataCount;
            }
            else
            {
                ViewBag.endIndex = endIndex;
            }
            ViewBag.TotalDataCount = TotalDataCount;
            var ColumnName = typeof(Invoice_Select).GetProperties().Where(p => p.Name == orderby).FirstOrDefault();

            IEnumerable Data = null;
            //Response.Write(ColumnName);
            //Response.End();
            if (IsAsc == 1)
            {
                ViewBag.AscVal = 0;
                Data = BindData.OfType<Invoice_Select>().ToList().OrderBy(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            else
            {

                ViewBag.AscVal = 1;

                Data = BindData.OfType<Invoice_Select>().ToList().OrderByDescending(n => ColumnName.GetValue(n, null)).Skip(startIndex - 1).Take(PageSize);
            }
            Data = BindData.OfType<Invoice_Select>().ToList().Skip(startIndex - 1).Take(PageSize);
            if (deptname == 0)
            {
                ViewBag.TotalInvoiceType = BindData.OfType<Invoice_Select>().ToList().Skip(startIndex - 1).Take(PageSize).Where(x => x.Type_id == 1).Select(x => x.TotalAmtByDept).Sum();
                ViewBag.TotalCreditMemo = BindData.OfType<Invoice_Select>().ToList().Skip(startIndex - 1).Take(PageSize).Where(x => x.Type_id == 2).Select(x => x.TotalAmtByDept).Sum();
                //ViewBag.total_amtgrid = BindData.OfType<Invoice_Select>().ToList().Skip(startIndex - 1).Take(PageSize).Where(x => x.Type_id == 1).Select(x => x.TotalAmtByDept).Sum();
            }
            else
            {
                ViewBag.TotalInvoiceType = BindData.OfType<Invoice_Select>().ToList().Skip(startIndex - 1).Take(PageSize).Where(x => x.Type_id == 1).Select(x => x.Amt).Sum();
                ViewBag.TotalCreditMemo = BindData.OfType<Invoice_Select>().ToList().Skip(startIndex - 1).Take(PageSize).Where(x => x.Type_id == 2).Select(x => x.Amt).Sum();
                //ViewBag.total_amtgrid = BindData.OfType<Invoice_Select>().ToList().Skip(startIndex - 1).Take(PageSize).Where(x => x.Type_id == 1).Select(x => x.Amt).Sum();

            }

            StatusMessage = "";


            //// ViewBag.Pagetext = "Showing " + iStartsRecods + " to " + iEndRecord + " of " + iTotalRecords + " entries";
            //List<ddllist> LstDatadept = new List<ddllist>();
            //LstDatadept = FillDrpLstDepartment();
            //ViewBag.DataDept = LstDatadept;

            List<ddllist> Lstdept = new List<ddllist>();
            Lstdept = FillDrpLstDepartment();
            ViewBag.Datadept = Lstdept;

            List<ddllist> Lststatus = new List<ddllist>();
            Lststatus = FillDrpLstStatus();
            ViewBag.Datastatus = Lststatus;

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

        private IEnumerable GetData(int SearchRecords = 0, int deptname = 0, string startdate = "", string enddate = "", string payment = "", string Store_val = "", int Status = 0)
        {
            string userid = WebSecurity.CurrentUserId.ToString();
            DateTime? start_date = null;
            DateTime? end_date = null;
            try
            {
                start_date = Convert.ToDateTime(startdate);
            }
            catch { }

            try
            {
                end_date = Convert.ToDateTime(enddate);
            }
            catch { }
            IEnumerable RtnData = null;
            //int storeid;

            //if (Store_val == "")
            //{


            //    var Store = db.tbl_user_store_By_Reg_userid(@WebSecurity.CurrentUserId).Select(x => x.StoreName).FirstOrDefault();
            //    storeid = db.tbl_Store.Where(x => x.Name == Store).Select(x => x.Id).FirstOrDefault();


            //}
            //else
            //{
            //    storeid = db.tbl_Store.Where(x => x.Name == Store_val).Select(x => x.Id).FirstOrDefault();
            //}

            //string useridbyroles="";
            //if (Roles.IsUserInRole("Back Office Manager"))
            //{
            //    useridbyroles = userid;
            //}
            //else if (Roles.IsUserInRole("Data Approver"))
            //{
            //    useridbyroles = db.tbl_user_store.Where(x => x.Storeid == storeid).Where(x => x.RoleId == 2).Select(x => x.Reg_userid).FirstOrDefault().ToString();
            //}
            //else if (Roles.IsUserInRole("Store Manager"))
            //{
            //    useridbyroles = db.tbl_user_store.Where(x => x.Storeid == storeid).Where(x => x.RoleId == 3).Select(x => x.Reg_userid).FirstOrDefault().ToString();
            //}


            string storeid = GlobalStore.GlobalStore_id;
            RtnData = (from data in db.tbl_Invoice_GridData(start_date, end_date, payment, deptname, Convert.ToInt32(storeid), Status)

                       select new Invoice_Select
                       {
                           id = data.id,
                           Storename = data.Storename,
                           Payment_type = data.Payment_type,
                           Type = data.Typename,
                           Vendorname = data.vendorname,
                           Invoice_Date = data.Invoice_Date.GetValueOrDefault(),
                           CreatedOn = data.CreatedOn.GetValueOrDefault(),
                           Invoice_Number = data.Invoice_Number,
                           Note = data.Note,
                           Type_id = data.Type_id.GetValueOrDefault(),
                           TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
                           Amt = data.deptamt,
                           deptid = deptname,
                           Status = data.Statusname,
                           IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
                           Store_id=data.Store_id.GetValueOrDefault(),
                       }).ToList<Invoice_Select>();

            return RtnData;

        }

//        #region Fill DropdownList Vendor
//        public List<ddllist> FillDrpLstVendor()
//        {
//            List<ddllist> LstVendor = new List<ddllist>();
//            LstVendor = (from a in db.tbl_Vendor
//                         orderby a.Name ascending
//                         select new ddllist
//                         {
//                             Value = a.id.ToString(),
//                             Text = a.Name
//                         }).ToList();

//            return LstVendor;
//        }
//#endregion

        #region Fill DropdownList Department
        public List<ddllist> FillDrpLstDepartment()
        {
            List<ddllist> LstDepartment = new List<ddllist>();
            LstDepartment = (from a in db.tbl_Department
                             where a.StoreID.ToString() == GlobalStore.GlobalStore_id
                             orderby a.Name ascending
                             select new ddllist
                             {
                                 Value = a.id.ToString(),
                                 Text = a.Name
                             }).ToList();

            return LstDepartment;
        }
        #endregion

        #region Fill DropdownList status
        public List<ddllist> FillDrpLstStatus()
        {
            List<ddllist> LstStatus = new List<ddllist>();
            LstStatus = (from a in db.tbl_Status
                         orderby a.Name ascending
                         select new ddllist
                         {
                             Value = a.id.ToString(),
                             Text = a.Name
                         }).ToList();

            return LstStatus;
        }
        #endregion

        #region Fill DropdownList pamenttype
        public List<ddllist> FillDrpLstPamentype()
        {
            List<ddllist> LstPamentype = new List<ddllist>();
            LstPamentype = (from a in db.tbl_Pamentype
                            orderby a.Name ascending
                            select new ddllist
                            {
                                Value = a.Name.ToString(),
                                Text = a.Name
                            }).ToList();

            return LstPamentype;
        }
        #endregion

        #region Fill DropdownList Store
        public List<ddllist> FillDrpLstStore()
        {
            List<ddllist> AdminStorenamelist = new List<ddllist>();
            AdminStorenamelist = (from dataUser in db.tbl_user_Selectstore()

                                            select new ddllist
                                            {
                                                Value = dataUser.Id.ToString(),
                                                Text = dataUser.Name
                                            }).ToList();
            

            return AdminStorenamelist;
        }
        #endregion


        #region Fill DropdownList Type
        public List<ddllist> FillDrpLstType()
        {
            List<ddllist> LstType = new List<ddllist>();
            LstType = (from a in db.tbl_Type
                       orderby a.Name ascending
                       select new ddllist
                       {
                           Value = a.id.ToString(),
                           Text = a.Name
                       }).ToList();

            return LstType;
        }
        #endregion

        //#region Fill DropdownList Vendor
        //public List<ddllist> FillDrpLstVendor()
        //{
        //    List<ddllist> LstVendor = new List<ddllist>();
        //    if (Roles.IsUserInRole("Administrator"))
        //    {

        //        LstVendor = (from a in db.tbl_Vendor
        //                     orderby a.Name ascending
        //                     select new ddllist
        //                     {
        //                         Value = a.id.ToString(),
        //                         Text = a.Name
        //                     }).ToList();
        //    }
        //    else
        //    {
        //        LstVendor = (from a in db.tbl_Vendor
        //                     where a.StoreId.ToString() == GlobalStore.GlobalStore_id
        //                     orderby a.Name ascending
        //                     select new ddllist
        //                     {
        //                         Value = a.id.ToString(),
        //                         Text = a.Name
        //                     }).ToList();
        //    }

        //    return LstVendor;
        //}
        //#endregion

        #region bind vendor address
        public string BindVendoraddress(int vid = 0)
        {
            string data = "";

            int vid1 = 0;
            if (vid > 0)
            {
                vid1 = Convert.ToInt32(vid);
                var dataval = db.tbl_Vendor.Where(x => x.id == vid1).Select(x => x.Address).FirstOrDefault();
                data = dataval;
            }
            return data;
        }
        #endregion

        //vendor drp
        public JsonResult BindVendorlist(int Store_idval = 0)
        {
          
            var LstVendor = (from a in db.tbl_Vendor
                             where a.StoreId.ToString() == Store_idval.ToString()
                             orderby a.Name ascending
                             select new ddllist
                             {
                                 Value = a.id.ToString(),
                                 Text = a.Name
                             }).ToList();
            return Json(new SelectList(LstVendor, "Value", "Text"), JsonRequestBehavior.AllowGet);
        }
        //end
        public JsonResult BindDepartmentlist(int Store_idval = 0)
        {
           
            var LstDepartment = (from a in db.tbl_Department
                                 where a.StoreID.ToString() == Store_idval.ToString()
                                 orderby a.Name ascending
                                 select new ddllist
                                 {
                                     Value = a.id.ToString(),
                                     Text = a.Name
                                 }).ToList();
            return Json(new SelectList(LstDepartment, "Value", "Text"), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int Id = 0, string storenameval = "")
        {
            
            ViewBag.Detailstorenamevalue = storenameval;
            IsArray = true;
            tbl_Invoice Data = db.tbl_Invoice.Find(Id);
            ViewBag.IDOnDetailPage = Id;
            GlobalStore.GlobalStore_id = Data.Store_id.ToString();
            Invoice_Edit Invoice_Edit = new Invoice_Edit
            {
              
            BindPaymentTypeList = FillDrpLstPamentype(),
                BindTypeList = FillDrpLstType(),
                //BindVendorList = FillDrpLstVendor(),
                BindVendorList = (from a in db.tbl_Vendor
                             where a.StoreId.ToString() == Data.Store_id.ToString()
                                  orderby a.Name ascending
                             select new ddllist
                             {
                                 Value = a.id.ToString(),
                                 Text = a.Name
                             }).ToList(),
                //BindDepartmentList = FillDrpLstDepartment(),
                BindDepartmentList = (from a in db.tbl_Department
                                 where a.StoreID.ToString() == Data.Store_id.ToString()
                                      orderby a.Name ascending
                                 select new ddllist
                                 {
                                     Value = a.id.ToString(),
                                     Text = a.Name
                                 }).ToList(),
            BindStoreList = FillDrpLstStore(),
                Dept_id = Convert.ToInt32(db.tbl_Invoice_Department.Where(x => x.Invoice_id == Data.id).Select(x => x.Dept_id).FirstOrDefault()),
                Amt = Convert.ToInt32(db.tbl_Invoice_Department.Where(x => x.Invoice_id == Data.id).Select(x => x.Amount).FirstOrDefault()),
                id = Data.id,
                Payment_type = Data.Payment_type,
                Type_id = Data.Type_id.GetValueOrDefault(),
                //Type = db.tbl_Type.Where(x => x.id == Data.Type_id).Select(x => x.Name).FirstOrDefault();
                Vendorname = db.tbl_Vendor.Where(x => x.id == Data.Vendor_id).Select(x => x.Name).FirstOrDefault(),
                Vendor_id = Data.Vendor_id.GetValueOrDefault(),
                Address = db.tbl_Vendor.Where(x => x.id == Data.Vendor_id).Select(x => x.Address).FirstOrDefault(),
                PhoneNumber = db.tbl_Vendor.Where(x => x.id == Data.Vendor_id).Select(x => x.PhoneNumber).FirstOrDefault(),
                Invoice_Number = Data.Invoice_Number,
                Invoice_Date = Data.Invoice_Date,
                //Convert.ToDateTime(@wwwroot.Class.AdminSiteConfiguration.GetDate(Data.Invoice_Date.ToString())),
                TotalAmtByDept = Data.TotalAmtByDept.GetValueOrDefault(),
                Note = Data.Note,
                CreatedBy = Data.CreatedBy,
                CreatedOn = Data.CreatedOn.GetValueOrDefault(),
                ModifiedOn = Data.ModifiedOn.GetValueOrDefault(),
                ModifiedBy = Data.ModifiedBy,
                ScanInvoice = Data.ScanInvoice,
                vendoraddress = db.tbl_Vendor.Where(x => x.id == Data.Vendor_id).Select(x => x.Address).FirstOrDefault(),
                IsStatus_id = Data.IsStatus_id.GetValueOrDefault(),
                ApproveRejectBy = Data.ApproveRejectBy,
                ApproveRejectDate = Data.ApproveRejectDate.GetValueOrDefault(),
                storeid= Data.Store_id.GetValueOrDefault(),

        };
            Invoice_Edit.drplst = (from a in db.tbl_Invoice_Department where a.Invoice_id == Data.id select new tbl_Drp { id = a.id, Deptid = a.Dept_id, Amt = a.Amount }).ToList<tbl_Drp>();

            foreach (var panelmodel in Invoice_Edit.drplst)
            {
                //var panelmodellist = (from a in db.tbl_CECApprovedPV where a.CEC_ID == panelmodel.PanelSelectId select a.LicenceOrCertiHolder).FirstOrDefault();

                panelmodel.drpname = (from s in db.tbl_Department
                                      where s.id == panelmodel.Deptid
                                      select new ddllist
                                      {
                                          Value = s.id.ToString(),
                                          Text = s.Name
                                      }).ToList();
            }
            return View(Invoice_Edit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Invoice_Edit PostedData, int ID = 0, HttpPostedFileBase ScanInvoice = null, string[] Deptid = null, string[] Amt = null)
        {
            IsEdit = true;
            Invoice_Edit custdata = new Invoice_Edit();
            if (ModelState.IsValid)
            {

                tbl_Invoice Invoice_data = db.tbl_Invoice.Find(ID);
                var exists = db.tbl_Invoice_exists_InNo_Edit(ID, PostedData.Invoice_Number, PostedData.TotalAmtByDept, Convert.ToDateTime(PostedData.Invoice_Date)).Select(x => x.Value).FirstOrDefault();
                if (Convert.ToInt32(exists) == 0)
                {
                    #region AttachNote

                    var Sacn_Title = "";
                    if (ScanInvoice != null)
                    {
                        if (ScanInvoice.ContentLength > 0)
                        {
                            var allowedExtensions = new[] { ".pdf" };
                            var extension = Path.GetExtension(ScanInvoice.FileName);

                            if (!allowedExtensions.Contains(extension))
                            {
                                ViewBag.StatusMessage = "InvalidImage";
                                return View("Index");
                            }
                            else
                            {
                                Sacn_Title = AdminSiteConfiguration.GetRandomNo() + Path.GetFileName(ScanInvoice.FileName);
                                Sacn_Title = AdminSiteConfiguration.RemoveSpecialCharacter(Sacn_Title);

                                var path1 = Request.PhysicalApplicationPath + "userfiles\\scanimage" + "\\" + Sacn_Title;
                                ScanInvoice.SaveAs(path1);
                                Invoice_data.UploadInvoice = Sacn_Title;
                                Invoice_data.ScanInvoice = Sacn_Title;
                            }
                        }

                    }
                    #endregion
                    int uid = WebSecurity.CurrentUserId;

                    string fullname = db.tbl_user.Where(x => x.Reg_userid == userid).Select(x => x.Name).FirstOrDefault();

                    Invoice_data.Store_id = Convert.ToInt32(GlobalStore.GlobalStore_id);
                    Invoice_data.Type_id = PostedData.Type_id;
                    Invoice_data.Payment_type = PostedData.Payment_type;
                    Invoice_data.Vendor_id = PostedData.Vendor_id;
                    Invoice_data.Invoice_Date = PostedData.Invoice_Date;
                    Invoice_data.Invoice_Number = PostedData.Invoice_Number;
                    Invoice_data.Note = PostedData.Note;
                    Invoice_data.IsStatus_id = PostedData.IsStatus_id;
                    Invoice_data.ModifiedBy = fullname;
                    Invoice_data.ModifiedOn = DateTime.Now;
                    Invoice_data.TotalAmtByDept = PostedData.TotalAmtByDept;
                    Invoice_data.UploadInvoice = Sacn_Title;
                    Invoice_data.ScanInvoice = Sacn_Title;
                    db.Entry(Invoice_data).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    int j = 0;
                    int dept1 = 0;
                    string amt1 = "";

                    List<int> drplst = (from a in db.tbl_Invoice_Department where a.Invoice_id == ID select a.id).ToList();

                    for (int i = 0; i < drplst.Count; i++)
                    {
                        tbl_Invoice_Department deptdata = db.tbl_Invoice_Department.Find(drplst[i]);
                        db.tbl_Invoice_Department.Remove(deptdata);
                        db.SaveChanges();
                    }



                    if (Deptid != null)
                    {
                        foreach (var val_id in Deptid)
                        {
                            tbl_Invoice_Department dataDept = new tbl_Invoice_Department();
                            try
                            {
                                if (val_id != "")
                                { 
                                dept1 = Convert.ToInt32(val_id);
                                amt1 = Amt[j];
                                var successDept = db.tbl_Invoice_Department_Insert(Convert.ToInt32(ID), dept1, Convert.ToDecimal(amt1), username);
                                
                                }
                                j++;
                            }
                            catch { }
                           
                        }
                    }

                    //activity Log


                    ActivityLogMessage = "Invoice Note with this Invoice Number " + "<a href='/Admin/InvoiceReport/Detail/" + Invoice_data.id + "'>" + Invoice_data.Invoice_Number + "</a> Edited by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.ToString());

                    var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, username, 2);
                }


                return RedirectToAction("Index");

            }
            else
            {
                StatusMessage = "Error";
            }

            ViewBag.StatusMessage = StatusMessage;
            return View(PostedData);
        }


        public ActionResult Detail(int Id = 0, string storenameval = "")
        {

            ViewBag.Detailstorenamevalue = storenameval;
            IsArray = true;
            tbl_Invoice Data = db.tbl_Invoice.Find(Id);
            ViewBag.IDOnDetailPage = Id;

            #region notification background color set to grey
            if (storenameval != "")
            {
                Data.NotificationColor = true;
                db.Entry(Data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            #endregion

            Invoice_Select Invoice_select = new Invoice_Select();
            Invoice_select.id = Data.id;
            Invoice_select.Payment_type = Data.Payment_type;
            Invoice_select.Type_id = Data.Type_id.GetValueOrDefault();
            Invoice_select.Type = db.tbl_Type.Where(x => x.id == Data.Type_id).Select(x => x.Name).FirstOrDefault();
            Invoice_select.Vendorname = db.tbl_Vendor.Where(x => x.id == Data.Vendor_id).Select(x => x.Name).FirstOrDefault();
            Invoice_select.Vendor_id = Data.Vendor_id.GetValueOrDefault();
            Invoice_select.Invoice_Number = Data.Invoice_Number;
            Invoice_select.Invoice_Date = Data.Invoice_Date.GetValueOrDefault();
            Invoice_select.TotalAmtByDept = Data.TotalAmtByDept.GetValueOrDefault();
            Invoice_select.Note = Data.Note;
            Invoice_select.CreatedBy = Data.CreatedBy;
            Invoice_select.CreatedOn = Data.CreatedOn.GetValueOrDefault();
            Invoice_select.ModifiedOn = Data.ModifiedOn.GetValueOrDefault();
            Invoice_select.ModifiedBy = Data.ModifiedBy;
            Invoice_select.ScanInvoice = Data.ScanInvoice;
            Invoice_select.address = db.tbl_Vendor.Where(x => x.id == Data.Vendor_id).Select(x => x.Address).FirstOrDefault();
            Invoice_select.IsStatus_id = Data.IsStatus_id.GetValueOrDefault();
            Invoice_select.ApproveRejectBy = Data.ApproveRejectBy;
            Invoice_select.ApproveRejectDate = Data.ApproveRejectDate.GetValueOrDefault();

            return View(Invoice_select);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Detail(Invoice_Select PostedData, int ID = 0)
        {
            IsEdit = true;
            Invoice_Select custdata = new Invoice_Select();
            if (ModelState.IsValid)
            {
                tbl_Invoice Invoice_data = db.tbl_Invoice.Find(ID);
                string fullname = db.tbl_user.Where(x => x.Reg_userid == userid).Select(x => x.Name).FirstOrDefault();
                Invoice_data.Note = PostedData.Note;
                Invoice_data.ModifiedBy = fullname;
                Invoice_data.ModifiedOn = DateTime.Now;
                db.Entry(Invoice_data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                //activity Log



                ActivityLogMessage = "Invoice Note with this Invoice Number " + "<a href='/Admin/InvoiceReport/Detail/" + Invoice_data.id + "'>" + Invoice_data.Invoice_Number + "</a> Edited by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.ToString());

                var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, username, 2);
                return RedirectToAction("Index");

            }
            else
            {
                StatusMessage = "Error";
            }

            ViewBag.StatusMessage = StatusMessage;
            return View(PostedData);
        }
        [HttpGet]
        public ActionResult InvoiceApprove(int Id = 0)
        {
            tbl_Invoice Invoice_data = db.tbl_Invoice.Find(Id);
            string fullname = db.tbl_user.Where(x => x.Reg_userid == userid).Select(x => x.Name).FirstOrDefault();

            Invoice_data.IsStatus_id = 2;
            Invoice_data.ApproveRejectBy = fullname;
            Invoice_data.ApproveRejectDate = DateTime.Now;
            db.Entry(Invoice_data).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            //activity Log



            ActivityLogMessage = "Invoice Number " + "<a href='/Admin/InvoiceReport/Detail/" + Invoice_data.id + "'>" + Invoice_data.Invoice_Number + "</a> Approved by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.ToString());

            var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, username, 4);

            return null;
        }
        [HttpGet]
        public ActionResult InvoiceReject(int Id = 0)
        {
            tbl_Invoice Invoice_data = db.tbl_Invoice.Find(Id);
            string fullname = db.tbl_user.Where(x => x.Reg_userid == userid).Select(x => x.Name).FirstOrDefault();
            Invoice_data.IsStatus_id = 3;
            Invoice_data.ApproveRejectBy = fullname;
            Invoice_data.ApproveRejectDate = DateTime.Now;
            db.Entry(Invoice_data).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            //activity Log



            ActivityLogMessage = "Invoice Number " + "<a href='/Admin/InvoiceReport/Detail/" + Invoice_data.id + "'>" + Invoice_data.Invoice_Number + "</a> Rejected by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.ToString());

            var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, username, 5);

            return null;
        }
        [HttpGet]
        public ActionResult InvoiceOnHold(int Id = 0)
        {
            tbl_Invoice Invoice_data = db.tbl_Invoice.Find(Id);
            string fullname = db.tbl_user.Where(x => x.Reg_userid == userid).Select(x => x.Name).FirstOrDefault();

            Invoice_data.IsStatus_id = 4;
            //Invoice_data.ApproveRejectBy = fullname;
            //Invoice_data.ApproveRejectDate = DateTime.Now;
            db.Entry(Invoice_data).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            //activity Log



            ActivityLogMessage = "Invoice Number " + "<a href='/Admin/InvoiceReport/Detail/" + Invoice_data.id + "'>" + Invoice_data.Invoice_Number + "</a> On Hold by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.ToString());

            var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, username, 6);

            return null;
        }

        public ActionResult Storename(string Store_val = "")
        {
            ViewBag.storename = Store_val;
            return null;
        }

        public ActionResult Delete(int Id = 0)
        {
            StatusMessage = "Error";

            tbl_Invoice Data = db.tbl_Invoice.Find(Id);
            Data.IsActive = false;
            db.Entry(Data).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();


            int uid = WebSecurity.CurrentUserId;
            string fullname = db.tbl_user.Where(x => x.userid == uid).Select(x => x.Name).FirstOrDefault();
            ActivityLogMessage = "Invoice Number " + Data.Invoice_Number + " deleted by " + fullname + " on " + wwwroot.Class.AdminSiteConfiguration.GetDate(DateTime.Now.ToString());
            var successActivity = db.tbl_Activity_log_Insert(userid, ActivityLogMessage, username, 3);
            StatusMessage = "Delete";
            DeleteMessage = Data.Invoice_Number + " deleted successfully.";
            ViewBag.Delete = DeleteMessage;
            return null;
        }


        public ActionResult ExportExcelData(string startdate = "", string enddate = "", string payment = "", int deptname = 0, int Status = 0)
        {
            DateTime? start_date = null;
            DateTime? end_date = null;
            try
            {
                start_date = Convert.ToDateTime(startdate);
            }
            catch { }

            try
            {
                end_date = Convert.ToDateTime(enddate);
            }
            catch { }

            string storeid = GlobalStore.GlobalStore_id;
            DataTable dt1 = new DataTable();
            var data1 = (from data in db.tbl_Invoice_GridData_ForExcel(start_date, end_date, payment, deptname, Convert.ToInt32(storeid), Status)select data).ToList();

            List<Invoice_Select> LstInvoice_Select = new List<Models.Invoice_Select>();
           


            for (int i = 0; i < data1.Count; i++)
            {
                Invoice_Select obj = new Invoice_Select();
                obj.Vendorname = data1[i].vendorname;
                obj.Type = data1[i].Typename;
                obj.Invoice_Number = data1[i].Invoice_Number;
                obj.Createdon_Date_string = data1[i].CreatedOn_str;
                obj.Invoice_Date_string = data1[i].Invoice_Date_str;

                if (deptname == 0)
                {
                    obj.TotalAmtByDept = data1[i].TotalAmtByDept.GetValueOrDefault();
                }
                else
                {
                    obj.TotalAmtByDept = data1[i].deptamt.GetValueOrDefault();
                }
                obj.Status = data1[i].Statusname;
                obj.Payment_type = data1[i].Payment_type;
                LstInvoice_Select.Add(obj);
            }

            //select new Invoice_Select
            //{
            //    id = data.id,
            //    Storename = data.Storename,
            //    Payment_type = data.Payment_type,
            //    Type = data.Typename,
            //    Vendorname = data.vendorname,
            //    Createdon_Date_string = data.CreatedOn_str.ToString(),
            //    Invoice_Date_string = data.Invoice_Date_str.ToString(),
            //    //Invoice_Date_string = AdminSiteConfiguration.GetDateformat(Convert.ToString(data.Invoice_Date)),
            //    Invoice_Number = data.Invoice_Number,
            //    Note = data.Note,
            //    Type_id = data.Type_id.GetValueOrDefault(),
            //    TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
            //    Status = data.Statusname,
            //    IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
            //}).ToList<Invoice_Select>();


            dt1 = LINQToDataTable(LstInvoice_Select);
            Export oExport = new Export();
            string FileName = "Report" + ".xls";

            //int[] ColList = { 22, 20, 6, 31, 27, 12, 3 };
            int[] ColList = { 22, 20, 6, 31, 32, 27, 12, 3 };
            string[] arrHeader = {
                 "Vendor",
                 "Type",
             "Invoice#",
             "CreatedOn",
             "Invoice Date",
             "Amount",
             "Status",
             "Payment Method",
                         };

            //only change file extension to .xls for excel file

            oExport.ExportDetails(dt1, ColList, arrHeader, Export.ExportFormat.Excel, FileName);

            return RedirectToAction("Index", "InvoiceReport");

        }

        public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others 

                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public ActionResult ExportPDFData(string startdate = "", string enddate = "", string payment = "", int deptname = 0, int Status = 0)
        {
            DateTime? start_date = null;
            DateTime? end_date = null;
            try
            {
                start_date = Convert.ToDateTime(startdate);
            }
            catch { }

            try
            {
                end_date = Convert.ToDateTime(enddate);
            }
            catch { }

            string storeid = GlobalStore.GlobalStore_id;
            DataTable dt1 = new DataTable();

            var data1 = (from data in db.tbl_Invoice_GridData_ForPdf(start_date, end_date, payment, deptname, Convert.ToInt32(storeid), Status)select data).ToList();


            //select new Invoice_Select_ForPdf
            //{
            //    //id = data.id,
            //    //Storename = data.Storename,
            //    //

            //    Vendorname = data.vendorname,
            //    Type = data.Typename,
            //    Invoice_Number = data.Invoice_Number,
            //    CreatedOn = data.CreatedOn,
            //    Invoice_Date = data.Invoice_Date,

            //    //Note = data.Note,
            //    //Type_id = data.Type_id.GetValueOrDefault(),
            //    TotalAmtByDept = data.TotalAmtByDept.GetValueOrDefault(),
            //    Status = data.Statusname,
            //    Payment_type = data.Payment_type,
            //    //IsStatus_id = data.IsStatus_id.GetValueOrDefault(),
            //}).ToList<Invoice_Select_ForPdf>();

            List<Invoice_Select_ForPdf> lstInvoice_Select_ForPdf = new List<Models.Invoice_Select_ForPdf>();

            for (int i = 0; i < data1.Count; i++)
            {
               
                Invoice_Select_ForPdf obj = new Invoice_Select_ForPdf();
                obj.Vendorname = data1[i].vendorname;
                obj.Type = data1[i].Typename;
                
                obj.Invoice_Number = data1[i].Invoice_Number;
                obj.CreatedOn = data1[i].CreatedOn;
                obj.Invoice_Date = data1[i].Invoice_Date;
                if (deptname == 0)
                {
                    obj.TotalAmtByDept = data1[i].TotalAmtByDept.GetValueOrDefault();
                }
                else
                {
                    obj.TotalAmtByDept = data1[i].deptamt.GetValueOrDefault();
                }
                obj.Status = data1[i].Statusname;
                obj.Payment_type = data1[i].Payment_type;   
                lstInvoice_Select_ForPdf.Add(obj);
                
            }
            dt1 = LINQToDataTable(lstInvoice_Select_ForPdf);


            GeneratePDF(dt1, "Report");

            return RedirectToAction("Index", "InvoiceReport");

        }

        private void GeneratePDF(DataTable dataTable, string Name)
        {
            FontFactory.RegisterDirectories();
            iTextSharp.text.Font myfont = FontFactory.GetFont("Tahoma", BaseFont.IDENTITY_H, 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            Document pdfDoc = new Document(PageSize.A4, 5f, 5f, 50f, 0f);
            System.IO.MemoryStream mStream = new System.IO.MemoryStream();
            PdfWriter wri = PdfWriter.GetInstance(pdfDoc, mStream);

            pdfDoc.Open();
            

          
         

            PdfPTable _mytable = new PdfPTable(dataTable.Columns.Count);
            _mytable.WidthPercentage = 100;
            _mytable.SetWidths(new float[] { 8.5f, 6f, 6f, 5.5f, 5.5f, 5f, 4f, 7.5f });

            PdfPTable tbl = new PdfPTable(dataTable.Columns.Count);
            tbl.WidthPercentage = 100;
            tbl.SetWidths(new float[] { 8.5f, 6f, 6f, 5.5f, 5.5f, 5f, 4f, 7.5f });
           
            Phrase phrase1 = new Phrase();
            phrase1.Add(new Chunk("Invoice Report", FontFactory.GetFont("Tahoma", 20, Font.BOLD, iTextSharp.text.BaseColor.RED)));
            PdfPCell cell1 = new PdfPCell(phrase1);
            cell1.HorizontalAlignment = Element.ALIGN_CENTER;

            tbl.SpacingAfter = 20f;
            cell1.Colspan = 8;
            cell1.Border= 0;
            tbl.AddCell(cell1);

            DataTable dt = new DataTable();

            dt.Columns.Add("VendorName", typeof(string));
            dt.Columns.Add("InvoiceType", typeof(string));
            dt.Columns.Add("InvoiceNo", typeof(string));
            dt.Columns.Add("CreatedOn", typeof(string));
            dt.Columns.Add("InvoiceDate", typeof(string));
            dt.Columns.Add("Amount", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("PaymentMethod", typeof(string));
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                iTextSharp.text.Font small = FontFactory.GetFont("Tahoma", BaseFont.IDENTITY_H, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                Phrase p = new Phrase(dt.Columns[i].ColumnName, small);
                PdfPCell cell = new PdfPCell(p);
                
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                // cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 111, 111);
                cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                _mytable.AddCell(cell);
            }
            //creating table data (actual result)   

            for (int k = 0; k < dataTable.Rows.Count; k++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    Phrase p = new Phrase(dataTable.Rows[k][j].ToString(), myfont);
                    PdfPCell cell = new PdfPCell(p);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    _mytable.AddCell(cell);
                }
            }

            pdfDoc.Add(tbl);
            pdfDoc.Add(_mytable);
            pdfDoc.Close();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=InvoiceReport.pdf");
            Response.Clear();
            Response.BinaryWrite(mStream.ToArray());
            Response.End();

            #region not in use
            //for (int j = 0; j < dataTable.Columns.Count; ++j)
            //{
            //    Phrase p = new Phrase(dataTable.Columns[j].ColumnName, myfont);
            //    PdfPCell cell = new PdfPCell(p);
            //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //   // cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 111, 111);
            //    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            //    _mytable.AddCell(cell);
            //}
            ////-------------------------
            //for (int i = 0; i < dataTable.Rows.Count - 1; ++i)
            //{
            //    for (int j = 0; j < dataTable.Columns.Count; ++j)
            //    {

            //        Phrase p = new Phrase(dataTable.Rows[i][j].ToString(), myfont);
            //        PdfPCell cell = new PdfPCell(p);
            //        cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            //        _mytable.AddCell(cell);
            //    }
            //}
            ////------------------------           
            ////pdfDoc.Add(_mytable);
            ////pdfDoc.Close();
            ////System.Diagnostics.Process.Start(FilePath);
            #endregion
        }

        #region not in use
        private void GeneratePDF1(DataTable dataTable, string Name)
        {
            try
            {
                string[] columnNames = (from dc in dataTable.Columns.Cast<DataColumn>()
                                        select dc.ColumnName).ToArray();
                int Cell = 0;
                int count = columnNames.Length;
                object[] array = new object[count];

                dataTable.Rows.Add(array);

                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                System.IO.MemoryStream mStream = new System.IO.MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, mStream);
                int cols = dataTable.Columns.Count;
                int rows = dataTable.Rows.Count;


                //HeaderFooter header = new HeaderFooter(new Phrase(Name), false);

                //// Remove the border that is set by default  
                //header.Border = iTextSharp.text.Rectangle.TITLE;
                //// Align the text: 0 is left, 1 center and 2 right.  
                //header.Alignment = Element.ALIGN_CENTER;
                //pdfDoc.AddHeader(header);
                //// Header.  
                //pdfDoc.Open();
                PdfPTable pdfTable = new PdfPTable(7);
                //pdfTable.BorderWidth = 1; pdfTable.Width = 100;
                //pdfTable.Padding = 1; pdfTable.Spacing = 4;

                //creating table headers  
                for (int i = 0; i < cols; i++)
                {
                    PdfPCell cellCols = new PdfPCell();
                    Chunk chunkCols = new Chunk();
                    cellCols.BackgroundColor = new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#548B54"));
                    iTextSharp.text.Font ColFont = FontFactory.GetFont(FontFactory.HELVETICA, 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE);

                    chunkCols = new Chunk(dataTable.Columns[i].ColumnName, ColFont);

                    cellCols.AddElement(chunkCols);
                    pdfTable.AddCell(cellCols);
                }
                //creating table data (actual result)   

                for (int k = 0; k < rows; k++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        PdfPCell cellRows = new PdfPCell();
                        if (k % 2 == 0)
                        {
                            cellRows.BackgroundColor = new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#cccccc")); ;
                        }
                        else { cellRows.BackgroundColor = new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff")); }
                        iTextSharp.text.Font RowFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                        Chunk chunkRows = new Chunk(dataTable.Rows[k][j].ToString(), RowFont);
                        cellRows.AddElement(chunkRows);

                        pdfTable.AddCell(cellRows);
                    }
                }

                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Name + "_" + DateTime.Now.ToString() + ".pdf");
                Response.Clear();
                Response.BinaryWrite(mStream.ToArray());
                Response.End();

            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}