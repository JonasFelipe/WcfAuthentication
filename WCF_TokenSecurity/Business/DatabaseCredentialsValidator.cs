using WCF_TokenSecurity.Data;
using WCF_TokenSecurity.Interfaces;
using WCF_TokenSecurity.Models;
using WCF_TokenSecurity.Utils;

namespace WCF_TokenSecurity.Business
{
    public class DatabaseCredentialsValidator : ICredentialsValidator
    {
        private readonly UserRepository userRepository;
        public DatabaseCredentialsValidator()
        {
            userRepository = new UserRepository();
        }

        public bool IsValid(Credentials creds)
        {
            //creds.Password = Hash.Get(creds.Password, Hash.HashType.SHA256);
            var user = userRepository.GetUser(creds.User);

            return user != null && Hash.Compare(creds.Password, user.Salt, user.Password, Hash.DefaultHashType, Hash.DefaultEncoding);
        }
    }
}