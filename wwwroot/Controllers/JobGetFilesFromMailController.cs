using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wwwrootBL.Entity;

namespace wwwroot.Controllers
{
    public class JobGetFilesFromMailController : Controller
    {
        WestZoneEntities db = new WestZoneEntities();
        // GET: JobGetFilesFromMail
        public ActionResult Index()
        {
            GetFiles();

            return View();
        }

        public void GetFiles()
        {

            #region download file from mail
            Chilkat.Imap imap = new Chilkat.Imap();

            // Connect to an IMAP server.
            // Use TLS
            imap.Ssl = true;
            imap.Port = 993;
            Chilkat.Global glob = new Chilkat.Global();
            // Connect to an IMAP server.
            // Use TLS
            //imap.UnlockComponent("Anything for 30-day trial");
            //  glob.UnlockBundle("Start my 30-day Trial");
            imap.UnlockComponent("IAMJPN.CB1082020_Tqfmq6Ua8RBe");

            // Login
            var storelist = (from a in db.tbl_Store where a.EmailId != null select a).ToList();
            for (int B = 0; B <= storelist.Count - 1; B++)
            {

                bool success = imap.Connect("imap.gmail.com");
                if (success != true)
                {
                    string kk = imap.LastErrorText;
                   // return kk;

                }
                string fromemail = storelist[B].EmailId;
                string emailpassword = storelist[B].Password;
                success = imap.Login(fromemail, emailpassword);

                if (success != true)
                {
                    string kk = imap.LastErrorText;

                    Response.Write(kk + "<===1===>" + fromemail + emailpassword);
                    //Response.End();
                    //return kk;
                }

                // Select an IMAP mailbox
                success = imap.SelectMailbox("Inbox");
                if (success != true)
                {
                    string kk = imap.LastErrorText;
                    Response.Write(kk + "2");
                   // return kk;
                    //Response.End();
                }
                int uid = 2014;
                bool isUid = true;
                bool fetchUids = true;

                Chilkat.MessageSet messageSet = null;
                messageSet = imap.Search("NOT SEEN", true);
                if (imap.LastMethodSuccess != true)
                {
                    string kk = imap.LastErrorText;
                    //return kk;
                }
                if (imap.LastMethodSuccess == true)
                {
                    Chilkat.EmailBundle bundle = null;
                    bundle = imap.FetchHeaders(messageSet);
                    if (bundle == null)
                    {
                        string kk = imap.LastErrorText;
                        Response.Write(kk + "3");
                        //return kk;
                        //Response.End();
                    }

                    //  Loop over the email objects...
                    int i;
                    for (i = 0; i <= bundle.MessageCount - 1; i++)
                    {
                        int mm = bundle.MessageCount;
                        Chilkat.Email email = null;

                        email = bundle.GetEmail(i);

                        //  The sender's email address and name are available
                        //  in the From, FromAddress, and FromName properties.
                        //  If the sender is "Chilkat Support <support@chilkatsoft.com",
                        //  then the From property will hold the entire string.
                        //  the FromName property contains"Chilkat Support",
                        //  and the FromAddress property contains "support@chilkatsoft.com";
                        if (email != null)
                        {
                            //Console.WriteLine(email.From);
                            //Console.WriteLine(email.FromAddress);
                            //Console.WriteLine(email.FromName);

                            //  Assume at this point your code checks to see if the sender
                            //  is one in your contacts database.  If so, this is
                            //  the code you would write to download the entire
                            //  email and save it to a file.

                            //  The ckx-imap-uid header field is added when
                            //  headers are downloaded.  This makes it possible
                            //  to get the UID from the email object.
                            string uidStr = email.GetHeaderField("ckx-imap-uid");
                            int uid1 = Convert.ToInt32(uidStr);

                            Chilkat.Email fullEmail = null;

                            fullEmail = imap.FetchSingle(uid1, true);
                            if (!(fullEmail == null))
                            {


                                string storeid = "";
                                int store_id = 0;


                                storeid = Convert.ToString(storelist[B].Id);

                                int m = fullEmail.NumAttachments;
                                if (m > 0)
                                {

                                    //insert store wise Excel in table 

                                    if (!string.IsNullOrEmpty(storeid))
                                    {
                                        store_id = Convert.ToInt32(storeid);

                                    }
                                    //For saving indiviual attachements
                                    for (int j = 0; j < m; j++)
                                    {
                                        var random = new Random();
                                        int randomnumber = random.Next();
                                        fullEmail.GetAttachmentFilename(j);

                                        var sucess = db.tbl_Storewise_Excelupload_insert(store_id, randomnumber + imap.GetMailAttachFilename(email, j));
                                        //if (System.IO.Directory.Exists(Server.MapPath("~\\Userfiles\\Pending\\" + DateTime.Now.ToString("ddMMyyyy"))))
                                        //{
                                        //    fullEmail.SaveAttachedFile(j, Server.MapPath("~\\Userfiles\\Pending\\"));
                                        //    System.IO.File.Move(Server.MapPath("~\\Userfiles\\Pending\\" + imap.GetMailAttachFilename(email, j)), Server.MapPath("~\\Userfiles\\Pending\\" + DateTime.Now.ToString("ddMMyyyy") + "\\" + DateTime.Now.ToString("ddMMyyyyhhmmss") + imap.GetMailAttachFilename(email, j)));
                                        //}
                                        //else
                                        // {
                                        // System.IO.Directory.CreateDirectory(Server.MapPath("~\\Userfiles\\Pending\\" + DateTime.Now.ToString("ddMMyyyy")));
                                        // fullEmail.SaveAttachedFile(j, Server.MapPath("~\\Userfiles\\Pending\\" + randomnumber + imap.GetMailAttachFilename(email, j)));
                                        fullEmail.SetAttachmentFilename(j, Server.MapPath("~\\Userfiles\\Pending\\" + randomnumber + imap.GetMailAttachFilename(email, j)));
                                        fullEmail.SaveAttachedFile(j, Server.MapPath("~\\Userfiles\\Pending\\"));
                                        //System.IO.File.Move(Server.MapPath("~\\Userfiles\\Pending\\" + imap.GetMailAttachFilename(email, j)), Server.MapPath("~\\Userfiles\\Pending\\" + DateTime.Now.ToString("ddMMyyyy") + "\\" + DateTime.Now.ToString("ddMMyyyyhhmmss") + imap.GetMailAttachFilename(email, j)));

                                        //success = fullEmail.SetAttachmentFilename(j, Server.MapPath("~\\files\\" + email.EmailDate.ToShortDateString()) + "\\" + imap.GetMailAttachFilename(email, j));
                                        // }
                                    }
                                }





                            }
                        }
                    }
                }

                // Disconnect from the IMAP server.
                success = imap.Disconnect();
            }
            #endregion

        }
    }
}