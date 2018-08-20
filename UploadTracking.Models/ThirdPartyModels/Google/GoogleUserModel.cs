using Newtonsoft.Json;

namespace UploadTracking.Models.ThirdPartyModels.Google
{
    public class GoogleUserModel
    {
        [JsonProperty("googleUserId")]
        public string GoogleUserId { get; set; }

        public int UserId { get; set; }

        [JsonProperty("idToken")]
        public string IdToken { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("familyName")]
        public string FamilyName { get; set; }

        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
