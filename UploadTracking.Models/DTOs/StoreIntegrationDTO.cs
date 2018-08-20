using System;
using System.Collections.Generic;
using System.Text;

namespace UploadTracking.Models.DTOs
{
    public class StoreIntegrationDTO
    {
        public int StoreIntegrationId { get; set; }
        public int UserId { get; set; }
        public string StoreName { get; set; }
        public string StoreId { get; set; }
        public string Token { get; set; }
        public int PlatformTypeId { get; set; }
    }
}
