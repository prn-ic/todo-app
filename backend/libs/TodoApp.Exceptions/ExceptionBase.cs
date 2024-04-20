using System.Net;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Responses.Constants;

namespace TodoApp.Exceptions
{
    public class ExceptionBase : Exception
    {
        public int Code;
        public IActionResult? Result;
        public HttpStatusCode ExceptionStatusCode { get; set; } = HttpStatusCode.BadRequest;

        public ExceptionBase()
            : base() { }

        public ExceptionBase(int code, string message)
            : base(message) => Code = code;

        public ExceptionBase(IActionResult? result)
            : base() => Result = result;
    }
}
