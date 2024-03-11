using DataAccess.EShop2.Entities;
using DataAccess.EShop2.EntitiesFramework;
using DataAccess.EShop2.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EShop2.Services
{
    public class PostService : IPostService
    {
        private EShopDbContext _Context;
        public PostService(EShopDbContext context)
        {
            _Context = context;
        }

        public async Task<Post> GetPostByCategoryId(GetPostByCategoryId requestData)
        {
            try
            {
                var list = _Context.Post.ToList();
                var post = list.Where(s => s.CategoryId == requestData.CategoryId).FirstOrDefault();
                return post;
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        public async Task<Post> GetPostById(GetPostByIdRequestData requestData)
        {
            try
            {
                var list = _Context.Post.ToList();
                var post = list.Where(s=>s.PostId == requestData.PostId).FirstOrDefault();
                return post;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<Post>> GetPostList()
        {
            try
            {
                var list = _Context.Post.ToList();
                return list;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ReturnData> Post_Delete(PostDeleteRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                if (requestData == null || requestData.PostId <= 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Dữ liệu đầu vào ko hợp lệ";
                    return returnData;
                }

                var list = _Context.Post.ToList();
                var post = list.Where(s => s.PostId == requestData.PostId).FirstOrDefault();
                if (post == null || post.PostId <= 0)
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMsg = "Không tìm thấy Post";
                    return returnData;
                }
                _Context.Post.Remove(post);
                var result = _Context.SaveChanges();
                if (result < 0)
                {
                    returnData.ReturnCode = -3;
                    returnData.ReturnMsg = "Xóa thất bại";
                    return returnData;
                }
                else
                {
                    returnData.ReturnCode = 1;
                    returnData.ReturnMsg = "Xóa thành công";
                    return returnData;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ReturnData> Post_InsertUpdate(Post post)
        {
            var returnData = new ReturnData();  
            try
            {
                if(post.PostId <=0)
                {
                    _Context.Post.Add(post);
                    _Context.SaveChanges();
                    returnData.ReturnCode = 1;
                    returnData.ReturnMsg = "Thêm Thành công";
                    return returnData;
                }
                

                else
                {
                    _Context.Post.Update(post);
                    _Context.SaveChanges();
                    returnData.ReturnCode = 1;
                    returnData.ReturnMsg = "Sửa Thành công";
                    return returnData;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
