using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_TokenSecurity.Data.Interface
{
    internal interface IRepositorio
    {
        IDbConnection Connection { get; }

        void SetTransaction(IDbTransaction transaction);
        void SetConnection(IDbConnection value);
    }
}
