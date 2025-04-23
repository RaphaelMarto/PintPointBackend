using Domain_PintPoint.Entities;

namespace API_PintPoint.DTOs.User
{
    public class UserProfile
    {
        public UserUpdate? userProfile { get; set; }
        public UserAddress? userAddress { get; set; }
    }
}
