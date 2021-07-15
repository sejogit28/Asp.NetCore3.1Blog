using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlServerConnect.Models
{
    public class SubComments : Comments
    {
        public int CommentsCommentId { get; set; }
       public Comments Comments { get; set; } 
       
    }
}
