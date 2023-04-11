using Authentication.Models;

namespace Authentication.Builder.Rules
{
    public interface IRule
    {
        /// <summary>
        /// 驗證
        /// </summary>
        /// <param name="dbUser"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Authenticate(DbUser dbUser, out string message);
    }
}
