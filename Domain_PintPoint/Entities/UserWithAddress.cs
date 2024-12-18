namespace Domain_PintPoint.Entities
{
    public class UserWithAddress : Users
    {
        public int IdCity { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
    }
}
