using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UploadTracking.DataModel.Model
{
    public partial class UploadTrackingContext : IUploadTrackingContext
    {
        Task<int> IUploadTrackingContext.SaveChangesAsync()
        {
            return SaveChangesAsync();
        }

        int IUploadTrackingContext.SaveChanges()
        {
            return SaveChanges();
        }
    }

    public interface IUploadTrackingContext
    {
        DbSet<StoreIntegration> StoreIntegration { get; set; }
        DbSet<User> User { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
