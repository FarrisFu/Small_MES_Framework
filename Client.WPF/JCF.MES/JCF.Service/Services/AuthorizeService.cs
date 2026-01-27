using JCF.Service.HttpCore;
using JCF.Service.IServices;
using JCF.Service.ModelRequests;
using JCF.Service.ModelResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Service.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        public async Task<HttpResult<LoginResponse>> Login(LoginRequest user)
        {
            var  result = await HttpHelper.PostAsync<LoginRequest, LoginResponse>("Auth/login", user);
            return result;
        }
    }
}
