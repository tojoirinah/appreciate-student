using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
    [Authorize]
    public class BehaviorEvaluateController : ApiBaseController
    {
        private readonly IBehaviorEvaluateService _service;

        public BehaviorEvaluateController(IMapper mapper, IBehaviorEvaluateService service) : base(mapper)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/BehaviorEvaluate/Add")]
        public async Task<IHttpActionResult> AddBehaviorEvalute([FromBody]AddBehaviorEvaluateRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.AddAsync(request);
                    await _service.CommitAsync();
                    return Ok();
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                await _service.RollbackAsync();
                return BadRequest(GetError(ex));
            }
        }

        [HttpPut]
        [Route("api/BehaviorEvaluate/Update")]
        public async Task<IHttpActionResult> UpdateBehaviorEvalute([FromBody]UpdateBehaviorEvaluateRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(request);
                    await _service.CommitAsync();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                await _service.RollbackAsync();
                return BadRequest(GetError(ex));
            }
        }

        [HttpPost]
        [Route("api/BehaviorEvaluate")]
        public async Task<IHttpActionResult> BehaviorEvaluteList([FromBody] BehaviorEvaluateSearchRequest request)
        {
            try
            {
                var list = await _service.SearchBehaviorEvaluate(request);
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
        [Route("api/BehaviorEvaluate/id")]
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

        [HttpDelete]
        [Route("api/BehaviorEvaluate/Delete")]
        public async Task<IHttpActionResult> Delete([FromUri]long id)
        {
            try
            {
                await _service.RemoveAsync(id);
                await _service.CommitAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                await _service.RollbackAsync();
                return BadRequest(GetError(ex));
            }
        }
    }
}
