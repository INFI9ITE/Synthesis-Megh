using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace wwwroot.Areas.Admin.Models
{
    public class DocumentCreate
    {
        public int Id { get; set; }

        [Required(ErrorMessage = " ")]
        public string Title { get; set; }

        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> StoreId { get; set; }
        public string StoreName { get; set; }
        public string CategoryName { get; set; }
                
        public string Notes { get; set; }
               
        public string Description { get; set; }

//        [Required(ErrorMessage = " ")]
        public string KeyWords { get; set; }

        public string FilePath { get; set; }
        public string AttachFile { get; set; }
        public string AttachExtention { get; set; }
        public string FileTypeImage { get; set; }
        

        public string FullPath { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedDateFormated { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public string CreatedByName { get; set; }
        public string ModifyByName { get; set; }

        public Nullable<bool> IsPrivate { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public bool IsPrivateN { get; set; }
        public Nullable<bool> IsFavorite { get; set; }
        public string chkPrivate { get; set; }
        public string chkFav { get; set; }

        public DocumentFavorites docFavorite { get; set; }
        public List<ddllist> CategoryList { get; set; }
        public List<ddllist> DocumentkeywordList { get; set; }
        public List<ddllist> StoreList { get; set; }

        public string strErrMessage { get; set; }
    }

    public class DocumentGallery
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> StoreId { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
        public string AttachFile { get; set; }
        public string AttachExtention { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsPrivate { get; set; }
        public Nullable<bool> IsDelete { get; set; }

    }

    public class DocumentFavorites
    {
        public int Id { get; set; }
        public Nullable<int> DocId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> IsFavorite { get; set; }
    }

    public class DocumentCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Documentkeyword
    {
        public int Id { get; set; }
        public Nullable<int> DocID { get; set; }
        public string Title { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }

    public class DocumentGridCommon
    {
        public List<DocumentGrid> docGridList { get; set; }

        public Nullable<int> CategoryId { get; set; }
        public List<ddllist> CategoryList { get; set; }
    }
    public class DocumentGrid
    {
    
        public int Id { get; set; }
        public string Type { get; set; }
        public bool isprivate { get; set; }
        public bool isFavorite { get; set; }
        public string DocTitle { get; set; }
        public string storeName { get; set; }
        public string categoryName { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> StoreId { get; set; }

        public string Notes { get; set; }
        public string Description { get; set; }
        public string KeyWords { get; set; }
        public string AttachFile { get; set; }
        public string AttachPath { get; set; }
        public string AttachExtention { get; set; }
        public string FileTypeImage { get; set; }
        public string AttachLink { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedDateFormated { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public int IsStatus_id { get; set; }
        public int FavId { get; set; }
        
    }
}