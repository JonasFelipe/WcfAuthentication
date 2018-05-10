using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_TokenSecurity.Models;

namespace WCF_TokenSecurity.Interfaces
{
    interface ITokenBuilder
    {
        string Build(Credentials creds);
    }
}
