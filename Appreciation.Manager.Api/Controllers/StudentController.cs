using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
    [Authorize]
    public class StudentController : ApiBaseController
    {
        protected readonly IStudentService _service;

        public StudentController(IMapper mapper, IStudentService studentService) : base(mapper)
        {
            _service = studentService;
        }

        [HttpPost]
        [Route("api/Student/Add")]
        public async Task<IHttpActionResult> AddStudent([FromBody]AddStudentRequest studentReq)
        {
            try
            {
                await _service.AddAsync(studentReq);
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
        [Route("api/Student/Update")]
        public async Task<IHttpActionResult> UpdateStudent([FromBody]UpdateInformationStudentRequest studentReq)
        {
            try
            {
                await _service.UpdateAsync(studentReq);
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
        [Route("api/Student")]
        public async Task<IHttpActionResult> StudentList()
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
        [Route("api/Student/id")]
        public async Task<IHttpActionResult> StudentById([FromUri] long id)
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
