using System.Data.Common;

namespace Authentication.Models
{
    /// <summary>
    /// Mock DB user table 
    /// </summary>
    public class DbUser
    {
        public string UserId { get; set; } 
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
