using System;
using System.Collections.Generic;

namespace UploadTracking.DataModel.Model
{
    public partial class StoreIntegration
    {
        public int StoreIntegrationId { get; set; }
        public int UserId { get; set; }
        public string StoreName { get; set; }
        public string StoreId { get; set; }
        public string Token { get; set; }
        public int PlatformTypeId { get; set; }

        public User User { get; set; }
    }
}
