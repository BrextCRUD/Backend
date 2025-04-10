namespace Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int RegionId { get; set; }
        public Region Region { get; set; } = null!;
    }
}
