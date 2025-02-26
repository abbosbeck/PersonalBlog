namespace PersonalBlog.Core.ViewModels
{
    public class BlogCreateViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public bool IsPublished { get; set; }
        public DateOnly PublishedAt { get; set; }
    }
}
