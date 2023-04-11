using Authentication.Models;

namespace Authentication.Builder.Rules
{
    /// <summary>
    /// 使用者帳號的驗證規則
    /// </summary>
    public class AuthUserIdRule : IRule
    {
        ///<inheritdoc/>
        public bool Authenticate(DbUser dbUser, out string message)
        {
            message = "";

            if (string.IsNullOrWhiteSpace(dbUser.UserId)) 
            {
                message = "UserId is required";
                return false;
            }

            return true;
        }
    }
}
