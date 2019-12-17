using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
    public class NoteEvaluateController : ApiBaseController
    {
        private readonly INoteEvaluateService _service;

        public NoteEvaluateController(IMapper mapper, INoteEvaluateService noteEvaluate) : base(mapper)
        {
            _service = noteEvaluate;

        }

        [HttpPost]
        [Route("api/NoteEvaluate/Add")]
        public async Task<IHttpActionResult> AddNoteEvaluate([FromBody]AddNoteEvaluateRequest request)
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
        [Route("api/NoteEvaluate/Update")]
        public async Task<IHttpActionResult> UpdateNoteEvaluate([FromBody]UpdateNoteEvaluateRequest request)
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
        [Route("api/NoteEvaluate")]
        public async Task<IHttpActionResult> NoteEvaluateList()
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
        [Route("api/NoteEvaluate/id")]
        public async Task<IHttpActionResult> NoteEvaluateById([FromUri] long id)
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
