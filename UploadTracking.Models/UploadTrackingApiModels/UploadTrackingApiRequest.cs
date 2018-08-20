using System;
using System.Collections.Generic;
using System.Text;

namespace UploadTracking.Models.UploadTrackingApiModels
{
    public class UploadTrackingApiRequest
    {
        public string Url { get; set; }
        public Dictionary<string,string> Header { get; set; }
        public Dictionary<string,string> QueryString { get; set; }
    }

    public class UploadTrackingApiUpsertRequest<T> : UploadTrackingApiRequest
    {
        public T Data { get; set; }
    }
}
