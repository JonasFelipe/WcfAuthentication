using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_TokenSecurity.Models
{
    public class Credentials
    {
        public string User { get; set; }
        public string Password { get; set; }

        public Credentials()
        {

        }

        public Credentials(string user, string passowrd)
        {
            this.User = user;
            this.Password = passowrd;
        }
    }
}