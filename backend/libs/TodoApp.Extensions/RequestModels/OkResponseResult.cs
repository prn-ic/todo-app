namespace TodoApp.Extensions.RequestModels
{
    public class OkResponseResult<T>
    {
        public int Code { get; set; }
        public string? Message { get; set; }       
        public T? Data { get; set; }
    }
}