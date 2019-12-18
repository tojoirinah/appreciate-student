using AutoMapper;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
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

        protected long CurrentUserId
        {
            get
            {
                long userid = 0;
                var identity = (ClaimsIdentity)User.Identity;
                IEnumerable<Claim> claims = identity.Claims;
                if (long.TryParse(claims.FirstOrDefault(x => x.Type == "UserId").Value, out userid))
                {
                    return userid;
                }
                return 0;
            }
        }
    }
}