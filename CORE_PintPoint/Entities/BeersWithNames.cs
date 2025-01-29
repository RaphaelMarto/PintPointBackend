using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Entities
{
    public class BeersWithNames : Beers
    {
        public BeersWithNames()
        {

        }
        public BeersWithNames(Beers b)
        {
            Id = b.Id;
            IdBeerType = b.IdBeerType;
            IdBrewery = b.IdBrewery;
            Name = b.Name;
            Price = b.Price;
            Capacity = b.Capacity;
            PictureUrl = b.PictureUrl;
            AlcoholPercent = b.AlcoholPercent;
            Description = b.Description;
            Rating = b.Rating;
            CreatedAt = b.CreatedAt;
            UpdatedAt = b.UpdatedAt;
            Rate = b.Rate;
            BirthYear = b.BirthYear;
        }
        public string? BeerTypeName { get; set; }
        public string? BreweryName { get; set; }
        public string? CountryName { get; set; }
        public string? FlagUrl { get; set; }
    }
}
