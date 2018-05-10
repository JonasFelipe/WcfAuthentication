using System;
using System.Configuration;
using System.Data;
using AlternateFramework.DAL;
using WCF_TokenSecurity.Data.Interface;

namespace WCF_TokenSecurity.Data
{
    internal class RepositoryBase : IRepositorio, IDisposable
    {
        protected IDbTransaction transaction { get; private set; }
        private IDbConnection connection;
        public IDbConnection Connection
        {
            get
            {
                return connection;
            }
            private set
            {
                connection = value;
            }
        }

        internal RepositoryBase()
        {
            var dal = new GenericClient(AlternateFramework.Data.DatabaseClients.MsSqlServer, ConfigurationManager.ConnectionStrings["ConnectionWCF"].ConnectionString);
            SetConnection(dal.Connection);
        }

        public void SetConnection(IDbConnection connection)
        {
            this.connection = connection;
        }

        public void SetTransaction(IDbTransaction transaction)
        {
            this.connection = transaction.Connection;
            this.transaction = transaction;
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}