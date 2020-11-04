using PLW.BL.IBusinessLayer;
using PLW.Data.Entity;
using PLW.Data.IService;

namespace PLW.BL.BusinessLayer
{
    public class UserBLService : IUserBLService
    {
        private IUserService _UserService;

        public UserBLService(IUserService UserService)
        {
            _UserService = UserService;
        }

        public string RegisterUser(User model)
        {
            return _UserService.RegisterUser(model);
        }
        public bool CheckUserLogin(string account, string password)
        {
            return _UserService.CheckUserLogin(account, password);
        }

        public User GetCurrentUserInfo(string account)
        {
            return _UserService.Get(c => c.Account == account)?[0];
        }
    }
}
