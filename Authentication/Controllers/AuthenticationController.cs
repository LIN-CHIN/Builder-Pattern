using Authentication.Builder;
using Authentication.Builder.Rules;
using Authentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet()]
        public IActionResult Post() 
        {
            DbUser dbUser = new DbUser
            {
                UserId = "",
                UserName = "chin",
                Phone = "0912345678",
                Email = "xxx@gmail.com"
            };

            var builder = AuthBuilder.CreateBuilder()
                                     .AddAuthUserIdRule()
                                     .Build();

            if (!builder.Authenticate(dbUser, out List<string> messages)) 
            {
                return Ok(new
                {
                    code = 10001,
                    content = messages,
                    message = "error"
                });
            }

            return Ok(new
            {
                code = 200,
                content = "",
                message = "success"
            });
        }
    }
}
