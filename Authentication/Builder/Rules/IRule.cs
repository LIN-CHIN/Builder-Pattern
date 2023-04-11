using Authentication.Models;

namespace Authentication.Builder.Rules
{
    /// <summary>
    /// 所有驗證規則的 Interface
    /// </summary>
    public interface IRule
    {
        /// <summary>
        /// 驗證
        /// </summary>
        /// <param name="dbUser">要驗證的使用者資訊</param>
        /// <param name="message">錯誤訊息</param>
        /// <returns></returns>
        public bool Authenticate(DbUser dbUser, out string message);
    }
}
