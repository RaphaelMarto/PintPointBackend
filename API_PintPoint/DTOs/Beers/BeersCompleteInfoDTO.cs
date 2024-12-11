namespace API_PintPoint.DTOs.Beers
{
    public class BeersCompleteInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public decimal AlcoholPercent { get; set; }
        public int IdBeerType { get; set; }
        public string BeerTypeName { get; set; }
        public int IdBrewery { get; set; }
        public string BreweryName { get; set; }
        public string CountryName { get; set; }
        public string PictureUrl { get; set; }
        public string? FlagUrl { get; set; }
        public decimal Rating { get; set; }
    }
}
