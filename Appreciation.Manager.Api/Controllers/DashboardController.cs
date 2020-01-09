using Appreciation.Manager.Services.Contracts;
using AutoMapper;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
    [Authorize]
    public class DashboardController : ApiBaseController
    {
        private IVDashboardExamService _service;

        public DashboardController(IMapper mapper, IVDashboardExamService service) : base(mapper)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/Stats")]
        public async Task<IHttpActionResult> Stats([FromUri] long examid = 0)
        {
            try
            {
                var item = await _service.GenerateDashboard(examid);
                await _service.CommitAsync();
                return Ok(new { Item = item });
            }
            catch (Exception ex)
            {
                await _service.RollbackAsync();
                return BadRequest(GetError(ex));
            }
        }
    }
}
