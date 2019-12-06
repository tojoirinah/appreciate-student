using AutoMapper;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
    public class ApiBaseController : ApiController
    {
        protected readonly IMapper _mapper;

        public ApiBaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

    }
}