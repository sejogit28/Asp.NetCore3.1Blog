using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MySqlServerConnect.Models
{
    public class Comments
    {   
        [Key]
        public int CommentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Commentor { get; set; }

        [Required]
        //FK from Posts
        public int PostsPostId { get; set; }
        public Posts Posts { get; set; }

        [Required]
        //FK from Users
        public string UsersUserId { get; set; } 
        public BlogAppUser Users { get; set; }

        
        [MaxLength(200)]
        public string Subject { get; set; }

        
        [MaxLength(3000)]
        public string Text { get; set; }

        [Required]
        //yyyy-mm-dd
        public DateTime DateCreated { get; set; }

        public bool IsSubcomment { get; set; }

        public IList<SubComments> SubComments { get; set; }
    }
}
