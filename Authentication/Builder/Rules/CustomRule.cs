using Authentication.Models;

namespace Authentication.Builder.Rules
{
    /// <summary>
    /// 自訂驗證規則的物件
    /// </summary>
    public class CustomRule
    {
        /// <summary>
        /// 驗證
        /// </summary>
        public Func<DbUser, CustomRuleResponseModel> Vaildate { get; set; }
    }
}
