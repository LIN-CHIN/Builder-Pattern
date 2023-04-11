using Authentication.Models;

namespace Authentication.Builder.Rules
{
    /// <summary>
    /// 密碼驗證規則
    /// </summary>
    public class AuthUserPwdRule : IRule
    {
        ///<inheritdoc/>
        public bool Authenticate(DbUser dbUser, out string message)
        {
            message = "";

            if (string.IsNullOrWhiteSpace(dbUser.Pwd))
            {
                message = "Pwd is required";
                return false;
            }

            if (dbUser.Pwd.Length < 6 )
            {
                message = "Pwd min length can't < 6";
                return false;
            }

            return true;
        }
    }
}
