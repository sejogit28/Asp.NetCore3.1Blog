using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlServerConnect.Models
{
    public class Posts
    {
        [Key]
        public int PostId { get; set;}

        [Required]
        [Column(TypeName = "varchar(80)")]
        public string BlogAppUserId { get; set; }

        [Required]
        public string AuthorName { get; set; }
       

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(400)]
        public string Summary { get; set; }

        

        [Required]
        
        //yyyy-mm-dd
        public DateTime DatePosted { get; set; }
        //Research if there is a way to put dates in MySQL through entity framework

        [Required]
        public string Text { get; set; }

        
        [MaxLength(200)]
        public string ImageURL { get; set; }

        [Required]
        public int ReadTime { get; set; }
        //Readtime is in minutes but just the number will be put
        //

        public int TagId { get; set;}

        public IList<Comments> Comments { get; set; }

        public ICollection<PostsTags> PostTags { get; set; }
    }


    
    
    public class PostsTags 
    {
        
        public int PostsPostId { get; set; }
        public Posts Posts { get; set; }

        public int TagsTagId { get; set; }
        public Tags Tags { get; set; }
        


    }
}
