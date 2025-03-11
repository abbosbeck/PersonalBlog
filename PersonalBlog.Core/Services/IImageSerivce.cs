using Microsoft.AspNetCore.Http;

namespace PersonalBlog.Core.Services
{
    public interface IImageSerivce
    {
        Task<string> SaveImageAsync(IFormFile imageFile, string blogSlug);
        Task<IEnumerable<string>> SaveImagesAsync(IEnumerable<IFormFile> imageFiles, string blogSlug);
        Task<IEnumerable<string>> GetAllImagesAsync();
    }
}
