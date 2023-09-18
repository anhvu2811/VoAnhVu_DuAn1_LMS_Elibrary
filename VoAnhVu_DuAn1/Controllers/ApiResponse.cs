namespace VoAnhVu_DuAn1.Controllers
{
    internal class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; internal set; }
    }
}