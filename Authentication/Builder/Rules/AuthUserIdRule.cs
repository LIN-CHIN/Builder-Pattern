using Authentication.Models;

namespace Authentication.Builder.Rules
{
    /// <summary>
    /// UserId athenticate rule 
    /// </summary>
    public class AuthUserIdRule : IRule
    {
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
