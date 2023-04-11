using Authentication.Models;

namespace Authentication.Builder.Rules
{
    public class CustomRule
    {
        public Func<DbUser, CustomRuleResultModel> Vaildate { get; set; }
    }
}
