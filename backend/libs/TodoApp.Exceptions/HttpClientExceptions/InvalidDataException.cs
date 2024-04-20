using TodoApp.Responses;
using TodoApp.Responses.Constants;

namespace TodoApp.Exceptions.HttpClientExceptions
{
    public class InvalidDataException : ExceptionBase
    {
        public InvalidDataException()
            : base((int)ClientErrorCodes.BadRequest, "Invalid data") { }

        public InvalidDataException(string message)
            : base((int)ClientErrorCodes.BadRequest, message) { }

        public InvalidDataException(object data, string message = "Invalid data")
            : base(ServerResponse.BadRequestResult(data, message)) { }
    }
}
