using Framework.Common.Service;
using PLW.Data.Entity;

namespace PLW.Data.IService
{
    public interface IUserService : IBaseService<User, ApplicationDbContext>
    {
        bool CheckUserLogin(string account, string password);
        string RegisterUser(User model);
    }
}
