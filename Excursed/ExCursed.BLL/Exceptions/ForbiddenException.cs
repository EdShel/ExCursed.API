using System.Net;

namespace ExCursed.BLL.Exceptions
{
    public class ForbiddenException : CustomHttpException
    {
        public ForbiddenException(string message)
            : base(message, HttpStatusCode.Forbidden)
        {

        }
    }
}
