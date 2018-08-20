using System;
using System.Net;

namespace UploadTracking.Models.UploadTrackingApiModels
{
    public class UploadTrackingApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
