namespace API_PintPoint.DTOs.Breweries
{
    public class BreweriesCompleteDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompleteAddress { get; set; }
        public string City { get; set; }
        public string? CountryName { get; set; }
    }
}
