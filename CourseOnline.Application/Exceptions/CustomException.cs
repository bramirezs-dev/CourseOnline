using System;
using System.Net;

namespace CourseOnline.Application.Exceptions
{
    public class CustomException<T> :Exception
    {
        public T Response { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}

