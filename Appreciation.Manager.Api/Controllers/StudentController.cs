using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using Appreciation.Manager.Utils;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
   // [Authorize]
    public class StudentController : ApiBaseController
    {
        protected readonly IStudentService _studentService;

        public StudentController(IMapper mapper,IStudentService studentService) : base(mapper)
        {
            _studentService = studentService;
        }
        
        [HttpPost]
        [Route("api/Student/Add")]
        public async Task<IHttpActionResult> AddStudent([FromBody]AddStudentRequest studentReq)
        {
            try
            {
                Student student = _mapper.Map<Student>(studentReq);
                await _studentService.AddOrUpdateAsync(student);
                return Ok();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return BadRequest();
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Student/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Student
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Student/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
        }
    }
}
