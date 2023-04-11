using Authentication.Builder.Rules;
using Authentication.Models;
using System.Runtime.CompilerServices;

namespace Authentication.Builder
{
    public class AuthBuilder
    {
        private Authenticator _authenticator;

        public AuthBuilder() 
        {
            _authenticator = new Authenticator();
        }    

        /// <summary>
        /// 建立Builder 
        /// </summary>
        /// <returns></returns>
        public static AuthBuilder CreateBuilder() 
        {
            return new AuthBuilder();
        }

        /// <summary>
        /// 建立Authenticator
        /// </summary>
        /// <returns></returns>
        public Authenticator Build() 
        {
            return _authenticator;
        }

        /// <summary>
        /// 建立驗證UserId規則
        /// </summary>
        /// <returns></returns>
        public AuthBuilder AddAuthUserIdRule() 
        {
            _authenticator.AddRule(new AuthUserIdRule());
            //_authenticator.AddRule(new TestRule() 
            //{
            //    Vaildate = dbUser => 
            //    {
            //        if (dbUser.UserId == "") 
            //        {
            //            return false;
            //        }

            //        return true;
            //    },
            //    Message = "is not empty"
            //});
            return this;
        }

        /// <summary>
        /// 建立驗證UserPwd規則
        /// </summary>
        /// <returns></returns>
        public AuthBuilder AddAuthUserPwdRule()
        {
            _authenticator.AddRule(new AuthUserPwdRule());
            return this;
        }

        public AuthBuilder AddCustomRule(Func<DbUser, CustomRuleResultModel> func) 
        {
            _authenticator.AddRule(new CustomRule()
            {
                Vaildate = func
            });
            return this;
        }

    }
}
