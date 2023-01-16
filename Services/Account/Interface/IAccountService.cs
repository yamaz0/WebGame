using Microsoft.AspNetCore.Identity;
using WebGame.Models.Account;

namespace WebGame.Services.Account.Interface
{
    public interface IAccountService
    {
        Task<SignInResult> Login(LoginModel loginModel);
        Task<IdentityResult> Register(RegisterModel registerModel);
        Task Logout();
    }
}