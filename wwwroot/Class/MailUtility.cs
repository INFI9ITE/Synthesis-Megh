using System;
using System.Web.Mail;

/// <summary>
/// Summary description for MailUtility
/// </summary>

namespace MeghMailUtility
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
            //try
            //{
                string strSMTPServer = wwwroot.Class.AdminSiteConfiguration.MailServer;


                MailMessage objMessage = new  MailMessage();

                objMessage.To = objMail.To;
                objMessage.From = objMail.From;
                if (objMail.Cc != null && objMail.Cc != "")
                {
                    objMessage.Cc = objMail.Cc.Replace(objMail.AddressSeparator, ';');
                }
                if (objMail.Attachment != null && objMail.Attachment != "")
                {
                    MailAttachment MyAttachment = new  MailAttachment(objMail.Attachment);
                    objMessage.Attachments.Add(MyAttachment);
                }
                if (objMail.Bcc != null && objMail.Bcc != "")
                    objMessage.Bcc = objMail.Bcc.Replace(objMail.AddressSeparator, ';');

                objMessage.Subject = objMail.Subject;
                objMessage.Body = objMail.Body;
                objMessage.BodyEncoding = System.Text.Encoding.UTF8;
                objMessage.BodyFormat = objMail.IsHtml ?  MailFormat.Html :  MailFormat.Text;

                if (objMail.IsAuthentification)
                {
                    string EmailAuthuserName = wwwroot.Class.AdminSiteConfiguration.MailServerUsername;
                    string EmailAuthpassword = wwwroot.Class.AdminSiteConfiguration.MailServerPassword;
                    string EmailsslPortNo = wwwroot.Class.AdminSiteConfiguration.MailServerPort.ToString();
                    string EmailSSLValue =Convert.ToString(true);

                    objMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                    objMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", EmailAuthuserName);
                    objMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", EmailAuthpassword);
                    objMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", EmailsslPortNo);
                    objMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", EmailSSLValue);
                }
                 SmtpMail.SmtpServer = strSMTPServer;
                 SmtpMail.Send(objMessage);

                return true;
            //}
            //catch(Exception e)
            //{
            //    // catch exception code
            //    //throw ex;
            //    return false;
            //}
        }
    }
}