using System.Threading.Tasks;
using UploadTracking.Models.DTOs;

namespace UploadTracking.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDTO> FindByEmail(string email);
        Task<UserDTO> SignUp(UserDTO user);
    }
}
