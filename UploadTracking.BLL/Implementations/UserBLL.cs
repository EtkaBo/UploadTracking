using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UploadTracking.BLL.Interfaces;
using UploadTracking.Models.DTOs;
using UploadTracking.Models.Enums;
using UploadTracking.Models.ThirdPartyModels.Google;
using UploadTracking.Repository.Interfaces;

namespace UploadTracking.BLL.Implementations
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserRepository _userRepo;
        public UserBLL(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<GoogleUserModel> GoogleSignIn(GoogleUserModel user)
        {
            var userToSignIn = await _userRepo.FindByEmail(user.Email);

            if (userToSignIn == null)
                return MapUserDTOToGoogleUser(await _userRepo.SignUp(MapGoogleUserToUserDTO(user)));

            return MapUserDTOToGoogleUser(userToSignIn);
        }

        #region mappers
        private Func<GoogleUserModel, UserDTO> MapGoogleUserToUserDTO = x => new UserDTO
        {
            Email = x.Email,
            FamilyName = x.FamilyName,
            FullName = x.FamilyName,
            GivenName = x.GivenName,
            IdToken = x.IdToken,
            LoginTypeId = (int)LoginTypeEnum.Google
        };
        private Func<UserDTO, GoogleUserModel> MapUserDTOToGoogleUser = x => new GoogleUserModel
        {
            Email = x.Email,
            FamilyName = x.FamilyName,
            FullName = x.FamilyName,
            GivenName = x.GivenName,
            IdToken = x.IdToken,
        };
        #endregion
    }
}
