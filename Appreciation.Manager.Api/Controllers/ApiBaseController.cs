using AutoMapper;
using System;
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

        protected string GetError(Exception ex)
        {
            return $"{ex.Message} \n{ex.InnerException?.Message} \n{ex.StackTrace}";
        }
    }
}