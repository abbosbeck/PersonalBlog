using PersonalBlog.Data.Entities;

namespace PersonalBlog.Core.ViewModels.UserViewModels
{
    public class AuthenticatedUser
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string GitHub { get; set; }
        public string LinkedIn { get; set; }
        public string Telegram { get; set; }

        public static explicit operator AuthenticatedUser(UserEntity user)
        {
            return new AuthenticatedUser
            {
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                GitHub = user.GitHub,
                LinkedIn = user.LinkedIn,
                Telegram = user.Telegram,
            };
        }
    }
}
