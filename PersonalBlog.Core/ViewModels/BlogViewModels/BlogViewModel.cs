namespace PersonalBlog.Core.ViewModels.BlogViewModels
{
    public class BlogViewModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public DateOnly PublishedAt { get; set; }
    }
}
