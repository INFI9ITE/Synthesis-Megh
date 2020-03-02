using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wwwrootBL.Entity;
using System.Collections;

namespace wwwroot.QBClass
{
    public class QBCreateRequest
    {
        public static ArrayList reqID = new System.Collections.ArrayList();
        WestZoneEntities DB = new WestZoneEntities();

        public string SetDuration(string Time)
        {
            string Duration = "";
            string[] Times = Time.Split('.');

            string Minute = ((Convert.ToDecimal(Times[1].ToString()) / 100) * 60).ToString();

            Duration += "PT" + Times[0].ToString() + "H" + Math.Round(Convert.ToDecimal(Minute), 0) + "M00S";

            return Duration;
        }

        public string ConvertDate_QbFormat(string Date)
        {
            string NewDate = "";
            try
            {
                DateTime dt = Convert.ToDateTime(Date);
                NewDate = dt.Year.ToString() + "-" + (dt.Month.ToString().Length == 1 ? "0" + dt.Month.ToString() : dt.Month.ToString()) + "-" + (dt.Day.ToString().Length == 1 ? "0" + dt.Day.ToString() : dt.Day.ToString());
            }
            catch (Exception ex)
            {

            }
            return NewDate;
        }

        //public string GenerateXmlRequest_RetrieveVendors(string version)
        //{
        //    StringBuilder sbRequest = new StringBuilder();
        //    sbRequest.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
        //    sbRequest.Append("<?qbxml version=\"" + version + "\"?>");
        //    sbRequest.Append("<QBXML>");
        //    sbRequest.Append("<QBXMLMsgsRq onError=\"continueOnError\">");
        //    sbRequest.Append("<VendorQueryRq requestID = \"0\">");
        //    sbRequest.Append("<OwnerID>0</OwnerID>");
        //    sbRequest.Append("</VendorQueryRq>");
        //    sbRequest.Append("</QBXMLMsgsRq>");
        //    sbRequest.Append("</QBXML>");
        //    return sbRequest.ToString();
        //}

        //public string GenerateXmlRequest_RetrieveAccounts(string version)
        //{
        //    StringBuilder sbRequest = new StringBuilder();
        //    sbRequest.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
        //    sbRequest.Append("<?qbxml version=\"" + version + "\"?>");
        //    sbRequest.Append("<QBXML>");
        //    sbRequest.Append("<QBXMLMsgsRq onError=\"continueOnError\">");
        //    sbRequest.Append("<AccountQueryRq requestID = \"0\">");
        //    sbRequest.Append("<OwnerID>0</OwnerID>");
        //    sbRequest.Append("</AccountQueryRq>");
        //    sbRequest.Append("</QBXMLMsgsRq>");
        //    sbRequest.Append("</QBXML>");
        //    return sbRequest.ToString();
        //}

        //public string GenrateXmlRequest_AddVendor(string version, int CompanyID)
        //{
        //    StringBuilder sbRequest = new StringBuilder();
        //    try
        //    {
        //        var Vendor = (from result in DB.SPVendor("SelectByIsSync", 0, CompanyID,0)
        //                      select new VendorMasterModel
        //                      {
        //                          ID = result.ID,
        //                          CompanyID = result.CompanyID,
        //                          FirstName = result.FirstName,
        //                          LastName = result.LastName,
        //                          VendorName = result.FirstName + " " + result.LastName,
        //                          Salution = result.Salution,
        //                          Email = result.Email,
        //                          Mobile = result.Mobile,
        //                          Address1 = result.Address1,
        //                          Address2 = result.Address2,
        //                          City = result.City,
        //                          State = result.State,
        //                          Country = result.Country,
        //                          ZipCode = result.ZipCode,
        //                          CreatedBy = result.CreatedBy,
        //                          CreatedTime = result.CreatedTime,
        //                          ModifiedBy = result.ModifiedBy,
        //                          ModifiedTime = result.ModifiedTime,
        //                          IsSync = Convert.ToInt32(result.IsSync),
        //                          IsUpdate = Convert.ToInt32(result.IsUpdate),
        //                          ListID = result.ListID,
        //                          EditSequence = result.EditSequence,
        //                          QBSyncDate = result.QBSyncDate,
        //                          LastSyncDate = result.LastSyncDate,
        //                      }).ToList();

        //        clsCommon.WriteErrorLogs("Form:QBCreateRequest, Function: GenrateXmlRequest_AddVendor, Vendor Add Total :" + Vendor.Count);

        //        if (Vendor.Count > 0)
        //        {
        //            sbRequest.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
        //            sbRequest.Append("<?qbxml version=\"" + version + "\"?>");
        //            sbRequest.Append("<QBXML>");
        //            sbRequest.Append("<QBXMLMsgsRq onError=\"continueOnError\">");

        //            foreach (var item in Vendor)
        //            {
        //                sbRequest.Append("<VendorAddRq>");
        //                sbRequest.Append("<VendorAdd>");

        //                if (item.VendorName != null)
        //                    sbRequest.Append("<Name>" + (clsCommon.RemoveSpecialCharacters(item.VendorName, "Name", "")) + " </Name>");

        //                //sbRequest.Append("<IsActive>" + "true" + "</IsActive>");
        //                if (item.Salution != null)
        //                    sbRequest.Append("<Salutation>" + (clsCommon.RemoveSpecialCharacters(item.Salution, "Ship", "")) + " </Salutation>");
        //                if (item.FirstName != null)
        //                    sbRequest.Append("<FirstName>" + (clsCommon.RemoveSpecialCharacters(item.FirstName, "FirstName", "")) + "</FirstName>");
        //                if (item.LastName != null)
        //                    sbRequest.Append("<LastName>" + (clsCommon.RemoveSpecialCharacters(item.LastName, "LastName", "")) + "</LastName>");

        //                sbRequest.Append("<VendorAddress>");
        //                if (item.Address1 != null)
        //                    sbRequest.Append("<Addr1>" + (clsCommon.RemoveSpecialCharacters(item.Address1, "Addr1", "")) + "</Addr1>");
        //                if (item.Address2 != null)
        //                    sbRequest.Append("<Addr2>" + (clsCommon.RemoveSpecialCharacters(item.Address2, "Addr1", "")) + "</Addr2>");
        //                if (item.City != null)
        //                    sbRequest.Append("<City>" + (clsCommon.RemoveSpecialCharacters(item.City, "Country", "")) + "</City>");
        //                if (item.State != null)
        //                    sbRequest.Append("<State>" + (clsCommon.RemoveSpecialCharacters(item.State, "State", "")) + "</State>");
        //                if (item.ZipCode != null)
        //                    sbRequest.Append("<PostalCode>" + (clsCommon.RemoveSpecialCharacters(item.ZipCode, "PostalCode", "")) + "</PostalCode>");
        //                if (item.Country != null)
        //                    sbRequest.Append("<Country>" + (clsCommon.RemoveSpecialCharacters(item.Country, "Country", "")) + "</Country>");
        //                sbRequest.Append("</VendorAddress>");

        //                if (item.Mobile != null)
        //                    sbRequest.Append("<Phone>" + (clsCommon.RemoveSpecialCharacters(item.Mobile, "Phone", "")) + "</Phone>");
        //                if (item.Email != null)
        //                    sbRequest.Append("<Email>" + (clsCommon.RemoveSpecialCharacters(item.Email, "Email", "")) + "</Email>");

        //                sbRequest.Append("</VendorAdd>");
        //                sbRequest.Append("</VendorAddRq>");
        //            }
        //            sbRequest.Append("</QBXMLMsgsRq>");
        //            sbRequest.Append("</QBXML>");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsCommon.WriteErrorLogs("Form:QBCreateRequest, Function: GenrateXmlRequest_AddVendor, Message:" + ex.Message);
        //       // clsCommon.ErrorLogEntry("QBCreateRequest", "GenrateXmlRequest_AddVendor", ex.Message);
        //    }
        //    return sbRequest.ToString();
        //}

        //public string GenrateXmlRequest_AddAccount(string version, int CompanyID)
        //{
        //    StringBuilder sbRequest = new StringBuilder();
        //    try
        //    {
        //        var Dep = (from result in DB.SPDepartment("SelectByIsSync", 0, CompanyID,0)
        //                   select new DepartmentModel
        //                   {
        //                       ID = result.ID,
        //                       CompanyID = result.CompanyID,
        //                       UserID = result.UserID,
        //                       Department = result.Department,
        //                       AccountType = result.AccountType,
        //                       CreatedBy = result.CreatedBy,
        //                       CreatedTime = result.CreatedTime,
        //                       ModifiedBy = result.ModifiedBy,
        //                       ModifiedTime = result.ModifiedTime,
        //                       IsSync = Convert.ToInt32(result.IsSync),
        //                       IsUpdate = Convert.ToInt32(result.IsUpdate),
        //                       ListID = result.ListID,
        //                       EditSequence = result.EditSequence,
        //                       QBSyncDate = result.QBSyncDate,
        //                       LastSyncDate = result.LastSyncDate,
        //                   }).ToList();

        //        clsCommon.WriteErrorLogs("Form:QBCreateRequest, Function: GenrateXmlRequest_AddAccount, Department Add Total :" + Dep.Count);

        //        if (Dep.Count > 0)
        //        {
        //            sbRequest.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
        //            sbRequest.Append("<?qbxml version=\"" + version + "\"?>");
        //            sbRequest.Append("<QBXML>");
        //            sbRequest.Append("<QBXMLMsgsRq onError=\"continueOnError\">");

        //            foreach (var item in Dep)
        //            {
        //                sbRequest.Append("<AccountAddRq>");
        //                sbRequest.Append("<AccountAdd>");

        //                if (item.Department != null)
        //                    sbRequest.Append("<Name>" + (clsCommon.RemoveSpecialCharacters(item.Department, "Country", "")) + " </Name>");

        //                //sbRequest.Append("<IsActive>" + "true" + "</IsActive>");
        //                if (item.AccountType != null)
        //                    sbRequest.Append("<AccountType>" + (clsCommon.RemoveSpecialCharacters(item.AccountType, "", "")) + "</AccountType>");

        //                sbRequest.Append("</AccountAdd>");
        //                sbRequest.Append("</AccountAddRq>");
        //            }
        //            sbRequest.Append("</QBXMLMsgsRq>");
        //            sbRequest.Append("</QBXML>");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsCommon.WriteErrorLogs("Form:QBCreateRequest, Function: GenrateXmlRequest_AddAccount, Message:" + ex.Message);
        //       // clsCommon.ErrorLogEntry("QBCreateRequest", "GenrateXmlRequest_AddAccount", ex.Message);
        //    }
        //    return sbRequest.ToString();
        //}

        //public string GenrateXmlRequest_ModVendor(string version, int CompanyID)
        //{
        //    StringBuilder sbRequest = new StringBuilder();
        //    try
        //    {
        //        var Vendor = (from result in DB.SPVendor("SelectByIsUpdate", 0, CompanyID,0)
        //                      select new VendorMasterModel
        //                      {
        //                          ID = result.ID,
        //                          CompanyID = result.CompanyID,
        //                          FirstName = result.FirstName,
        //                          LastName = result.LastName,
        //                          VendorName = result.FirstName + " " + result.LastName,
        //                          Salution = result.Salution,
        //                          Email = result.Email,
        //                          Mobile = result.Mobile,
        //                          Address1 = result.Address1,
        //                          Address2 = result.Address2,
        //                          City = result.City,
        //                          State = result.State,
        //                          Country = result.Country,
        //                          ZipCode = result.ZipCode,
        //                          CreatedBy = result.CreatedBy,
        //                          CreatedTime = result.CreatedTime,
        //                          ModifiedBy = result.ModifiedBy,
        //                          ModifiedTime = result.ModifiedTime,
        //                          IsSync = Convert.ToInt32(result.IsSync),
        //                          IsUpdate = Convert.ToInt32(result.IsUpdate),
        //                          ListID = result.ListID,
        //                          EditSequence = result.EditSequence,
        //                          QBSyncDate = result.QBSyncDate,
        //                          LastSyncDate = result.LastSyncDate,
        //                      }).ToList();

        //        clsCommon.WriteErrorLogs("Form:QBCreateRequest, Function: GenrateXmlRequest_ModVendor, Vendor Mod Total :" + Vendor.Count);

        //        if (Vendor.Count > 0)
        //        {
        //            sbRequest.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
        //            sbRequest.Append("<?qbxml version=\"" + version + "\"?>");
        //            sbRequest.Append("<QBXML>");
        //            sbRequest.Append("<QBXMLMsgsRq onError=\"continueOnError\">");

        //            foreach (var item in Vendor)
        //            {
        //                sbRequest.Append("<VendorModRq>");
        //                sbRequest.Append("<VendorMod>");

        //                if (item.ListID != null)
        //                    sbRequest.Append("<ListID>" + item.ListID + "</ListID>");

        //                if (item.EditSequence != null)
        //                    sbRequest.Append("<EditSequence>" + item.EditSequence + "</EditSequence>");

        //                if (item.VendorName != null)
        //                    sbRequest.Append("<Name>" + (clsCommon.RemoveSpecialCharacters(item.VendorName, "Name", "")) + " </Name>");

        //                if (item.Salution != null)
        //                    sbRequest.Append("<Salutation>" + (clsCommon.RemoveSpecialCharacters(item.Salution, "Ship", "")) + " </Salutation>");
        //                if (item.FirstName != null)
        //                    sbRequest.Append("<FirstName>" + (clsCommon.RemoveSpecialCharacters(item.FirstName, "FirstName", "")) + "</FirstName>");
        //                if (item.LastName != null)
        //                    sbRequest.Append("<LastName>" + (clsCommon.RemoveSpecialCharacters(item.LastName, "LastName", "")) + "</LastName>");

        //                sbRequest.Append("<VendorAddress>");
        //                if (item.Address1 != null)
        //                    sbRequest.Append("<Addr1>" + (clsCommon.RemoveSpecialCharacters(item.Address1, "Addr1", "")) + "</Addr1>");
        //                if (item.Address2 != null)
        //                    sbRequest.Append("<Addr2>" + (clsCommon.RemoveSpecialCharacters(item.Address2, "Addr1", "")) + "</Addr2>");
        //                if (item.City != null)
        //                    sbRequest.Append("<City>" + (clsCommon.RemoveSpecialCharacters(item.City, "Country", "")) + "</City>");
        //                if (item.State != null)
        //                    sbRequest.Append("<State>" + (clsCommon.RemoveSpecialCharacters(item.State, "State", "")) + "</State>");
        //                if (item.ZipCode != null)
        //                    sbRequest.Append("<PostalCode>" + (clsCommon.RemoveSpecialCharacters(item.ZipCode, "PostalCode", "")) + "</PostalCode>");
        //                if (item.Country != null)
        //                    sbRequest.Append("<Country>" + (clsCommon.RemoveSpecialCharacters(item.Country, "Country", "")) + "</Country>");
        //                sbRequest.Append("</VendorAddress>");

        //                if (item.Mobile != null)
        //                    sbRequest.Append("<Phone>" + (clsCommon.RemoveSpecialCharacters(item.Mobile, "Phone", "")) + "</Phone>");
        //                if (item.Email != null)
        //                    sbRequest.Append("<Email>" + (clsCommon.RemoveSpecialCharacters(item.Email, "Email", "")) + "</Email>");

        //                sbRequest.Append("</VendorMod>");
        //                sbRequest.Append("</VendorModRq>");
        //            }
        //            sbRequest.Append("</QBXMLMsgsRq>");
        //            sbRequest.Append("</QBXML>");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsCommon.WriteErrorLogs("Form:QBCreateRequest, Function: GenrateXmlRequest_ModVendor, Message:" + ex.Message);
        //        //clsCommon.ErrorLogEntry("QBCreateRequest", "GenrateXmlRequest_ModVendor", ex.Message);
        //    }
        //    return sbRequest.ToString();
        //}

        //public string GenrateXmlRequest_ModAccount(string version, int CompanyID)
        //{
        //    StringBuilder sbRequest = new StringBuilder();
        //    try
        //    {
        //        var Dep = (from result in DB.SPDepartment("SelectByIsUpdate", 0, CompanyID,0)
        //                   select new DepartmentModel
        //                   {
        //                       ID = result.ID,
        //                       CompanyID = result.CompanyID,
        //                       UserID = result.UserID,
        //                       Department = result.Department,
        //                       AccountType = result.AccountType,
        //                       CreatedBy = result.CreatedBy,
        //                       CreatedTime = result.CreatedTime,
        //                       ModifiedBy = result.ModifiedBy,
        //                       ModifiedTime = result.ModifiedTime,
        //                       IsSync = Convert.ToInt32(result.IsSync),
        //                       IsUpdate = Convert.ToInt32(result.IsUpdate),
        //                       ListID = result.ListID,
        //                       EditSequence = result.EditSequence,
        //                       QBSyncDate = result.QBSyncDate,
        //                       LastSyncDate = result.LastSyncDate,
        //                   }).ToList();

        //        clsCommon.WriteErrorLogs("Form:QBCreateRequest, Function: GenrateXmlRequest_ModAccount, Department Mod Total :" + Dep.Count);

        //        if (Dep.Count > 0)
        //        {
        //            sbRequest.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
        //            sbRequest.Append("<?qbxml version=\"" + version + "\"?>");
        //            sbRequest.Append("<QBXML>");
        //            sbRequest.Append("<QBXMLMsgsRq onError=\"continueOnError\">");

        //            foreach (var item in Dep)
        //            {
        //                sbRequest.Append("<AccountModRq>");
        //                sbRequest.Append("<AccountMod>");

        //                if (item.ListID != null)
        //                    sbRequest.Append("<ListID>" + item.ListID + " </ListID>");

        //                if (item.EditSequence != null)
        //                    sbRequest.Append("<EditSequence>" + item.EditSequence + " </EditSequence>");

        //                if (item.Department != null)
        //                    sbRequest.Append("<Name>" + (clsCommon.RemoveSpecialCharacters(item.Department, "Country", "")) + " </Name>");

        //                if (item.AccountType != null)
        //                    sbRequest.Append("<AccountType>" + (clsCommon.RemoveSpecialCharacters(item.AccountType, "", "")) + "</AccountType>");

        //                sbRequest.Append("</AccountMod>");
        //                sbRequest.Append("</AccountModRq>");
        //            }
        //            sbRequest.Append("</QBXMLMsgsRq>");
        //            sbRequest.Append("</QBXML>");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsCommon.WriteErrorLogs("Form:QBCreateRequest, Function: GenrateXmlRequest_AddAccount, Message:" + ex.Message);
        //       // clsCommon.ErrorLogEntry("QBCreateRequest", "GenrateXmlRequest_AddAccount", ex.Message);
        //    }
        //    return sbRequest.ToString();
        //}

        //public string GenrateXmlRequest_AddBill(string version, int CompanyID)
        //{
        //    StringBuilder sbRequest = new StringBuilder();
        //    try
        //    {
        //        int RequestID = 0;
        //        var invoices = (from result in DB.SPDocumentInvoice("SelectForQBSync", 0, 0, CompanyID,0)
        //                        select new DocumentInvoiceModel
        //                        {
        //                            ID = result.ID,
        //                            CompanyID = result.CompanyID,
        //                            RefNumber = result.RefNumber,
        //                            VendorID = result.VendorID,
        //                            ListID = result.ListID,
        //                            VendorName = result.VendorName,
        //                            Address = result.Address,
        //                            Amount = result.Amount,
        //                            InvoiceDate = result.InvoiceDate,
        //                            CreatedBy = result.CreatedBy,
        //                            CreatedTime = result.CreatedTime,
        //                            ModifiedBy = result.ModifiedBy,
        //                            ModifiedTime = result.ModifiedTime,
        //                            InvoiceType = result.InvoiceType,
        //                            DocumentID = result.DocumentID,
        //                            Notes = result.Notes,
        //                        }).ToList();

        //        clsCommon.WriteErrorLogs("Form:QBCreateRequest, Function: GenrateXmlRequest_AddBill, Bill invoice Total :" + invoices.Count);

        //        sbRequest.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
        //        sbRequest.Append("<?qbxml version=\"" + version + "\"?>");
        //        sbRequest.Append("<QBXML>");
        //        sbRequest.Append("<QBXMLMsgsRq onError=\"continueOnError\">");

        //        if (invoices.Count > 0)
        //        {
        //            foreach (var item in invoices)
        //            {
        //                var invoicesDetail = (from result in DB.SPDocumentInvoiceDetails("SelectByInvoiceID", 0, item.DocumentID)
        //                                      select new DocumentInvoiceDetailModel
        //                                      {
        //                                          ID = Convert.ToInt32(result.ID),
        //                                          DocumentInvoiceID = result.DocumentInvoiceID,
        //                                          DepartmentID = result.DepartmentID,
        //                                          ListID = result.ListID,
        //                                          DepartmentName = result.DepartmentName,
        //                                          Amount = result.Amount,
        //                                          Description = result.Description,
        //                                          CreatedBy = result.CreatedBy,
        //                                          CreatedTime = result.CreatedTime,
        //                                          ModifiedBy = result.ModifiedBy,
        //                                          ModifiedTime = result.ModifiedTime,
        //                                      }).ToList();

        //                clsCommon.WriteErrorLogs("Form:QBCreateRequest, Function: GenrateXmlRequest_AddBill, Bill invoiceDetail Total :" + invoicesDetail.Count + "and InvoiceID" + item.ID);

        //                if (invoicesDetail.Count > 0)
        //                {
        //                    sbRequest.Append("<BillAddRq requestID = \"" + RequestID + "\">");
        //                    sbRequest.Append("<BillAdd>");

        //                    if (item.ListID != null)
        //                    {
        //                        sbRequest.Append("<VendorRef>");
        //                        sbRequest.Append("<ListID>" + item.ListID + "</ListID>");
        //                        sbRequest.Append("</VendorRef>");
        //                    }

        //                    if (item.InvoiceDate != null)
        //                        sbRequest.Append("<TxnDate>" + ConvertDate_QbFormat(item.InvoiceDate.ToString()) + "</TxnDate>");

        //                    if (item.RefNumber != null)
        //                        sbRequest.Append("<RefNumber>" + (clsCommon.RemoveSpecialCharacters(item.RefNumber, "RefNumber", "")) + "</RefNumber>");

        //                    if (item.Notes != null && item.Notes.ToString() != "")
        //                        sbRequest.Append("<Memo>" + (clsCommon.RemoveSpecialCharacters(item.Notes, "Address", "")) + "</Memo>");

        //                    foreach (var itemDetail in invoicesDetail)
        //                    {
        //                        sbRequest.Append("<ExpenseLineAdd>");
        //                        if (itemDetail.ListID != null)
        //                        {
        //                            sbRequest.Append("<AccountRef>");
        //                            sbRequest.Append("<ListID>" + itemDetail.ListID + "</ListID>");
        //                            sbRequest.Append("</AccountRef>");
        //                        }
        //                        if (itemDetail.Amount != null)
        //                        {
        //                            sbRequest.Append("<Amount>" + itemDetail.Amount + "</Amount>");
        //                        }
        //                        if (itemDetail.Description != null)
        //                            sbRequest.Append("<Memo>" + (clsCommon.RemoveSpecialCharacters(itemDetail.Description, "Address", "")) + "</Memo>");

        //                        clsCommon.WriteErrorLogs("Form: QBCreateRequest, Function: GenrateXmlRequest_AddBill, itemDetail ListID: " + itemDetail.ListID);

        //                        sbRequest.Append("</ExpenseLineAdd>");
        //                    }

        //                    sbRequest.Append("</BillAdd>");
        //                    sbRequest.Append("</BillAddRq>");
        //                    RequestID++;
        //                    reqID.Add(item.ID);
        //                }
        //            }
        //        }
        //        sbRequest.Append("</QBXMLMsgsRq>");
        //        sbRequest.Append("</QBXML>");
        //    }
        //    catch (Exception ex)
        //    {
        //        clsCommon.WriteErrorLogs("Form:QBCreateRequest, Function: GenrateXmlRequest_AddBill, Message:" + ex.Message);
        //       // clsCommon.ErrorLogEntry("QBCreateRequest", "GenrateXmlRequest_AddBill", ex.Message);
        //    }
        //    clsCommon.WriteErrorLogs("Form:QBCreateRequest, Function: GenrateXmlRequest_AddBill, Bill Response:" + sbRequest.ToString());
        //    return sbRequest.ToString();
        //}
    }
}