using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Web.Mail;
using wwwroot.Class;

namespace wwwroot.Models
{
    public class Mail
    {

        public Mail()
        {
            _cc = null;
            _bcc = null;
            _subject = "";
            _body = "";
            _isHtml = true;
            _isAuthentification = false;
            _mailType = TypeMail.NetMail;
            _addressSeparator = new char[] { ';' };
            _attachment = "";
        }
        private string _to;

        public string To
        {
            get { return _to; }
            set { _to = value; }
        }
        private string _cc;

        public string Cc
        {
            get { return _cc; }
            set { _cc = value; }
        }
        private string _from;

        public string From
        {
            get { return _from; }
            set { _from = value; }
        }
        private string _bcc;

        public string Bcc
        {
            get { return _bcc; }
            set { _bcc = value; }
        }
        private char[] _addressSeparator;

        public char AddressSeparator
        {
            set { _addressSeparator = new char[] { value }; }
            get { return _addressSeparator[0]; }
        }

        private string _subject;

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        private string _body;

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }
        private bool _isHtml;

        public bool IsHtml
        {
            get { return _isHtml; }
            set { _isHtml = value; }
        }
        public enum TypeMail
        {
            NetMail = 0,
            WebMail = 1
        }
        private TypeMail _mailType;

        public TypeMail MailType
        {
            get { return _mailType; }
            set { _mailType = value; }
        }
        private bool _isAuthentification;

        public bool IsAuthentification
        {
            get { return _isAuthentification; }
            set { _isAuthentification = value; }
        }
        private string _attachment;
        public string Attachment
        {
            get { return _attachment; }
            set { _attachment = value; }
        }





        public static bool SendMail(Mail objMail)
        {

            try
            {
                string strSMTPServer = AdminSiteConfiguration.MailServer;

                if (objMail.MailType == Mail.TypeMail.NetMail)
                {
                    System.Net.Mail.MailMessage objMessage = new System.Net.Mail.MailMessage();
                    objMessage.To.Add(objMail.To);
                    objMessage.From = new MailAddress(objMail.From);

                    if (objMail.Cc != null && objMail.Cc != "")
                    {
                        foreach (string mailItem in objMail.Cc.Split(objMail._addressSeparator))
                            objMessage.CC.Add(mailItem);
                    }
                    if (objMail.Bcc != null && objMail.Bcc != "")
                    {
                        foreach (string mailItem in objMail.Bcc.Split(objMail._addressSeparator))
                            objMessage.Bcc.Add(mailItem);
                    }
                    objMessage.Subject = objMail.Subject;
                    objMessage.Body = objMail.Body;
                    objMessage.IsBodyHtml = objMail.IsHtml;
                    System.Net.Mail.SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = strSMTPServer;

                    smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EmailSSLValue"]);
                    if (smtpClient.EnableSsl)
                        smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["EmailSSLPortNo"]);
                    else
                        smtpClient.Port = 25;
                    if (objMail.IsAuthentification)
                    {
                        System.Net.NetworkCredential myMailCredential = new System.Net.NetworkCredential();
                        myMailCredential.UserName = ConfigurationManager.AppSettings["EmailAuthUserName"];
                        myMailCredential.Password = ConfigurationManager.AppSettings["EmailAuthPassword"];
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = myMailCredential;
                    }
                    smtpClient.Send(objMessage);
                }
                else
                {
                    System.Web.Mail.MailMessage objMessage = new System.Web.Mail.MailMessage();

                    objMessage.To = objMail.To;
                    objMessage.From = objMail.From;
                    if (objMail.Cc != null && objMail.Cc != "")
                    {
                        objMessage.Cc = objMail.Cc.Replace(objMail.AddressSeparator, ';');
                    }
                    if (objMail.Attachment != null && objMail.Attachment != "")
                    {
                        MailAttachment MyAttachment = new MailAttachment(objMail.Attachment);
                        objMessage.Attachments.Add(MyAttachment);
                    }
                    if (objMail.Bcc != null && objMail.Bcc != "")
                        objMessage.Bcc = objMail.Bcc.Replace(objMail.AddressSeparator, ';');

                    objMessage.Subject = objMail.Subject;
                    objMessage.Body = objMail.Body;
                    objMessage.BodyFormat = objMail.IsHtml ? System.Web.Mail.MailFormat.Html : System.Web.Mail.MailFormat.Text;


                    if (objMail.IsAuthentification)
                    {
                        string EmailAuthuserName = ConfigurationManager.AppSettings["EmailAuthUserName"];
                        string EmailAuthpassword = ConfigurationManager.AppSettings["EmailAuthPassword"];
                        string EmailsslPortNo = ConfigurationManager.AppSettings["EmailSSLPortNo"];
                        string EmailSSLValue = ConfigurationManager.AppSettings["EmailSSLValue"];

                        objMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                        objMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", EmailAuthuserName);
                        objMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", EmailAuthpassword);
                        objMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", EmailsslPortNo);
                        objMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", EmailSSLValue);
                    }
                    System.Web.Mail.SmtpMail.SmtpServer = strSMTPServer;
                    System.Web.Mail.SmtpMail.Send(objMessage);
                }
                return true;
            }
            catch (Exception ex)
            {
                // catch exception code
                //throw ex;
                return false;
            }

        }


    }
}