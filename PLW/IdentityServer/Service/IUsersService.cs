namespace IdentityServer.Service
{
    public interface IUsersService
    {
        bool CheckUserLogin(string account, string password);
    }
}
