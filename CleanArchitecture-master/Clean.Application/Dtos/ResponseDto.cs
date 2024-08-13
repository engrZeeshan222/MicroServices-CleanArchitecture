namespace Clean.Application.Dtos
{
    public class ResponseDto
    {
        public bool Status { get; set; } = false;
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
