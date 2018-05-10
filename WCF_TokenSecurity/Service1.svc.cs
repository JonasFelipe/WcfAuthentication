using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using WCF_TokenSecurity.Business;
using WCF_TokenSecurity.Interfaces;

namespace WCF_TokenSecurity
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        public string Test()
        {
            var token = HttpContext.Current.Request.Headers["Authorization"];
            token = token.Substring(7);
            ITokenValidator validator = new DatabaseTokenValidator();
            return validator.IsValid(token) ? "Your token worked!" : "Your token failed!";
        }

    }
}
