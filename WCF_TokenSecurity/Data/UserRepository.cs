using AlternateFramework.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using Dapper;
using System.Linq;
using System.Web;
using WCF_TokenSecurity.Data.Models;

namespace WCF_TokenSecurity.Data
{
    internal class UserRepository : RepositoryBase
    {
        private readonly GenericClient dal;

        internal UserRepository()
        {
            dal = new GenericClient(AlternateFramework.Data.DatabaseClients.MsSqlServer, ConfigurationManager.ConnectionStrings["ConnectionWCF"].ConnectionString);
        }

        internal Users GetUser(string user)
        {
            var userDbo = Connection.QueryFirstOrDefault<Users>(@"Select * from [dbo].[User] as U where U.[User] = @User", new
            {
                User = user
            }, transaction: transaction);

            return userDbo;
        }

        internal bool GetUserValid(string user, string password)
        {
            var valid = Connection.ExecuteScalar<int>(@"Select 1 from [dbo].[User] as U where U.[User] = @User and U.[Password] = @Password", new
            {
                User = user,
                Password = password
            }, transaction: transaction);

            return valid == 1;
        }
    }
}