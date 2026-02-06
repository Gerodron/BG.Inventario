using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.User.Queries.AuthenticateUser
{
    public class AuthenticateUserResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}
