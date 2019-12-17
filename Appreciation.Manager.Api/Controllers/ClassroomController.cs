using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
    public class ClassroomController : ApiBaseController
    {
        protected readonly IClassroomService _service;

        public ClassroomController(IMapper mapper, IClassroomService classroomService) : base(mapper)
        {
            _service = classroomService;
        }

        // add
        [HttpPost]
        [Route("api/Classroom/Add")]
        public async Task<IHttpActionResult> AddClassroom([FromBody]AddClassroomRequest request)
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

        // update
        [HttpPut]
        [Route("api/Classroom/Update")]
        public async Task<IHttpActionResult> UpdateClassroom([FromBody]UpdateClassroomRequest request)
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

        // delete
        [HttpDelete]
        [Route("api/Classroom/Delete")]
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

        // get
        [HttpGet]
        [Route("api/Classroom")]
        public async Task<IHttpActionResult> ClassroomList()
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
        [Route("api/Classroom/id")]
        public async Task<IHttpActionResult> ClassroomById(long id)
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
    }
}
