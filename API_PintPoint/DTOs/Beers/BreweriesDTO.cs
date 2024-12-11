namespace API_PintPoint.DTOs.Beers
{
    public class BreweriesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompleteAddress { get; set; }
        public string City { get; set; }
        public string? CountryName { get; set; }
    }
}
