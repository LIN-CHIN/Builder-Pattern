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
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost()]
        public IActionResult Login(DbUser dbUser) 
        {
            var builder = AuthBuilder.CreateBuilder()
                                     .AddAuthUserIdRule()
                                     .AddAuthUserPwdRule()
                                     .AddCustomRule(AuthEmailCustomRule)
                                     .Build();

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

        private CustomRuleResultModel AuthEmailCustomRule(DbUser dbUser) 
        {
            CustomRuleResultModel customRuleResultModel = new CustomRuleResultModel();

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
