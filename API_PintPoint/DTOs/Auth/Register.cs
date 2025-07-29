namespace API_PintPoint.DTOs.Auth
{
    public class Register
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string PictureUrl { get; set; }
        public bool PolicyCheck { get; set; }
        public int IdCity { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
    }
}
