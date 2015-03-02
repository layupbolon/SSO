using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class User
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public User(string userName,string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public User() { }
    }
}
