using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF_TokenSecurity.Data;
using WCF_TokenSecurity.Data.Models;
using WCF_TokenSecurity.Interfaces;

namespace WCF_TokenSecurity.Business
{
    public class DatabaseTokenValidator : ITokenValidator 
    {
        public static double DefaultSecondsUntilTokenExpires = 1800;
        private readonly TokenRepository tokenRepository;

        public DatabaseTokenValidator()
        {
            tokenRepository = new TokenRepository();
        }

        public bool IsValid(string tokentext)
        {
            var token = tokenRepository.GetToken(tokentext);
            return token != null && !IsExpired(token);
        }

        internal bool IsExpired(Tokens token)
        {
            var span = DateTime.Now - token.CreateDate;
            return span.TotalSeconds > DefaultSecondsUntilTokenExpires;
        }
    }
}