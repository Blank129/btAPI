using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EShop2.Entities
{
    public class Post
    {
        public int PostId { get; set; } 
        public string PostName { get; set; }
        public int CategoryId { get; set; }
    }

    public class GetPostByIdRequestData
    {
        public int PostId { get; set;}
    }

    public class PostDeleteRequestData
    {
        public int PostId { get; set; }
    }
    public class GetPostByCategoryId
    {
        public int CategoryId { get; set; }
    }
}
