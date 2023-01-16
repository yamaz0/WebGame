using Microsoft.AspNetCore.Identity;
using WebGame.Entities;
using WebGame.Models.Account;
using WebGame.Services.Account.Interface;

namespace WebGame.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public AccountService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> Login(LoginModel loginModel)
        {
            return await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, false);
        }

        public async Task<IdentityResult> Register(RegisterModel registerModel)
        {
            var newUser = new UserEntity()
            {
                Email = registerModel.Email,
                UserName = registerModel.UserName
            };
            return await _userManager.CreateAsync(newUser, registerModel.Password);
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
