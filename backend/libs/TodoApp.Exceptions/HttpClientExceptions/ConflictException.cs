using TodoApp.Responses;
using TodoApp.Responses.Constants;

namespace TodoApp.Exceptions.HttpClientExceptions
{
    public class ConflictException : ExceptionBase
    {
        public ConflictException()
            : base((int)ClientErrorCodes.Conflict, "Received data was conflicted") { }

        public ConflictException(string message)
            : base((int)ClientErrorCodes.Conflict, message) { }

        public ConflictException(object data, string message = "Received data was conflicted")
            : base(ServerResponse.ConflictResult(data, message)) { }
    }
}
