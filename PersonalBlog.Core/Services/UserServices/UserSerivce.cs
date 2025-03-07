using Microsoft.EntityFrameworkCore;
using PersonalBlog.Core.Helpers;
using PersonalBlog.Core.ViewModels.UserViewModels;
using PersonalBlog.Data;

namespace PersonalBlog.Core.Services.UserServices
{
    public class UserSerivce : IUserService
    {
        private readonly AppDbContext _appDbContext;
        public UserSerivce(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<AuthenticatedUser> AuthenticateAsync(UserLoginViewModel userLoginViewModel)
        {
            userLoginViewModel.Password = StringHasher.HashPassword(userLoginViewModel.Password);

            var user = await _appDbContext.Users
                            .FirstOrDefaultAsync(u => u.Username == userLoginViewModel.Username &
                                                            u.Password == userLoginViewModel.Password);

            if (user == null)
            {
                throw new Exception("There is no user with this credentials");
            }

            return Token
        }

        public Task<AuthenticatedUser> RegisterAsync(UserRegisterViewModel userRegisterViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticatedUser> UpdateUserDataAsyn(AuthenticatedUser authenticatedUser)
        {
            throw new NotImplementedException();
        }
    }
}
