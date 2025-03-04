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
        public Task<AuthenticatedUser> AuthenticateAsync(UserLoginViewModel userLoginViewModel)
        {
            throw new NotImplementedException();
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
