using API_PintPoint.DTOs.Beers;
using CORE_PintPoint.Entities;

namespace API_PintPoint.Mapper
{
    public static class BreweriesMapper
    {
        public static BreweriesDTO ToDTO(this BreweriesWithCountry breweries)
        {
            return new BreweriesDTO()
            {
                Name = breweries.Name,
                CountryName = breweries.CountryName,
                City = breweries.City,
                CompleteAddress = breweries.CompleteAddress,
                Id = breweries.Id,
            };
        }
    }
}
