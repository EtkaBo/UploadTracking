using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UploadTracking.BLL.Interfaces;
using UploadTracking.Models.ThirdPartyModels.Google;

namespace UploadTracking.Web.Api
{
    [AllowAnonymous]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserBLL _userBLL;
        public UserController(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }

        [AllowAnonymous]
        [HttpPost, Route("googleSignIn")]
        public async Task<IActionResult> GoogleSignIn([FromBody]GoogleUserModel user)
        {
            return Ok(await _userBLL.GoogleSignIn(user));
        }
    }
}