using System;
using System.Linq;
using System.Threading.Tasks;
using UploadTracking.DataModel.Model;
using UploadTracking.Models.DTOs;
using UploadTracking.Repository.Interfaces;

namespace UploadTracking.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        IUploadTrackingContext _context;
        public UserRepository(IUploadTrackingContext context)
        {
            _context = context;
        }
        public async Task<UserDTO> FindByEmail(string email)
        {
            var user = _context.User.FirstOrDefault(x => x.Email == email);
            return user == null ? null : MapUserToUserDTO(user);
        }

        public async Task<UserDTO> SignUp(UserDTO user)
        {
            var userToAdd = MapUserDTOToUser(user);

            _context.User.Add(userToAdd);
            _context.SaveChanges();

            user.UserId = userToAdd.UserId;
            return user;
        }

        #region mappers
        private Func<UserDTO, User> MapUserDTOToUser = x => new User
        {
            Email = x.Email,
            FamilyName = x.FamilyName,
            FullName = x.FullName,
            GivenName = x.GivenName,
            IdToken = x.IdToken,
            LoginTypeId = x.LoginTypeId
        };

        private Func<User, UserDTO> MapUserToUserDTO = x => new UserDTO
        {
            UserId = x.UserId,
            Email = x.Email,
            FamilyName = x.FamilyName,
            FullName = x.FullName,
            GivenName = x.GivenName,
            IdToken = x.IdToken,
            LoginTypeId = x.LoginTypeId
        };

        #endregion
    }
}
