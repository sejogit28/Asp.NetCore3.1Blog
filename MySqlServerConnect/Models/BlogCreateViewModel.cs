using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlServerConnect.Models
{
    public class BlogCreateViewModel
    {
        [Key]
        public int PostId { get; set; }


        

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(400)]
        public string Summary { get; set; }

        [MaxLength(200)]
        public string ImageURL { get; set; }

       
        
        [Display(Name = "Date Posted")]
        //yyyy-mm-dd
        public DateTime DatePosted { get; set; }
        //Research if there is a way to put dates in MySQL through entity framework


        [Required]
        public string Text { get; set; }


        [Required]
        public int ReadTime { get; set; }
        //Readtime is in minutes but just the number will be put

        public int TagId { get; set; }

        
        public IEnumerable<Comments> Comments { get; set; }

        public ICollection<PostsTags> PostTags { get; set; }
    }

}
