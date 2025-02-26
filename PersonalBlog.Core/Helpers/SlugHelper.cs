using System.Text.RegularExpressions;

namespace PersonalBlog.Core.Helpers
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return string.Empty;

            string slug = title.ToLower();
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", ""); 
            slug = Regex.Replace(slug, @"\s+", "-"); 
            slug = slug.Trim('-');

            return slug;
        }
    }
}
