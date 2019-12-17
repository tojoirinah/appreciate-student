using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
    public class BehaviorEvaluateController : ApiBaseController
    {
        private readonly IBehaviorEvaluateService _service;

        public BehaviorEvaluateController(IMapper mapper, IBehaviorEvaluateService service) : base(mapper)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/BehaviorEvalute/Add")]
        public async Task<IHttpActionResult> AddBehaviorEvalute([FromBody]AddBehaviorEvaluateRequest request)
        {
            try
            {
                await _service.AddAsync(request);
                await _service.CommitAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                await _service.RollbackAsync();
                return BadRequest(GetError(ex));
            }
        }

        [HttpPut]
        [Route("api/BehaviorEvalute/Update")]
        public async Task<IHttpActionResult> UpdateBehaviorEvalute([FromBody]UpdateBehaviorEvaluateRequest request)
        {
            try
            {
                await _service.UpdateAsync(request);
                await _service.CommitAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                await _service.RollbackAsync();
                return BadRequest(GetError(ex));
            }
        }

        [HttpGet]
        [Route("api/BehaviorEvalute")]
        public async Task<IHttpActionResult> BehaviorEvaluteList()
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

        [HttpGet]
        [Route("api/BehaviorEvalute/id")]
        public async Task<IHttpActionResult> BehaviorEvaluteById([FromUri] long id)
        {
            try
            {
                var student = await _service.GetByIdAsync(id);
                await _service.CommitAsync();
                return Ok(new { Item = student });
            }
            catch (Exception ex)
            {
                await _service.RollbackAsync();
                return BadRequest(GetError(ex));
            }
        }
    }
}
