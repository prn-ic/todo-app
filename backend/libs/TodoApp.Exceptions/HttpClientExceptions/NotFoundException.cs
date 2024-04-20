using TodoApp.Responses;
using TodoApp.Responses.Constants;

namespace TodoApp.Exceptions.HttpClientExceptions
{
    public class NotFoundException : ExceptionBase
    {
        public NotFoundException()
            : base((int)ClientErrorCodes.NotFound, "Not found") { }

        public NotFoundException(string message)
            : base((int)ClientErrorCodes.NotFound, message) { }

        public NotFoundException(object data, string message = "Not found")
            : base(ServerResponse.NotFoundResult(data, message)) { }
    }
}
