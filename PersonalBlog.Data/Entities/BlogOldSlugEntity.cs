namespace PersonalBlog.Data.Entities
{
    public class BlogOldSlugEntity
    {
        public Guid Id { get; set; }
        public string OldSlug { get; set; }
        public Guid BlogId { get; set; }
        public DateTime CreatedDate { get; set; }
        public BlogEntity Blog { get; set; }
    }
}
