using TodoApp.Responses;
using TodoApp.Responses.Constants;

namespace TodoApp.Exceptions.HttpClientExceptions
{
    public class ForbiddenException : ExceptionBase
    {
        public ForbiddenException()
            : base((int)ClientErrorCodes.Forbidden, "Forbidden") { }

        public ForbiddenException(string message)
            : base((int)ClientErrorCodes.Forbidden, message) { }

        public ForbiddenException(object data, string message = "Forbidden")
            : base(ServerResponse.ConflictResult(data, message)) { }
    }
}
