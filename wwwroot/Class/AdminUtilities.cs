using MeghMailUtility;
using wwwrootBL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;


namespace wwwroot.Class
{
    public class AdminUtilities
    {
        #region Returns the Utilities Data

        public static string sitename
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.Utilities.Find(1).sitename;
            }
            set { }
        }
        public static string sitelogo
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.Utilities.Find(1).sitelogo;
            }
            set { }
        }
        public static string siteurl
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.Utilities.Find(1).siteurl;
            }
            set { }
        }
        public static string MailServer
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.Utilities.Find(1).MailServer;
            }
            set { }
        }
        public static string from
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.Utilities.Find(1).from;
            }
            set { }
        }
        public static string cc
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.Utilities.Find(1).cc;
            }
            set { }
        }
        public static string username
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.Utilities.Find(1).username;
            }
            set { }
        }
        public static string Password
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.Utilities.Find(1).Password;
            }
            set { }
        }
        public static int Authenticate
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.Utilities.Find(1).Authenticate.GetValueOrDefault();
            }
            set { }
        }
        public static string emailtop
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.Utilities.Find(1).emailtop;
            }
            set { }
        }
        public static int port
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.Utilities.Find(1).port.GetValueOrDefault();
            }
            set { }
        }
        public static int pagination
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.Utilities.Find(1).pagination.GetValueOrDefault();
            }
            set { }
        }
        public static string sitebyname
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.Utilities.Find(1).sitebyname;
            }
            set { }
        }
        public static string sitebyurl
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.Utilities.Find(1).sitebyurl;
            }
            set { }
        }


        #endregion

        //public static void SendMail(string from, string to, string subject, string Message)
        //{
        //    var body = "{0}";
        //    var message = new MailMessage();
        //    message.To.Add(new MailAddress(to));

        //    message.From = new MailAddress(from, "Workspacemanagement");
        //    message.Subject = subject;
        //    message.Body = string.Format(body, Message);
        //    message.IsBodyHtml = true;

        //    using (var smtp = new SmtpClient())
        //    {

        //        if (AdminSiteConfiguration.MailServerAuthenticate > 0)
        //        {
        //            var credential = new NetworkCredential
        //            {
        //                UserName = AdminSiteConfiguration.MailServerUsername,
        //                Password = AdminSiteConfiguration.MailServerPassword
        //            };
        //            smtp.Credentials = credential;
        //        }

        //        smtp.Host = AdminSiteConfiguration.MailServer;
        //        smtp.Port = AdminSiteConfiguration.MailServerPort;
        //        smtp.EnableSsl = true;

        //        smtp.Send(message);
        //    }
        //}



        public static void SendMail(string from, string to, string subject, string body)
        {
            String mailbody = body;
          
            mailbody = body;
            Mail mail = new Mail();
            string mailFrom = from;
            string mailTo = to;
            mail.Subject = subject;
            mail.IsHtml = true;
            mail.To = to;
            mail.From = from;
            mail.Body = mailbody;
            mail.IsAuthentification = true;
            mail.MailType = Mail.TypeMail.WebMail;
            Mail.SendMail(mail);

        }

        //public static void SendMailWithOutTemplate(string from, string to, string subject, string body)
        //{
        //    String mailbody = body;
        //    string authnticate = ClsAdminUtilities.StUtilitiesGetDataStructById("1").Authenticate.ToString();
        //    if (authnticate == "2")
        //    {
        //        mailbody = body;
        //        Mail mail = new Mail();
        //        string mailFrom = from;
        //        string mailTo = to;
        //        mail.Subject = subject;
        //        mail.IsHtml = true;
        //        mail.To = to;
        //        mail.From = from;
        //        mail.Body = mailbody;
        //        mail.IsAuthentification = true;
        //        mail.MailType = Mail.TypeMail.WebMail;
        //        Mail.SendMail(mail);
        //    }
        //    else
        //    {
        //        SmtpClient mailClient = new SmtpClient(SiteConfiguration.MailServer);
        //        MailMessage mailMessage = new MailMessage();
        //        mailMessage.From = new MailAddress(from, displayname);
        //        mailMessage.To.Add(to);
        //        mailMessage.Subject = subject;
        //        mailMessage.Body = mailbody;
        //        mailMessage.Priority = MailPriority.High;
        //        mailMessage.IsBodyHtml = true;

        //        if (authnticate == "1")
        //        {
        //            System.Net.NetworkCredential myMailCredential = new System.Net.NetworkCredential();
        //            myMailCredential.UserName = ClsAdminUtilities.StUtilitiesGetDataStructById("1").username.ToString();
        //            myMailCredential.Password = ClsAdminUtilities.StUtilitiesGetDataStructById("1").Password.ToString();
        //            mailClient.UseDefaultCredentials = false;
        //            mailClient.Credentials = myMailCredential;
        //        }
        //        mailClient.Send(mailMessage);

        //    }
        //}

        //public static void SendMail(string from, string to, string subject, string body, string cc)
        //{
        //    string mailbody = body;
        //    string authnticate = ClsAdminUtilities.StUtilitiesGetDataStructById("1").Authenticate.ToString();
        //    if (authnticate == "2")
        //    {
        //        mailbody = body;
        //        Mail mail = new Mail();
        //        string mailFrom = from;
        //        string mailTo = to;
        //        mail.Subject = subject;
        //        mail.IsHtml = true;
        //        mail.To = to;
        //        mail.From = from;
        //        mail.Body = mailbody;
        //        mail.Cc = cc;
        //        mail.IsAuthentification = true;
        //        mail.MailType = Mail.TypeMail.WebMail;
        //        Mail.SendMail(mail);
        //    }
        //    else
        //    {
        //        SmtpClient mailClient = new SmtpClient(SiteConfiguration.MailServer);
        //        MailMessage mailMessage = new MailMessage();
        //        mailMessage.From = new MailAddress(from, displayname);
        //        mailMessage.To.Add(to);
        //        mailMessage.Subject = subject;
        //        mailMessage.Body = mailbody;
        //        mailClient.Port = SiteConfiguration.MailServerPort;
        //        mailMessage.Priority = MailPriority.High;
        //        mailMessage.IsBodyHtml = true;
        //        mailMessage.CC.Add(cc);

        //        if (authnticate == "1")
        //        {
        //            System.Net.NetworkCredential myMailCredential = new System.Net.NetworkCredential();
        //            myMailCredential.UserName = ClsAdminUtilities.StUtilitiesGetDataStructById("1").username.ToString();
        //            myMailCredential.Password = ClsAdminUtilities.StUtilitiesGetDataStructById("1").Password.ToString();
        //            mailClient.UseDefaultCredentials = false;
        //            mailClient.Credentials = myMailCredential;
        //        }
        //        mailClient.Send(mailMessage);
        //    }
        //}

        //public static void SendMail(string from, string to, string subject, string body, string cc, string bcc)
        //{
        //    String mailbody = body;
        //    string authnticate = ClsAdminUtilities.StUtilitiesGetDataStructById("1").Authenticate.ToString();
        //    if (authnticate == "2")
        //    {
        //        mailbody = body;
        //        Mail mail = new Mail();
        //        string mailFrom = from;
        //        string mailTo = to;
        //        mail.Subject = subject;
        //        mail.IsHtml = true;
        //        mail.To = to;
        //        mail.From = from;
        //        mail.Body = mailbody;
        //        mail.Cc = cc;
        //        mail.Bcc = bcc;
        //        mail.IsAuthentification = true;
        //        mail.MailType = Mail.TypeMail.WebMail;
        //        Mail.SendMail(mail);
        //    }
        //    else
        //    {
        //        SmtpClient mailClient = new SmtpClient(SiteConfiguration.MailServer);
        //        MailMessage mailMessage = new MailMessage();
        //        mailMessage.From = new MailAddress(from, displayname);
        //        mailMessage.To.Add(to);
        //        mailMessage.Subject = subject;
        //        mailMessage.Body = mailbody;
        //        mailClient.Port = SiteConfiguration.MailServerPort;
        //        mailMessage.Priority = MailPriority.High;
        //        mailMessage.IsBodyHtml = true;
        //        mailMessage.CC.Add(cc);
        //        mailMessage.Bcc.Add(bcc);

        //        if (authnticate == "1")
        //        {
        //            System.Net.NetworkCredential myMailCredential = new System.Net.NetworkCredential();
        //            myMailCredential.UserName = ClsAdminUtilities.StUtilitiesGetDataStructById("1").username.ToString();
        //            myMailCredential.Password = ClsAdminUtilities.StUtilitiesGetDataStructById("1").Password.ToString();
        //            mailClient.UseDefaultCredentials = false;
        //            mailClient.Credentials = myMailCredential;
        //        }
        //        mailClient.Send(mailMessage);
        //    }
        //}
         
        public static string GetPageName(string URL)
        {
            string url = URL;

            char[] patt = { '/' };
            char[] p = { '.' };
            string[] arr = url.Split(patt);
            url = arr[arr.Length - 1];

            url = url.Remove(url.IndexOf('.'));

            return url;
        }

        public static string GetFileName(string URL)
        {
            string url = URL;
            try
            {
                char[] patt = { '/' };
                char[] p = { '.' };
                string[] arr = url.Split(patt);
                url = arr[arr.Length - 1];
                //url = url.Remove(url.IndexOf('.'));
            }
            catch
            {
            }
            return url;
        }

        public static string[] GetFileExtensions()
        {
            string[] filenames = { ".zip", ".rar", ".exe", ".jpeg", ".png", ".jpg", ".mp3", ".swf", ".flv", ".wmv", ".mov" };
            return filenames;
        }

        public static string[] GetFileExtensionsForJukebox()//add video file extensions
        {
            string[] filenames = { ".mp3" };
            return filenames;
        }

        public static string[] GetFileExtensionsForGallery()//add video file extensions
        {
            string[] filenames = { ".jpg", ".png", "gif", "jpeg" };
            return filenames;
        }


        public static string ProperCase(string stringInput)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            bool fEmptyBefore = true;
            foreach (char ch in stringInput)
            {
                char chThis = ch;
                if (Char.IsWhiteSpace(chThis))
                    fEmptyBefore = true;
                else
                {
                    if (Char.IsLetter(chThis) && fEmptyBefore)
                        chThis = Char.ToUpper(chThis);
                    else
                        chThis = Char.ToLower(chThis);
                    fEmptyBefore = false;
                }
                sb.Append(chThis);
            }
            return sb.ToString();
        }

        public static DataTable ConvertXSLXtoDataTable(string strFilePath, string connString)
        {
            OleDbConnection oledbConn = new OleDbConnection(connString);
            DataTable dt = new DataTable();
            //try
            //{

            oledbConn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);
            OleDbDataAdapter oleda = new OleDbDataAdapter();
            oleda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            oleda.Fill(ds);

            dt = ds.Tables[0];

            //}
            //catch
            //{
            //}
            //finally
            //{

            oledbConn.Close();
            //s}

            return dt;

        }
    }
}