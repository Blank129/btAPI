using DataAccess.EShop2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EShop2.IServices
{
    public interface IPostService
    {
        Task<List<Post>> GetPostList();
        Task<Post> GetPostById(GetPostByIdRequestData requestData);
        Task<Post> GetPostByCategoryId(GetPostByCategoryId requestData);
        Task<ReturnData> Post_Delete(PostDeleteRequestData requestData);
        Task<ReturnData> Post_InsertUpdate(Post post);

    }
}
