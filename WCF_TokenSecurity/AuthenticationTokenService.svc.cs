using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Authentication;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using WCF_TokenSecurity.Business;
using WCF_TokenSecurity.Interfaces;
using WCF_TokenSecurity.Models;

namespace WCF_TokenSecurity
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AuthenticationTokenService : IAuthenticationTokenService
    {
        public string Authenticate()
        {
            var user = HttpContext.Current.Request.Headers["Username"];
            var password = HttpContext.Current.Request.Headers["Password"];
            Credentials creds = new Credentials(user, password);
            ICredentialsValidator validator = new DatabaseCredentialsValidator();
            if (validator.IsValid(creds))
                return new DatabaseTokenBuilder().Build(creds);
            throw new InvalidCredentialException("Invalid credentials");
        }
    }
}
