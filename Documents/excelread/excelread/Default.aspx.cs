using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;

namespace excelread
{
    public partial class _Default : System.Web.UI.Page
    {
        Application excelApplication = null;
        Workbook excelWorkBook = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ReadExcelFile();
        }
        private void ReadExcelFile()
        {
            string EXCEL_PATH = Request.PhysicalApplicationPath + "Data.xls";
            //try
            //{
                excelApplication = new Application();
                //Opening/Loading the workBook in memory
                excelWorkBook = excelApplication.Workbooks.Open(EXCEL_PATH);

                //retrieving the worksheet counts inside the excel workbook
                int workSheetCounts = excelWorkBook.Worksheets.Count;
                int totalColumns = 0;
                Range objRange = null;
                var masterEntry = new Dictionary<string, string>();
                var TendersDrawer = new Dictionary<string, string>();
                var DepartmentSales = new Dictionary<string, string>();
                var Paidoutreports = new Dictionary<string, string>();
                string tablename = "";

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

                            if (objRange.MergeCells)
                            {
                                string columnValue = Convert.ToString(((Range)objRange.MergeArea[1, 1]).Text).Trim();
                                if(columnValue== "Tenders In Drawer Report")
                                {
                                    tablename= "TendersDrawer";
                                }
                                if (columnValue == "Tenders In DrawerTotals")
                                {
                                    tablename="";
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
                                    }
                                    hasdata++;
                                    data[hasdata - 1] = columnValue;
                                }
                            }
                            else
                            {
                                if (Convert.ToString(objRange.Text).Trim() != "")
                                {
                                    hasdata++;
                                    data[hasdata - 1] = Convert.ToString(objRange.Text).Trim();
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
                                    if(data[elementcount + 1]!=null)
                                    {
                                        masterEntry.Add("Customer Count", data[elementcount + 1].ToString());
                                    }
                                }
                                if (element.ToString().Contains("Net Sales With Tax") && !masterEntry.Keys.Contains("Net Sales With Tax"))
                                {
                                    if (data[elementcount + 1] != null)
                                    {
                                        masterEntry.Add("Net Sales With Tax", data[elementcount + 1].ToString());
                                    }
                                }
                                if (element.ToString().Contains("Total Tax Collected") && !masterEntry.Keys.Contains("Total Tax Collected"))
                                {
                                    if (data[elementcount + 1] != null)
                                    {
                                        masterEntry.Add("Total Tax Collected", data[elementcount + 1].ToString());
                                    }
                                }
                                if(tablename== "TendersDrawer")
                                {
                                    if (!TendersDrawer.Keys.Contains(element.ToString()) && element.ToString()!="" && element.ToString() != "Quantity")
                                    {
                                        if (data[elementcount + 1] != null)
                                        {
                                            TendersDrawer.Add(data[elementcount].ToString(), data[elementcount + 1].ToString());
                                            break;
                                        }
                                    }
                                }
                                if (tablename == "DepartmentSales")
                                {
                                    if (!DepartmentSales.Keys.Contains(element.ToString()) && element.ToString() != "" && element.ToString() != "Department Name" && element.ToString() != "(Net Sales include Negative Total and Discount, without Tax)")
                                    {
                                        if (data[elementcount + 1] != null)
                                        {
                                            DepartmentSales.Add(data[elementcount].ToString(), data[elementcount + 1].ToString());
                                            break;
                                        }
                                    }
                                }
                                if (tablename == "Paidoutreports")
                                {
                                    if (!Paidoutreports.Keys.Contains(element.ToString()) && element.ToString() != "" && element.ToString() != "Quantity")
                                    {
                                        if (data[elementcount + 1] != null)
                                        {
                                            Paidoutreports.Add(data[elementcount].ToString(), data[elementcount + 1].ToString());
                                            break;
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
                    foreach (var kvp in masterEntry)
                    {
                        Response.Write(kvp.Key + "==>" + kvp.Value);
                        Response.Write("<br/>");
                    }
                    foreach (var kvp in TendersDrawer)
                    {
                        Response.Write(kvp.Key + "==>" + kvp.Value);
                        Response.Write("<br/>");
                    }
                    foreach (var kvp in DepartmentSales)
                    {
                        Response.Write(kvp.Key + "==>" + kvp.Value);
                        Response.Write("<br/>");
                    }
                    foreach (var kvp in Paidoutreports)
                    {
                        Response.Write(kvp.Key + "==>" + kvp.Value);
                        Response.Write("<br/>");
                    }
                }
            //}
            //catch (Exception ex)
            //{
                //Response.Write(ex.Message);
            //}
            //finally
            //{
            //    //Release the Excel objects   
            //    excelWorkBook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
            //    excelApplication.Workbooks.Close();
            //    excelApplication.Quit();
            //    excelApplication = null;
            //    excelWorkBook = null;

            //    GC.GetTotalMemory(false);
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //    GC.Collect();
            //    GC.GetTotalMemory(true);

            //    //DumbDataIntoSql();
            //}

        }
    }
}