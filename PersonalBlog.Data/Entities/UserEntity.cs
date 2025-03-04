namespace PersonalBlog.Data.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string GitHub { get; set; }
        public string LinkedIn { get; set; }
        public string Telegram { get; set; }
        public List<BlogEntity> Blogs { get; set; }
    }
}
