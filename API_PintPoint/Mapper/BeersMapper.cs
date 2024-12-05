using API_PintPoint.DTOs.Beers;
using Domain_PintPoint.Entities;

namespace API_PintPoint.Mapper
{
    public static class BeersMapper
    {
        public static BeersDTO ToDTO(this Beers dto)
        {
            return new BeersDTO()
            {
                AlcoholPercent = dto.AlcoholPercent,
                Capacity = dto.Capacity,
                CreatedAt = dto.CreatedAt,
                Description = dto.Description,
                Id = dto.Id,
                IdBeerType = dto.IdBeerType,
                IdBrewery = dto.IdBrewery,
                Name = dto.Name,
                Price = dto.Price,
                UpdatedAt = dto.UpdatedAt,
            };
        }

        public static Beers ToDomain(this BeersDTO dto)
        {
            return new Beers()
            {
                AlcoholPercent = dto.AlcoholPercent,
                Capacity = dto.Capacity,
                CreatedAt = dto.CreatedAt,
                Description = dto.Description,
                Id = dto.Id,
                IdBeerType = dto.IdBeerType,
                IdBrewery = dto.IdBrewery,
                Name = dto.Name,
                Price = dto.Price,
                UpdatedAt = dto.UpdatedAt,
            };
        }
    }
}
