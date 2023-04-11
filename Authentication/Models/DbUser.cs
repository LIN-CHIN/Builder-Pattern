using System.Data.Common;

namespace Authentication.Models
{
    /// <summary>
    /// 假的 DB user table 
    /// </summary>
    public class DbUser
    {
        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string UserId { get; set; } 

        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        public string Pwd { get; set; }
        
        /// <summary>
        /// 手機
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 信箱
        /// </summary>
        public string Email { get; set; }
    }
}
