using Microsoft.EntityFrameworkCore;

namespace PersonalBlog.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
    }
}
