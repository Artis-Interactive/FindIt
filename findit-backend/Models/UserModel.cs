namespace findit_backend.Models
{
    public class UserModel
    {
        public string LegalId { get; set; }
        public string Name { get; set; }
        public string LastNames { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string? AccountState { get; set; }
        public string Password { get; set; }
    }

}


