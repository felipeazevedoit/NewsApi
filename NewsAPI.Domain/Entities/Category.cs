namespace NewsAPI.Domain.Entities
{
    public class Category: Base
    {
        public string Description { get; set; }

        public Category( string description)
        {

            Description = description;
        }

    }
}
