using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Core.Services;
using PersonalBlog.Core.ViewModels;
using PersonalBlog.Core.ViewModels.BlogViewModels;

namespace PersonalBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("Blog Titles")]
        public async Task<IActionResult> GetBlogTitlesAsync()
        {
            return Ok(await _blogService.GetBlogTitlesAsync());
        }

        [HttpGet("Blog/{slug}")]
        public async Task<IActionResult> GetBlogBySlugAsync(string slug)
        {
            return Ok(await _blogService.GetBlogBySlugAsync(slug));
        }

        [HttpPost("Add Blog")]
        public async Task<IActionResult> AddBlogAsync([FromBody] BlogCreateAndUpdateViewModel blogCreateViewModel)
        {
            var slug = await _blogService.AddBlogAsync(blogCreateViewModel);
            
            return Ok(slug);
        }

        [HttpPut("{slug}")]
        public async Task<IActionResult> UpdateBlogAsync(string slug, [FromBody] BlogCreateAndUpdateViewModel blogUpdateViewModel)
        {
            await _blogService.UpdateBlogAsync(slug, blogUpdateViewModel);
            
            return Ok();
        }
    }
}
