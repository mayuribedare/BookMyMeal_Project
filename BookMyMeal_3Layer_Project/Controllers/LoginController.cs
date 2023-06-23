using BAL_BMM.Interface;
using DL_BMM.Models;
using DL_BMM.request;
using DL_BMM.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Login.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        private readonly ILoginBAL _Loginbal;
        public Login(ILoginBAL loginBAL)
        {
            _Loginbal = loginBAL;
        }

        [HttpPost("Authentication")]
        public async Task<ActionResult<LoginResponse>> GetByUsernameAndPassword(LoginRequest req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            var res = await _Loginbal.Authenticate(req.Email, req.Password);
            if (res == null)
            {
                return NotFound(new { Message = "User Not Found" });
            }


            res.employee.Token = CreateJWT(res.employee);

            return Ok(new
            {
                Token = res.employee.Token,
                Message = "Login successful",
                res.employee.Eid
            });

        }
        private string CreateJWT(Employee employee)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authentication");
            var Identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, employee.Email),
                //new Claim(ClaimTypes.Name, employee.Email)
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = Identity,
                Expires = DateTime.Now.AddSeconds(30),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);

        }

    }
}
