using System.Collections.Generic;
using System.Threading.Tasks;
using UploadTracking.BLL.Interfaces;
using UploadTracking.Helpers;
using UploadTracking.Models.Constants;
using UploadTracking.Models.DTOs;
using UploadTracking.Models.ThirdPartyModels.Shopify;
using UploadTracking.Models.UploadTrackingApiModels;
using UploadTracking.Repository.Interfaces;

namespace UploadTracking.BLL.Implementations
{
    public class ShopifyBLL : IShopifyBLL
    {
        private readonly IStoreIntegrationRepository _storeIntRepo;


        public ShopifyBLL(IStoreIntegrationRepository storeIntRepo)
        {
            _storeIntRepo = storeIntRepo;
        }

        public async Task<UploadTrackingApiRequest> IntegrateShopify(int userId)
        {
            var integration = await _storeIntRepo.GetIntegration(userId);

            //TODO: DELETE THIS
            integration.StoreName = "uploadtrackingtest";
            ///////////////TODO:

            var request = new UploadTrackingApiRequest
            {
                Url = $"https://{integration.StoreName}.myshopify.com/admin/oauth/authorize?",
                QueryString = new Dictionary<string, string>
                {
                    {"client_id",$"{ShopifyConstants.apiKey}" },
                    {"scope", $"{ShopifyConstants.scopes}" },
                    {"redirect_uri", $"{ShopifyConstants.redirectUri}" },
                    //{"amp;state", $"{nonce}" }
                }
            };

            foreach (var qString in request.QueryString)
                request.Url += qString.Key + "=" + qString.Value + "&";

            return request;
        }

        public async Task GetAccessToken(string code, string fullStoreName)
        {
            var storeName = fullStoreName.Substring(0, fullStoreName.LastIndexOf(".myshopify.com"));

            var request = new UploadTrackingApiUpsertRequest<ShopifyAccessTokenRequestModel>
            {
                Url = $"https://{storeName}.myshopify.com/admin/oauth/access_token",
                Data = new ShopifyAccessTokenRequestModel
                {
                    Code = code
                }
            };

            var response = await HttpClientHelper.Post<ShopifyAccessTokenResponseModel, ShopifyAccessTokenRequestModel>(request);

            await _storeIntRepo.SaveIntegration(13, storeName, response.Data.AccessToken);
        }


        public async Task<UploadTrackingApiResponse<ShopifyOrders>> GetOrders(int userId)
        {
            ////////var integration = await _storeIntRepo.GetIntegration(userId);


            ///////////////////TODO: DELETE THIS
            var integration = new StoreIntegrationDTO
            {
                StoreName = "uploadtrackingtest",
                Token = ""
            };

            /////////////////////////////

            var request = new UploadTrackingApiRequest
            {
                Url = $"https://{integration.StoreName}.myshopify.com/admin/orders",
                Header = new Dictionary<string, string>
                {
                    {"X-Shopify-Access-Token", integration.Token }
                }
            };

            return await HttpClientHelper.Get<ShopifyOrders>(request);
        }


        //public async Task CreateFulfillment()
        //{

        //}

        //public async Task CompleteFulfillment(int fulfillmentId)
        //{

        //}


    }
}
