using API_PintPoint.DTOs.Beers;
using CORE_PintPoint.Entities;

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
            };
        }

        //public static Beers ToDomain(this BeersDTO dto)
        //{
        //    return new Beers()
        //    {
        //        AlcoholPercent = dto.AlcoholPercent,
        //        Capacity = dto.Capacity,
        //        CreatedAt = dto.CreatedAt,
        //        Description = dto.Description,
        //        Id = dto.Id,
        //        IdBeerType = dto.IdBeerType,
        //        IdBrewery = dto.IdBrewery,
        //        Name = dto.Name,
        //        Price = dto.Price,
        //        UpdatedAt = dto.UpdatedAt,
        //    };
        //}
    }
}
