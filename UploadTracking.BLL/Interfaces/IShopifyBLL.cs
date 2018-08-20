using System.Threading.Tasks;
using UploadTracking.Models.ThirdPartyModels.Shopify;
using UploadTracking.Models.UploadTrackingApiModels;

namespace UploadTracking.BLL.Interfaces
{
    public interface IShopifyBLL
    {
        Task<UploadTrackingApiRequest> IntegrateShopify(int userId);
        Task<UploadTrackingApiResponse<ShopifyOrders>> GetOrders(int userId);
        Task GetAccessToken(string code, string storeName);
    }
}
