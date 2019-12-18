using Appreciation.Manager.Services.Contracts;
using AutoMapper;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
    [Authorize]
    public class RoleController : ApiBaseController
    {
        protected readonly IUserRoleService _service;

        public RoleController(IMapper mapper, IUserRoleService userRoleService) : base(mapper)
        {
            _service = userRoleService;
        }

        [HttpGet]
        [Route("api/Role")]
        public async Task<IHttpActionResult> UserRoleList()
        {
            try
            {
                var list = await _service.GetAllAsync();
                await _service.CommitAsync();
                return Ok(new { List = list });
            }
            catch (Exception ex)
            {
                await _service.RollbackAsync();
                return BadRequest(GetError(ex));
            }
        }
    }
}
