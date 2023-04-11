namespace Authentication.Models
{
    public class ApiResponseModel
    {
        public int Code { get; set; }
        public object Content { get; set; }
        public string Message { get; set; }
    }
}
