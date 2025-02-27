using PersonalBlog.Core.ViewModels.BlogViewModels;

namespace PersonalBlog.Core.Services
{
    public interface IBlogService
    {
        Task<string> AddBlogAsync(BlogCreateAndUpdateViewModel blogCreateViewModel);
        Task<IEnumerable<BlogTitleViewModel>> GetBlogTitlesAsync();
        Task<BlogViewModel> GetBlogBySlugAsync(string slug);
        Task UpdateBlogAsync(string slug, BlogCreateAndUpdateViewModel blogUpdateViewModel);
    }
}
