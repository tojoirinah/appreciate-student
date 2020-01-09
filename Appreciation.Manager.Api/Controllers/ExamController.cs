using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
    [Authorize]
    public class ExamController : ApiBaseController
    {
        protected readonly IExamService _service;

        public ExamController(IMapper mapper, IExamService service) : base(mapper)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/Exam/Add")]
        public async Task<IHttpActionResult> AddExam([FromBody]AddExamRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.AddAsync(request);
                    await _service.CommitAsync();
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                await _service.RollbackAsync();
                return BadRequest(GetError(ex));
            }
        }

        [HttpPut]
        [Route("api/Exam/Update")]
        public async Task<IHttpActionResult> UpdateExam([FromBody]UpdateExamRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(request);
                    await _service.CommitAsync();
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                await _service.RollbackAsync();
                return BadRequest(GetError(ex));
            }
        }

        [HttpGet]
        [Route("api/Exam")]
        public async Task<IHttpActionResult> ExamList()
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
        [Route("api/Exam/id")]
        public async Task<IHttpActionResult> ExamById([FromUri] long id)
        {
            try
            {
                var item = await _service.GetByIdAsync(id);
                await _service.CommitAsync();
                return Ok(new { Item = item });
            }
            catch (Exception ex)
            {
                await _service.RollbackAsync();
                return BadRequest(GetError(ex));
            }
        }

        [HttpDelete]
        [Route("api/Exam/Delete")]
        public async Task<IHttpActionResult> DeleteClassroom([FromUri]long id)
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
