using JCF.Application.Contracts.Results;
using JCF.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JCF.Web.Controllers
{
    /// <summary>
    /// 生产日志查询
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OperationLogController : Controller
    {
        private readonly OperationLogService _OperationLogService;
        public OperationLogController(OperationLogService operationLogService)
        {
            _OperationLogService = operationLogService;
        }

        [HttpGet]
        public async Task<ActionResult> GetOperationLogs()
        {
            var result = await _OperationLogService.GetOperationLogList();
            return Ok(result);
        }

        [Authorize(Policy = "OperationLogRead")]
        [HttpPost]
        public async Task<ActionResult> AddOperationLogs()
        {
            var result = await _OperationLogService.AddOperationLogList();
            return Ok(result);
        }
    }

}
