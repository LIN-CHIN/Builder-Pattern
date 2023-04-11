namespace Authentication.Models
{
    /// <summary>
    /// 定義自訂驗證規則的Response的格式
    /// </summary>
    public class CustomRuleResponseModel
    {
        public bool Result { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
