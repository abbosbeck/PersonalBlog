using PersonalBlog.Data.Entities;

namespace PersonalBlog.Core.ViewModels
{
    public class BlogCreateViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; }

        public static explicit operator BlogEntity(BlogCreateViewModel blogCreateViewModel)
        {
            return new BlogEntity
            {
                Title = blogCreateViewModel.Title,
                Content = blogCreateViewModel.Content,
                IsPublished = blogCreateViewModel.IsPublished
            };
        }
    }
}    
