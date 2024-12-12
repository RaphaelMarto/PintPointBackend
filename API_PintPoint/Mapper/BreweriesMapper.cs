using API_PintPoint.DTOs.Breweries;
using CORE_PintPoint.Entities;
using Domain_PintPoint.Entities;

namespace API_PintPoint.Mapper
{
    public static class BreweriesMapper
    {
        public static BreweriesDTO ToDTO(this BreweriesWithCountry breweries)
        {
            return new BreweriesDTO()
            {
                Id = breweries.Id,
                Name = breweries.Name,
            };
        }
        public static BreweriesCompleteDTO ToCompleteDTO(this BreweriesWithCountry breweries)
        {
            return new BreweriesCompleteDTO()
            {
                Name = breweries.Name,
                CountryName = breweries.CountryName,
                City = breweries.City,
                CompleteAddress = breweries.CompleteAddress,
                Id = breweries.Id,
            };
        }

        public static Breweries ToDomain(this BreweriesPost breweries)
        {
            return new Breweries()
            {
                City = breweries.City,
                Name = breweries.Name,
                CompleteAddress = breweries.CompleteAddress,
                IdCountry = breweries.IdCountry,
            };
        }
    }
}
