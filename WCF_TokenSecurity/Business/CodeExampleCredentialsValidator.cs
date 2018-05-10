using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF_TokenSecurity.Interfaces;
using WCF_TokenSecurity.Models;
using WCF_TokenSecurity.Utils;

namespace WCF_TokenSecurity.Business
{
    public class CodeExampleCredentialsValidator : ICredentialsValidator
    {
        public bool IsValid(Credentials creds)
        {
            //Check for valid creds here
            //I compared using hashes only for example purposes
            if (creds.User == "user1" && Hash.Get(creds.Password, Hash.HashType.SHA256) == Hash.Get("pass1", Hash.HashType.SHA256))
            {
                return true;
            }
            return false;
        }
    }
}