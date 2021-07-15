using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlServerConnect.Models
{
    public class RegisterViewModel //Used for Authors and Users, Admins will be assigned after the person becomes a User
    {

        [Required]
        [MaxLength(70)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Login Name")]
        public string LoginName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(70)]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9_]+\.[a-zA-Z0-9-.]+$")]
        public string Email { get; set; }

        
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "Emails do not match")]
        public string ConfirmEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
       
        public string Password { get; set; }

      
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]

        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        [MaxLength(100)]
        public string JobTitle { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Bio { get; set; }

        [Required]
        [Display(Name = "Date Joined ")]
        [MaxLength(10)]
        //yyyy-mm-dd
        public string DateJoined { get; set; }
        
    }
}
