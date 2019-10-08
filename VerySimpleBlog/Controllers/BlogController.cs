using DBRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerySimpleBlog.Controllers
{

    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [Route("page")]
        [HttpGet]
        public async Task<Page<Post>> GetPosts(int pageIndex, string tag)
        {
            return await _blogRepository.GetPosts(pageIndex, 10, tag);
        }
    }

}
