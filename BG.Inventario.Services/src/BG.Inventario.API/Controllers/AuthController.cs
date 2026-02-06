using BG.Inventario.Application.Database.User.Queries.AuthenticateUser;
using BG.Inventario.Application.External.GetTokenJwt;
using BG.Inventario.Application.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BG.Inventario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(
            [FromServices] IAuthenticateUserQuery services,
            [FromServices] IGetTokenJwtService getTokenJwtService,
            [FromBody] AuthenticateUserModel model
        )
        {
            try
            {
                var data = await services.Execute(model);
                if(data == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status200OK, data));
                }

                data.Token = getTokenJwtService.Execute(data.UserId.ToString());

                return Ok(ResponseApiService.Response(StatusCodes.Status200OK, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, ex.Message));
            }
        }
    }
}
