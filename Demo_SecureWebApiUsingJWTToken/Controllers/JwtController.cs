using Demo_SecureWebApiUsingJWTToken.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Demo_SecureWebApiUsingJWTToken.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class JwtController : ControllerBase
    {
        // Generates the token for us and get it back to us
        [HttpGet]
        public IActionResult Jwt() 
        {
            // Calls GenerateJwtToken method from JwtToken class
            return new ObjectResult(JwtToken.GenerateJwtToken());
        }
    }
}
