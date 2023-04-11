namespace Authentication.Models
{
    /// <summary>
    /// 定義 api Response的格式
    /// </summary>
    public class ApiResponseModel
    {
        public int Code { get; set; }
        public object Content { get; set; }
        public string Message { get; set; }
    }
}
