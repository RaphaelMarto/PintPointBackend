namespace Domain_PintPoint.Entities
{
    public class BeersRating
    {
        public int Id { get; set; }
        public decimal Rate { get; set; }
        public string Comment { get; set; }
        public int Likes { get; set; }
        public int IdBeer { get; set; }
        public int IdUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool? Liked { get; set; }
        public string PictureUrl { get; set; }
        public string NickName { get; set; }
    }
}
