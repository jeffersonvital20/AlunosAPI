namespace AlunosAPI.Services
{
    public interface IUserServices
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> RegisterUse(string email, string password);
        Task Logout();
    }
}
