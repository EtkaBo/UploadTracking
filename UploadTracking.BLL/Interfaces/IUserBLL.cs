using System.Threading.Tasks;
using UploadTracking.Models.ThirdPartyModels.Google;

namespace UploadTracking.BLL.Interfaces
{
    public interface IUserBLL
    {
        Task<GoogleUserModel> GoogleSignIn(GoogleUserModel user);
    }
}
