using Authentication.Builder.Rules;
using Authentication.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Authentication.Builder
{
    /// <summary>
    /// 驗證者
    /// </summary>
    public class Authenticator
    {
        private DbUser _dbUser;
        private List<IRule> rules = new List<IRule>();
        private List<CustomRule> customRules = new List<CustomRule>(); 

        public Authenticator()
        {
            _dbUser = new DbUser();
        }

        /// <summary>
        /// 新增驗證規則
        /// </summary>
        /// <param name="rule">驗證規則</param>
        /// <returns></returns>
        public Authenticator AddRule(IRule rule)
        {
            rules.Add(rule);
            return this;
        }

        /// <summary>
        /// 新增Client自訂的驗證規則
        /// </summary>
        /// <param name="rule">Client自訂的驗證規則</param>
        /// <returns></returns>
        public Authenticator AddRule(CustomRule rule)
        {
            customRules.Add(rule);
            return this;
        }

        /// <summary>
        /// 執行驗證
        /// </summary>
        /// <param name="dbUser">要驗證的使用者資料</param>
        /// <param name="messages">錯誤訊息</param>
        /// <returns></returns>
        public bool Authenticate(DbUser dbUser, out List<string> messages) 
        {
            messages = new List<string>();

            //執行驗證
            foreach (var rule in rules) 
            {
                rule.Authenticate(dbUser, out string message);
                if (!string.IsNullOrWhiteSpace(message)) 
                {
                    messages.Add(message);
                }
            }

            //執行Client自訂的驗證
            foreach (var rule in customRules) 
            {
                CustomRuleResponseModel customRuleResultModel =  rule.Vaildate(dbUser);
                if (!customRuleResultModel.Result)
                {
                    messages.Add(customRuleResultModel.Message);
                }
            }

            //若有任何錯誤則回傳false
            if (messages.Count() > 0) 
            {
                return false;
            }

            return true;
        }
    }
}
