using Newtonsoft.Json;

namespace UploadTracking.Models.ThirdPartyModels.Shopify
{
    public class ShopifyAccessTokenResponseModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}
