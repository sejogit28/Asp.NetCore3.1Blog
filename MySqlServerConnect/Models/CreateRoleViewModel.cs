using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlServerConnect.Models
{
    public class CreateRoleViewModel
    {   

        [Required]
        [Display(Name = "Name of Role")]
        public string RoleName { get; set; }



    }
}
