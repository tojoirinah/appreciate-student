using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
    public class UsersController : ApiBaseController
    {
        protected readonly IUsersService _service;

        public UsersController(IMapper mapper, IUsersService usersService) : base(mapper)
        {
            _service = usersService;
        }

        [HttpPost]
        [Route("api/Users/AddAdmin")]
        public async Task<IHttpActionResult> AddUsersAdmin([FromBody]AddUsersRequest request)
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
        [Route("api/Users/UpdateInformation")]
        public async Task<IHttpActionResult> UpdateInformation([FromBody]UpdateInformationUsersRequest request)
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

    }
}
