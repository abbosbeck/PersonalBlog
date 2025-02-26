namespace PersonalBlog.Data.Entities
{
    public class BlogEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public bool IsPublished { get; set; }
        public DateOnly PublishedAt { get; set; }
    }
}
