using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wwwrootBL.Entity;

namespace wwwroot.QBClass
{
    public class QBExtractResponse
    {
        QBCreateRequest objQBReq = new QBCreateRequest();
        WestZoneEntities DB = new WestZoneEntities();

        //public void ExtractQBResponse_Vendor(string QBResponse, string Path, int CompanyID)
        //{
        //    try
        //    {
        //        XmlDocument oDoc = new XmlDocument();
        //        oDoc.LoadXml(QBResponse);

        //        XmlNodeList oList = oDoc.SelectNodes("QBXML//QBXMLMsgsRs//" + Path + "//VendorRet");
        //        if (oList.Count > 0)
        //        {
        //            for (int i = 0; i < oList.Count; i++)
        //            {
        //                clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ExtractQBResponse_Vendor, QB Vendor Count: " + oList.Count);

        //                VendorMaster oVen = new VendorMaster();
        //                string FullName = "";
        //                string FirstName = "";
        //                string LastName = "";
        //                string FirstN = "";
        //                string LastN = "";
        //                string FName = "";
        //                XmlNode oNode = oList[i];

        //                FirstName = (oNode["FirstName"] == null ? "" : oNode["FirstName"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                LastName = (oNode["LastName"] == null ? "" : oNode["LastName"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));

        //                if (FirstName == "" && LastName == "")
        //                {
        //                    FullName = (oNode["Name"] == null ? "" : oNode["Name"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    if (FullName != "")
        //                    {
        //                        //string[] data = oNode["Name"].InnerXml.ToString().Split(' ');
        //                        string[] data = oNode["Name"].InnerXml.ToString().Split(new char[] { ' ' }, 2);
        //                        if (data.Length > 1)
        //                        {
        //                            FirstN = data[0].ToString().Replace("&amp;", "&").Replace("&apos", "'");
        //                            LastN = data[1].ToString().Replace("&amp;", "&").Replace("&apos", "'");
        //                            FName = FirstN + " " + LastN;
        //                        }
        //                    }
        //                }
        //                if (FirstName != "" || LastName != "")
        //                {
        //                    FirstN = (oNode["FirstName"] == null ? "" : oNode["FirstName"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    LastN = (oNode["LastName"] == null ? "" : oNode["LastName"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    FName = FirstN + " " + LastN;
        //                }

        //                var Vendor = DB.VendorMasters.Where(a => a.CompanyID == CompanyID && (a.FirstName + " " + a.LastName).Equals(FName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

        //                if (Vendor != null)
        //                {
        //                    Vendor.ListID = (oNode["ListID"] == null ? "" : oNode["ListID"].InnerXml);
        //                    Vendor.EditSequence = (oNode["EditSequence"] == null ? "" : oNode["EditSequence"].InnerXml);
        //                    Vendor.CreatedTime = DateTime.Now;
        //                    Vendor.ModifiedTime = DateTime.Now;
        //                    Vendor.IsSync = 1;
        //                    DB.SaveChanges();
        //                }
        //                else
        //                {
        //                    if (FirstName == "" && LastName == "")
        //                    {
        //                        oVen.FirstName = FirstN;
        //                        oVen.LastName = LastN;
        //                    }
        //                    if (FirstName != "" || LastName != "")
        //                    {
        //                        oVen.FirstName = FirstN;
        //                        oVen.LastName = LastN;
        //                    }
        //                    oVen.Salution = (oNode["Salutation"] == null ? "" : oNode["Salutation"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    oVen.Email = (oNode["Email"] == null ? "" : oNode["Email"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    oVen.Mobile = (oNode["Phone"] == null ? "" : oNode["Phone"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));

        //                    if (oNode["VendorAddress"] != null)
        //                    {
        //                        oVen.Address1 = (oNode["VendorAddress"]["Addr1"] == null ? "" : oNode["VendorAddress"]["Addr1"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                        oVen.Address2 = (oNode["VendorAddress"]["Addr2"] == null ? "" : oNode["VendorAddress"]["Addr2"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                        oVen.City = (oNode["VendorAddress"]["City"] == null ? "" : oNode["VendorAddress"]["City"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                        oVen.State = (oNode["VendorAddress"]["State"] == null ? "" : oNode["VendorAddress"]["State"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                        oVen.Country = (oNode["VendorAddress"]["Country"] == null ? "" : oNode["VendorAddress"]["Country"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                        oVen.ZipCode = (oNode["VendorAddress"]["PostalCode"] == null ? "" : oNode["VendorAddress"]["PostalCode"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    }
        //                    oVen.CreatedBy = WebHelpers.GetUserId();
        //                    oVen.CreatedTime = DateTime.Now;
        //                    oVen.ModifiedBy = WebHelpers.GetUserId();
        //                    oVen.ModifiedTime = DateTime.Now;
        //                    oVen.IsSync = 1;
        //                    oVen.IsUpdate = 0;
        //                    oVen.ListID = (oNode["ListID"] == null ? "" : oNode["ListID"].InnerXml);
        //                    oVen.EditSequence = (oNode["EditSequence"] == null ? "" : oNode["EditSequence"].InnerXml);
        //                    oVen.QBSyncDate = Convert.ToDateTime(DateTime.Now);
        //                    oVen.CompanyID = CompanyID;
        //                    oVen.QBConnectionType = 1;

        //                    DB.VendorMasters.Add(oVen);
        //                    DB.SaveChanges();
        //                    oVen = null;

        //                    //clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ExtractQBResponse_Vendor, Vendor ListID: " + oVen.ListID);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ExtractQBResponse_Vendor, Message: No Venodr found in Quickbook");
        //            //clsCommon.ErrorLogEntry("QBExtractResponse", "ExtractQBResponse_Vendor", "Message: No Venodr found in Quickbook");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ExtractQBResponse_Vendor, Message:" + ex.Message);
        //        //clsCommon.ErrorLogEntry("QBExtractResponse", "ExtractQBResponse_Vendor", ex.Message);
        //    }
        //}

        //public void ExtractQBResponse_Account(string QBResponse, string Path, int CompanyID)
        //{
        //    try
        //    {
        //        XmlDocument oDoc = new XmlDocument();
        //        oDoc.LoadXml(QBResponse);

        //        XmlNodeList oList = oDoc.SelectNodes("QBXML//QBXMLMsgsRs//" + Path + "//AccountRet");
        //        if (oList.Count > 0)
        //        {
        //            for (int i = 0; i < oList.Count; i++)
        //            {
        //                Department objDep = new Department();
        //                string FullName = "";
        //                XmlNode oNode = oList[i];

        //                clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ExtractQBResponse_Account, QB Department Count :" + oList.Count);

        //                FullName = (oNode["FullName"] == null ? "" : oNode["FullName"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));

        //                var Dept = DB.Departments.Where(a => a.CompanyID == CompanyID && a.Department1.Equals(FullName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

        //                if (Dept != null)
        //                {
        //                    Dept.ListID = (oNode["ListID"] == null ? "" : oNode["ListID"].InnerXml);
        //                    Dept.EditSequence = (oNode["EditSequence"] == null ? "" : oNode["EditSequence"].InnerXml);
        //                    Dept.CreatedTime = DateTime.Now;
        //                    Dept.ModifiedTime = DateTime.Now;
        //                    Dept.IsSync = 1;
        //                    DB.SaveChanges();
        //                }
        //                else
        //                {
        //                    objDep.UserID = WebHelpers.GetUserId();
        //                    objDep.Department1 = (oNode["FullName"] == null ? "" : oNode["FullName"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    objDep.AccountType = (oNode["AccountType"] == null ? "" : oNode["AccountType"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    objDep.CreatedBy = WebHelpers.GetUserId();
        //                    objDep.CreatedTime = DateTime.Now;
        //                    objDep.ModifiedBy = WebHelpers.GetUserId();
        //                    objDep.ModifiedTime = DateTime.Now;
        //                    objDep.IsSync = 1;
        //                    objDep.IsUpdate = 0;
        //                    objDep.ListID = (oNode["ListID"] == null ? "" : oNode["ListID"].InnerXml);
        //                    objDep.EditSequence = (oNode["EditSequence"] == null ? "" : oNode["EditSequence"].InnerXml);
        //                    objDep.QBSyncDate = Convert.ToDateTime(DateTime.Now);
        //                    objDep.CompanyID = CompanyID;
        //                    objDep.QBConnectionType = 1;

        //                    DB.Departments.Add(objDep);
        //                    DB.SaveChanges();

        //                    clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ExtractQBResponse_Account, Department ListID :" + objDep.ListID);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ExtractQBResponse_Account, Message: No Account Found in Quickbook");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ExtractQBResponse_Account, Message:" + ex.Message);
        //       // clsCommon.ErrorLogEntry("QBExtractResponse", "ExtractQBResponse_Account", ex.Message);
        //    }
        //}

        //public void CreateQBResponse_Vendor(string QBResponse, string Path, int CompanyID)
        //{
        //    try
        //    {
        //        XmlDocument oDoc = new XmlDocument();
        //        oDoc.LoadXml(QBResponse);

        //        XmlNodeList oList = oDoc.SelectNodes("QBXML//QBXMLMsgsRs//" + Path + "//VendorRet");

        //        if (oList.Count > 0)
        //        {
        //            for (int i = 0; i < oList.Count; i++)
        //            {
        //                XmlNode oNode = oList[i];

        //                clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Vendor, DB Create Vendor Count :" + oList.Count);

        //                string ListID = (oNode["ListID"] == null ? "" : oNode["ListID"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                string FullName = (oNode["Name"] == null ? "" : oNode["Name"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));

        //                var Vendor = DB.VendorMasters.Where(a => a.CompanyID == CompanyID && (a.FirstName + " " + a.LastName).Equals(FullName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        //                //(from result in DB.SPVendor("SelectByCompnayId", 0, CompanyID)
        //                //          select new VendorMaster
        //                //          {
        //                //              ID = result.ID,
        //                //              ListID = result.ListID,
        //                //              FirstName =result.FirstName,
        //                //              LastName = result.LastName
        //                //          }).ToList().Where(a => (a.FirstName + " " + a.LastName).Equals(FullName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

        //                if (Vendor != null)
        //                {
        //                    Vendor.ListID = (oNode["ListID"] == null ? "" : oNode["ListID"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    Vendor.EditSequence = (oNode["EditSequence"] == null ? "" : oNode["EditSequence"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    Vendor.IsSync = 1;
        //                    Vendor.IsUpdate = 0;
        //                    Vendor.ModifiedTime = DateTime.Now;
        //                    Vendor.QBSyncDate = Convert.ToDateTime(DateTime.Now);
        //                    Vendor.LastSyncDate = Convert.ToDateTime(DateTime.Now);
        //                    Vendor.QBConnectionType = (int)QBConnectionType.Desktop;
        //                    DB.SaveChanges();

        //                    clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Vendor, Create Vendor ListID :" + Vendor.ListID);

        //                    var objRequest = DB.MasterRequests.SingleOrDefault(b => b.RequestId == Vendor.ID && b.CompanyId == CompanyID && b.RequestType == (int)RequestType.Vendor);
        //                    if (objRequest != null)
        //                    {
        //                        objRequest.Status = 2;
        //                        DB.SaveChanges();
        //                    }
        //                }
        //                else
        //                {
        //                    clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Vendor, Message: No Vendor Found in DB");
        //                   // clsCommon.ErrorLogEntry("QBExtractResponse", "CreateQBResponse_Vendor", "Message: No Vendor Found in DB");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Vendor, Message: No Vendor Found in DB");
        //            //clsCommon.ErrorLogEntry("QBExtractResponse", "CreateQBResponse_Vendor", "Message: No Vendor Found in DB");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Vendor, Message:" + ex.Message);
        //       // clsCommon.ErrorLogEntry("QBExtractResponse", "CreateQBResponse_Vendor", ex.Message);
        //    }
        //}

        //public void CreateQBResponse_Account(string QBResponse, string Path, int CompanyID)
        //{
        //    try
        //    {
        //        XmlDocument oDoc = new XmlDocument();
        //        oDoc.LoadXml(QBResponse);

        //        XmlNodeList oList = oDoc.SelectNodes("QBXML//QBXMLMsgsRs//" + Path + "//AccountRet");

        //        if (oList.Count > 0)
        //        {
        //            for (int i = 0; i < oList.Count; i++)
        //            {
        //                clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Account, DB Create Department Count :" + oList.Count);

        //                XmlNode oNode = oList[i];
        //                string ListID = (oNode["ListID"] == null ? "" : oNode["ListID"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                string Name = (oNode["FullName"] == null ? "" : oNode["FullName"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));

        //                var Dep = DB.Departments.Where(a => a.CompanyID == CompanyID && a.Department1.Equals(Name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

        //                if (Dep != null)
        //                {
        //                    Dep.ListID = (oNode["ListID"] == null ? "" : oNode["ListID"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    Dep.EditSequence = (oNode["EditSequence"] == null ? "" : oNode["EditSequence"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    Dep.IsSync = 1;
        //                    Dep.IsUpdate = 0;
        //                    Dep.ModifiedTime = DateTime.Now;
        //                    Dep.QBSyncDate = Convert.ToDateTime(DateTime.Now);
        //                    Dep.LastSyncDate = Convert.ToDateTime(DateTime.Now);
        //                    Dep.QBConnectionType = Convert.ToInt32(QBConnectionType.Desktop);

        //                    DB.SaveChanges();

        //                    clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Account, DB Create Department ListID :" + Dep.ListID);

        //                    var objRequest = DB.MasterRequests.SingleOrDefault(b => b.RequestId == Dep.ID && b.CompanyId == CompanyID && b.RequestType == (int)RequestType.Department);
        //                    if (objRequest != null)
        //                    {
        //                        objRequest.Status = 2;
        //                        DB.SaveChanges();
        //                    }
        //                }
        //                else
        //                {
        //                    clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Account, Error: No Account Found in DB");
        //                    //clsCommon.ErrorLogEntry("QBExtractResponse", "CreateQBResponse_Account", "Error: No Account Found in DB");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Account, Error: No Account Found in DB");
        //            //clsCommon.ErrorLogEntry("QBExtractResponse", "CreateQBResponse_Account", "Error: No Account Found in DB");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Account, Message:" + ex.Message);
        //        //clsCommon.ErrorLogEntry("QBExtractResponse", "CreateQBResponse_Account", ex.Message);
        //    }

        //}

        //public void ModQBResponse_Vendor(string QBResponse, string Path, int CompanyID)
        //{
        //    try
        //    {
        //        XmlDocument oDoc = new XmlDocument();
        //        oDoc.LoadXml(QBResponse);

        //        XmlNodeList oList = oDoc.SelectNodes("QBXML//QBXMLMsgsRs//" + Path + "//VendorRet");

        //        if (oList.Count > 0)
        //        {
        //            for (int i = 0; i < oList.Count; i++)
        //            {
        //                clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ModQBResponse_Vendor, DB Mod Vendor Count :" + oList.Count);

        //                XmlNode oNode = oList[i];

        //                string ListID = (oNode["ListID"] == null ? "" : oNode["ListID"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                string EditSequence = (oNode["EditSequence"] == null ? "" : oNode["EditSequence"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                string FullName = (oNode["Name"] == null ? "" : oNode["Name"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));

        //                var Vendor = DB.VendorMasters.Where(a => a.CompanyID == CompanyID && a.ListID.Equals(ListID, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        //                //(from result in DB.SPVendor("SelectByCompnayId", 0, CompanyID)
        //                //          select new VendorMaster
        //                //          {
        //                //              ID = result.ID,
        //                //              ListID = result.ListID,
        //                //              FirstName =result.FirstName,
        //                //              LastName = result.LastName
        //                //          }).ToList().Where(a => (a.FirstName + " " + a.LastName).Equals(FullName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

        //                if (Vendor != null)
        //                {
        //                    Vendor.ListID = (oNode["ListID"] == null ? "" : oNode["ListID"].InnerXml);
        //                    Vendor.EditSequence = (oNode["EditSequence"] == null ? "" : oNode["EditSequence"].InnerXml);
        //                    Vendor.FirstName = (oNode["FirstName"] == null ? "" : oNode["FirstName"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    Vendor.LastName = (oNode["LastName"] == null ? "" : oNode["LastName"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    Vendor.Salution = (oNode["Salutation"] == null ? "" : oNode["Salutation"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    Vendor.Email = (oNode["Email"] == null ? "" : oNode["Email"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    Vendor.Mobile = (oNode["Phone"] == null ? "" : oNode["Phone"].InnerXml);
        //                    Vendor.Address1 = (oNode["Addr1"] == null ? "" : oNode["Addr1"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    Vendor.Address2 = (oNode["Addr2"] == null ? "" : oNode["Addr2"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    Vendor.City = (oNode["City"] == null ? "" : oNode["City"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    Vendor.State = (oNode["State"] == null ? "" : oNode["State"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    Vendor.Country = (oNode["Country"] == null ? "" : oNode["Country"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    Vendor.ZipCode = (oNode["PostalCode"] == null ? "" : oNode["PostalCode"].InnerXml);
        //                    Vendor.IsSync = 1;
        //                    Vendor.IsUpdate = 0;
        //                    Vendor.ModifiedTime = DateTime.Now;
        //                    Vendor.QBSyncDate = Convert.ToDateTime(DateTime.Now);
        //                    Vendor.LastSyncDate = DateTime.Now;

        //                    DB.SaveChanges();

        //                    clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Account, DB Mod Vendor ListID :" + Vendor.ListID);
        //                }
        //                else
        //                {
        //                    clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ModQBResponse_Vendor, Error: No Vendor Found in DB");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ModQBResponse_Vendor, Error: No Vendor Found in DB");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ModQBResponse_Vendor, Message:" + ex.Message);
        //       // clsCommon.ErrorLogEntry("QBExtractResponse", "ModQBResponse_Vendor", ex.Message);
        //    }
        //}

        //public void ModQBResponse_Account(string QBResponse, string Path, int CompanyID)
        //{
        //    try
        //    {
        //        XmlDocument oDoc = new XmlDocument();
        //        oDoc.LoadXml(QBResponse);

        //        XmlNodeList oList = oDoc.SelectNodes("QBXML//QBXMLMsgsRs//" + Path + "//AccountRet");

        //        if (oList.Count > 0)
        //        {
        //            for (int i = 0; i < oList.Count; i++)
        //            {
        //                clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ModQBResponse_Account, DB Mod Department Count :" + oList.Count);

        //                XmlNode oNode = oList[i];
        //                string ListID = (oNode["ListID"] == null ? "" : oNode["ListID"].InnerXml);
        //                string EditSequence = (oNode["EditSequence"] == null ? "" : oNode["EditSequence"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                string Name = (oNode["FullName"] == null ? "" : oNode["FullName"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));

        //                var Dep = DB.Departments.Where(a => a.CompanyID == CompanyID && a.ListID.Equals(ListID, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

        //                if (Dep != null)
        //                {
        //                    Dep.ListID = (oNode["ListID"] == null ? "" : oNode["ListID"].InnerXml);
        //                    Dep.EditSequence = (oNode["EditSequence"] == null ? "" : oNode["EditSequence"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    Dep.Department1 = (oNode["Name"] == null ? "" : oNode["Name"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    Dep.AccountType = (oNode["AccountType"] == null ? "" : oNode["AccountType"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                    Dep.IsSync = 1;
        //                    Dep.IsUpdate = 0;
        //                    Dep.ModifiedTime = DateTime.Now;
        //                    Dep.QBSyncDate = Convert.ToDateTime(DateTime.Now);
        //                    Dep.LastSyncDate = DateTime.Now;

        //                    DB.SaveChanges();

        //                    clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ModQBResponse_Account, DB Mod Department ListID :" + Dep.ListID);

        //                }
        //                else
        //                {
        //                    clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ModQBResponse_Account, Error: No Account Found in DB");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ModQBResponse_Account, Error: No Account Found in DB");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: ModQBResponse_Account, Message:" + ex.Message);
        //       // clsCommon.ErrorLogEntry("QBExtractResponse", "ModQBResponse_Account", ex.Message);
        //    }

        //}

        //public void CreateQBResponse_Invoice(string QBResponse, string Path, int CompanyID)
        //{
        //    try
        //    {
        //        XmlDocument oDoc = new XmlDocument();
        //        oDoc.LoadXml(QBResponse);
        //        clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Invoice, Response: " + QBResponse);
        //        //XmlNodeList oList = oDoc.SelectNodes("QBXML//QBXMLMsgsRs//" + Path + "//BillRet");
        //        XmlNodeList oList2 = oDoc.SelectNodes("QBXML//QBXMLMsgsRs//" + Path);
        //        int j = 0;
        //        foreach (int InvoiceID in QBCreateRequest.reqID)
        //        {
        //            if (oList2.Count > 0)
        //            {
        //                for (int i = j; i < oList2.Count; i++)
        //                {
        //                    XmlNode oNode = oList2[i];

        //                    XmlNodeList oList = oNode.SelectNodes("BillRet");
        //                    if (oList.Count > 0)
        //                    {
        //                        foreach (XmlNode oInner in oList)
        //                        {
        //                            clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Invoice, Bill Create Count :" + oList.Count);

        //                            string TxnID = (oInner["TxnID"] == null ? "" : oInner["TxnID"].InnerXml);
        //                            string EditSequence = (oInner["EditSequence"] == null ? "" : oInner["EditSequence"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));
        //                            string RefNumber = (oInner["RefNumber"] == null ? "" : oInner["RefNumber"].InnerXml.Replace("&amp;", "&").Replace("&apos", "'"));


        //                            var Invoice = DB.DocumentInvoices.Where(a => a.CompanyID == CompanyID && a.ID == InvoiceID).FirstOrDefault();
        //                            //(from result in DB.SPVendor("SelectByCompnayId", 0, CompanyID)
        //                            //          select new VendorMaster
        //                            //          {
        //                            //              ID = result.ID,
        //                            //              ListID = result.ListID,
        //                            //              FirstName =result.FirstName,
        //                            //              LastName = result.LastName
        //                            //          }).ToList().Where(a => (a.FirstName + " " + a.LastName).Equals(FullName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

        //                            if (Invoice != null)
        //                            {
        //                                Invoice.TxnId = (oInner["TxnID"] == null ? "" : oInner["TxnID"].InnerXml);
        //                                Invoice.IsSync = 1;
        //                                Invoice.ModifiedTime = DateTime.Now;
        //                                Invoice.QBSyncDate = Convert.ToDateTime(DateTime.Now);
        //                                Invoice.Status = 1;
        //                                Invoice.QBConnectionType = (int)QBConnectionType.Desktop;

        //                                DB.SaveChanges();

        //                                clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Invoice, Bill Create TxnID :" + Invoice.TxnId);
        //                                j++;
        //                                goto Next;
        //                            }
        //                            else
        //                            {
        //                                clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Invoice, Error: No Invoices Found in DB");
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Invoice, Error: Invoice Fail, InvoiceID" + InvoiceID);
        //                    }
        //                }

        //            }
        //            else
        //            {
        //                clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Invoice, Error: No Invoices Found in DB");
        //            }

        //            Next:;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsCommon.WriteErrorLogs("Form:QBExtractResponse, Function: CreateQBResponse_Invoice, Message:" + ex.Message);
        //        //clsCommon.ErrorLogEntry("QBExtractResponse", "CreateQBResponse_Invoice", ex.Message);
        //    }
        //}
    }
}