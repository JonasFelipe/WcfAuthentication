using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using WCF_TokenSecurity.Data;
using WCF_TokenSecurity.Data.Models;
using WCF_TokenSecurity.Interfaces;
using WCF_TokenSecurity.Models;
using WCF_TokenSecurity.Utils;

namespace WCF_TokenSecurity.Business
{
    public class DatabaseTokenBuilder : ITokenBuilder
    {
        public static int TokenSize = 100;
        private readonly TokenRepository tokenRepository;
        private readonly UserRepository userRepository;
        public DatabaseTokenBuilder()
        {
            tokenRepository = new TokenRepository();
            userRepository = new UserRepository();
        }
        public string Build(Credentials creds)
        {
            var token = BuildSecureToken(TokenSize);
            creds.Password = Hash.Get(creds.Password, Hash.HashType.SHA256);
            var user = userRepository.GetUser(creds.User);

            Tokens tokenUser = new Tokens(token, user.Id, DateTime.Now);
            tokenRepository.InsertToken(tokenUser);

            return token;
        }

        private string BuildSecureToken(int length)
        {
            var buffer = new byte[length];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetNonZeroBytes(buffer);
            }
            return Convert.ToBase64String(buffer);
        }
    }
}