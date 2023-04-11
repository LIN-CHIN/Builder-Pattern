using Authentication.Builder.Rules;
using Authentication.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Authentication.Builder
{
    public class Authenticator
    {
        private DbUser _dbUser;
        private List<IRule> rules = new List<IRule>();
        private List<CustomRule> customRules = new List<CustomRule>(); 

        public Authenticator()
        {
            _dbUser = new DbUser();
        }

        public Authenticator AddRule(IRule rule)
        {
            rules.Add(rule);
            return this;
        }

        public Authenticator AddRule(CustomRule rule)
        {
            customRules.Add(rule);
            return this;
        }

        public bool Authenticate(DbUser dbUser, out List<string> messages) 
        {
            messages = new List<string>();

            foreach (var rule in rules) 
            {
                rule.Authenticate(dbUser, out string message);
                if (!string.IsNullOrWhiteSpace(message)) 
                {
                    messages.Add(message);
                }
            }

            foreach (var rule in customRules) 
            {
                CustomRuleResultModel customRuleResultModel =  rule.Vaildate(dbUser);
                if (!customRuleResultModel.Result)
                {
                    messages.Add(customRuleResultModel.Message);
                }
            }

            if (messages.Count() > 0) 
            {
                return false;
            }

            return true;
        }



    }
}
