using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.External.GetTokenJwt
{
    public interface IGetTokenJwtService
    {
        string Execute(string id);
    }
}
