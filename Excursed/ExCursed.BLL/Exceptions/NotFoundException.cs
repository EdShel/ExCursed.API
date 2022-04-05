using System.Net;

namespace ExCursed.BLL.Exceptions
{
    public class NotFoundException : CustomHttpException
    {
        public NotFoundException(string message)
            : base(message, HttpStatusCode.NotFound)
        {

        }
    }
}
