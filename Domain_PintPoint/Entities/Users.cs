namespace Domain_PintPoint.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string PictureUrl { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public bool PolicyCheck { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public int AddressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
