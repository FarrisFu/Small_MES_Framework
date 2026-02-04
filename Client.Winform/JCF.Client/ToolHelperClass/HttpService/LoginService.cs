using JCF.Service.HttpCore;
using JCF.Service.ModelRequests;
using JCF.Service.ModelResults;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolHelperClass.HttpService
{
    public  class LoginService
    {
        public static async Task<HttpResult<LoginResult>> Login(LoginRequest user)
        {
            var result = await HttpHelper.PostAsync<LoginRequest, LoginResult>("Auth/login", user);
            return result;
        }
    }
}
