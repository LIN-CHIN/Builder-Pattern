using Authentication.Builder.Rules;
using Authentication.Models;
using System.Runtime.CompilerServices;

namespace Authentication.Builder
{
    /// <summary>
    /// 驗證的Builder
    /// </summary>
    public class AuthenticationBuilder
    {
        private Authenticator _authenticator;

        public AuthenticationBuilder() 
        {
            _authenticator = new Authenticator();
        }    

        /// <summary>
        /// 建立Builder 
        /// </summary>
        /// <returns></returns>
        public static AuthenticationBuilder CreateBuilder() 
        {
            return new AuthenticationBuilder();
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
        public AuthenticationBuilder AddAuthUserIdRule() 
        {
            _authenticator.AddRule(new AuthUserIdRule());
            return this;
        }

        /// <summary>
        /// 建立驗證UserPwd規則
        /// </summary>
        /// <returns></returns>
        public AuthenticationBuilder AddAuthUserPwdRule()
        {
            _authenticator.AddRule(new AuthUserPwdRule());
            return this;
        }

        /// <summary>
        /// 建立自訂的驗證規則
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public AuthenticationBuilder AddCustomRule(Func<DbUser, CustomRuleResponseModel> func) 
        {
            _authenticator.AddRule(new CustomRule()
            {
                Vaildate = func
            });
            return this;
        }

    }
}
