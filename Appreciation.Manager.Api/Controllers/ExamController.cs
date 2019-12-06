using Appreciation.Manager.Api.App_Start;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
    public class ExamController : ApiBaseController
    {
        protected readonly IExamService _service;

        public ExamController(IMapper mapper, IExamService service) : base(mapper)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/Exam/Add")]
        public IHttpActionResult AddExam([FromBody]AddExamRequest request)
        {
            try
            {
                var entity = _mapper.Map<Exam>(request);
                _service.AddOrUpdateAsync(entity);
                _service.Completed();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return BadRequest();
        }

        // GET: api/Exam
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Exam/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Exam
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Exam/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Exam/5
        public void Delete(int id)
        {
        }
    }
}
