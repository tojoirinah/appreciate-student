using Appreciation.Manager.Services.Contracts;
using AutoMapper;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
    [Authorize]
    public class BehaviorController : ApiBaseController
    {
        protected readonly IBehaviorService _service;

        public BehaviorController(IMapper mapper, IBehaviorService behaviorService) : base(mapper)
        {
            _service = behaviorService;
        }

        [HttpGet]
        [Route("api/Behavior")]
        public async Task<IHttpActionResult> BehaviorList()
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
