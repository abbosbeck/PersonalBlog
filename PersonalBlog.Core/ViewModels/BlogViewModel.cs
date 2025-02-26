using PersonalBlog.Data.Entities;

namespace PersonalBlog.Core.ViewModels
{
    public class BlogViewModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public DateOnly PublishedAt { get; set; }

        public static explicit operator BlogViewModel(BlogEntity blogEntity)
        {
            return new BlogViewModel
            {
                Title = blogEntity.Title,
                Slug = blogEntity.Slug,
                Content = blogEntity.Content,
                AuthorId = blogEntity.AuthorId,
                PublishedAt = blogEntity.PublishedAt
            };
        }
    }
}
