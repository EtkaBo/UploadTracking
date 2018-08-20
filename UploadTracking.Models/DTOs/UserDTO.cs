namespace UploadTracking.Models.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string IdToken { get; set; }
        public string FullName { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public int LoginTypeId { get; set; }
    }
}
