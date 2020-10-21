using Framework.Common.Helpers;
using Framework.Common.Service;
using Framework.Common.Sqlhelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PLW.Data.Entity;
using PLW.Data.IService;
using PLW.Data.Model;
using System;
using System.Data.SqlClient;

namespace PLW.Data.Service
{
    public class UserService : BaseService<User, ApplicationDbContext>, IUserService
    {
        private readonly AppConfig _appConfig;
        private readonly string _connString;
         
        public UserService(ILogger<UserService> logger, ApplicationDbContext context,
        IConfiguration configuration, IOptions<AppConfig> AppConfig) : base(logger, context)
        {
            _appConfig = AppConfig.Value;
            _connString = configuration.GetConnectionString(_appConfig.ConnectionName);
        }

        public bool CheckUserLogin(string account, string password)
        {
            try
            {
                if (_appConfig.IsTestEnvironment)
                {
                    return true;
                }
                SqlParameter[] paramArr = new SqlParameter[] {
                    new SqlParameter("@account", account),
                    new SqlParameter("@password", EncryptHelper.EncryptMD5(password))          
                };

                var result = Sqlhelper.ExecuteScalar(_connString, "Proc_CheckUserLogin", paramArr);
                return Convert.ToBoolean(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Proc_CheckUserLogin :" + ex.Message);
                throw ex;
            };
        }

        public string RegisterUser(User model)
        {
            try
            {
                SqlParameter[] paramArr = new SqlParameter[] {
                    new SqlParameter("@account", model.Account),
                    new SqlParameter("@password", EncryptHelper.EncryptMD5(model.Password)),
                    new SqlParameter("@email", model.Email),
                    new SqlParameter("@lastName", model.LastName),
                    new SqlParameter("@firstName", model.FirstName)
                };

                var result = Sqlhelper.ExecuteScalar(_connString, "Proc_RegisterUser", paramArr);
                return result.ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Proc_RegisterUser :" + ex.Message);
                throw ex;
            };
        }
    }
}
