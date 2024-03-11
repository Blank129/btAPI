using DataAccess.EShop2.Entities;
using DataAccess.EShop2.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet("GetPost")]
        public async Task<ActionResult> GetPost()
        {
            var list = new List<Post>();
            list = await _postService.GetPostList();
            return Ok(list);
        }
        [HttpPost("PostDelete")]
        public async Task<ActionResult> PostDelete(PostDeleteRequestData requestData)
        {
            var returnData = new ReturnData();
            returnData = await _postService.Post_Delete(requestData);
            return Ok(returnData);
        }
        [HttpPost("PostInsert_Update")]
        public async Task<ActionResult> PostInsert_Update(Post post)
        {
            var returnData = new ReturnData();
            returnData = await _postService.Post_InsertUpdate(post);
            return Ok(returnData);
        }
        [HttpPost("GetPostById")]
        public async Task<ActionResult> GetPostById(GetPostByIdRequestData requestData)
        {
            var list = new Post();
            list  = await _postService.GetPostById(requestData);
            return Ok(list);
        }
        [HttpPost("GetPostByCategoryId")]
        public async Task<ActionResult> GetPostByCategoryId(GetPostByCategoryId requestData)
        {
            var list = new Post();
            list = await _postService.GetPostByCategoryId(requestData);
            return Ok(list);
        }
    }
}
