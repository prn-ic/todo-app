using TodoApp.Responses;
using TodoApp.Responses.Constants;

namespace TodoApp.Exceptions.HttpClientExceptions
{
    public class InvalidTokenException : ExceptionBase
    {
        public InvalidTokenException()
            : base((int)ClientErrorCodes.Forbidden, "Invalid token") { }

        public InvalidTokenException(string message)
            : base((int)ClientErrorCodes.Forbidden, message) { }

        public InvalidTokenException(object data, string message = "Invalid token")
            : base(ServerResponse.ForbiddenResult(data, message)) { }
    }
}
