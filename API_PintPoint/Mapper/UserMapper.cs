using API_PintPoint.DTOs.User;
using Domain_PintPoint.Entities;

namespace API_PintPoint.Mapper
{
    public static class UserMapper
    {
        public static UserProfile ToUserProfile(this UserWithAddress user)
        {
            return new UserProfile()
            {
                userProfile = new UserUpdate()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    NickName = user.NickName,
                    Email = user.Email,
                    Phone = user.Phone,
                    DateOfBirth = user.DateOfBirth
                },
                userAddress = new UserAddress()
                {
                    IdCity = user.IdCity,
                    AddressId = user.AddressId,
                    HouseNumber = user.HouseNumber,
                    PostCode = user.PostCode,
                    Street = user.Street
                }
            };
        }
    }
}
