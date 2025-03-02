using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Core.Services;

namespace PersonalBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogImageController : ControllerBase
    {
        private readonly IImageSerivce _imageService;
        public BlogImageController(IImageSerivce imageSerivce)
        {
            _imageService = imageSerivce;
        }

        [HttpPost("Add Image")]
        public async Task<IActionResult> AddImageAsync(IFormFile imageFile, [FromForm] string blogSlug)
        {
            var url = await _imageService.SaveImageAsync(imageFile, blogSlug);
         
            return Ok(url);
        }
        [HttpPost("Add Images")]
        public async Task<IActionResult> AddImagesAsync(IEnumerable<IFormFile> imageFiles, [FromForm] string blogSlug)
        {
            var urls = await _imageService.SaveImagesAsync(imageFiles, blogSlug);

            return Ok(urls);
        }
    }
}
