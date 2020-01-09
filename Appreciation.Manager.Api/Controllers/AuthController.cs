using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using Appreciation.Manager.Utils;
using AutoMapper;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
    public class AuthController : ApiBaseController
    {
        protected readonly IUsersService _userService;

        public AuthController(IMapper mapper, IUsersService userService) : base(mapper)
        {
            _userService = userService;
        }

        // POST: /api/Auth/SignIn
        [HttpPost]
        [Route("api/Auth/Signin")]
        public async Task<IHttpActionResult> SignIn([FromBody]AuthenticationRequest req)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userService.Login(req);
                    if (user != null)
                    {
                        var claimIdentity = new ClaimsIdentity(new Claim[] {
                    new Claim("UserId",user.Id.ToString()),
                    new Claim("RoleId",user.RoleId.ToString()),
                    new Claim("UserName",user.UserName)
                });

                        var token = JwtTokenHelper.CreateToken(
                            claimIdentity,
                            Settings.TokenExpire,
                            Settings.JwtSecretKey
                            );

                        return Ok(new { Token = token });
                    }
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.StatusCode = 500;
                throw ex;
            }
        }
    }
}
