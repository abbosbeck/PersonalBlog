namespace PersonalBlog.Data.Entities
{
    public class BlogImageEntity
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public Guid BlogId { get; set; }
        public BlogEntity Blog { get; set; }
    }
}
