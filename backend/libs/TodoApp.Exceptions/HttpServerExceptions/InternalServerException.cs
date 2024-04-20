using TodoApp.Responses;

namespace TodoApp.Exceptions.HttpServerExceptions
{
    public class InternalServerException : ExceptionBase
    {
        public InternalServerException()
            : base(0, "Something wrong!") { }

        public InternalServerException(string message = "Something wrong")
            : base(ServerResponse.InternalServerError(message)) { }
    }
}
