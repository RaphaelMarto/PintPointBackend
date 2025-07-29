namespace API_PintPoint.DTOs.Auth
{
    public class PwdByCode
    {
        public string code { get; set; }
        public int id { get; set; }
        public string newPassword { get; set; }
    }
}
