using System.Net;

namespace MODULE5HW1.Models
{
    public class Response<TData>
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public TData Tdata { get; set; }
    }
}