using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using wwwrootBL.Entity;
using WebMatrix.WebData;
using System.Globalization;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace wwwroot.Controllers
{
    public class JobSalesAcityvitySummaryController : Controller
    {
        Excel.Application excelApplication;
        //Application excelApplication = null;
        Excel.Workbook excelWorkBook;
        //   Workbook excelWorkBook = null;
        bool isexists = false;
        WestZoneEntities db = new WestZoneEntities();
        string EXCEL_PATH = "";
        // GET: JobSalesAcityvitySummary
        public ActionResult Index()
        {
            ReadExcelFile("");
            return View();
        }
        private void ReadExcelFile(string storeidval)
        {
            bool isexists = false;
            WestZoneEntities db = new WestZoneEntities();
            tbl_Excelread_Errormsg tbl_Excelread_Errormsg = new tbl_Excelread_Errormsg();
            string EXCEL_PATH = "";
            string app_path = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                tbl_ExcelRead tbl_ExcelRead = new tbl_ExcelRead();
                var Exceldata = (from a in db.tbl_Storewise_Excelupload where a.issync == 0 orderby a.id ascending select a).Take(20).ToList();
                string EXCEL_PATH1 = app_path + "Userfiles\\Pending\\";
                foreach (var Filedata in Exceldata)
                {
                    try
                    {
                        //FileInfo info = new FileInfo(files);
                        //var fileName = Path.GetFileName(info.FullName);
                        var fileName = Filedata.filename;
                        EXCEL_PATH = app_path + "Userfiles\\Pending\\" + fileName;
                        if (System.IO.File.Exists(EXCEL_PATH))
                        {
                            int store_idval = 0;
                            store_idval = Convert.ToInt32(Filedata.Storeid);
                            if (!EXCEL_PATH.EndsWith(".xls"))
                            {

                                tbl_ExcelRead.Filename = Filedata.filename;


                                store_idval = (from a in db.tbl_Storewise_Excelupload where a.filename == fileName select a.Storeid).FirstOrDefault().GetValueOrDefault();
                                tbl_ExcelRead.Excelreadate = DateTime.Now;
                                tbl_ExcelRead.CreatedDate = DateTime.Now;
                                tbl_ExcelRead.Type = 2;
                                db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                db.SaveChanges();
                                tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                tbl_Excelread_Errormsg.ErrorMessage = "Invalid File";
                                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                db.SaveChanges();
                                int idval = Filedata.id;
                                WestZoneEntities db1 = new WestZoneEntities();
                                var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                break;
                            }

                            // System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
                            Excel.Application excelApplication = new Application();
                            //Opening/Loading the workBook in memory
                            Excel.Workbook excelWorkBook = excelApplication.Workbooks.Open(EXCEL_PATH);

                            //retrieving the worksheet counts inside the excel workbook
                            int workSheetCounts = excelWorkBook.Worksheets.Count;
                            int totalColumns = 0;
                            Range objRange = null;
                            var masterEntry = new Dictionary<string, string>();
                            var TendersDrawer = new Dictionary<string, string>();
                            var DepartmentSales = new Dictionary<string, string>();
                            var Paidoutreports = new Dictionary<string, string>();
                            string tablename = "";
                            int rowcount = 0;
                            int columncount = 0;
                            int IsMain = 0;
                            try
                            {
                                for (int sheetCounter = 1; sheetCounter <= workSheetCounts; sheetCounter++)
                                {
                                    Worksheet workSheet = excelWorkBook.Sheets[sheetCounter];
                                    totalColumns = workSheet.UsedRange.Cells.Columns.Count + 1;
                                    object[] data = null;

                                    //Iterating from row 2 because first row contains HeaderNames
                                    for (int row = 1; row < workSheet.UsedRange.Cells.Rows.Count; row++)
                                    {
                                        data = new object[totalColumns - 1];
                                        int hasdata = 0;
                                        for (int col = 1; col < totalColumns; col++)
                                        {
                                            objRange = workSheet.Cells[row, col];
                                            rowcount = row;
                                            columncount = col;
                                            if (objRange.MergeCells)
                                            {
                                                string columnValue = Convert.ToString(((Range)objRange.MergeArea[1, 1]).Text).Trim();
                                                if (columnValue == "Tenders In Drawer Report")
                                                {
                                                    tablename = "TendersDrawer";
                                                }
                                                if (columnValue == "Tenders In DrawerTotals")
                                                {
                                                    tablename = "";
                                                }
                                                if (columnValue == "Department Net Sales Report")
                                                {
                                                    tablename = "DepartmentSales";
                                                }
                                                if (columnValue == "Net Sales for Departments Listed")
                                                {
                                                    tablename = "";
                                                }
                                                if (columnValue == "Paid Out Report")
                                                {
                                                    tablename = "Paidoutreports";
                                                }
                                                if (columnValue == "Paid Out Totals")
                                                {
                                                    tablename = "";
                                                }
                                                if (!data.ToList().Contains(columnValue))
                                                {
                                                    if (columnValue.Contains("Transaction End Time") && !masterEntry.Keys.Contains("Transaction End Time"))
                                                    {
                                                        int terminalindex = columnValue.IndexOf("Terminal:");
                                                        masterEntry.Add("Transaction End Time", columnValue.Substring(0, 70).Replace("Transaction End Time:", "").Trim());
                                                        masterEntry.Add("Terminal", columnValue.Substring(70).Replace("Terminal:", "").Trim());
                                                        masterEntry.Add("ROWtransection time", rowcount.ToString());
                                                        masterEntry.Add("Columntransection time", columncount.ToString());
                                                    }
                                                    hasdata++;
                                                    data[hasdata - 1] = columnValue;
                                                }
                                            }
                                            else
                                            {
                                                string columnValue = Convert.ToString(objRange.Text).Trim();
                                                //if (Convert.ToString(objRange.Text).Trim() != "")
                                                //{
                                                //    hasdata++;
                                                //    data[hasdata - 1] = Convert.ToString(objRange.Text).Trim();
                                                //}
                                                if (columnValue == "Tenders In Drawer Report")
                                                {
                                                    tablename = "TendersDrawer";
                                                }
                                                if (columnValue == "Tenders In DrawerTotals")
                                                {
                                                    tablename = "";
                                                }
                                                if (columnValue == "Department Net Sales Report")
                                                {
                                                    tablename = "DepartmentSales";
                                                }
                                                if (columnValue == "Net Sales for Departments Listed")
                                                {
                                                    tablename = "";
                                                }
                                                if (columnValue == "Paid Out Report")
                                                {
                                                    tablename = "Paidoutreports";
                                                }
                                                if (columnValue == "Paid Out Totals")
                                                {
                                                    tablename = "";
                                                }
                                                if (!data.ToList().Contains(columnValue))
                                                {
                                                    if (columnValue.Contains("Transaction End Time") && !masterEntry.Keys.Contains("Transaction End Time"))
                                                    {
                                                        int terminalindex = columnValue.IndexOf("Terminal:");
                                                        masterEntry.Add("Transaction End Time", columnValue.Substring(0, 70).Replace("Transaction End Time:", "").Trim());
                                                        masterEntry.Add("Terminal", columnValue.Substring(70).Replace("Terminal:", "").Trim());
                                                        masterEntry.Add("ROWtransection time", rowcount.ToString());
                                                        masterEntry.Add("Columntransection time", columncount.ToString());
                                                    }
                                                    hasdata++;
                                                    data[hasdata - 1] = columnValue;
                                                }
                                            }
                                        }
                                        int elementcount = 0;

                                        foreach (object element in data)
                                        {
                                            if (element != null) // Avoid NullReferenceException
                                            {
                                                if (element.ToString().Contains("Customer Count") && !masterEntry.Keys.Contains("Customer Count"))
                                                {
                                                    if (data[elementcount + 1] != null)
                                                    {
                                                        masterEntry.Add("Customer Count", data[elementcount + 1].ToString());
                                                        masterEntry.Add("ROWCustomer Count", rowcount.ToString());
                                                        masterEntry.Add("ColCustomer Count", columncount.ToString());
                                                    }
                                                }
                                                if (element.ToString().Contains("Net Sales With Tax") && !masterEntry.Keys.Contains("Net Sales With Tax"))
                                                {
                                                    if (data[elementcount + 1] != null)
                                                    {
                                                        masterEntry.Add("Net Sales With Tax", data[elementcount + 2].ToString());
                                                        masterEntry.Add("Net Sales With Tax Row", rowcount.ToString());
                                                        masterEntry.Add("Net Sales With Tax Col", columncount.ToString());
                                                    }
                                                }
                                                if (element.ToString().Contains("Total Tax Collected") && !masterEntry.Keys.Contains("Total Tax Collected"))
                                                {
                                                    if (data[elementcount + 1] != null)
                                                    {
                                                        masterEntry.Add("Total Tax Collected", data[elementcount + 2].ToString());
                                                        masterEntry.Add("Total Tax Collected Row", rowcount.ToString());
                                                        masterEntry.Add("Total Tax Collected Col", columncount.ToString());
                                                    }
                                                }
                                                if (element.ToString().Contains("Average Sale") && !masterEntry.Keys.Contains("Average Sale"))
                                                {
                                                    if (data[elementcount + 1] != null)
                                                    {
                                                        masterEntry.Add("Average Sale", data[elementcount + 1].ToString());
                                                        masterEntry.Add("Average Sale Row", rowcount.ToString());
                                                        masterEntry.Add("Average Sale Col", columncount.ToString());
                                                    }
                                                }
                                                if (tablename == "TendersDrawer")
                                                {
                                                    if (element.ToString() != "Tenders In Drawer Report")
                                                    {
                                                        if (!TendersDrawer.Keys.Contains(element.ToString()) && element.ToString() != "" && element.ToString() != "Quantity")
                                                        {
                                                            if (data[elementcount + 1] != null)
                                                            {
                                                                TendersDrawer.Add(data[elementcount].ToString(), data[elementcount + 1].ToString());

                                                                break;
                                                            }
                                                            else
                                                            {
                                                                if (IsMain != 1)
                                                                {
                                                                    tbl_ExcelRead.Filename = fileName;
                                                                    tbl_ExcelRead.Excelreadate = DateTime.Now;
                                                                    tbl_ExcelRead.CreatedDate = DateTime.Now;
                                                                    db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                                                    db.SaveChanges();
                                                                    IsMain = 1;
                                                                }
                                                                tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                                tbl_Excelread_Errormsg.RowNo = rowcount;
                                                                tbl_Excelread_Errormsg.ColumnNo = columncount;
                                                                tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + rowcount + ", Column No: " + columncount + ", " + "'" + data[elementcount].ToString() + "'" + " is Invalid.";
                                                                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                                db.SaveChanges();
                                                                int idval = Filedata.id;
                                                                WestZoneEntities db1 = new WestZoneEntities();
                                                                var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                                            }
                                                        }

                                                    }
                                                }
                                                if (tablename == "DepartmentSales")
                                                {
                                                    if (element.ToString() != "Department Net Sales Report")
                                                    {
                                                        if (!DepartmentSales.Keys.Contains(element.ToString()) && element.ToString() != "" && element.ToString() != "Department Name" && element.ToString() != "(Net Sales include Negative Total and Discount, without Tax)")
                                                        {
                                                            if (data[elementcount + 1] != null)
                                                            {
                                                                DepartmentSales.Add(data[elementcount].ToString(), data[elementcount + 1].ToString());
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                if (data[elementcount].ToString() != "Net Sales")
                                                                {
                                                                    if (IsMain != 1)
                                                                    {
                                                                        tbl_ExcelRead.Filename = fileName;
                                                                        tbl_ExcelRead.Excelreadate = DateTime.Now;
                                                                        tbl_ExcelRead.CreatedDate = DateTime.Now;
                                                                        db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                                                        db.SaveChanges();
                                                                        IsMain = 1;
                                                                    }
                                                                    tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                                    tbl_Excelread_Errormsg.RowNo = rowcount;
                                                                    tbl_Excelread_Errormsg.ColumnNo = columncount;
                                                                    tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + rowcount + ", Column No: " + columncount + ", " + "'" + data[elementcount].ToString() + "'" + " is Invalid.";
                                                                    db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                                    db.SaveChanges();
                                                                    int idval = Filedata.id;
                                                                    WestZoneEntities db1 = new WestZoneEntities();
                                                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                if (tablename == "Paidoutreports")
                                                {
                                                    if (element.ToString() != "Paid Out Report")
                                                    {
                                                        if (!Paidoutreports.Keys.Contains(element.ToString()) && element.ToString() != "" && element.ToString() != "Quantity")
                                                        {
                                                            if (data[elementcount + 1] != null)
                                                            {
                                                                Paidoutreports.Add(data[elementcount].ToString(), data[elementcount + 1].ToString());
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                if (IsMain != 1)
                                                                {
                                                                    tbl_ExcelRead.Filename = fileName;
                                                                    tbl_ExcelRead.Excelreadate = DateTime.Now;
                                                                    tbl_ExcelRead.CreatedDate = DateTime.Now;
                                                                    db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                                                    db.SaveChanges();
                                                                    IsMain = 1;
                                                                }
                                                                tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                                tbl_Excelread_Errormsg.RowNo = rowcount;
                                                                tbl_Excelread_Errormsg.ColumnNo = columncount;
                                                                tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + rowcount + ", Column No: " + columncount + ", " + "'" + data[elementcount].ToString() + "'" + " is Invalid.";
                                                                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                                db.SaveChanges();
                                                                int idval = Filedata.id;
                                                                WestZoneEntities db1 = new WestZoneEntities();
                                                                var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                                            }
                                                        }
                                                    }
                                                }
                                                //Response.Write(element.ToString());
                                                //Response.Write("-------------------------------");
                                            }
                                            elementcount++;
                                        }
                                        //if (hasdata > 0)
                                        //{
                                        //    Response.Write("<br/>");
                                        //}

                                    }

                                    string userid = "0";

                                    int isflagtime = 0, timerowno = 0, timecolno = 0;
                                    int isflagTerminal = 0, Terminalrowno = 0, Terminalcolno = 0;
                                    int isflagColCount = 0, ColCountrowno = 0, ColCountcolno = 0;
                                    int isflagColNetSales = 0, NetSalesrowno = 0, NetSalescolno = 0;
                                    int isflagColTotTax = 0, TotTaxrowno = 0, TotTaxcolno = 0;
                                    int isflagColAvgTax = 0, AvgTaxrowno = 0, AvgTaxcolno = 0;

                                    //string TenderindrawkeyRow = "",TenderindrawkeyCol = "";
                                    string[] specialCharacters = new string[] { "$", ",", "(", ")" };
                                    tbl_SalesActivitySummary ObjSalesactivitysummary = new tbl_SalesActivitySummary();
                                    foreach (var kvp in masterEntry)
                                    {
                                        if (kvp.Key == "Transaction End Time")
                                        {
                                            try
                                            {
                                                string StartDate = kvp.Value.Substring(0, 19);
                                                string endDate = kvp.Value.Substring(kvp.Value.LastIndexOf("-") + 2, 19);

                                                DateTime Sdt = DateTime.ParseExact(StartDate, "MM/dd/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                                                DateTime Edt = DateTime.ParseExact(endDate, "MM/dd/yyyy hh:mm:ss", CultureInfo.InvariantCulture);

                                                string[] dtarray = StartDate.Split('/');
                                                string[] dtarray2 = endDate.Split('/');

                                                string SHours = dtarray[2].Substring(5, 2);
                                                string EHours = dtarray2[2].Substring(5, 2);

                                                DateTime? DateS = Convert.ToDateTime(wwwroot.Class.AdminSiteConfiguration.GetDate24HoursFormatMMMDD(Convert.ToString(Sdt)));
                                                DateTime? DateE = Convert.ToDateTime(wwwroot.Class.AdminSiteConfiguration.GetDate24HoursFormatMMMDD(Convert.ToString(Edt)));

                                                string STime = kvp.Value.Substring(20, 2);
                                                string ETime = kvp.Value.Substring(kvp.Value.LastIndexOf("-") + 22, 2);
                                                DateTime SD;
                                                DateTime ED;
                                                if (STime == "PM" || STime == "Pm" || STime == "pm")
                                                {
                                                    SD = Convert.ToDateTime(DateS).AddHours(12);
                                                }
                                                //else if (STime == "AM" || STime == "Am" || STime == "am" && SHours == "12")
                                                //{
                                                //    SD = Convert.ToDateTime(DateS).AddHours(-12);
                                                //}
                                                else
                                                {
                                                    SD = Convert.ToDateTime(DateS);
                                                }

                                                if (ETime == "PM" || ETime == "Pm" || ETime == "pm")
                                                {
                                                    ED = Convert.ToDateTime(DateE).AddHours(12);
                                                }
                                                //else if (ETime == "AM" || ETime == "Am" || ETime == "am" && EHours == "12")
                                                //{
                                                //    ED = Convert.ToDateTime(DateE).AddHours(-12);
                                                //}
                                                else
                                                {
                                                    ED = Convert.ToDateTime(DateE);
                                                }

                                                //Convert.ToString(DateTime.ParseExact(StartDate, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
                                                //string datechanged = dtarray[0] + "/" + dtarray[1] + "/" + dtarray[2];
                                                //string datechanged2 = dtarray2[0] + "/" + dtarray2[1] + "/" + dtarray2[2];

                                                string datechanged = wwwroot.Class.AdminSiteConfiguration.GetDate24HoursFormatMMMDD(Convert.ToString(SD));
                                                string datechanged2 = wwwroot.Class.AdminSiteConfiguration.GetDate24HoursFormatMMMDD(Convert.ToString(ED));
                                                try
                                                {
                                                    if ((!string.IsNullOrEmpty(datechanged)) && (!string.IsNullOrEmpty(datechanged2)))
                                                    {
                                                        ObjSalesactivitysummary.StartDate = Convert.ToDateTime(datechanged);
                                                        //ObjSalesactivitysummary.TransactionStartTime = Convert.ToDateTime(datechanged);
                                                        ObjSalesactivitysummary.TransactionEndTime = Convert.ToDateTime(datechanged2);
                                                        ObjSalesactivitysummary.shiftname = "Shift#";
                                                        if (STime == "AM" && ETime == "AM")
                                                        {
                                                            ObjSalesactivitysummary.TransactionStartTime = Convert.ToDateTime(datechanged);
                                                        }
                                                        else if (STime == "PM" && ETime == "PM")
                                                        {
                                                            ObjSalesactivitysummary.TransactionStartTime = Convert.ToDateTime(datechanged2);
                                                        }
                                                        else if (STime == "AM" && ETime == "PM")
                                                        {
                                                            ObjSalesactivitysummary.TransactionStartTime = Convert.ToDateTime(datechanged);
                                                        }
                                                        else if (STime == "PM" && ETime == "AM")
                                                        {
                                                            ObjSalesactivitysummary.TransactionStartTime = Convert.ToDateTime(datechanged2);
                                                        }
                                                        else
                                                        {
                                                            ObjSalesactivitysummary.TransactionStartTime = Convert.ToDateTime(datechanged);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        isflagtime = 1;

                                                    }
                                                }
                                                catch (Exception e)
                                                {
                                                    isflagtime = 1;
                                                    int idval = Filedata.id;
                                                    tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                    tbl_Excelread_Errormsg.ErrorMessage = e.Message.ToString();
                                                    db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                    db.SaveChanges();
                                                    WestZoneEntities db1 = new WestZoneEntities();
                                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                tbl_Excelread_Errormsg.ErrorMessage = e.Message.ToString();
                                                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                db.SaveChanges();
                                                isflagtime = 1;
                                                int idval = Filedata.id;
                                                WestZoneEntities db1 = new WestZoneEntities();
                                                var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                            }
                                        }
                                        if (kvp.Key == "Terminal")
                                        {
                                            var storeid = store_idval;
                                            var terminalid = (from a in db.tbl_Store_Terminal
                                                              where a.Terminal == kvp.Value && a.IsActive == true
                                                              select a.id).FirstOrDefault();
                                            if (Convert.ToString(terminalid) == "0")
                                            {
                                                var terminalsucess = db.tbl_Store_Terminal_Insert(storeid, kvp.Value, "").FirstOrDefault().Value;
                                                if (terminalsucess > 0)
                                                {
                                                    terminalid = Convert.ToInt32(terminalsucess);
                                                }
                                            }
                                            try
                                            {
                                                if ((!string.IsNullOrEmpty(terminalid.ToString())) && (!string.IsNullOrEmpty(storeid.ToString())))
                                                {
                                                    ObjSalesactivitysummary.Terminalid = terminalid;
                                                    ObjSalesactivitysummary.Storeid = storeid;
                                                }
                                                else
                                                {
                                                    isflagTerminal = 1;
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                isflagTerminal = 1;
                                                int idval = Filedata.id;
                                                tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                tbl_Excelread_Errormsg.ErrorMessage = e.Message.ToString();
                                                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                db.SaveChanges();
                                                WestZoneEntities db1 = new WestZoneEntities();
                                                var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                            }

                                        }
                                        if (kvp.Key == "Customer Count")
                                        {
                                            string Customercount = kvp.Value;
                                            for (int i = 0; i < specialCharacters.Length; i++)
                                            {
                                                if (kvp.Value.Contains(specialCharacters[i]))
                                                {
                                                    Customercount = Customercount.Replace(specialCharacters[i], "");
                                                }
                                            }
                                            try
                                            {
                                                if (!string.IsNullOrEmpty(Customercount))
                                                {
                                                    ObjSalesactivitysummary.CustomerCount = Convert.ToDecimal(Customercount);

                                                }
                                                else
                                                {
                                                    isflagColCount = 1;
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                isflagColCount = 1;
                                                tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                tbl_Excelread_Errormsg.ErrorMessage = e.Message.ToString();
                                                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                db.SaveChanges();
                                                int idval = Filedata.id;
                                                WestZoneEntities db1 = new WestZoneEntities();
                                                var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                            }
                                        }
                                        if (kvp.Key == "Net Sales With Tax")
                                        {
                                            string NetSalesWithTax = kvp.Value;
                                            for (int i = 0; i < specialCharacters.Length; i++)
                                            {
                                                if (kvp.Value.Contains(specialCharacters[i]))
                                                {
                                                    NetSalesWithTax = NetSalesWithTax.Replace(specialCharacters[i], "");
                                                }
                                            }
                                            try
                                            {
                                                if (!string.IsNullOrEmpty(NetSalesWithTax))
                                                {
                                                    ObjSalesactivitysummary.NetSalesWithTax = Convert.ToDecimal(NetSalesWithTax);

                                                }
                                                else
                                                {
                                                    isflagColNetSales = 1;
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                isflagColNetSales = 1;
                                                int idval = Filedata.id;
                                                tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                tbl_Excelread_Errormsg.ErrorMessage = e.Message.ToString();
                                                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                db.SaveChanges();
                                                WestZoneEntities db1 = new WestZoneEntities();
                                                var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                            }
                                        }
                                        if (kvp.Key == "Total Tax Collected")
                                        {
                                            string TotalTaxCollected = kvp.Value;
                                            for (int i = 0; i < specialCharacters.Length; i++)
                                            {
                                                if (kvp.Value.Contains(specialCharacters[i]))
                                                {
                                                    TotalTaxCollected = TotalTaxCollected.Replace(specialCharacters[i], "");
                                                }
                                            }
                                            try
                                            {
                                                if (!string.IsNullOrEmpty(TotalTaxCollected))
                                                {
                                                    ObjSalesactivitysummary.TotalTaxCollected = Convert.ToDecimal(TotalTaxCollected);
                                                    //isflagColTotTax = 1;
                                                }
                                                else
                                                {
                                                    isflagColTotTax = 1;
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                isflagColTotTax = 1;
                                                int idval = Filedata.id;
                                                WestZoneEntities db1 = new WestZoneEntities();
                                                tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                tbl_Excelread_Errormsg.ErrorMessage = e.Message.ToString();
                                                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                db.SaveChanges();
                                                var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                            }
                                        }

                                        if (kvp.Key == "Average Sale")
                                        {
                                            string AverageSale = kvp.Value;
                                            for (int i = 0; i < specialCharacters.Length; i++)
                                            {
                                                if (kvp.Value.Contains(specialCharacters[i]))
                                                {
                                                    AverageSale = AverageSale.Replace(specialCharacters[i], "");
                                                }
                                            }
                                            try
                                            {
                                                if (!string.IsNullOrEmpty(AverageSale))
                                                {
                                                    ObjSalesactivitysummary.AverageSale = Convert.ToDecimal(AverageSale);
                                                }
                                                else
                                                {
                                                    isflagColAvgTax = 1;
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                isflagColAvgTax = 1;
                                                int idval = Filedata.id;
                                                tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                tbl_Excelread_Errormsg.ErrorMessage = e.Message.ToString();
                                                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                db.SaveChanges();
                                                WestZoneEntities db1 = new WestZoneEntities();
                                                var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                            }
                                        }
                                        //else
                                        //{
                                        //    ObjSalesactivitysummary.AverageSale = Convert.ToDecimal("0.00");
                                        //}

                                        if (isflagtime == 1)
                                        {
                                            if (kvp.Key == "ROWtransection time")
                                            {
                                                timerowno = Convert.ToInt32(kvp.Value);
                                            }
                                            if (kvp.Key == "Columntransection time")
                                            {
                                                timecolno = Convert.ToInt32(kvp.Value);
                                            }
                                            if (timerowno != 0 && timecolno != 0)
                                            {
                                                if (IsMain != 1)
                                                {
                                                    tbl_ExcelRead.Filename = fileName;
                                                    tbl_ExcelRead.Excelreadate = DateTime.Now;
                                                    tbl_ExcelRead.CreatedDate = DateTime.Now;
                                                    db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                                    db.SaveChanges();
                                                    IsMain = 1;
                                                }
                                                tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                tbl_Excelread_Errormsg.RowNo = timerowno;
                                                tbl_Excelread_Errormsg.ColumnNo = timecolno;
                                                tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + timerowno + ", Column No: " + timecolno + ", " + "'" + " Transaction end time" + "'" + " is Invalid.";
                                                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                db.SaveChanges();
                                                int idval = Filedata.id;
                                                WestZoneEntities db1 = new WestZoneEntities();
                                                var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                                timerowno = 0;
                                                timecolno = 0;

                                            }
                                        }

                                        if (isflagTerminal == 1)
                                        {
                                            if (kvp.Key == "ROWtransection time")
                                            {
                                                Terminalrowno = Convert.ToInt32(kvp.Value);
                                            }
                                            if (kvp.Key == "Columntransection time")
                                            {
                                                Terminalcolno = Convert.ToInt32(kvp.Value);
                                            }
                                            if (Terminalrowno != 0 && Terminalcolno != 0)
                                            {
                                                if (IsMain != 1)
                                                {
                                                    tbl_ExcelRead.Filename = fileName;
                                                    tbl_ExcelRead.Excelreadate = DateTime.Now;
                                                    tbl_ExcelRead.CreatedDate = DateTime.Now;
                                                    db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                                    db.SaveChanges();
                                                    IsMain = 1;
                                                }
                                                tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                tbl_Excelread_Errormsg.RowNo = Terminalrowno;
                                                tbl_Excelread_Errormsg.ColumnNo = Terminalcolno;
                                                tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + Terminalrowno + ", Column No: " + Terminalcolno + ", " + "'" + " Terminal" + "'" + " is Invalid.";
                                                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                db.SaveChanges();
                                                int idval = Filedata.id;
                                                WestZoneEntities db1 = new WestZoneEntities();
                                                var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                                Terminalrowno = 0;
                                                Terminalcolno = 0;

                                            }
                                        }

                                        if (isflagColCount == 1)
                                        {
                                            if (kvp.Key == "ROWCustomer Count")
                                            {
                                                ColCountrowno = Convert.ToInt32(kvp.Value);
                                            }
                                            if (kvp.Key == "ColCustomer Count")
                                            {
                                                ColCountcolno = Convert.ToInt32(kvp.Value);
                                            }
                                            if (ColCountrowno != 0 && ColCountcolno != 0)
                                            {
                                                if (IsMain != 1)
                                                {
                                                    tbl_ExcelRead.Filename = fileName;
                                                    tbl_ExcelRead.Excelreadate = DateTime.Now;
                                                    tbl_ExcelRead.CreatedDate = DateTime.Now;
                                                    db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                                    db.SaveChanges();
                                                    IsMain = 1;
                                                }
                                                tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                tbl_Excelread_Errormsg.RowNo = ColCountrowno;
                                                tbl_Excelread_Errormsg.ColumnNo = ColCountcolno;
                                                tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + ColCountrowno + ", Column No: " + ColCountcolno + ", " + "'" + " Customer Count" + "'" + " is Invalid.";
                                                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                db.SaveChanges();
                                                int idval = Filedata.id;
                                                WestZoneEntities db1 = new WestZoneEntities();
                                                var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                                ColCountrowno = 0;
                                                ColCountcolno = 0;

                                            }
                                        }

                                        if (isflagColNetSales == 1)
                                        {
                                            if (kvp.Key == "Net Sales With Tax Row")
                                            {
                                                NetSalesrowno = Convert.ToInt32(kvp.Value);
                                            }
                                            if (kvp.Key == "Net Sales With Tax Col")
                                            {
                                                NetSalescolno = Convert.ToInt32(kvp.Value);
                                            }
                                            if (NetSalesrowno != 0 && NetSalescolno != 0)
                                            {
                                                if (IsMain != 1)
                                                {
                                                    tbl_ExcelRead.Filename = fileName;
                                                    tbl_ExcelRead.Excelreadate = DateTime.Now;
                                                    tbl_ExcelRead.CreatedDate = DateTime.Now;
                                                    db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                                    db.SaveChanges();
                                                    IsMain = 1;
                                                }
                                                tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                tbl_Excelread_Errormsg.RowNo = NetSalesrowno;
                                                tbl_Excelread_Errormsg.ColumnNo = NetSalescolno;
                                                tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + NetSalesrowno + ", Column No: " + NetSalescolno + ", " + "'" + " Net Sales With Tax" + "'" + " is Invalid.";
                                                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                db.SaveChanges();
                                                int idval = Filedata.id;
                                                WestZoneEntities db1 = new WestZoneEntities();
                                                var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                                NetSalesrowno = 0;
                                                NetSalescolno = 0;

                                            }
                                        }

                                        if (isflagColTotTax == 1)
                                        {
                                            if (kvp.Key == "Total Tax Collected Row")
                                            {
                                                TotTaxrowno = Convert.ToInt32(kvp.Value);
                                            }
                                            if (kvp.Key == "Total Tax Collected Col")
                                            {
                                                TotTaxcolno = Convert.ToInt32(kvp.Value);
                                            }
                                            if (TotTaxrowno != 0 && TotTaxcolno != 0)
                                            {
                                                if (IsMain != 1)
                                                {
                                                    tbl_ExcelRead.Filename = fileName;
                                                    tbl_ExcelRead.Excelreadate = DateTime.Now;
                                                    tbl_ExcelRead.CreatedDate = DateTime.Now;
                                                    db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                                    db.SaveChanges();
                                                    IsMain = 1;
                                                }
                                                tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                tbl_Excelread_Errormsg.RowNo = TotTaxrowno;
                                                tbl_Excelread_Errormsg.ColumnNo = TotTaxcolno;
                                                tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + TotTaxrowno + ", Column No: " + TotTaxcolno + ", " + "'" + " Total Tax Collected" + "'" + " is Invalid.";
                                                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                db.SaveChanges();
                                                int idval = Filedata.id;
                                                WestZoneEntities db1 = new WestZoneEntities();
                                                var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                                TotTaxrowno = 0;
                                                TotTaxcolno = 0;

                                            }
                                        }

                                        if (isflagColAvgTax == 1)
                                        {
                                            if (kvp.Key == "Average Sale Row")
                                            {
                                                AvgTaxrowno = Convert.ToInt32(kvp.Value);
                                            }
                                            if (kvp.Key == "Average Sale Col")
                                            {
                                                AvgTaxcolno = Convert.ToInt32(kvp.Value);
                                            }
                                            if (AvgTaxrowno != 0 && AvgTaxcolno != 0)
                                            {
                                                if (IsMain != 1)
                                                {
                                                    tbl_ExcelRead.Filename = fileName;
                                                    tbl_ExcelRead.Excelreadate = DateTime.Now;
                                                    tbl_ExcelRead.CreatedDate = DateTime.Now;
                                                    db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                                    db.SaveChanges();
                                                    IsMain = 1;
                                                }
                                                tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                tbl_Excelread_Errormsg.RowNo = AvgTaxrowno;
                                                tbl_Excelread_Errormsg.ColumnNo = AvgTaxcolno;
                                                tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + AvgTaxrowno + ", Column No: " + AvgTaxcolno + ", " + "'" + " Average Sale" + "'" + " is Invalid.";
                                                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                db.SaveChanges();
                                                int idval = Filedata.id;
                                                WestZoneEntities db1 = new WestZoneEntities();
                                                var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                                AvgTaxrowno = 0;
                                                AvgTaxcolno = 0;

                                            }
                                        }
                                        //Response.Write(kvp.Key + "==>" + kvp.Value);
                                        //Response.Write("<br/>");
                                    }
                                    if (IsMain != 1)
                                    {
                                        var exist = db.tbl_SalesActivitySummary_Excelread_exists(ObjSalesactivitysummary.StartDate, ObjSalesactivitysummary.Terminalid, ObjSalesactivitysummary.Storeid).Count();
                                        if (exist == 0)
                                        {
                                            isexists = true;
                                            ObjSalesactivitysummary.FileName = fileName;
                                            ObjSalesactivitysummary.CreatedDate = DateTime.Now;
                                            ObjSalesactivitysummary.CeatedBy = userid;
                                            ObjSalesactivitysummary.IsActive = true;
                                            WestZoneEntities db2 = new WestZoneEntities();
                                            db2.tbl_SalesActivitySummary.Add(ObjSalesactivitysummary);
                                            db2.SaveChanges();

                                            tbl_TendersInDrawer objtbl_TendersInDrawer = new tbl_TendersInDrawer();
                                            foreach (var kvp in TendersDrawer)
                                            {
                                                objtbl_TendersInDrawer.ActivitySalesSummuryId = ObjSalesactivitysummary.Id;
                                                objtbl_TendersInDrawer.Title = kvp.Key;


                                                string tenderamount = kvp.Value;
                                                for (int i = 0; i < specialCharacters.Length; i++)
                                                {
                                                    if (kvp.Value.Contains(specialCharacters[i]))
                                                    {
                                                        tenderamount = tenderamount.Replace(specialCharacters[i], "");
                                                    }
                                                }
                                                try
                                                {
                                                    if (!string.IsNullOrEmpty(tenderamount))
                                                    {
                                                        objtbl_TendersInDrawer.Amount = Convert.ToDecimal(tenderamount);
                                                    }
                                                }
                                                catch
                                                {
                                                    if (IsMain != 1)
                                                    {
                                                        tbl_ExcelRead.Filename = fileName;
                                                        tbl_ExcelRead.Excelreadate = DateTime.Now;
                                                        tbl_ExcelRead.CreatedDate = DateTime.Now;
                                                        db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                                        db.SaveChanges();
                                                        IsMain = 1;
                                                    }
                                                    tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                    tbl_Excelread_Errormsg.RowNo = rowcount;
                                                    tbl_Excelread_Errormsg.ColumnNo = columncount;
                                                    tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + rowcount + ", Column No: " + columncount + ", " + "'" + kvp.Value + "'" + " is Invalid.";
                                                    db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                    db.SaveChanges();
                                                    int idval = Filedata.id;
                                                    WestZoneEntities db_1 = new WestZoneEntities();
                                                    var updatissynflag = db_1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                                }
                                                objtbl_TendersInDrawer.CreatedDate = DateTime.Now;
                                                objtbl_TendersInDrawer.CeatedBy = userid;
                                                objtbl_TendersInDrawer.IsActive = true;
                                                WestZoneEntities db3 = new WestZoneEntities();
                                                db3.tbl_TendersInDrawer.Add(objtbl_TendersInDrawer);
                                                db3.SaveChanges();
                                                //Response.Write(kvp.Key + "==>" + kvp.Value);
                                                //Response.Write("<br/>");
                                            }

                                            tbl_DepartmentNetSales objtbl_DepartmentNetSales = new tbl_DepartmentNetSales();
                                            foreach (var kvp in DepartmentSales)
                                            {
                                                objtbl_DepartmentNetSales.ActivitySalesSummuryId = ObjSalesactivitysummary.Id;
                                                objtbl_DepartmentNetSales.Title = kvp.Key;


                                                string departmentamount = kvp.Value;
                                                for (int i = 0; i < specialCharacters.Length; i++)
                                                {
                                                    if (kvp.Value.Contains(specialCharacters[i]))
                                                    {
                                                        departmentamount = departmentamount.Replace(specialCharacters[i], "");
                                                    }
                                                }
                                                try
                                                {
                                                    if (!string.IsNullOrEmpty(departmentamount))
                                                    {
                                                        objtbl_DepartmentNetSales.Amount = Convert.ToDecimal(departmentamount);
                                                    }
                                                }
                                                catch (Exception e)
                                                {
                                                    if (IsMain != 1)
                                                    {
                                                        tbl_ExcelRead.Filename = fileName;
                                                        tbl_ExcelRead.Excelreadate = DateTime.Now;
                                                        tbl_ExcelRead.CreatedDate = DateTime.Now;
                                                        db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                                        db.SaveChanges();
                                                        IsMain = 1;
                                                    }
                                                    tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                    tbl_Excelread_Errormsg.RowNo = rowcount;
                                                    tbl_Excelread_Errormsg.ColumnNo = columncount;
                                                    tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + rowcount + ", Column No: " + columncount + ", " + "'" + kvp.Value + "'" + " is Invalid.";
                                                    db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                    db.SaveChanges();
                                                    int idval = Filedata.id;
                                                    WestZoneEntities db1 = new WestZoneEntities();
                                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                                }
                                                objtbl_DepartmentNetSales.CreatedDate = DateTime.Now;
                                                objtbl_DepartmentNetSales.CeatedBy = userid;
                                                objtbl_DepartmentNetSales.IsActive = true;

                                                db.tbl_DepartmentNetSales.Add(objtbl_DepartmentNetSales);
                                                db.SaveChanges();
                                                //Response.Write(kvp.Key + "==>" + kvp.Value);
                                                //Response.Write("<br/>");
                                            }

                                            tbl_PaidOut objtbl_PaidOut = new tbl_PaidOut();
                                            foreach (var kvp in Paidoutreports)
                                            {
                                                objtbl_PaidOut.ActivitySalesSummuryId = ObjSalesactivitysummary.Id;
                                                objtbl_PaidOut.Title = kvp.Key;


                                                string Paidoutamount = kvp.Value;
                                                for (int i = 0; i < specialCharacters.Length; i++)
                                                {
                                                    if (kvp.Value.Contains(specialCharacters[i]))
                                                    {
                                                        Paidoutamount = Paidoutamount.Replace(specialCharacters[i], "");
                                                    }
                                                }
                                                try
                                                {
                                                    if (!string.IsNullOrEmpty(Paidoutamount))
                                                    {
                                                        objtbl_PaidOut.Amount = Convert.ToDecimal(Paidoutamount);
                                                    }
                                                }
                                                catch
                                                {
                                                    if (IsMain != 1)
                                                    {
                                                        tbl_ExcelRead.Filename = fileName;
                                                        tbl_ExcelRead.Excelreadate = DateTime.Now;
                                                        tbl_ExcelRead.CreatedDate = DateTime.Now;
                                                        db.tbl_ExcelRead.Add(tbl_ExcelRead);
                                                        db.SaveChanges();
                                                        IsMain = 1;
                                                    }
                                                    tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                                    tbl_Excelread_Errormsg.RowNo = rowcount;
                                                    tbl_Excelread_Errormsg.ColumnNo = columncount;
                                                    tbl_Excelread_Errormsg.ErrorMessage = "Data in Row No: " + rowcount + ", Column No: " + columncount + ", " + "'" + kvp.Value + "'" + " is Invalid.";
                                                    db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                                    db.SaveChanges();
                                                    int idval = Filedata.id;
                                                    WestZoneEntities db1 = new WestZoneEntities();
                                                    var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                                                }


                                                objtbl_PaidOut.CreatedDate = DateTime.Now;
                                                objtbl_PaidOut.CeatedBy = userid;
                                                objtbl_PaidOut.IsActive = true;

                                                db.tbl_PaidOut.Add(objtbl_PaidOut);
                                                db.SaveChanges();
                                                //Response.Write(kvp.Key + "==>" + kvp.Value);
                                                //Response.Write("<br/>");
                                            }

                                        }
                                        else
                                        {
                                            isexists = false;
                                            int idval = Filedata.id;
                                            WestZoneEntities db1 = new WestZoneEntities();
                                            var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 3);

                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                //Response.Write(ex.Message + Convert.ToString(Filedata.id));
                                int idval = Filedata.id;
                                tbl_Excelread_Errormsg.Excelid = tbl_ExcelRead.id;
                                tbl_Excelread_Errormsg.RowNo = rowcount;
                                tbl_Excelread_Errormsg.ColumnNo = columncount;
                                tbl_Excelread_Errormsg.ErrorMessage = ex.Message.ToString();
                                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                                db.SaveChanges();
                                WestZoneEntities db1 = new WestZoneEntities();

                                var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                            }
                            finally
                            {
                                //Release the Excel objects   
                                excelWorkBook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                                excelApplication.Workbooks.Close();
                                excelApplication.Quit();
                                excelApplication = null;
                                excelWorkBook = null;

                                GC.GetTotalMemory(false);
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                GC.Collect();
                                GC.GetTotalMemory(true);

                                if (IsMain != 1)
                                {
                                    //String path = @"D:\MyTestFile1.txt";
                                    //string Path =@wwwroot.Class.AdminSiteConfiguration.GetURL() + "userfiles/Pending/" + fileName;
                                    string repFilePath = app_path + @"userfiles\Pending\" + fileName;
                                    DirectoryInfo sourceDir = new DirectoryInfo(repFilePath);
                                    //DirectoryInfo sourceDir = new DirectoryInfo(@Path);
                                    string Path = app_path + @"userfiles\Done\";
                                    string destinationPath = Path + fileName;
                                    //sourceDir.MoveTo(destinationPath);
                                    int idval1 = Filedata.id;

                                    if (System.IO.Directory.Exists(Path))
                                    {
                                        sourceDir.MoveTo(destinationPath);
                                    }
                                    else
                                    {
                                        System.IO.Directory.CreateDirectory(Path);
                                        sourceDir.MoveTo(destinationPath);
                                    }
                                    if (!isexists)
                                    {
                                        WestZoneEntities db1 = new WestZoneEntities();
                                        var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval1, 3);
                                    }
                                    else
                                    {
                                        WestZoneEntities db1 = new WestZoneEntities();
                                        var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval1, 1);
                                    }

                                }
                                //DumbDataIntoSql();
                            }
                        }
                        else
                        {
                            int idval = Filedata.id;
                            tbl_Excelread_Errormsg.ErrorMessage = "File Not Exist.";
                            db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                            db.SaveChanges();
                            WestZoneEntities db1 = new WestZoneEntities();
                            var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                        }

                    }
                    catch (Exception e)
                    {
                        int idval = Filedata.id;
                        tbl_Excelread_Errormsg.ErrorMessage = e.ToString();
                        db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                        db.SaveChanges();
                        WestZoneEntities db1 = new WestZoneEntities();
                        var updatissynflag = db1.tbl_Storewise_Excelupload_updateissync(idval, 2);
                    }

                }
            }
            catch (Exception e)
            {
                tbl_Excelread_Errormsg.ErrorMessage = e.ToString();
                db.tbl_Excelread_Errormsg.Add(tbl_Excelread_Errormsg);
                db.SaveChanges();
            }
        }
    }
}