using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersonalBlog.Core.Helpers;
using PersonalBlog.Core.ViewModels.UserViewModels;
using PersonalBlog.Data;

namespace PersonalBlog.Core.Services.UserServices
{
    public class UserSerivce : IUserService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        public UserSerivce(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
        }
        public async Task<string> AuthenticateAsync(UserLoginViewModel userLoginViewModel)
        {
            userLoginViewModel.Password = StringHasher.HashPassword(userLoginViewModel.Password);

            var user = await _appDbContext.Users
                            .FirstOrDefaultAsync(u => u.Username == userLoginViewModel.Username &
                                                            u.Password == userLoginViewModel.Password);

            if (user == null)
            {
                throw new Exception("There is no user with this credentials");
            }

            var authenticatedUser = (AuthenticatedUser)user;

            var jwtTokenGenerator = new JWTTokenGenerator(_configuration);


            return jwtTokenGenerator.GenerateToken(authenticatedUser.Username);
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
