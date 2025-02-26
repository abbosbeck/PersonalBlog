using PersonalBlog.Data.Entities;

namespace PersonalBlog.Core.ViewModels
{
    public class BlogCreateAndUpdateViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; }

        public static explicit operator BlogEntity(BlogCreateAndUpdateViewModel blogCreateViewModel)
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
