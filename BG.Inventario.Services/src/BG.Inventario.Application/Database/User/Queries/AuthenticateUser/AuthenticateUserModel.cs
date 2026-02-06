using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.User.Queries.AuthenticateUser
{
    public class AuthenticateUserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
