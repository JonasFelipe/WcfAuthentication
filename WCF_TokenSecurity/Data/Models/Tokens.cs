using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_TokenSecurity.Data.Models
{
    public class Tokens
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }

        public Tokens()
        {
        }
        public Tokens(string token, int idUser, DateTime date)
        {
            this.Token = token;
            this.UserId = idUser;
            this.CreateDate = date;
        }
    }
}