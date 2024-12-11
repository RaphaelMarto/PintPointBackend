namespace Domain_PintPoint.Entities
{
    public class OffsetResult<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Results { get; set; }
    }
}
