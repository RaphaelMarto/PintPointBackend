using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Entities
{
    public class BreweriesWithCountry : Breweries
    {
        public BreweriesWithCountry() { }
        public BreweriesWithCountry(Breweries b)
        {
            Id = b.Id;
            IdCountry = b.IdCountry;
            Name = b.Name;
            CompleteAddress = b.CompleteAddress;
            City = b.City;
        }

        public string? CountryName { get; set; }
    }
}
