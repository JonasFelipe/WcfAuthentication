using AlternateFramework.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Dapper;
using System.Web;
using WCF_TokenSecurity.Data.Models;

namespace WCF_TokenSecurity.Data
{
    internal class TokenRepository : RepositoryBase
    {
        private readonly GenericClient dal;

        internal TokenRepository()
        {
            dal = new GenericClient(AlternateFramework.Data.DatabaseClients.MsSqlServer, ConfigurationManager.ConnectionStrings["ConnectionWCF"].ConnectionString);
        }

        internal Tokens GetToken(string token)
        {
            var tokenDbo = Connection.QueryFirstOrDefault<Tokens>(@"Select * from [dbo].[Token] where Token = @Token", new
            {
                Token = token
            }, transaction: transaction);

            return tokenDbo;
        }

        internal void InsertToken(Tokens tokens)
        {
            try
            {
                var sqlInsert = GetCommandInsert();
                Connection.Execute(sqlInsert, tokens, transaction: transaction);

            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao gerar Token: {ex.Message}", ex);
            }
                
        }

        private string GetCommandInsert()
        {
            return @"Insert Into [dbo].[Token]([Token]
							,[UserId]
							,[CreateDate]) 
					Values(@token
							,@userId
							,@createDate)";
        }
    }
}