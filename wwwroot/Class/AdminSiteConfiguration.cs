using wwwrootBL.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;


namespace wwwroot.Class
{
    public class AdminSiteConfiguration
    {
        #region Returns the SiteConfiguration Data

        public static int CategoryLevel
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.SiteConfigurations.Find(1).level.GetValueOrDefault();
            }
            set { }
        }

        public static int Currencydigit
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.SiteConfigurations.Find(1).Currencydigit.GetValueOrDefault();
            }
            set { }
        }

        public static string CurrencySymbol
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return db.SiteConfigurations.Find(1).Symbol;
            }
            set { }
        }

        #endregion

        public static string SiteName
        {
            get
            {

                WestZoneEntities db = new WestZoneEntities();
                return (from data in db.Utilities where data.id == 1 select data.sitename).FirstOrDefault().ToString();
            }
        }
        public static string SiteURl
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return (from data in db.Utilities where data.id == 1 select data.siteurl).FirstOrDefault().ToString();
            }
        }
        public static string MailServer
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return (from data in db.Utilities where data.id == 1 select data.MailServer).FirstOrDefault().ToString();
            }
        }

        public static int MailServerPort
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return Convert.ToInt32((from data in db.Utilities where data.id == 1 select data.port).FirstOrDefault().ToString());
            }
        }

        public static int MailServerAuthenticate
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return Convert.ToInt32((from data in db.Utilities where data.id == 1 select data.Authenticate).FirstOrDefault().ToString());
            }
        }

        public static string MailServerUsername
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return (from data in db.Utilities where data.id == 1 select data.username).FirstOrDefault().ToString();
            }
        }
        public static string MailServerPassword
        {
            get
            {
                WestZoneEntities db = new WestZoneEntities();
                return (from data in db.Utilities where data.id == 1 select data.Password).FirstOrDefault().ToString();
            }
        }
        #region Image code Start
        public static bool ThumbnailCallBack()
        {
            return false;
        }
        public static bool ImageResize(string pimage, string foldername, int large, int medium, int small)
        {
            int imgwidth = 0;
            int imgheight = 0;
            int imgthumbwidth = 0;
            int imgthumbheight = 0;
            int imgiconwidth = 0;
            int imgiconheight = 0;

            //Panel1.Visible = true;
            System.Drawing.Image.GetThumbnailImageAbort callback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallBack);
            System.Drawing.Image mainImage = System.Drawing.Image.FromFile(HttpContext.Current.Request.PhysicalApplicationPath + "\\userfiles\\" + foldername + "\\" + pimage);

            //==resize main image - if image's height or width > 250 px

            if (mainImage.Width >= large || mainImage.Height >= large)
            {
                if (mainImage.Width > mainImage.Height)
                {
                    imgwidth = large;
                    imgheight = (mainImage.Height * large) / mainImage.Width;

                    imgthumbwidth = medium;
                    imgthumbheight = (mainImage.Height * medium) / mainImage.Width;

                    imgiconwidth = small;
                    imgiconheight = (mainImage.Height * small) / mainImage.Width;

                }
                else if (mainImage.Width < mainImage.Height)
                {
                    imgheight = large;
                    imgwidth = (mainImage.Width * large) / mainImage.Height;

                    imgthumbheight = medium;
                    imgthumbwidth = (mainImage.Width * medium) / mainImage.Height;

                    imgiconheight = small;
                    imgiconwidth = (mainImage.Width * small) / mainImage.Height;
                }
                else if (mainImage.Width == mainImage.Height)
                {
                    imgheight = large;
                    imgwidth = large;
                    imgthumbwidth = medium;
                    imgthumbheight = medium;
                    imgiconheight = small;
                    imgiconwidth = small;
                }

                string ProductImageMain = pimage;
                Bitmap thumbnail1 = new Bitmap(imgwidth, imgheight, PixelFormat.Format24bppRgb);
                thumbnail1.SetResolution(mainImage.HorizontalResolution, mainImage.VerticalResolution);
                Graphics grPhoto = Graphics.FromImage(thumbnail1);
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
                grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;
                grPhoto.CompositingQuality = CompositingQuality.HighQuality;

                grPhoto.DrawImage(mainImage,
                    new Rectangle(-1, -1, imgwidth + 2, imgheight + 2),
                    new Rectangle(-1, -1, mainImage.Width + 2, mainImage.Height + 2),
                    GraphicsUnit.Pixel);
                grPhoto.Dispose();
                thumbnail1.Save(HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\" + foldername + "\\large\\" + ProductImageMain);
                thumbnail1.Dispose();


                string ProudctImageThumb = pimage;
                Bitmap thumbnail2 = new Bitmap(imgthumbwidth, imgthumbheight, PixelFormat.Format24bppRgb);
                thumbnail2.SetResolution(mainImage.HorizontalResolution, mainImage.VerticalResolution);
                Graphics grPhoto2 = Graphics.FromImage(thumbnail2);
                grPhoto2.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto2.SmoothingMode = SmoothingMode.AntiAlias;
                grPhoto2.PixelOffsetMode = PixelOffsetMode.HighQuality;
                grPhoto2.CompositingQuality = CompositingQuality.HighQuality;

                grPhoto2.DrawImage(mainImage,
                    new Rectangle(-1, -1, imgthumbwidth + 2, imgthumbheight + 2),
                    new Rectangle(-1, -1, mainImage.Width + 2, mainImage.Height + 2),
                    GraphicsUnit.Pixel);
                grPhoto2.Dispose();
                thumbnail2.Save(HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\" + foldername + "\\medium\\" + ProudctImageThumb);
                thumbnail2.Dispose();


                //==create icon of the image
                string ProductImageIcon = pimage;
                Bitmap thumbnail3 = new Bitmap(imgiconwidth, imgiconheight, PixelFormat.Format24bppRgb);
                thumbnail3.SetResolution(mainImage.HorizontalResolution, mainImage.VerticalResolution);
                Graphics grPhoto3 = Graphics.FromImage(thumbnail3);
                grPhoto3.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto3.SmoothingMode = SmoothingMode.AntiAlias;
                grPhoto3.PixelOffsetMode = PixelOffsetMode.HighQuality;
                grPhoto3.CompositingQuality = CompositingQuality.HighQuality;

                grPhoto3.DrawImage(mainImage,
                    new Rectangle(-1, -1, imgiconwidth + 2, imgiconheight + 2),
                    new Rectangle(-1, -1, mainImage.Width + 2, mainImage.Height + 2),
                    GraphicsUnit.Pixel);
                grPhoto3.Dispose();
                thumbnail3.Save(HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\" + foldername + "\\small\\" + ProductImageIcon);
                thumbnail3.Dispose();

            }
            else
            {
                mainImage.Save(HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\" + foldername + "\\large\\" + pimage);


                if ((mainImage.Width >= medium & mainImage.Width < large) | (mainImage.Height >= medium & mainImage.Width < large))
                {
                    if (mainImage.Width > mainImage.Height)
                    {

                        imgthumbwidth = medium;
                        imgthumbheight = (mainImage.Height * medium) / mainImage.Width;

                        imgiconwidth = small;
                        imgiconheight = (mainImage.Height * small) / mainImage.Width;

                    }
                    else if (mainImage.Width < mainImage.Height)
                    {

                        imgthumbheight = medium;
                        imgthumbwidth = (mainImage.Width * medium) / mainImage.Height;

                        imgiconheight = small;
                        imgiconwidth = (mainImage.Width * small) / mainImage.Height;
                    }
                    else if (mainImage.Width == mainImage.Height)
                    {
                        imgthumbwidth = medium;
                        imgthumbheight = medium;
                        imgiconheight = small;
                        imgiconwidth = small;
                    }
                    //==create thumbnail of the image
                    string ProudctImageThumb = pimage;
                    Bitmap thumbnail2 = new Bitmap(imgthumbwidth, imgthumbheight, PixelFormat.Format24bppRgb);
                    thumbnail2.SetResolution(mainImage.HorizontalResolution, mainImage.VerticalResolution);
                    Graphics grPhoto2 = Graphics.FromImage(thumbnail2);
                    grPhoto2.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    grPhoto2.SmoothingMode = SmoothingMode.AntiAlias;
                    grPhoto2.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    grPhoto2.CompositingQuality = CompositingQuality.HighQuality;

                    grPhoto2.DrawImage(mainImage,
                        new Rectangle(-1, -1, imgthumbwidth + 2, imgthumbheight + 2),
                        new Rectangle(-1, -1, mainImage.Width + 2, mainImage.Height + 2),
                        GraphicsUnit.Pixel);
                    grPhoto2.Dispose();
                    thumbnail2.Save(HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\" + foldername + "\\medium\\" + ProudctImageThumb);
                    thumbnail2.Dispose();

                    //==create icon of the image
                    string ProductImageIcon = pimage;
                    Bitmap thumbnail3 = new Bitmap(imgiconwidth, imgiconheight, PixelFormat.Format24bppRgb);
                    thumbnail3.SetResolution(mainImage.HorizontalResolution, mainImage.VerticalResolution);
                    Graphics grPhoto3 = Graphics.FromImage(thumbnail3);
                    grPhoto3.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    grPhoto3.SmoothingMode = SmoothingMode.AntiAlias;
                    grPhoto3.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    grPhoto3.CompositingQuality = CompositingQuality.HighQuality;

                    grPhoto3.DrawImage(mainImage,
                        new Rectangle(-1, -1, imgiconwidth + 2, imgiconheight + 2),
                        new Rectangle(-1, -1, mainImage.Width + 2, mainImage.Height + 2),
                        GraphicsUnit.Pixel);
                    grPhoto3.Dispose();
                    thumbnail3.Save(HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\" + foldername + "\\small\\" + ProductImageIcon);
                    thumbnail3.Dispose();
                }
                else
                {


                    if (mainImage.Width < medium | mainImage.Height < medium)
                    {
                        if (mainImage.Width > mainImage.Height)
                        {


                            imgiconwidth = small;
                            imgiconheight = (mainImage.Height * small) / mainImage.Width;

                        }
                        else if (mainImage.Width < mainImage.Height)
                        {

                            imgiconheight = small;
                            imgiconwidth = (mainImage.Width * small) / mainImage.Height;
                        }
                        else if (mainImage.Width == mainImage.Height)
                        {
                            imgiconheight = small;
                            imgiconwidth = small;
                        }
                        mainImage.Save(HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\" + foldername + "\\large\\" + pimage);
                        mainImage.Save(HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\" + foldername + "\\medium\\" + pimage);

                        //==create icon of the image
                        string ProductImageIcon = pimage;
                        Bitmap thumbnail3 = new Bitmap(imgiconwidth, imgiconheight, PixelFormat.Format24bppRgb);
                        thumbnail3.SetResolution(mainImage.HorizontalResolution, mainImage.VerticalResolution);
                        Graphics grPhoto3 = Graphics.FromImage(thumbnail3);
                        grPhoto3.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        grPhoto3.SmoothingMode = SmoothingMode.AntiAlias;
                        grPhoto3.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        grPhoto3.CompositingQuality = CompositingQuality.HighQuality;

                        grPhoto3.DrawImage(mainImage,
                            new Rectangle(-1, -1, imgiconwidth + 2, imgiconheight + 2),
                            new Rectangle(-1, -1, mainImage.Width + 2, mainImage.Height + 2),
                            GraphicsUnit.Pixel);
                        grPhoto3.Dispose();
                        thumbnail3.Save(HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\" + foldername + "\\small\\" + ProductImageIcon);
                        thumbnail3.Dispose();
                    }
                }
            }
            mainImage.Dispose();
            return true;
        }

        public static bool DeleteImage(string cimage, string foldername)
        {

            System.IO.FileInfo image = new System.IO.FileInfo(HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\" + foldername + "\\" + cimage);
            bool isfileUploaded = image.Exists;
            if (isfileUploaded)
            {
                GC.Collect();
                try
                {
                    image.Delete();
                }
                catch
                {

                }
            }
            System.IO.FileInfo image1 = new System.IO.FileInfo(HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\" + foldername + "\\large\\" + cimage);
            bool isfileUploaded1 = image1.Exists;
            if (isfileUploaded1)
            {
                GC.Collect();
                try
                {
                    image1.Delete();
                }
                catch
                {

                }
            }
            System.IO.FileInfo image2 = new System.IO.FileInfo(HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\" + foldername + "\\medium\\" + cimage);
            bool isfileUploaded2 = image2.Exists;
            if (isfileUploaded2)
            {
                GC.Collect();
                try
                {
                    image2.Delete();
                }
                catch
                {

                }
            }
            System.IO.FileInfo image3 = new System.IO.FileInfo(HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\" + foldername + "\\small\\" + cimage);
            bool isfileUploaded3 = image3.Exists;
            if (isfileUploaded3)
            {
                GC.Collect();
                try
                {
                    image3.Delete();
                }
                catch
                {

                }
            }


            return true;
        }

        public static bool ExistsImage(string folder, string imagename)
        {
            bool retvale = false;
            try
            {
                System.IO.FileInfo image = new System.IO.FileInfo(HttpContext.Current.Request.PhysicalApplicationPath + "userfiles\\" + folder + "\\" + imagename);
                bool isfileUploaded = image.Exists;

                if (isfileUploaded)
                {
                    retvale = true;
                }
            }
            catch { }
            return retvale;
        }
        #endregion


        #region Change Currency Start
        public static string ChangeCurrencyWithSymbol(string Price)
        {
            WestZoneEntities db = new WestZoneEntities();
            //var Data = db.SiteConfigurations.Find(1);

            //int Currencydigit = AdminSiteConfiguration.Currencydigit;
            //string CurrencySymbol = AdminSiteConfiguration.CurrencySymbol;
            if (Price.Trim() != "")
            {
                Price = "AED " + GetPrice(Price);//+ " " + "DH";
            }
            return Price;
        }

        public static string ChangeCurrencyWithoutSymbol(string Price)
        {
            WestZoneEntities db = new WestZoneEntities();
            //var Data = db.SiteConfigurations.Find(1);

            //int Currencydigit = AdminSiteConfiguration.Currencydigit;
            //string CurrencySymbol = AdminSiteConfiguration.CurrencySymbol;
            if (Price.Trim() != "")
            {
                Price = GetPrice(Price);//+ " " + "DH";
            }
            return Price;
        }

        public static string ChangeCurrencyWithPercentage(string Price)
        {
            WestZoneEntities db = new WestZoneEntities();
            //var Data = db.SiteConfigurations.Find(1);

            //int Currencydigit = AdminSiteConfiguration.Currencydigit;
            //string CurrencySymbol = AdminSiteConfiguration.CurrencySymbol;
            if (Price.Trim() != "")
            {
                Price = GetPrice(Price) + " %";
            }
            return Price;
        }

        public static string ChangePhone_AddPrefix(string Price)
        {
            WestZoneEntities db = new WestZoneEntities();
            //var Data = db.SiteConfigurations.Find(1);

            //int Currencydigit = AdminSiteConfiguration.Currencydigit;
            //string CurrencySymbol = AdminSiteConfiguration.CurrencySymbol;
            if (Price != "")
            {
                Price = "+971 " + GetPrice(Price);//+ " " + "DH";
            }
            return Price;
        }

        public static string Change_InvoiceNo(int no)
        {
            string number = "#" + no.ToString().PadLeft(2, '0');
            return number;
        }


        public static string ChangeCurrency(string Price)
        {
            return GetPrice(Price);
        }

        public static string GetPrice(string number)
        {
            string returnval = "";
            try
            {
                //returnval = Convert.ToString((double.Parse(number)));

                returnval = Convert.ToString(Math.Round(Convert.ToDecimal(number), 2));
            }
            catch
            {
            }
            return returnval;
        }
        #endregion


        #region Get Remove Special Character Code Start
        public static string RemoveSpecialCharacter(String name)
        {
            name = name.Trim();

            StringBuilder sb = new StringBuilder();
            foreach (char c in name)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        #endregion


        #region Get URL Code Start
        public static string GetURL()
        {
            return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/";

        }
        #endregion



        #region Get Date Code Start

        public static string GetDateformat(string date)
        {
            string retval = "";
            try
            {
                DateTime currDate = Convert.ToDateTime(date);
                //TimeSpan time = new TimeSpan(0, -1, -30, 0);
                //DateTime combined = currDate.Add(time);
                DateTime octoberUtc = new DateTime(2012, 10, 1, 0, 0, 0, DateTimeKind.Utc);
                retval = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(currDate));
            }
            catch { }
            return retval;
        }
        public static string GetDatetimeformat(string date)
        {
            string retval = "";
            try
            {
                DateTime currDate = Convert.ToDateTime(date);
                //TimeSpan time = new TimeSpan(0, -1, -30, 0);
                //DateTime combined = currDate.Add(time);
                DateTime octoberUtc = new DateTime(2012, 10, 1, 0, 0, 0, DateTimeKind.Utc);
                retval = string.Format("{0: dd/MM/yyyy hh:mm}", Convert.ToDateTime(currDate));
            }
            catch { }
            return retval;
        }
        public static string GetDatetimeformatwithAMPM(string date)
        {
            string retval = "";
            try
            {
                DateTime currDate = Convert.ToDateTime(date);
                //TimeSpan time = new TimeSpan(0, -1, -30, 0);
                //DateTime combined = currDate.Add(time);
                DateTime octoberUtc = new DateTime(2012, 10, 1, 0, 0, 0, DateTimeKind.Utc);
                retval = string.Format("{0:MM/dd/yyyy hh:mm:ss tt}", Convert.ToDateTime(currDate));
            }
            catch { }
            return retval;
        }
        public static string GetDate24HoursFormat(string date)
        {
            string retval = "";
            try
            {
                DateTime currDate = Convert.ToDateTime(date);
                //TimeSpan time = new TimeSpan(0, -1, -30, 0);
                //DateTime combined = currDate.Add(time);
                DateTime octoberUtc = new DateTime(2012, 10, 1, 0, 0, 0, DateTimeKind.Utc);
                retval = string.Format("{0:dd/MM/yyyy HH:mm:ss}", Convert.ToDateTime(currDate));
            }
            catch { }
            return retval;
        }
        public static string GetDate24HoursFormatMMMDD(string date)
        {
            string retval = "";
            try
            {
                DateTime currDate = Convert.ToDateTime(date);
                //TimeSpan time = new TimeSpan(0, -1, -30, 0);
                //DateTime combined = currDate.Add(time);
                DateTime octoberUtc = new DateTime(2012, 10, 1, 0, 0, 0, DateTimeKind.Utc);
                retval = string.Format("{0:MMM dd, yyyy HH:mm:ss}", Convert.ToDateTime(currDate));
            }
            catch { }
            return retval;
        }
        public static string GetFullDate(string date)
        {
            string retval = "";
            try
            {
                DateTime currDate = Convert.ToDateTime(date);
                //TimeSpan time = new TimeSpan(0, -1, -30, 0);
                //DateTime combined = currDate.Add(time);
                DateTime octoberUtc = new DateTime(2012, 10, 1, 0, 0, 0, DateTimeKind.Utc);
                retval = string.Format("{0:ddd MMM dd yyyy HH:mm:ss 'GMT'}", Convert.ToDateTime(currDate));
            }
            catch { }
            return retval;
        }
        public static string GetDateDateTime(string date)
        {
            string retval = "";
            try
            {
                DateTime currDate = Convert.ToDateTime(date);
                //TimeSpan time = new TimeSpan(0, -1, -30, 0);
                //DateTime combined = currDate.Add(time);
                DateTime octoberUtc = new DateTime(2012, 10, 1, 0, 0, 0, DateTimeKind.Utc);
                retval = string.Format("{0:dd/MM/yyyy hh:mm:ss}", Convert.ToDateTime(currDate));
            }
            catch { }
            return retval;
        }
        public static string GetShortDate(string date)
        {
            string retval = "";
            try
            {
                DateTime currDate = Convert.ToDateTime(date);
                //TimeSpan time = new TimeSpan(0, -1, -30, 0);
                //DateTime combined = currDate.Add(time);
                DateTime octoberUtc = new DateTime(2012, 10, 1, 0, 0, 0, DateTimeKind.Utc);
                retval = string.Format("{0:dd/MMM/yyyy}", Convert.ToDateTime(currDate));
            }
            catch { }
            return retval;
        }
        public static string GetDate1(string date)
        {
            string retval = "";
            try
            {
                DateTime currDate = Convert.ToDateTime(date);
                //TimeSpan time = new TimeSpan(0, -1, -30, 0);
                //DateTime combined = currDate.Add(time);
                DateTime octoberUtc = new DateTime(2012, 10, 1, 0, 0, 0, DateTimeKind.Utc);
                retval = string.Format("{0:MMM dd, yyyy}", Convert.ToDateTime(currDate));
            }
            catch
            {
            }

            return retval;
        }
        public static string GetMonthDateFormat(string date)
        {
            string retval = "";
            try
            {
                DateTime currDate = Convert.ToDateTime(date);
                //TimeSpan time = new TimeSpan(0, -1, -30, 0);
                //DateTime combined = currDate.Add(time);
                DateTime octoberUtc = new DateTime(2012, 10, 1, 0, 0, 0, DateTimeKind.Utc);
                retval = string.Format("{0:MMM - yyyy}", Convert.ToDateTime(currDate));
            }
            catch
            {
            }

            return retval;
        }
        public static string PriceWithComma(string number)
        {
            string returnval = "";
            try
            {
                //returnval = Convert.ToString((double.Parse(number)));

                //returnval = Convert.ToString(Math.Round(Convert.ToDecimal(number), 2));
                //returnval = Convert.ToDecimal(number).ToString("#,##0.00");
                //returnval= string.Format("{0:0.00}", number);
                returnval = Convert.ToDecimal(number).ToString("#,##0.00");
                // returnval = Convert.ToString(Math.Round(Convert.ToDecimal(number), 2));



            }
            catch
            {
            }
            return returnval;
        }
        public static string RoundPriceWithComma(string number)
        {
            string returnval = "";
            try
            {
                //returnval = Convert.ToString((double.Parse(number)));

                //returnval = Convert.ToString(Math.Round(Convert.ToDecimal(number), 2));
                //returnval = Convert.ToDecimal(number).ToString("#,##0.00");
                //returnval= string.Format("{0:0.00}", number);
                  returnval = Convert.ToInt32(number).ToString("#,##");
               // returnval = Convert.ToString(Math.Round(Convert.ToDecimal(number), 2));



            }
            catch
            {
            }
            return returnval;
        }
        public static string GetDatestatusmsg(string date)
        {
            string retval = "";
            try
            {
                retval = string.Format("{0:MMM dd, yyyy hh:mm tt}", Convert.ToDateTime(date));
            }
            catch
            {
            }

            return retval;
        }
        public static string GetDate(string date)
        {
            string retval = "";
            try
            {
                retval = string.Format("{0:MMM dd, yyyy}", Convert.ToDateTime(date));
            }
            catch
            {
            }

            return retval;
        }
        public static string CleanNUmber(string pdfname)
        {
            string data = "";
            try
            {
                data = Regex.Replace(pdfname, @"[\d-]", string.Empty);
            }
            catch { };
            return data;
        }
        public static string GetDateDisplay(string date)
        {
            string retval = "";
            try
            {
                //retval = string.Format("{0:dd MMM yyyy}", Convert.ToDateTime(date));
                retval = string.Format("{0:dd MMM yyyy}", Convert.ToDateTime(date));
            }
            catch
            {
            }

            return retval;
        }

        public static string GetDateAndTime(string date)
        {
            string retval = "";
            try
            {
                retval = string.Format("{0:MMMM dd, yyyy}", Convert.ToDateTime(date));
            }
            catch
            {
            }

            return retval;

        }
        public static string GetDateAndTimeFormat(string date)
        {
            string retval = "";
            try
            {
                retval = string.Format("{0:MMMM dd, yyyy hh:mm tt}", Convert.ToDateTime(date));
            }
            catch
            {
            }
            return retval;
        }

        public static string GetDateedit_dayformat(string date)
        {
            string retval = "";
            try
            {
                retval = string.Format("{0:dddd MMMM d, yyyy}", Convert.ToDateTime(date));
            }
            catch
            {

            }

            return retval;
        }


        public static string GetDateTime_TimeDiffreance(string timespan1, string timespan2)
        {
            try
            {
                TimeSpan between = DateTime.Parse(timespan2).Subtract(DateTime.Parse(timespan1));
                return between.TotalHours.ToString();
            }
            catch
            {
                return "";
            }

        }

        public static int GetDate_year(string date)
        {
            string retval = "";
            try
            {
                retval = string.Format("{0:yyyy}", Convert.ToDateTime(date));
            }
            catch
            {
            }

            return Convert.ToInt32(retval);

        }
        public static int GetDate_month(string date)
        {
            string retval = "";
            try
            {
                retval = string.Format("{0:MM}", Convert.ToDateTime(date));
            }
            catch
            {
            }

            return Convert.ToInt32(retval);

        }

        public static int GetDate_day(string date)
        {
            string retval = "";
            try
            {
                retval = string.Format("{0:dd}", Convert.ToDateTime(date));
            }
            catch
            {
            }

            return Convert.ToInt32(retval);

        }

        public static int GetDate_hours(string date)
        {
            string retval = "";
            try
            {
                retval = string.Format("{0:HH}", Convert.ToDateTime(date));
            }
            catch
            {
            }

            return Convert.ToInt32(retval);

        }

        public static int GetDate_min(string date)
        {
            string retval = "";
            try
            {
                retval = string.Format("{0:mm}", Convert.ToDateTime(date));
            }
            catch
            {
            }

            return Convert.ToInt32(retval);

        }

        public static string Get_time_display(string date)
        {
            string retval = "";
            try
            {
                retval = string.Format("{0:HH:mm}", Convert.ToDateTime(date));
            }
            catch
            {
            }

            return retval;

        }

        #endregion

        #region Get Random No
        public static int GetRandomNo()
        {
            Random rn = new Random();
            int i = 0;
            i = rn.Next(1, 10000);
            return i;
        }
        public static int GetRandomNo(int noofcount)
        {
            Random rn = new Random();
            int i = 0;
            i = rn.Next(1, noofcount);
            return i;
        }
        #endregion
        public static string getvalue(string no)
        {
            string value = "";
            value = Convert.ToString(Math.Round(Convert.ToDecimal(no), 2));
            return value;
        }
        #region Viewsing Record
        public static string GetArrayForRecord()
        {
            return "10:10,50:50,100:100";//,All:0";
        }
        #endregion

        #region Viewsing 100 Record for report only
        public static string GetArrayForRecordReport()
        {
            return "10:10,50:50,100:100";//,All:0";
        }
        #endregion

        #region Alpha Search
        public static string GetArrayForAlphaRecord()
        {
            return "[0-9]:0,A:A,B:B,C:C,D:D,E:E,F:F,G:G,H:H,I:I,J:J,K:K,L:L,M:M,N:N,O:O,P:P,Q:Q,R:R,S:S,T:T,U:U,V:V,W:W,X:X,Y:Y,Z:Z,ALL:";
        }
        #endregion

        #region All Record
        public static string GetArrayForSearchRecord()
        {
            return "All Record:1,Active Record:2,In Active Record:3";
        }

        public static string GetvalueForSearchRecord(string ArrayValue)
        {
            string rtnval = "";
            if (ArrayValue.Trim() == 2.ToString())
            {
                rtnval = true.ToString();
            }
            if (ArrayValue.Trim() == 3.ToString())
            {
                rtnval = false.ToString();
            }
            return rtnval;
        }
        #endregion

        #region Get Code Top of Page Start
        public static void ToTopOfPage(Page sender, Type e)
        {

            ScriptManager.RegisterStartupScript(sender, e.GetType(), "ToTheTop", "setTimeout('window.scrollTo(0, 0)', 0);", true);
            sender.Page.MaintainScrollPositionOnPostBack = false;
        }
        #endregion

        #region Get Control Index
        public static int GetControlIndex(String controlID)
        {
            try
            {
                Regex regex = new Regex("([0-9.*]{2})",
                           RegexOptions.RightToLeft);
                Match match = regex.Match(controlID);
                return Convert.ToInt32(match.Value);


            }
            catch
            {


                Regex regex = new Regex("([0-9.*])",
                              RegexOptions.RightToLeft);
                Match match = regex.Match(controlID);
                return Convert.ToInt32(match.Value);
            }
        }
        #endregion

      
    }
}