namespace NewsAPI.Domain.Entities
{
    public class Source : Base
    {
        public string Name { get; set; }

        public Source() { }


        public Source(string name)
        {
            Name = name;
        }

    }
}
