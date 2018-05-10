using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using WCF_TokenSecurity.Interfaces;
using WCF_TokenSecurity.Models;

namespace WCF_TokenSecurity.Business
{
    public class CodeExampleTokenBuilder : ITokenBuilder
    {
        internal static string StaticToken = "{B709CE08-D2DE-4201-962B-3BBAC74C5952}";
        public string Build(Credentials creds)
        {
            if (new CodeExampleCredentialsValidator().IsValid(creds))
            {
                return StaticToken;
            }
            throw new AuthenticationException();
        }
    }
}