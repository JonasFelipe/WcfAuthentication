using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF_TokenSecurity.Interfaces;

namespace WCF_TokenSecurity.Business
{
    public class CodeExampleTokenValidator : ITokenValidator
    {
        public bool IsValid(string tokentext)
        {
            return CodeExampleTokenBuilder.StaticToken == tokentext;
        }
    }
}