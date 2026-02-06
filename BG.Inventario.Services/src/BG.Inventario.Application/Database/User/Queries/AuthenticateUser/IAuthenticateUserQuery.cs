using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.User.Queries.AuthenticateUser
{
    public interface IAuthenticateUserQuery
    {
        Task<AuthenticateUserResponse> Execute(AuthenticateUserModel model);
    }
}
