using Newtonsoft.Json;
using UploadTracking.Models.Constants;

namespace UploadTracking.Models.ThirdPartyModels.Shopify
{
    public class ShopifyAccessTokenRequestModel
    {
        public ShopifyAccessTokenRequestModel()
        {
            ClientId = ShopifyConstants.apiKey;
            ClientSecret = ShopifyConstants.apiSecretKey;
        }
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        [JsonProperty("code")]
        public string Code{ get; set; }

    }
}
