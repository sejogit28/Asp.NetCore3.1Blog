using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlServerConnect.Models
{
    public class Tags
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        [MaxLength(50)]
        public string TagName { get; set; }

       
        public ICollection<PostsTags> PostTags { get; set; }
    }
}
