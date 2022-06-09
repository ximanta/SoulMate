namespace SoulMate.API.data
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public virtual IList<Soulmate> Soulmate { get; set; }
    }
}