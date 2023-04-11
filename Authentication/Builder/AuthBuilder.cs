using Authentication.Builder.Rules;
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
            return this;
        }
    }
}
