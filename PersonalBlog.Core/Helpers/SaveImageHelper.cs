using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace PersonalBlog.Core.Helpers
{
    public class SaveImageHelper
    {
        public static async Task<string> SaveAndCreateImagePathAsync(IFormFile image, 
                                                    IWebHostEnvironment webHostEnvironment)
        {
            var file = image;
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string wwwrootPath = webHostEnvironment.WebRootPath;
            string filePath = Path.Combine(wwwrootPath, "images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}
