using PLW.Data.Entity;

namespace PLW.BL.IBusinessLayer
{
    public interface IUserBLService
    {
        string RegisterUser(User model);
        bool CheckUserLogin(string account, string password);
        User GetCurrentUserInfo(string account);
    }
}
