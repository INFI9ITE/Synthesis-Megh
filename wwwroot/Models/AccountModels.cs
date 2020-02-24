using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace wwwroot.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile1> UserProfile1 { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile1
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
    public class ForgetPassword
    {


        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Enter Valid E-Mail Address")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required(ErrorMessage = " ")]
        public string Username { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }

    }
    public class ResetPassword
    {
        [Required(ErrorMessage = " ")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The password must be at least 6 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = " ")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The new password and confirmation new password do not match.")]
        public string ConfirmPassword { get; set; }


        public string rt { get; set; }
    }

}
