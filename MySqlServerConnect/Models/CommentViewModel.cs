using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlServerConnect.Models
{
    public class CommentViewModel
    {


        [Required]
        //FK from Posts
        public int PostsPostId { get; set; }
         public Posts Posts { get; set; }

        [Required]
        //FK from Users
        public int UserId { get; set; }
        public BlogAppUser Users { get; set; }

        
        [Required]
        [MaxLength(200)]
        public string Subject { get; set; }


        [MaxLength(3000)]
        public string Text { get; set; }

        [Required]
        //yyyy-mm-dd
        public DateTime DateCreated { get; set; }

        public bool IsSubcomment { get; set; }


        public int CommentsCommentId { get; set; }
        public Comments Comments { get; set; }


        public IEnumerable<SubComments> SubComments { get; set; }
    }
}
