using System.Net;

namespace OsDsII.api.Services.Http.Exceptions
{
    public class ConflictException : BaseException
    {

        public ConflictException(string message) :
        base
            (
                "HSO-001", // código identificador de erros
                message,
                HttpStatusCode.Conflict,
                StatusCodes.Status409Conflict,
                null,
                DateTimeOffset.UtcNow,
                null
            )
        { }

    }
}
