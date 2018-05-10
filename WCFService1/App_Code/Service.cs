using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public string Test()
    {
        var token = HttpContext.Current.Request.Headers["Token"];
        ITokenValidator validator = new CodeExampleTokenValidator();
        if (validator.IsValid(token))
        {
            return "Your token worked!";
        }
        else
        {
            return "Your token failed!";
        }
    }
}
