namespace Pallada.DB
{
    public class HitsMedianFromDb : MedianFromDb, IHitsMedianFromDb
    {
        public HitsMedianFromDb(IRepository repository) : base(repository)
        {
        }

        protected override string table => "results";
        protected override string parameter => "hits";
    }
}