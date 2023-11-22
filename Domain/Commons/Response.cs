using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commons
{
    public class Response
    {
        public Response(HttpStatusCode statusCode, IEnumerable<string> errors = null, object data = null)
        {
            StatusCode = statusCode;
            Errors = errors?.ToList()?.AsReadOnly();
            Data = data;
        }

        public HttpStatusCode StatusCode { get; }
        public IReadOnlyCollection<string> Errors { get; }
        public object Data { get; set; }
    }
}
