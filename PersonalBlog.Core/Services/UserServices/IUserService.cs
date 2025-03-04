using PersonalBlog.Core.ViewModels.UserViewModels;

namespace PersonalBlog.Core.Services.UserServices
{
    public interface IUserService
    {
        Task<AuthenticatedUser> AuthenticateAsync(UserLoginViewModel userLoginViewModel);
        Task<AuthenticatedUser> RegisterAsync(UserRegisterViewModel userRegisterViewModel);
        Task<AuthenticatedUser> UpdateUserDataAsyn(AuthenticatedUser authenticatedUser);
    }
}
