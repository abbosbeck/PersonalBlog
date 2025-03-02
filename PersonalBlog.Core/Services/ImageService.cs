using Microsoft.AspNetCore.Http;
using PersonalBlog.Data;
using Microsoft.AspNetCore.Hosting;
using PersonalBlog.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace PersonalBlog.Core.Services
{
    public class ImageService : IImageSerivce
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ImageService(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> SaveImageAsync(IFormFile imageFile, string blogSlug)
        {
            try
            {
                var file = imageFile;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string wwwrootPath = _webHostEnvironment.WebRootPath;
                string filePath = Path.Combine(wwwrootPath, "uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var blogId = await _appDbContext.Blogs
                    .Where(x => x.Slug == blogSlug)
                    .Select(x => x.Id).FirstOrDefaultAsync();

                var newImage = new BlogImageEntity
                {
                    Url = fileName,
                    BlogId = blogId
                };

                await _appDbContext.BlogImages.AddAsync(newImage);
                await _appDbContext.SaveChangesAsync();
             
                return newImage.Url;
            }
            catch (Exception ex)
            {

                throw new Exception("Something went wrong: {0}", ex);
            }
        }

        public async Task<IEnumerable<string>> SaveImagesAsync(IEnumerable<IFormFile> imageFiles, string blogSlug)
        {
            try
            {
                var blogId = await _appDbContext.Blogs
                    .Where(x => x.Slug == blogSlug)
                    .Select(x => x.Id).FirstOrDefaultAsync();

                List<BlogImageEntity> blogImages = new List<BlogImageEntity>();
                List<string> urls = new List<string>();
                foreach (var file in imageFiles)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string wwwrootPath = _webHostEnvironment.WebRootPath;
                    string filePath = Path.Combine(wwwrootPath, "uploads", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var newImage = new BlogImageEntity
                    {
                        Url = fileName,
                        BlogId = blogId
                    };

                    blogImages.Add(newImage);
                    urls.Add(newImage.Url);
                }
               
                await _appDbContext.BlogImages.AddRangeAsync(blogImages);
                await _appDbContext.SaveChangesAsync();

                return urls;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong: {0}", ex);
            }
        }
    }
}
