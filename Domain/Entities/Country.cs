namespace Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Region> Regions { get; set; } = new List<Region>();
    }
}