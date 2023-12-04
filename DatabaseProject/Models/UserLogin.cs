using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{

    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class LoginModel
    {
        public static List<JWTModel> Users = new()
            {
                    new JWTModel(){ Username="naeem",Password="naeem_admin",Role="Admin"}
            };
    }
}
