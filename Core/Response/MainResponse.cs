namespace Core.Response
{
    public class  MainResponse<T>
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }= default;
    
    }
}
