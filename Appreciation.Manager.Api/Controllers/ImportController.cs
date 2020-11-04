using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;

using AutoMapper;

namespace Appreciation.Manager.Api.Controllers
{
    [Authorize]
    public class ImportController : ApiBaseController
    {
        private readonly IStudentService _studentService;

        public ImportController(IMapper mapper, IStudentService studentService) : base(mapper)
        {
            _studentService = studentService;
        }

        [HttpPost]
        [Route("api/Import/Student")]
        public async Task<IHttpActionResult> ImportFile(List<ImportStudentRequest> request)
        {
          //  if (importFile == null) return Json(new { Status = 0, Message = "No File Selected" });

            try
            {
                var result = await _studentService.ImportDatas(request);
                return Json(new { Status = 1, Message = result });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0, Message = ex.Message });
            }
        }
    }
}
