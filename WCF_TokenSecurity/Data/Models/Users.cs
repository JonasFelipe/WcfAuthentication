using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_TokenSecurity.Data.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}