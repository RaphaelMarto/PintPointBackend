using API_PintPoint.DTOs.Beers;
using CORE_PintPoint.Entities;
using Domain_PintPoint.Entities;

namespace API_PintPoint.Mapper
{
    public static class BeersMapper
    {
        public static BeersDTO ToDTO(this BeersWithNames dto)
        {
            return new BeersDTO()
            {
                Capacity = dto.Capacity,
                Id = dto.Id,
                BeerTypeName = dto.BeerTypeName,
                Name = dto.Name,
                Price = dto.Price,
                CountryName = dto.CountryName,
                PictureUrl = dto.PictureUrl,
                FlagUrl = dto.FlagUrl,
                Rating = dto.Rating,
                BirthYear = dto.BirthYear,
            };
        }

        public static BeersCompleteInfoDTO ToCompleteDTO(this BeersWithNames dto)
        {
            return new BeersCompleteInfoDTO()
            {
                AlcoholPercent = dto.AlcoholPercent,
                Capacity = dto.Capacity,
                Description = dto.Description,
                Id = dto.Id,
                IdBeerType = dto.IdBeerType,
                BeerTypeName = dto.BeerTypeName,
                IdBrewery = dto.IdBrewery,
                BreweryName = dto.BreweryName,
                Name = dto.Name,
                Price = dto.Price,
                CountryName = dto.CountryName,
                PictureUrl = dto.PictureUrl,
                FlagUrl = dto.FlagUrl,
                Rating = dto.Rating,
                Rate = dto.Rate,
                BirthYear = dto.BirthYear
            };
        }

        public static Beers ToDomain(this BeerPost dto)
        {
            return new Beers()
            {
                AlcoholPercent = dto.AlcoholPercent,
                Capacity = dto.Capacity,
                Description = dto.Description,
                IdBeerType = dto.IdBeerType,
                IdBrewery = dto.IdBrewery,
                Name = dto.Name,
                Price = dto.Price,
                PictureUrl = dto.PictureUrl,
                BirthYear = dto.BirthYear,
            };
        }

        public static Beers ToDomain(this BeerPut dto)
        {
            return new Beers()
            {
                Id = dto.Id,
                AlcoholPercent = dto.AlcoholPercent,
                Capacity = dto.Capacity,
                Description = dto.Description,
                IdBeerType = dto.IdBeerType,
                IdBrewery = dto.IdBrewery,
                Name = dto.Name,
                Price = dto.Price,
                PictureUrl = dto.PictureUrl,
                BirthYear = dto.BirthYear,
            };
        }
    }
}
