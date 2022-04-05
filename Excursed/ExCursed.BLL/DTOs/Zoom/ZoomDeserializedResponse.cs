using System.Net.Http;

namespace ExCursed.BLL.DTOs.Zoom
{
    public class ZoomDeserializedResponse<T>
    {
        public HttpResponseMessage HttpMessage { get; set; }

        public T Body { get; set; }
    }
}
