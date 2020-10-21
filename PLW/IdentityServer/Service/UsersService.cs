using Framework.Common.Helpers;
using Framework.Common.Sqlhelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Data.SqlClient;

namespace IdentityServer.Service
{
    public class UsersService : IUsersService
    {
        public readonly ILogger Logger;
        public readonly DbContext dc;
        private readonly string _connString;
        private readonly AppConfig _appConfig;

        public UsersService(ILogger<UsersService> logger, AplicationDbContext context , 
                    IConfiguration configuration, IOptions<AppConfig> AppConfig)
        {
            this.dc = context;
            this.Logger = logger;
            _appConfig = AppConfig.Value;
            _connString = configuration.GetConnectionString(_appConfig.ConnectionName);
        }

        public bool CheckUserLogin(string account, string password)
        {
            try
            {
                SqlParameter[] paramArr = new SqlParameter[] {
                    new SqlParameter("@account",account),
                    new SqlParameter("@password",EncryptHelper.EncryptMD5(password))              
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
    }
}
