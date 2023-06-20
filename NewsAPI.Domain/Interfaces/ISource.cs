using NewsAPI.Domain.Entities;

namespace NewsAPI.Domain.Interfaces
{

    public interface ISource
    {
        public Source RegisterSource(Source fonte); 
        public Source GetSource(Source fonte); 
        public bool InactivateSource(Source fonte); 

    }
}
