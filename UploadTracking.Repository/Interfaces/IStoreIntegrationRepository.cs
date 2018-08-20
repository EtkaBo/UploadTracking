using System.Threading.Tasks;
using UploadTracking.Models.DTOs;

namespace UploadTracking.Repository.Interfaces
{
    public interface IStoreIntegrationRepository
    {
        Task<StoreIntegrationDTO> GetIntegration(int userId);
        Task SaveIntegration(int userId, string storeName, string accessToken);
    }
}
