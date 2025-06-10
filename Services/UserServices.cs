
using Microsoft.AspNetCore.Identity;

namespace AlunosAPI.Services
{
    public class UserServices : IUserServices
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        public UserServices(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterUse(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
