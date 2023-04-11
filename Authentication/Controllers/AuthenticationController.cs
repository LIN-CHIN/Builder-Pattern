using Authentication.Builder;
using Authentication.Builder.Rules;
using Authentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace Authentication.Controllers
{
    /// <summary>
    /// 驗證Controller, 作為Client端 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        /// <summary>
        /// 驗證使用者
        /// </summary>
        /// <param name="dbUser">要驗證的使用者資訊</param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult AuthenticateUser(DbUser dbUser) 
        {
            var builder = AuthenticationBuilder.CreateBuilder()
                                     .AddAuthUserIdRule()
                                     .AddAuthUserPwdRule()
                                     .AddCustomRule(AuthEmailCustomRule)
                                     .Build();

            //如果驗證失敗
            if (!builder.Authenticate(dbUser, out List<string> messages)) 
            {
                return Ok(new ApiResponseModel()
                {
                    Code = 10001,
                    Content = messages,
                    Message = "error"
                });
            }

            return Ok(new ApiResponseModel()
            {
                Code = 200,
                Content = "",
                Message = "success"
            });
        }

        /// <summary>
        /// Client自訂的Email驗證規則
        /// </summary>
        /// <param name="dbUser"></param>
        /// <returns></returns>
        private CustomRuleResponseModel AuthEmailCustomRule(DbUser dbUser) 
        {
            CustomRuleResponseModel customRuleResultModel = new CustomRuleResponseModel();

            if (string.IsNullOrEmpty(dbUser.Email)) 
            {
                customRuleResultModel.Result = false;
                customRuleResultModel.Message = "Email is required";
            }
            else
            {
                if (dbUser.Email.IndexOf("@") == 0) 
                {
                    customRuleResultModel.Result = false;
                    customRuleResultModel.Message = "Email format is error";
                }
            }

            return customRuleResultModel;   
        }
    }
}
