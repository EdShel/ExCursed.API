using System.Net;

namespace ExCursed.BLL.Exceptions
{
    public class BadRequestException : CustomHttpException
    {
        public BadRequestException(string message)
            : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}
