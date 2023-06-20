namespace NewsAPI.Domain.Entities
{
    public abstract class Base
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
    }
}
