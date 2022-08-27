using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JGPHR.JobAssignment.API.Helper;
using JGPHR.JobAssignment.Entities;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using JGPHR.JobAssignment.Business;
using JGPHR.JobAssignment.Entity;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JGPHR.JobAssignment.API.Controllers
{
    [Produces("application/json")]
    [Route("api/ProcessCodeData")]
    [Route("api/[controller]/[action]")]
    [Route("JGPHR.JobAssignment.API/api/[controller]")]
    [Route("JGPHR.JobAssignment.API/api/[controller]/[action]")]
    public class ProcessCodeDataController : Controller
    {
        ProcessCodeDataMgr _ProcessCodeDataMgr;

        public ProcessCodeDataController(IOptions<AppSettings> appSettings)
        {
            _ProcessCodeDataMgr = new  ProcessCodeDataMgr(appSettings);
        }

         

        #region CURD
        [HttpPost]
        [ValidateModelStateAttribute]
        public async Task<IActionResult> GetProcessCodeData([FromBody]ProcessCodeDataParam param ,[FromHeader] string EmployeeId)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                param.EmployeeId = EmployeeId;
                var result = await _ProcessCodeDataMgr.GetProcessCodeData(param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [ValidateModelStateAttribute]
        public async Task<IActionResult>  GetProcessCodeDataMain([FromBody]ProcessCodeDataParam param,[FromHeader] string EmployeeId)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                param.EmployeeId = EmployeeId;
                var result = await _ProcessCodeDataMgr.GetProcessCodeDataMain(param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ValidateModelStateAttribute]
        public async Task<IActionResult> InsProcessCodeData([FromBody][FromHeader] string EmployeeId, [FromBody] ProcessCodeDataParam param)
        {
            try
            {
                param.EmployeeId = EmployeeId;
                var result = await _ProcessCodeDataMgr.InsProcessCodeData(param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ValidateModelStateAttribute]
        public async Task<IActionResult> UpdProcessCodeData([FromHeader] string EmployeeId, [FromBody] ProcessCodeDataParam param)
        {
            try
            {
                param.EmployeeId = EmployeeId;
                var result = await _ProcessCodeDataMgr.UpdProcessCodeData(param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ValidateModelStateAttribute]
        public async Task<IActionResult> DelProcessCodeData([FromBody] ProcessCodeDataParam param,[FromHeader] string EmployeeId)
        {
            try
            {
                param.EmployeeId = EmployeeId;
                var result = await _ProcessCodeDataMgr.DelProcessCodeData(param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [ValidateModelStateAttribute]
        public async Task<IActionResult> UnintTest([FromBody] ProcessCodeDataParam param,[FromHeader] string EmployeeId)
        {
            try
            {
                // https://localhost:44378/api/ProcessCodeData/UnintTest
                param.EmployeeId = EmployeeId;
                var result = await _ProcessCodeDataMgr.UnintTest(param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion CURD

        #region Upload
        [HttpPost]
        [ValidateModelStateAttribute]
        public async Task<int> BulkProcessCodeData([FromHeader] string EmployeeId, [FromBody]ProcessCodeDataParam request)
        {
            int result = 0;
            try
            {
                request.CreatedBy = EmployeeId;
                DataTable dt = ConvertGenericListToDataTable.ListToDataTable(request.UploadProcessCodeData);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["TM_UID"] = Guid.NewGuid().ToString();
                        dt.Rows[i]["CreatedBy"] = EmployeeId; //EmployeeId
                        dt.Rows[i]["CreatedTime"] = DateTime.Now; //DateTime
                    }
                }
                await _ProcessCodeDataMgr.BulkDelProcessCodeData(request);
                await _ProcessCodeDataMgr.BulkProcessCodeData(dt);
                result = await _ProcessCodeDataMgr.BulkValidProcessCodeData(request);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        } 
        #endregion Upload
    }
}
