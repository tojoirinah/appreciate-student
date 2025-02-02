﻿using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appreciation.Manager.Api.Controllers
{
    [Authorize]
    public class SchoolYearController : ApiBaseController
    {
        private readonly ISchoolYearService _service;

        public SchoolYearController(IMapper mapper, ISchoolYearService service) : base(mapper)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/SchoolYear/Add")]
        public async Task<IHttpActionResult> AddSchoolYear([FromBody]AddSchoolYearRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.AddAsync(request);
                    await _service.CommitAsync();
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                await _service.RollbackAsync();
                return BadRequest(GetError(ex));
            }
        }

        [HttpPut]
        [Route("api/SchoolYear/Update")]
        public async Task<IHttpActionResult> UpdateSchoolYear([FromBody]UpdateSchoolYearRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(request);
                    await _service.CommitAsync();
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                await _service.RollbackAsync();
                return BadRequest(GetError(ex));
            }
        }

        [HttpPut]
        [Route("api/SchoolYear/SetStatus")]
        public async Task<IHttpActionResult> UpdateStatusSchoolYear([FromBody]UpdateStatusSchoolYearRequest request)
        {
            try
            {
                var item = await _service.UpdateStatusSchoolYear(request);
                await _service.CommitAsync();
                return Ok(new { Item = item });
            }
            catch (Exception ex)
            {
                await _service.RollbackAsync();
                return BadRequest(GetError(ex));
            }
        }

        [HttpGet]
        [Route("api/SchoolYear")]
        public async Task<IHttpActionResult> SchoolYearList()
        {
            try
            {
                var list = await _service.GetAllViewAsync();
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
        [Route("api/SchoolYear/id")]
        public async Task<IHttpActionResult> SchoolYearById([FromUri] long id)
        {
            try
            {
                var student = await _service.GetByIdAsync(id);
                await _service.CommitAsync();
                return Ok(new { Item = student });
            }
            catch (Exception ex)
            {
                await _service.RollbackAsync();
                return BadRequest(GetError(ex));
            }
        }
        [HttpDelete]
        [Route("api/SchoolYear/Delete")]
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
    }
}
