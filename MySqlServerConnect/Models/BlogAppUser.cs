using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlServerConnect.Models
{
    public class BlogAppUser : IdentityUser
    {

        [Required]
        [MaxLength(50)]
        [Display(Name = "Full Name")]
        public string GovName { get; set; }


        [Required]
        [Column(TypeName = "varchar(10)")]
        [Display(Name = "Date Joined")]
        //yyyy-mm-dd
        public string DateJoined { get; set; }

        public bool IsAuthor { get; set; }

        
        [MaxLength(2000)]
        public string Bio { get; set; }

       
        [MaxLength(100)]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        public bool IsAdmin { get; set; }


        public ICollection<Comments> Comments { get; set; }
    }
}
