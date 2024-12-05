namespace Domain_PintPoint.Entities
{
    public class Beers
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public decimal AlcoholPercent { get; set; }
        public int IdBeerType { get; set; }
        public int IdBrewery { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
