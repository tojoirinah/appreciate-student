using Appreciation.Manager.Services.Contracts;
using AutoMapper;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
    public class NoteCriteriaController : ApiBaseController
    {
        protected INoteCriteriaService _service;

        public NoteCriteriaController(IMapper mapper, INoteCriteriaService service) : base(mapper)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/NoteCriteria")]
        public async Task<IHttpActionResult> NoteCriteriaList()
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
