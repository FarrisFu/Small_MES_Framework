using JCF.Service.HttpCore;
using JCF.Service.ModelRequests;
using JCF.Service.ModelResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolHelperClass.DbEntity;

namespace ToolHelperClass.HttpService
{
    public class OperationLogService
    {
        //public static async Task<HttpResult<List<OperationLogEntity>>> Login(LoginRequest user)
        //{
        //    var result = await HttpHelper.PostAsync<LoginRequest, List<OperationLogEntity>>("OperationLog/AddOperationLogs", user);
        //    return result;
        //}

        public static async Task<HttpResult<List<OperationLogEntity>>> GetOperationLogs()
        {
            var result = await HttpHelper.GetAsync<List<OperationLogEntity>>("OperationLog/GetOperationLogs");
            return result;
        }
    }
}
