using Microsoft.EntityFrameworkCore;
using PersonalBlog.Core.Helpers;
using PersonalBlog.Core.ViewModels.BlogViewModels;
using PersonalBlog.Data;
using PersonalBlog.Data.Entities;

namespace PersonalBlog.Core.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _appDbContext;
        public BlogService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> AddBlogAsync(BlogCreateAndUpdateViewModel blogCreateViewModel)
        {
            var blogEntity = (BlogEntity)blogCreateViewModel;
            blogEntity.PublishedAt = DateOnly.FromDateTime(DateTime.Now);
            blogEntity.Slug = SlugHelper.GenerateSlug(blogEntity.Title);
            blogEntity.AuthorId = Guid.NewGuid();

            int count = 1;
            string baseSlug = blogEntity.Slug;
            while (await _appDbContext.Blogs.AnyAsync(x => x.Slug == blogEntity.Slug))
            {
                blogEntity.Slug = $"{baseSlug}-{count}";
            }

            await _appDbContext.Blogs.AddAsync(blogEntity);
            await _appDbContext.SaveChangesAsync();

            return blogEntity.Slug;
        }

        public async Task<BlogViewModel> GetBlogBySlugAsync(string slug)
        {
            var blogEntity = await _appDbContext.Blogs
                .FirstOrDefaultAsync(x => x.Slug == slug);

            if (blogEntity == null)
                throw new Exception("There is no data with this slug");

            return (BlogViewModel)blogEntity;
        }

        public async Task<IEnumerable<BlogTitleViewModel>> GetBlogTitlesAsync()
        {
            var blogTitleAndSlugs = await _appDbContext.Blogs
                .Select(b => new BlogTitleViewModel
                {
                    Title = b.Title,
                    Slug = b.Slug,
                })
                .ToListAsync();

            return blogTitleAndSlugs;
        }

        public async Task UpdateBlogAsync(string slug, BlogCreateAndUpdateViewModel blogUpdateViewModel)
        {
            var blogEntity = await _appDbContext.Blogs.FirstOrDefaultAsync(x => x.Slug == slug);

            if (blogEntity == null)
                throw new Exception("There is no data with this slug");

            blogEntity.Title = blogUpdateViewModel.Title;
            blogEntity.Content = blogUpdateViewModel.Content;
            blogEntity.Slug = SlugHelper.GenerateSlug(blogUpdateViewModel.Title);

            int count = 1;
            string baseSlug = blogEntity.Slug;
            while (await _appDbContext.Blogs.AnyAsync(x => x.Slug == blogEntity.Slug))
            {
                blogEntity.Slug = $"{baseSlug}-{count}";
            }

            await _appDbContext.SaveChangesAsync();
        }
    }
}
