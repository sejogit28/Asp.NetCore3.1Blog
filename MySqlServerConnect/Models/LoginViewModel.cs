using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace MySqlServerConnect.Models
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name = "Login Name")]
        public string LoginName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        

    }
}
