using API_PintPoint.DTOs.Auth;
using Domain_PintPoint.Entities;

namespace API_PintPoint.Mapper
{
    public static class AuthMapper
    {
        public static UserWithAddress ToUserAddress(this Register register)
        {
            return new UserWithAddress()
            {
                AddressId = register.AddressId,
                DateOfBirth = register.DateOfBirth,
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                NickName = register.NickName,
                HouseNumber = register.HouseNumber,
                IdCity = register.IdCity,
                Password = register.Password,
                Phone = register.Phone,
                PictureUrl = register.PictureUrl,
                PolicyCheck = register.PolicyCheck,
                PostCode = register.PostCode,
                Street = register.Street,

            };
        }
    }
}
