using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
    [Authorize]
    public class StudentExamController : ApiBaseController
    {
        private readonly IStudentExamService _service;

        public StudentExamController(IMapper mapper, IStudentExamService service) : base(mapper)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/StudentExam/Add")]
        public async Task<IHttpActionResult> AddStudentExam([FromBody]AddStudentExamRequest request)
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
        [Route("api/StudentExam/Update")]
        public async Task<IHttpActionResult> UpdateStudentExam([FromBody]UpdateStudentExamRequest request)
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

        [HttpPost]
        [Route("api/StudentExam")]
        public async Task<IHttpActionResult> StudentExamList([FromBody] StudentExamSearchRequest request)
        {
            try
            {
                var list = await _service.SearchStudentExam(request);
                await _service.CommitAsync();
                return Ok(new { List = list });
            }
            catch (Exception ex)
            {
                await _service.RollbackAsync();
                return BadRequest(GetError(ex));
            }
        }

        [HttpPost]
        [Route("api/StudentExam/Generate")]
        public async Task<IHttpActionResult> StudentExamGenerate()
        {
            try
            {
                await _service.GenerateComment();
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
        [Route("api/StudentExam/id")]
        public async Task<IHttpActionResult> StudentExamById([FromUri] long id)
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
