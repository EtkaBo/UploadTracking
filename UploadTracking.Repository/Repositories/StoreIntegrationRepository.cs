using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UploadTracking.DataModel.Model;
using UploadTracking.Models.DTOs;
using UploadTracking.Models.Enums;
using UploadTracking.Repository.Interfaces;

namespace UploadTracking.Repository.Repositories
{

    public class StoreIntegrationRepository : IStoreIntegrationRepository
    {
        private readonly IUploadTrackingContext _context;
        public StoreIntegrationRepository(IUploadTrackingContext context)
        {
            _context = context;
        }

        public async Task<StoreIntegrationDTO> GetIntegration(int userId)
        {
            return await _context.StoreIntegration
                            .Where(x => x.UserId == userId) //TODO: query with platformType
                            .Select(x => MapStoreIntegrationToDTO(x))
                            .FirstOrDefaultAsync();
        }

        public async Task SaveIntegration(int userId, string storeName, string accessToken)
        {
            try
            {
                _context.StoreIntegration.Add(new StoreIntegration
                {
                    PlatformTypeId = (int)PlatformTypeEnum.Shopify,
                    StoreName = storeName,
                    Token = accessToken,
                    UserId = userId,
                });

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region mappers
        private Func<StoreIntegration, StoreIntegrationDTO> MapStoreIntegrationToDTO = x => new StoreIntegrationDTO
        {
            UserId = x.UserId,
            StoreId = x.StoreId,
            StoreIntegrationId = x.StoreIntegrationId,
            PlatformTypeId = x.PlatformTypeId,
            StoreName = x.StoreName,
            Token = x.Token
        };
        #endregion

    }
}
