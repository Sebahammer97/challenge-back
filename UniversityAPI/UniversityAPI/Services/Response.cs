namespace UniversityAPI.Services
{
    public static class Response
    {
        public static Response<T> Fail<T>(string message, T data = default) => new Response<T>(data, message, true);
        public static Response<T> Ok<T>(T data, string message) => new Response<T>(data, message, false);
        public static Response<T> Ok<T>(string message) => new Response<T>(message, false);
        public static Response<T> Ok<T>(T data) => new Response<T>(data, false);
    }

    public class Response<T> 
    {
        public Response(T data, string msg, bool error)
        {
            Data = data;
            Message = msg;
            Error = error;
        }

        public Response(string msg, bool error)
        {
            Message = msg;
            Error = error;
        }

        public Response(T data, bool error)
        {
            Data = data;
            Error = error;
        }

        public T Data { get; set; }
        public string Message { get; set; }
        public bool Error { get; set; }
    }
}
